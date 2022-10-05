using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Core.Exceptions;
using TicTacToe.Core.Services;
using TicTacToe.FormUI.Helpers;
using TicTacToe.FormUI.UserControls;

namespace TicTacToe.FormUI.Forms
{
    public partial class GameForm : Form
    {
        private readonly List<Piece> pieces;
        private readonly IGameManager gameManager;
        private readonly GameEndedForm gameEndedForm;

        public GameForm(
            IGameManager gameManager, 
            GameEndedForm gameEndedForm)
        {
            this.pieces = new List<Piece>();
            this.gameManager = gameManager;
            this.gameEndedForm = gameEndedForm;

            InitializeComponent();

            // Restricts shrinking.
            this.LockResising(FormExtension.ResizeLockEnum.ShrinkLock);

            this.gameManager.OnTurn += GameManager_OnTurn;
            this.gameManager.OnPlayerChange += GameManager_OnPlayerChange;
            this.gameEndedForm.FormClosing += GameEndedForm_FormClosing;
        }

        private void GameEndedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.gameEndedForm.Hide();
            this.Close();
        }

        private void SetGameBoard()
        {
            // Clears previous board.
            this.ClearPieces();

            // Recalculates table layout panel size - bug fix.
            int marginX = 40;
            int marginY = 60;
            this.tableLayoutPanel.Size = new Size(this.Size.Width - marginX, this.Size.Height - marginY);
            
            int size = this.gameManager.Game.BoardSize;
            int percentPerOne = 100 / size;

            // Sets board row and col styles.
            this.board.ColumnStyles.Clear();
            this.board.RowStyles.Clear();
            this.board.ColumnCount = size;
            this.board.RowCount = size;
            for (int i = 0; i < size; i++)
            {
                this.board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentPerOne));
                this.board.RowStyles.Add(new RowStyle(SizeType.Percent, percentPerOne));
            }
            // Adds pieces to board.
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    var piece = new Piece(new Core.Models.Position(x, y), this.gameManager);
                    piece.Click += Piece_Click;

                    // Sets row, col and span for piece.
                    this.board.SetRow(piece, x);
                    this.board.SetColumn(piece, y);
                    this.board.SetRowSpan(piece, 1);
                    this.board.SetColumnSpan(piece, 1);

                    this.pieces.Add(piece);
                    this.board.Controls.Add(piece);
                }            
        }

        private void Piece_Click(object sender, EventArgs e)
        {
            var piece = sender as Piece;
            try
            {
                var turn = this.gameManager.MakeTurn(piece.Position);
                piece.SetLabelValue();
            }
            catch (PieceMarkedException ex)
            {
                this.gameEndedForm.Show();
            }
            catch (Exception ex)
            {
                // TODO: Add form.
                throw new NotImplementedException();
            }
        }

        private void SetGame()
        {
            this.SetGameBoard();
            this.gameManager.Start();
        }
        private void ResetGame()
        {
            // Resets game.            
            this.gameManager.Reset();
        }
        private void ClearPieces()
        {
            // Unsubscribes from event handler and removes pieces.
            foreach (var piece in pieces)
            {
                piece.Click -= Piece_Click;
                this.board.Controls.Remove(piece);                
            }
            this.pieces.Clear();
        }

        public void CustomShow()
        {
            // Refreshes language.
            this.ApplyResourceToControl();

            this.SetGame();
            this.Show();
            this.Update();
        }

        private void GameManager_OnTurn(object sender, Core.Models.TurnEventArgs e)
        {
            if (e.GameState == Core.Enums.GameStateEnum.SomeoneWon || 
                e.GameState == Core.Enums.GameStateEnum.Even)
            {
                this.gameEndedForm.CustomShow();
            }
        }

        private void GameManager_OnPlayerChange(object sender, Core.Models.PlayerChangeEventArgs e)
        {
            // Sets current player name from event args.
            this.labelCurrentPlayerValue.Text = e.Player.Name;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ResetGame();

            // Cancels form closing.
            e.Cancel = true;

            // Hides form.
            this.Hide();
        }
    }
}
