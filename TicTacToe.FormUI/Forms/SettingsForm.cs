using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Core.Models;
using TicTacToe.Core.Services;
using TicTacToe.FormUI.Helpers;
using TicTacToe.FormUI.Models;

namespace TicTacToe.FormUI.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly IGameManager gameManager;
        private readonly GameForm gameForm;
        private readonly BindingList<Models.Player> players;
        private bool loaded = false;

        public SettingsForm(
            IGameManager gameManager,
            GameForm gameForm)
        {
            this.gameManager = gameManager;
            this.gameForm = gameForm;

            InitializeComponent();

            this.SetControlsLimits();

            // Initializes players list.
            this.players = new BindingList<Models.Player>();
            this.SetPlayersListBasedOnNumeric();

            // Sets grid view's data source to players.
            this.dataGridViewPlayers.DataSource = this.players;

            this.loaded = true;

            gameForm.FormClosing += GameForm_FormClosing;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Shows this form when game form is closing.
            this.Show();
        }

        /// <summary>
        /// Sets limits for controls - mininum and maximum.
        /// </summary>
        private void SetControlsLimits()
        {
            this.numericGridSize.Minimum = Core.Constants.MinimumBoardSize;
            this.numericGridSize.Maximum = Core.Constants.MaximumBoardSize;

            this.numericWinCount.Minimum = Core.Constants.MinimumWinCount;
            this.numericWinCount.Maximum = Core.Constants.MaximumWinCount;

            this.numericPlayerCount.Minimum = Core.Constants.MinimumPlayerCount;
            this.numericPlayerCount.Maximum = Core.Constants.MaximumPlayerCount;
        }

        private void SetPlayersListBasedOnNumeric()
        {
            // Determines whether to add new player.
            bool shouldAdd = this.players.Count < this.numericPlayerCount.Value;
            // Calculates difference between current player count and desired.
            int difference = Math.Abs(this.players.Count - (int)this.numericPlayerCount.Value);

            for (int i = 0; i < difference; i++)
            {
                // Adds new player to the end.
                if (shouldAdd)
                    this.players.Add(new Models.Player());
                // Removes player from the end.
                else
                    this.players.RemoveAt(this.players.Count - 1);
            }
        }

        /// <summary>
        /// Configures game manager based on this form's controls.
        /// </summary>
        private void ConfigureGameManager()
        {
            var configuration = new Configuration(
                (int)this.numericGridSize.Value,
                (int)this.numericPlayerCount.Value,
                (int)this.numericWinCount.Value,
                this.players.Select(player => player.Name).ToArray());

            this.gameManager.Configure(configuration);
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Exits application.
            Environment.Exit(0);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.ConfigureGameManager();

            this.Hide();
            this.gameForm.CustomShow();
        }

        private void numericPlayerCount_ValueChanged(object sender, EventArgs e)
        {
            if (this.loaded)
                this.SetPlayersListBasedOnNumeric();
        }
    }
}
