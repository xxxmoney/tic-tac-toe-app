namespace TicTacToe.FormUI.Forms
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelCurrentPlayer = new System.Windows.Forms.Label();
            this.labelCurrentPlayerValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.labelCurrentPlayer, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelCurrentPlayerValue, 1, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // labelCurrentPlayer
            // 
            resources.ApplyResources(this.labelCurrentPlayer, "labelCurrentPlayer");
            this.labelCurrentPlayer.Name = "labelCurrentPlayer";
            // 
            // labelCurrentPlayerValue
            // 
            resources.ApplyResources(this.labelCurrentPlayerValue, "labelCurrentPlayerValue");
            this.labelCurrentPlayerValue.Name = "labelCurrentPlayerValue";
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Shown += new System.EventHandler(this.GameForm_Shown);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label labelCurrentPlayer;
        private Label labelCurrentPlayerValue;
    }
}