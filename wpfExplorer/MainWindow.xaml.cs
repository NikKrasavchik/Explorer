﻿using libraryExplorer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace wpfExplorer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initDriveButtons(LeftTableDisks);
            initDriveButtons(RightTableDisks);

            initTable(LeftTable, @"C:\");
            initTable(RightTable, @"C:\");
        }

        public void initTable(DataGrid table, string path)
        {
            List<ComplexData> complexData = new List<ComplexData>();
            TableData tableData = new TableData();
            bool isError = tableData.determineFiles(path);

            if (!isError)
            {
                if (path[path.LastIndexOf('\\') - 1] != ':')
                    complexData.Add(new ComplexData());
                for (int i = 0; i < tableData.getDirCount(); i++)
                    complexData.Add(new ComplexData(tableData.getDir(i)));
                for (int i = 0; i < tableData.getFileCount(); i++)
                    complexData.Add(new ComplexData(tableData.getFile(i)));

                table.ItemsSource = complexData;

                if (table.Name[0] == 'L')
                    LeftTablePath.Text = path;
                else
                    RightTablePath.Text = path;
            }
        }

        public void initDriveButtons(WrapPanel wrapPanel)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                Button diskButton = new Button() { Content = drives[i] };
                diskButton.Click += diskButton_Click;
                wrapPanel.Children.Add(diskButton);
            }
        }

        public void diskButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            string senderName = senderButton.Content.ToString();

            WrapPanel senderParent = senderButton.Parent as WrapPanel;
            string senderParentName = senderParent.Name;
            if (senderParentName[0] == 'L')
                initTable(LeftTable, senderName);
            else
                initTable(RightTable, senderName);
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            ComplexData rowData = row.Item as ComplexData;

            var leftSelect = LeftTable.SelectedItem;
            var rightSelect = RightTable.SelectedItem;

            if (rowData.type == null)
            {
                DataGrid currentTable = null;
                TextBlock currentTablePath = null;

                if (leftSelect != null && rightSelect != null)
                {
                    LeftTable.SelectedItem = null;
                    RightTable.SelectedItem = null;
                    return;
                }

                if (leftSelect != null)
                {
                    currentTable = LeftTable;
                    currentTablePath = LeftTablePath;
                }
                else if (rightSelect != null)
                {
                    currentTable = RightTable;
                    currentTablePath = RightTablePath;
                }

                if (leftSelect != null || rightSelect != null)
                {
                    LeftTable.SelectedItem = null;
                    RightTable.SelectedItem = null;

                    if (rowData.name == "...")
                    {
                        currentTablePath.Text = currentTablePath.Text.Remove(currentTablePath.Text.Length - 1);
                        int indLastSlash = currentTablePath.Text.LastIndexOf('\\');
                        string path = "";
                        for (int i = 0; i < indLastSlash + 1; i++)
                            path += currentTablePath.Text[i];
                        initTable(currentTable, path);
                    }
                    else
                        initTable(currentTable, currentTablePath.Text + rowData.name + "\\");
                }
            }
            else
            {
                string fullFileName = "";
                if (leftSelect != null)
                {
                    LeftTable.SelectedItem = null;
                    fullFileName += LeftTablePath.Text;
                }
                else if (rightSelect != null)
                {
                    RightTable.SelectedItem = null;
                    fullFileName += RightTablePath.Text;
                }
                fullFileName += rowData.name + "." + rowData.type;
                try
                {
                    System.Diagnostics.Process.Start(fullFileName);
                }
                catch (Exception exc)
                {
                    string messageBoxText = "Error while opening file";
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icon = MessageBoxImage.Warning;

                    MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
            }
        }

        public void RefreshInteractionsButton_Click(object sender, RoutedEventArgs e)
        {
            LeftTableDisks.Children.Clear();
            RightTableDisks.Children.Clear();

            initDriveButtons(LeftTableDisks);
            initDriveButtons(RightTableDisks);

            initTable(LeftTable, LeftTablePath.Text);
            initTable(RightTable, RightTablePath.Text);
        }

        public void RemoveInteractionsButton_Click(object sender, RoutedEventArgs e)
        {
            ComplexData leftSelect = LeftTable.SelectedItem as ComplexData;
            ComplexData rightSelect = RightTable.SelectedItem as ComplexData;

            string currentTablePath = null;
            DataGrid currentTable = null;
            ComplexData currentSelect = null;

            List<ComplexData> complexData = new List<ComplexData>();
            TableData tableData = new TableData();

            if (leftSelect != null)
            {
                currentTablePath = LeftTablePath.Text;
                currentTable = LeftTable;
                currentSelect = leftSelect;
            }
            else if (rightSelect != null)
            {
                currentTablePath = RightTablePath.Text;
                currentTable = RightTable;
                currentSelect = rightSelect;
            }

            if (currentSelect.type == null)
                Directory.Delete(currentTablePath + currentSelect.name, true);
            else if (currentSelect.type != null)
                File.Delete(currentTablePath + currentSelect.name + '.' + currentSelect.type);
            initTable(currentTable, currentTablePath);
        }

        public void UpInteractionsButton_Click(object sender, RoutedEventArgs e)
        {
            ComplexData leftSelect = LeftTable.SelectedItem as ComplexData;
            ComplexData rightSelect = RightTable.SelectedItem as ComplexData;

            string currentTablePath = null;
            DataGrid currentTable = null;

            List<ComplexData> complexData = new List<ComplexData>();
            TableData tableData = new TableData();

            if (leftSelect != null && rightSelect != null)
                return;
            else if (leftSelect != null)
            {
                currentTablePath = LeftTablePath.Text;
                currentTable = LeftTable;
            }
            else if (rightSelect != null)
            {
                currentTablePath = RightTablePath.Text;
                currentTable = RightTable;
            }

            if (currentTablePath[currentTablePath.LastIndexOf('\\') - 1] == ':')
                return;

            string upPath = currentTablePath;
            upPath = upPath.Remove(upPath.LastIndexOf('\\'));
            upPath = upPath.Remove(upPath.LastIndexOf('\\') + 1);
            initTable(currentTable, upPath);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var leftSelect = LeftTable.SelectedItem;
            var rightSelect = RightTable.SelectedItem;

            if (e.Key == Key.F4)
            {
                if (leftSelect != null)
                {
                    LeftTable.SelectedItem = null;

                    if ((leftSelect as ComplexData).type == null)
                        initTable(RightTable, LeftTablePath.Text + (leftSelect as ComplexData).name + '\\');
                }
                else if (rightSelect != null)
                {
                    RightTable.SelectedItem = null;

                    if ((rightSelect as ComplexData).type == null)
                        initTable(LeftTable, RightTablePath.Text + (rightSelect as ComplexData).name + '\\');
                }
            }

            if (e.Key == Key.F5)
            {
                string fullFileName = "";
                if (leftSelect != null)
                {
                    LeftTable.SelectedItem = null;
                    fullFileName += LeftTablePath.Text + (leftSelect as ComplexData).name + ((leftSelect as ComplexData).type != null ? "." + (leftSelect as ComplexData).type : "");
                }
                else if (rightSelect != null)
                {
                    RightTable.SelectedItem = null;
                    fullFileName = RightTablePath.Text + (rightSelect as ComplexData).name + ((rightSelect as ComplexData).type != null ? "." + (rightSelect as ComplexData).type : "");
                }
                Clipboard.Clear();
                Clipboard.SetText(fullFileName);
            }

            if (e.Key == Key.F6)
            {
                string copyingFileName = Clipboard.GetText();

                int indLastSlash = copyingFileName.LastIndexOf('\\');
                string fileName = "";
                for (int i = indLastSlash + 1; i < copyingFileName.Length; i++)
                    fileName += copyingFileName[i];

                string dectinationFileName = null;
                if (leftSelect != null)
                {
                    LeftTable.SelectedItem = null;
                    dectinationFileName = LeftTablePath.Text + fileName;
                }
                else if (rightSelect != null)
                {
                    RightTable.SelectedItem = null;
                    dectinationFileName = RightTablePath.Text + fileName;
                }

                try
                {
                    if (copyingFileName.LastIndexOf('.') == -1)
                    {
                        Directory.Move(copyingFileName, dectinationFileName);
                    }
                    else
                    {
                        File.Copy(copyingFileName, dectinationFileName);
                    }
                }
                catch (IOException copyError)
                {
                    string messageBoxText = "Error while copying file";
                    string caption = "File already exist";
                    MessageBoxButton button = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icon = MessageBoxImage.Warning;

                    MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
                initTable(LeftTable, LeftTablePath.Text);
                initTable(RightTable, RightTablePath.Text);
            }

            if (e.Key == Key.F7)
            {
                if (leftSelect != null)
                {
                    LeftTable.SelectedItem = null;

                    string path = LeftTablePath.Text + "Новая папка";
                    int num = 2;
                    while (Directory.Exists(path))
                    {
                        path = LeftTablePath.Text + "Новая папка " + num.ToString();
                        num++;
                    }
                    Directory.CreateDirectory(path);

                    initTable(LeftTable, LeftTablePath.Text);
                }
                else if (rightSelect != null)
                {
                    RightTable.SelectedItem = null;

                    string path = RightTablePath.Text + "Новая папка";
                    int num = 2;
                    while (Directory.Exists(path))
                    {
                        path = RightTablePath.Text + "Новая папка " + num.ToString();
                        num++;
                    }
                    Directory.CreateDirectory(path);

                    initTable(RightTable, RightTablePath.Text);
                }
            }

            if (e.Key == Key.F8)
            {
                string fullFileName = "";
                if (leftSelect != null)
                {
                    LeftTable.SelectedItem = null;
                    fullFileName += LeftTablePath.Text + (leftSelect as ComplexData).name + ((leftSelect as ComplexData).type != null ? "." + (leftSelect as ComplexData).type : "");
                }
                else if (rightSelect != null)
                {
                    RightTable.SelectedItem = null;
                    fullFileName = RightTablePath.Text + (rightSelect as ComplexData).name + ((rightSelect as ComplexData).type != null ? "." + (rightSelect as ComplexData).type : "");
                }
                File.Delete(fullFileName);

                initTable(LeftTable, LeftTablePath.Text);
                initTable(RightTable, RightTablePath.Text);
            }

            if (e.Key == Key.F9)
            {
                System.Diagnostics.Process.Start(@"C:\\Windows\\System32\\Cmd.exe");
            }

            if (e.SystemKey == Key.F10)
                Close();
        }
    }

    public class FileTypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fileType = value as string;
            string resourceKey = "DefaultFileIcon";

            if (string.IsNullOrEmpty(fileType))
            {
                resourceKey = "FolderIcon";
            }
            else
            {
                switch (fileType.ToLower())
                {
                    case "txt":
                        resourceKey = "TextFileIcon";
                        break;
                    case "jpg":
                    case "jpeg":
                    case "png":
                    case "gif":
                        resourceKey = "ImageFileIcon";
                        break;
                    case "pdf":
                        resourceKey = "PdfFileIcon";
                        break;
                    case "doc":
                    case "docx":
                        resourceKey = "WordFileIcon";
                        break;
                    case "xls":
                    case "xlsx":
                        resourceKey = "ExcelFileIcon";
                        break;
                    case "ppt":
                    case "pptx":
                        resourceKey = "PowerPointFileIcon";
                        break;
                }
            }

            return Application.Current.Resources[resourceKey] as BitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
