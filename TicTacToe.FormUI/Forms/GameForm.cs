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

namespace TicTacToe.FormUI.Forms
{
    public partial class GameForm : Form
    {
        private readonly IGameManager gameManager;

        public GameForm(IGameManager gameManager)
        {
            this.gameManager = gameManager;

            InitializeComponent();

            this.gameManager.OnTurn += GameManager_OnTurn;
            this.gameManager.OnPlayerChange += GameManager_OnPlayerChange;
        }

        private void GameManager_OnTurn(object sender, Core.Models.TurnEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameManager_OnPlayerChange(object sender, Core.Models.PlayerChangeEventArgs e)
        {
            // Sets current player name from event args.
            this.labelCurrentPlayerValue.Text = e.Player.Name;
        }

        private void GameForm_Shown(object sender, EventArgs e)
        {
            // Starts game.
            this.gameManager.Start(); 
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Resets game.            
            this.gameManager.Reset();

            // Cancels form closing.
            e.Cancel = true;

            // Hides form.
            this.Hide();
        }
    }
}
