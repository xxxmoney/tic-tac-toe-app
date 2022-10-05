using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Core.Services;
using TicTacToe.FormUI.Helpers;

namespace TicTacToe.FormUI.Forms
{
    public partial class GameEndedForm : Form
    {
        private readonly IGameManager gameManager;

        public GameEndedForm(
            IGameManager gameManager)
        {
            this.gameManager = gameManager;

            InitializeComponent();
        }

        private void SetWonValue()
        {
            if (this.gameManager.Game.State == Core.Enums.GameStateEnum.SomeoneWon)
                this.labelWonValue.Text = this.gameManager.CurrentPlayer.Name;
            else
                this.labelWonValue.Text = null;
        }

        public void CustomShow()
        {
            // Refreshes language.
            this.ApplyResourceToControl();

            this.Show();
            this.SetWonValue();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }



    }
}
