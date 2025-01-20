namespace wfaExplorer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel MainGrid;
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Panel Interactions;
        private System.Windows.Forms.Panel Footer;
        private System.Windows.Forms.Button RefreshInteractionsButton;
        private System.Windows.Forms.Button RemoveInteractionsButton;
        private System.Windows.Forms.Button UpInteractionsButton;
        private System.Windows.Forms.TableLayoutPanel TablesLayoutPanel;
        private System.Windows.Forms.DataGridView LeftTable;
        private System.Windows.Forms.DataGridView RightTable;
        private System.Windows.Forms.Label LeftTablePath;
        private System.Windows.Forms.Label RightTablePath;
        private System.Windows.Forms.Label ViewF4;
        private System.Windows.Forms.Label CopyF5;
        private System.Windows.Forms.Label PasteF6;
        private System.Windows.Forms.Label MakeDirF7;
        private System.Windows.Forms.Label DeleteF8;
        private System.Windows.Forms.Label TerminalF9;
        private System.Windows.Forms.Label ExitF10;
        private System.Windows.Forms.Panel LeftMenuPanel;
        private System.Windows.Forms.FlowLayoutPanel RightMenuPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.MainGrid = new System.Windows.Forms.Panel();
            this.Menu = new System.Windows.Forms.Panel();
            this.Interactions = new System.Windows.Forms.Panel();
            this.TablesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Footer = new System.Windows.Forms.Panel();
            this.RefreshInteractionsButton = new System.Windows.Forms.Button();
            this.RemoveInteractionsButton = new System.Windows.Forms.Button();
            this.UpInteractionsButton = new System.Windows.Forms.Button();
            this.LeftTable = new System.Windows.Forms.DataGridView();
            this.RightTable = new System.Windows.Forms.DataGridView();
            this.LeftTablePath = new System.Windows.Forms.Label();
            this.RightTablePath = new System.Windows.Forms.Label();
            this.ViewF4 = new System.Windows.Forms.Label();
            this.CopyF5 = new System.Windows.Forms.Label();
            this.PasteF6 = new System.Windows.Forms.Label();
            this.MakeDirF7 = new System.Windows.Forms.Label();
            this.DeleteF8 = new System.Windows.Forms.Label();
            this.TerminalF9 = new System.Windows.Forms.Label();
            this.ExitF10 = new System.Windows.Forms.Label();
            this.LeftMenuPanel = new System.Windows.Forms.Panel();
            this.RightMenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MainGrid.SuspendLayout();
            this.Menu.SuspendLayout();
            this.Interactions.SuspendLayout();
            this.TablesLayoutPanel.SuspendLayout();
            this.Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightTable)).BeginInit();
            this.SuspendLayout();

            // MainGrid
            this.MainGrid.Controls.Add(this.Menu);
            this.MainGrid.Controls.Add(this.Interactions);
            this.MainGrid.Controls.Add(this.TablesLayoutPanel);
            this.MainGrid.Controls.Add(this.Footer);
            this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGrid.Location = new System.Drawing.Point(0, 0);
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.Size = new System.Drawing.Size(800, 450);
            this.MainGrid.TabIndex = 0;
            this.MainGrid.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // Menu
            this.Menu.Controls.Add(this.LeftMenuPanel);
            this.Menu.Controls.Add(this.RightMenuPanel);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(800, 50);
            this.Menu.TabIndex = 1;
            this.Menu.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.Menu.Paint += new System.Windows.Forms.PaintEventHandler(this.Menu_Paint);

            // LeftMenuPanel
            this.LeftMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMenuPanel.Name = "LeftMenuPanel";
            this.LeftMenuPanel.Size = new System.Drawing.Size(400, 50);
            this.LeftMenuPanel.TabIndex = 0;

            // RightMenuPanel
            this.RightMenuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMenuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.RightMenuPanel.Location = new System.Drawing.Point(400, 0);
            this.RightMenuPanel.Name = "RightMenuPanel";
            this.RightMenuPanel.Size = new System.Drawing.Size(400, 50);
            this.RightMenuPanel.TabIndex = 1;

            // Interactions
            this.Interactions.Controls.Add(this.RefreshInteractionsButton);
            this.Interactions.Controls.Add(this.RemoveInteractionsButton);
            this.Interactions.Controls.Add(this.UpInteractionsButton);
            this.Interactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.Interactions.Location = new System.Drawing.Point(0, 50);
            this.Interactions.Name = "Interactions";
            this.Interactions.Size = new System.Drawing.Size(800, 50);
            this.Interactions.TabIndex = 2;
            this.Interactions.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);

            // RefreshInteractionsButton
            this.RefreshInteractionsButton.Location = new System.Drawing.Point(10, 10);
            this.RefreshInteractionsButton.Name = "RefreshInteractionsButton";
            this.RefreshInteractionsButton.Size = new System.Drawing.Size(75, 30);
            this.RefreshInteractionsButton.TabIndex = 0;
            this.RefreshInteractionsButton.Text = "Refresh";
            this.RefreshInteractionsButton.UseVisualStyleBackColor = true;
            this.RefreshInteractionsButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.RefreshInteractionsButton.ForeColor = System.Drawing.Color.White;
            this.RefreshInteractionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // RemoveInteractionsButton
            this.RemoveInteractionsButton.Location = new System.Drawing.Point(90, 10);
            this.RemoveInteractionsButton.Name = "RemoveInteractionsButton";
            this.RemoveInteractionsButton.Size = new System.Drawing.Size(75, 30);
            this.RemoveInteractionsButton.TabIndex = 1;
            this.RemoveInteractionsButton.Text = "Remove";
            this.RemoveInteractionsButton.UseVisualStyleBackColor = true;
            this.RemoveInteractionsButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.RemoveInteractionsButton.ForeColor = System.Drawing.Color.White;
            this.RemoveInteractionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // UpInteractionsButton
            this.UpInteractionsButton.Location = new System.Drawing.Point(170, 10);
            this.UpInteractionsButton.Name = "UpInteractionsButton";
            this.UpInteractionsButton.Size = new System.Drawing.Size(75, 30);
            this.UpInteractionsButton.TabIndex = 2;
            this.UpInteractionsButton.Text = "Up";
            this.UpInteractionsButton.UseVisualStyleBackColor = true;
            this.UpInteractionsButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.UpInteractionsButton.ForeColor = System.Drawing.Color.White;
            this.UpInteractionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // TablesLayoutPanel
            this.TablesLayoutPanel.ColumnCount = 2;
            this.TablesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablesLayoutPanel.Controls.Add(this.LeftTable, 0, 1);
            this.TablesLayoutPanel.Controls.Add(this.RightTable, 1, 1);
            this.TablesLayoutPanel.Controls.Add(this.LeftTablePath, 0, 0);
            this.TablesLayoutPanel.Controls.Add(this.RightTablePath, 1, 0);
            this.TablesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablesLayoutPanel.Location = new System.Drawing.Point(0, 100);
            this.TablesLayoutPanel.Name = "TablesLayoutPanel";
            this.TablesLayoutPanel.RowCount = 2;
            this.TablesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TablesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablesLayoutPanel.Size = new System.Drawing.Size(800, 300);
            this.TablesLayoutPanel.TabIndex = 3;
            this.TablesLayoutPanel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // LeftTable
            this.LeftTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LeftTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTable.Location = new System.Drawing.Point(3, 23);
            this.LeftTable.Name = "LeftTable";
            this.LeftTable.Size = new System.Drawing.Size(394, 274);
            this.LeftTable.TabIndex = 0;
            this.LeftTable.BackgroundColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.LeftTable.ForeColor = System.Drawing.Color.White;

            // RightTable
            this.RightTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RightTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTable.Location = new System.Drawing.Point(403, 23);
            this.RightTable.Name = "RightTable";
            this.RightTable.Size = new System.Drawing.Size(394, 274);
            this.RightTable.TabIndex = 1;
            this.RightTable.BackgroundColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.RightTable.ForeColor = System.Drawing.Color.White;

            // LeftTablePath
            this.LeftTablePath.AutoSize = true;
            this.LeftTablePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTablePath.Location = new System.Drawing.Point(3, 0);
            this.LeftTablePath.Name = "LeftTablePath";
            this.LeftTablePath.Size = new System.Drawing.Size(394, 20);
            this.LeftTablePath.TabIndex = 2;
            this.LeftTablePath.Text = "Path";
            this.LeftTablePath.ForeColor = System.Drawing.Color.White;

            // RightTablePath
            this.RightTablePath.AutoSize = true;
            this.RightTablePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTablePath.Location = new System.Drawing.Point(403, 0);
            this.RightTablePath.Name = "RightTablePath";
            this.RightTablePath.Size = new System.Drawing.Size(394, 20);
            this.RightTablePath.TabIndex = 3;
            this.RightTablePath.Text = "Path";
            this.RightTablePath.ForeColor = System.Drawing.Color.White;

            // Footer
            this.Footer.Controls.Add(this.ViewF4);
            this.Footer.Controls.Add(this.CopyF5);
            this.Footer.Controls.Add(this.PasteF6);
            this.Footer.Controls.Add(this.MakeDirF7);
            this.Footer.Controls.Add(this.DeleteF8);
            this.Footer.Controls.Add(this.TerminalF9);
            this.Footer.Controls.Add(this.ExitF10);
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(0, 400);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(800, 50);
            this.Footer.TabIndex = 4;
            this.Footer.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);

            // ViewF4
            this.ViewF4.AutoSize = true;
            this.ViewF4.Location = new System.Drawing.Point(10, 15);
            this.ViewF4.Name = "ViewF4";
            this.ViewF4.Size = new System.Drawing.Size(44, 13);
            this.ViewF4.TabIndex = 0;
            this.ViewF4.Text = "View F4";
            this.ViewF4.ForeColor = System.Drawing.Color.White;

            // CopyF5
            this.CopyF5.AutoSize = true;
            this.CopyF5.Location = new System.Drawing.Point(120, 15);
            this.CopyF5.Name = "CopyF5";
            this.CopyF5.Size = new System.Drawing.Size(48, 13);
            this.CopyF5.TabIndex = 1;
            this.CopyF5.Text = "Copy F5";
            this.CopyF5.ForeColor = System.Drawing.Color.White;

            // PasteF6
            this.PasteF6.AutoSize = true;
            this.PasteF6.Location = new System.Drawing.Point(230, 15);
            this.PasteF6.Name = "PasteF6";
            this.PasteF6.Size = new System.Drawing.Size(50, 13);
            this.PasteF6.TabIndex = 2;
            this.PasteF6.Text = "Paste F6";
            this.PasteF6.ForeColor = System.Drawing.Color.White;

            // MakeDirF7
            this.MakeDirF7.AutoSize = true;
            this.MakeDirF7.Location = new System.Drawing.Point(340, 15);
            this.MakeDirF7.Name = "MakeDirF7";
            this.MakeDirF7.Size = new System.Drawing.Size(64, 13);
            this.MakeDirF7.TabIndex = 3;
            this.MakeDirF7.Text = "MakeDir F7";
            this.MakeDirF7.ForeColor = System.Drawing.Color.White;

            // DeleteF8
            this.DeleteF8.AutoSize = true;
            this.DeleteF8.Location = new System.Drawing.Point(450, 15);
            this.DeleteF8.Name = "DeleteF8";
            this.DeleteF8.Size = new System.Drawing.Size(53, 13);
            this.DeleteF8.TabIndex = 4;
            this.DeleteF8.Text = "Delete F8";
            this.DeleteF8.ForeColor = System.Drawing.Color.White;

            // TerminalF9
            this.TerminalF9.AutoSize = true;
            this.TerminalF9.Location = new System.Drawing.Point(560, 15);
            this.TerminalF9.Name = "TerminalF9";
            this.TerminalF9.Size = new System.Drawing.Size(61, 13);
            this.TerminalF9.TabIndex = 5;
            this.TerminalF9.Text = "Terminal F9";
            this.TerminalF9.ForeColor = System.Drawing.Color.White;

            // ExitF10
            this.ExitF10.AutoSize = true;
            this.ExitF10.Location = new System.Drawing.Point(670, 15);
            this.ExitF10.Name = "ExitF10";
            this.ExitF10.Size = new System.Drawing.Size(44, 13);
            this.ExitF10.TabIndex = 6;
            this.ExitF10.Text = "Exit F10";
            this.ExitF10.ForeColor = System.Drawing.Color.White;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainGrid);
            this.Name = "Form1";
            this.Text = "Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainGrid.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.Interactions.ResumeLayout(false);
            this.TablesLayoutPanel.ResumeLayout(false);
            this.TablesLayoutPanel.PerformLayout();
            this.Footer.ResumeLayout(false);
            this.Footer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightTable)).EndInit();
            this.ResumeLayout(false);
        }
    }
}