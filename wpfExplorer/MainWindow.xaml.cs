// MainWindow.xaml.cs
using libraryExplorer;
using System.Windows;
using System.Windows.Controls;

namespace wpfExplorer
{
    public partial class MainWindow : Window
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
            foreach (var drive in System.IO.DriveInfo.GetDrives())
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
                foreach (var dir in _fileManager.GetDirectoryContents(path))
                {
                    TreeViewItem subItem = new TreeViewItem() { Header = System.IO.Path.GetFileName(dir), Tag = dir };
                    subItem.Items.Add(null); // Добавление заглушки для возможности раскрытия узла
                    selectedItem.Items.Add(subItem);
                }
                FileList.ItemsSource = _fileManager.GetDirectoryContents(path);
            }
        }
    }
}