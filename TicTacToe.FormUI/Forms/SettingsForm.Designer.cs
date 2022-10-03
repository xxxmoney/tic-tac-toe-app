namespace TicTacToe.FormUI.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gridSizeLabel = new System.Windows.Forms.Label();
            this.numericGridSize = new System.Windows.Forms.NumericUpDown();
            this.labelWinCount = new System.Windows.Forms.Label();
            this.numericWinCount = new System.Windows.Forms.NumericUpDown();
            this.labelPlayerCount = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericPlayerCount = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWinCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.gridSizeLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.numericGridSize, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelWinCount, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.numericWinCount, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelPlayerCount, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.labelPlayers, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonStart, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.numericPlayerCount, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.dataGridViewPlayers, 1, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // gridSizeLabel
            // 
            resources.ApplyResources(this.gridSizeLabel, "gridSizeLabel");
            this.gridSizeLabel.Name = "gridSizeLabel";
            // 
            // numericGridSize
            // 
            resources.ApplyResources(this.numericGridSize, "numericGridSize");
            this.numericGridSize.Name = "numericGridSize";
            // 
            // labelWinCount
            // 
            resources.ApplyResources(this.labelWinCount, "labelWinCount");
            this.labelWinCount.Name = "labelWinCount";
            // 
            // numericWinCount
            // 
            resources.ApplyResources(this.numericWinCount, "numericWinCount");
            this.numericWinCount.Name = "numericWinCount";
            // 
            // labelPlayerCount
            // 
            resources.ApplyResources(this.labelPlayerCount, "labelPlayerCount");
            this.labelPlayerCount.Name = "labelPlayerCount";
            // 
            // labelPlayers
            // 
            resources.ApplyResources(this.labelPlayers, "labelPlayers");
            this.labelPlayers.Name = "labelPlayers";
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.tableLayoutPanel.SetColumnSpan(this.buttonStart, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numericPlayerCount
            // 
            resources.ApplyResources(this.numericPlayerCount, "numericPlayerCount");
            this.numericPlayerCount.Name = "numericPlayerCount";
            this.numericPlayerCount.ValueChanged += new System.EventHandler(this.numericPlayerCount_ValueChanged);
            // 
            // dataGridViewPlayers
            // 
            resources.ApplyResources(this.dataGridViewPlayers, "dataGridViewPlayers");
            this.dataGridViewPlayers.AllowUserToAddRows = false;
            this.dataGridViewPlayers.AllowUserToDeleteRows = false;
            this.dataGridViewPlayers.AllowUserToOrderColumns = true;
            this.dataGridViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlayers.Name = "dataGridViewPlayers";
            this.dataGridViewPlayers.RowTemplate.Height = 25;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWinCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label gridSizeLabel;
        private NumericUpDown numericGridSize;
        private Label labelWinCount;
        private NumericUpDown numericWinCount;
        private Label labelPlayerCount;
        private Label labelPlayers;
        private Button buttonStart;
        private NumericUpDown numericPlayerCount;
        private DataGridView dataGridViewPlayers;
    }
}