using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.FormUI.Helpers;

namespace TicTacToe.FormUI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SettingsForm settingsForm;

        public MainForm(SettingsForm settingsForm)
        {
            InitializeComponent();

            this.settingsForm = settingsForm;            
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.settingsForm.Show();
        }
    }
}
