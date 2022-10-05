namespace TicTacToe.FormUI.Forms
{
    partial class GameEndedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameEndedForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelWon = new System.Windows.Forms.Label();
            this.labelWonValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.buttonOk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelWon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelWonValue, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.tableLayoutPanel1.SetColumnSpan(this.buttonOk, 2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelWon
            // 
            resources.ApplyResources(this.labelWon, "labelWon");
            this.labelWon.Name = "labelWon";
            // 
            // labelWonValue
            // 
            resources.ApplyResources(this.labelWonValue, "labelWonValue");
            this.labelWonValue.Name = "labelWonValue";
            // 
            // GameEndedForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameEndedForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonOk;
        private Label labelWon;
        private Label labelWonValue;
    }
}