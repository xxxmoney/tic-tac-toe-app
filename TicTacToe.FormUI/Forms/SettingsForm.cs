using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private readonly ILanguageSwitcher languageSwitcher;
        private readonly GameForm gameForm;
        private readonly CustomBindingList<Models.Player> players;
        private readonly bool loaded = false;

        public SettingsForm(
            IGameManager gameManager,
            ILanguageSwitcher languageSwitcher,
            GameForm gameForm)
        {
            this.gameManager = gameManager;
            this.languageSwitcher = languageSwitcher;
            this.gameForm = gameForm;

            InitializeComponent();

            this.SetControlsLimits();

            // Initializes players list.
            this.players = new CustomBindingList<Models.Player>();
            this.SetPlayersListBasedOnNumeric();

            // Sets grid view's data source to players.
            this.dataGridViewPlayers.DataSource = this.players;

            this.loaded = true;

            // Sets handler for game form's closing.
            gameForm.FormClosing += GameForm_FormClosing;

            // Adds handlers for validation.
            this.numericGridSize.ValueChanged += OnChangeValidate;
            this.numericWinCount.ValueChanged += OnChangeValidate;
            this.numericPlayerCount.ValueChanged += OnChangeValidate;
            // Sets handling for players.
            this.players.ListChanged += OnChangeValidate;
            this.players.AddingNew += Players_AddingNew;
            this.players.BeforeRemove += Players_BeforeRemove;
            this.languageSwitcher = languageSwitcher;
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
        
        /// <summary>
        /// Validates controls's values.
        /// </summary>
        /// <returns></returns>
        private bool ValidateControls()
        {
            bool playersCheck = this.players.All(player => !string.IsNullOrWhiteSpace(player.Name));
            bool winCountCheck = this.numericWinCount.Value <= this.numericGridSize.Value;

            return playersCheck && winCountCheck;
        }
        /// <summary>
        /// Sets button's enabled by validation.
        /// </summary>
        private void SetButtonStartEnabled()
        {
            this.buttonStart.Enabled = this.ValidateControls();
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

        private void RefreshLanguage()
        {
            // Refrehes language.
            this.ApplyResourceToControl();

            this.SetButtonStartEnabled();
        }


        private void Players_AddingNew(object sender, AddingNewEventArgs e)
        {
            // Adds handler to new player.
            if (e.NewObject is Models.Player player)
            {
                player.PropertyChanged += Player_PropertyChanged;
            }
        }

        private void Players_BeforeRemove(Models.Player player)
        {
            // Removes handler from removed player.
            player.PropertyChanged -= Player_PropertyChanged;
        }

        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Validates on change.
            this.SetButtonStartEnabled();
        }

        private void OnChangeValidate(object sender, EventArgs e)
        {
            this.SetButtonStartEnabled();   
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Shows this form when game form is closing.
            this.Show();
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

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.languageSwitcher.SetCurrentLanguage(Enums.LanguageEnum.EN);

            this.RefreshLanguage();
        }

        private void czechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.languageSwitcher.SetCurrentLanguage(Enums.LanguageEnum.CZ);

            this.RefreshLanguage();
        }
    }
}
