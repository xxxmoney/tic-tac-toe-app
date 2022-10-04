using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Core.Models;
using TicTacToe.Core.Services;

namespace TicTacToe.FormUI.UserControls
{
    public partial class Piece : UserControl
    {
        private readonly IGameManager gameManager;
        public Position Position { get; }
        private Player Player => this.gameManager.Game.Board[this.Position]?.MarkedBy;

        public Piece(Position position, IGameManager gameManager)
        {
            this.gameManager = gameManager;
            this.Position = position;
            
            InitializeComponent();

            this.labelValue.Anchor = AnchorStyles.None;
            this.labelValue.Dock = DockStyle.Fill;

            this.SetLabelValue();
        }

        /// <summary>
        /// Sets value of piece.
        /// </summary>
        public void SetLabelValue()
        {
            this.labelValue.Text = this.Player?.Name;
        }

        private void labelValue_Click(object sender, EventArgs e)
        {          
            this.OnClick(EventArgs.Empty);
        }
    }
}
