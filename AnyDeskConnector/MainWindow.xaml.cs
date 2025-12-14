using AnyDeskConnector.Connector;
using AnyDeskConnector.Connector.AnyDesk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnyDeskConnector
{
    public class Computer
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

       public string Protocol { get; set; }
    }

    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, List<Computer>> _sklady = new();
        private readonly string _configsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs");

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSklady();
        }

        private void LoadSklady()
        {
            if (!Directory.Exists(_configsPath))
            {
                Directory.CreateDirectory(_configsPath);
                MessageBox.Show("Создана пaпка Configs рядом с программой.\nПоложите туда .txt файлы — по одному на склад.", "Папка создана");
                return;
            }

            var files = Directory.GetFiles(_configsPath, "*.txt");
            if (files.Length == 0)
            {
                MessageBox.Show("В папке Configs нет .txt файлов.\nДобавьте хотя бы один файл (имя файла = имя склада).");
                return;
            }

            foreach (var file in files)
            {
                string skladName = Path.GetFileNameWithoutExtension(file);
                var computers = new List<Computer>();

                try
                {
                    var configs = new AnyDeskConfigReader().Read(file);

                    for (int i = 0; i < configs.Count; i++)
                    {
                        if (configs[i] is AnyDeskRemoteConnectionConfig cfg)
                        {
                            computers.Add(new Computer
                            {
                                Name = $"Компьютер {i + 1} ({cfg.RemoteHostName})",
                                Id = cfg.RemoteHostName,
                                Password = cfg.Password
                            });
                        }
                    }

                    _sklady[skladName] = computers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка в файле {skladName}.txt:\n{ex.Message}");
                }
            }

            SkladyPanel.ItemsSource = _sklady.Keys.OrderBy(x => x).ToList();
        }

        private void Sklad_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Content is string skladName && _sklady.TryGetValue(skladName, out var list))
            {
                computersKonteiner.ItemsSource = list;                    // ← Это ItemsControl!
                computers.Text = $"Склад: {skladName} — {list.Count} комп."; // ← Это TextBlock!
            }
        }

        private void Comp_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (e.ClickCount != 2) return;
            
            if (sender is not Button btn || btn.DataContext is not Computer comp) return;
            if (comp.Protocol=="AnyDesk")
            {

            }
            else if (comp.Protocol=="RDP") 
            {
            }
                try
            {
                var connector = new AnydeskHostConnector(new AnyDeskCredentials(comp.Password));
                ExecutionWithLogs.Execute(() => connector.Connect(new MyRemoteHost(comp.Id)), "AnyDesk");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к {comp.Name}:\n{ex.Message}");
            }
        }
    }
}