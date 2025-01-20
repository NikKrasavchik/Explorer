using System;
using System.IO;
using System.Windows.Forms;

namespace wfaExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form1_Resize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the DataGridView columns
            InitializeGridView(LeftTable);
            InitializeGridView(RightTable);

            // Set the minimum size of the form to its initial size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // Add buttons to the menu based on root directories
            AddButtonsToMenu(LeftMenuPanel, RightMenuPanel);

            // Set initial paths
            LeftTablePath.Text = "C:\\";
            RightTablePath.Text = "C:\\";

            // Load files and folders from C:/ into both tables
            LoadFilesAndFolders("C:\\", LeftTable);
            LoadFilesAndFolders("C:\\", RightTable);

            // Add event handlers for double-clicking on rows
            LeftTable.CellDoubleClick += LeftTable_CellDoubleClick;
            RightTable.CellDoubleClick += RightTable_CellDoubleClick;
        }

        private void InitializeGridView(DataGridView gridView)
        {
            gridView.Columns.Add("name", "Name");
            gridView.Columns.Add("type", "Type");
            gridView.Columns.Add("dateCreated", "Date Created");
            gridView.Columns.Add("dateLastWrite", "Date Last Write");

            // Set the style of the DataGridView
            gridView.BackgroundColor = System.Drawing.Color.FromArgb(37, 37, 38);
            gridView.ForeColor = System.Drawing.Color.White;
            gridView.GridColor = System.Drawing.Color.FromArgb(51, 51, 51);
            gridView.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            gridView.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            gridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            gridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            gridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            gridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            gridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            gridView.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            gridView.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            gridView.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            gridView.RowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            gridView.EnableHeadersVisualStyles = false;
            gridView.ScrollBars = ScrollBars.Both;

            // Remove the right header
            gridView.RowHeadersVisible = false;
        }

        private void LoadFilesAndFolders(string path, DataGridView gridView)
        {
            if (gridView == LeftTable)
                LeftTablePath.Text = path;
            else if (gridView == RightTable)
                RightTablePath.Text = path;
            gridView.Rows.Clear();
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                foreach (var dir in dirInfo.GetDirectories())
                {
                    gridView.Rows.Add(dir.Name, "Folder", dir.CreationTime, dir.LastWriteTime);
                }
                foreach (var file in dirInfo.GetFiles())
                {
                    gridView.Rows.Add(file.Name, "File", file.CreationTime, file.LastWriteTime);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading files and folders: {ex.Message}");
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterRightMenuButtons();
        }

        private void AddButtonsToMenu(Panel leftPanel, FlowLayoutPanel rightPanel)
        {
            leftPanel.Controls.Clear();
            rightPanel.Controls.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            int buttonWidth = 75;
            int buttonHeight = 30;
            int margin = 5;

            for (int i = 0; i < drives.Length; i++)
            {
                int index = i; // Захват индекса для использования в замыкании

                Button leftButton = new Button();
                leftButton.Text = drives[index].Name;
                leftButton.Width = buttonWidth;
                leftButton.Height = buttonHeight;
                leftButton.Left = index * (buttonWidth + margin);
                leftButton.Top = 10;
                leftButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
                leftButton.ForeColor = System.Drawing.Color.White;
                leftButton.FlatStyle = FlatStyle.Flat;
                leftButton.Click += (s, e) =>
                {
                    LoadFilesAndFolders(drives[index].RootDirectory.FullName, LeftTable);
                };
                leftPanel.Controls.Add(leftButton);

                Button rightButton = new Button();
                rightButton.Text = drives[index].Name;
                rightButton.Width = buttonWidth;
                rightButton.Height = buttonHeight;
                rightButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
                rightButton.ForeColor = System.Drawing.Color.White;
                rightButton.FlatStyle = FlatStyle.Flat;
                rightButton.Click += (s, e) =>
                {
                    LoadFilesAndFolders(drives[index].RootDirectory.FullName, RightTable);
                };
                rightPanel.Controls.Add(rightButton);
            }

            CenterRightMenuButtons();
        }

        private void CenterRightMenuButtons()
        {
            int totalButtonHeight = 0;
            foreach (Control control in RightMenuPanel.Controls)
            {
                totalButtonHeight += control.Height + RightMenuPanel.Margin.Vertical;
            }

            int startY = (RightMenuPanel.Height - totalButtonHeight) / 2;
            RightMenuPanel.Padding = new Padding(0, startY, 0, 0);
        }

        private void RefreshInteractionsButton_Click(object sender, EventArgs e)
        {
            // Handle Refresh button click
        }

        private void RemoveInteractionsButton_Click(object sender, EventArgs e)
        {
            // Handle Remove button click
        }

        private void UpInteractionsButton_Click(object sender, EventArgs e)
        {
            // Handle Up button click
        }

        private void Menu_Paint(object sender, PaintEventArgs e)
        {
            // Handle Menu paint event if needed
        }

        private void LeftTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string name = LeftTable.Rows[e.RowIndex].Cells["name"].Value.ToString();
                string type = LeftTable.Rows[e.RowIndex].Cells["type"].Value.ToString();
                string currentPath = LeftTablePath.Text;
                string path = Path.Combine(currentPath, name);

                if (type == "Folder")
                {
                    LoadFilesAndFolders(path, LeftTable);
                    LeftTablePath.Text = path; // Update the current path
                }
                else if (type == "File")
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        private void RightTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string name = RightTable.Rows[e.RowIndex].Cells["name"].Value.ToString();
                string type = RightTable.Rows[e.RowIndex].Cells["type"].Value.ToString();
                string currentPath = RightTablePath.Text;
                string path = Path.Combine(currentPath, name);

                if (type == "Folder")
                {
                    LoadFilesAndFolders(path, RightTable);
                    RightTablePath.Text = path; // Update the current path
                }
                else if (type == "File")
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }
    }
}