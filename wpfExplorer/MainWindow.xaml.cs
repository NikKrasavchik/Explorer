using MahApps.Metro.Controls;
using libraryExplorer;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace wpfExplorer
{
    public partial class MainWindow : MetroWindow
    {
        private FileManager _fileManager;

        public MainWindow()
        {
            InitializeComponent();
            _fileManager = new FileManager();
            LoadRootDirectories();
        }

        private void LoadRootDirectories()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                TreeViewItem item = new TreeViewItem() { Header = drive.Name, Tag = drive.Name };
                item.Items.Add(null); // Заглушка для возможности раскрытия узла
                DirectoryTree.Items.Add(item);
            }
        }

        private void DirectoryTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DirectoryTree.SelectedItem is TreeViewItem selectedItem)
            {
                string path = selectedItem.Tag.ToString();
                selectedItem.Items.Clear(); // Очистка заглушки
                foreach (var dir in Directory.GetDirectories(path))
                {
                    TreeViewItem subItem = new TreeViewItem() { Header = Path.GetFileName(dir), Tag = dir };
                    subItem.Items.Add(null); // Добавление заглушки для возможности раскрытия узла
                    selectedItem.Items.Add(subItem);
                }
                FileList.ItemsSource = GetFileList(path);
            }
        }

        private List<FileItem> GetFileList(string path)
        {
            List<FileItem> fileItems = new List<FileItem>();
            foreach (var filePath in Directory.GetFiles(path))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                fileItems.Add(new FileItem
                {
                    Name = fileInfo.Name,
                    Type = fileInfo.Extension,
                    Size = fileInfo.Length
                });
            }
            return fileItems;
        }
    }

    public class FileItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
    }
}