using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Enums;
using TicTacToe.Core.Helpers;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Services
{
    /// <summary>
    /// Judges game - determines games states.
    /// </summary>
    public interface IGameJudge
    {
        /// <summary>
        /// Searches the specified line of position in pieces.
        /// </summary>
        /// <param name="pieces"></param>
        /// <param name="position"></param>
        /// <param name="player"></param>
        /// <param name="winCount"></param>
        /// <param name="searchEnum"></param>
        /// <returns></returns>
        bool IsConsecutiveForPlayer(
            Piece[,] pieces,
            Position position,
            Player player,
            int winCount,
            JudgeSearchEnum searchEnum);

        /// <summary>
        /// Determines whether turn made player win.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="turnInfo"></param>
        /// <returns></returns>
        bool FindAnyWinning(Game game, TurnInfo turnInfo);
        /// <summary>
        /// Judges game based on turn.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="turnInfo"></param>
        /// <returns></returns>
        Judgement Judge(Game game, TurnInfo turnInfo);
    }

    public class GameJudge : IGameJudge
    {        
        public bool IsConsecutiveForPlayer(
            Piece[,] pieces, 
            Position position, 
            Player player, 
            int winCount,
            JudgeSearchEnum searchEnum)
        {
            // Gets limits for x and y axis.
            int xLimit = pieces.GetLength(0);
            int yLimit = pieces.GetLength(1);

            int xStep, yStep, xStart, yStart;
            // Checks what line to check.
            switch (searchEnum)
            {
                case JudgeSearchEnum.Horizontal:
                    xStart = 0;
                    yStart = position.Y;
                    xStep = 1;
                    yStep = 0;
                    break;
                case JudgeSearchEnum.Vertical:
                    xStart = position.X;
                    yStart = 0;
                    xStep = 0;
                    yStep = 1;
                    break;
                case JudgeSearchEnum.MainDiagonal:
                    Position cornerLeftToRight = Helpers.PositionHelper.GetMainDiagonalLeftCorner(position);
                    xStart = cornerLeftToRight.X;
                    yStart = cornerLeftToRight.Y;
                    xStep = 1;
                    yStep = 1;
                    break;
                case JudgeSearchEnum.AntiDiagonal:
                    Position cornerRightToLeft = Helpers.PositionHelper.GetAntiDiagonalLeftCorner(position, yLimit);
                    xStart = cornerRightToLeft.X;
                    yStart = cornerRightToLeft.Y;
                    xStep = 1;
                    yStep = -1;
                    break;
                default:
                    throw new Exception("Unknown enum.");
            }

            int consecutive = 0;
            int x = xStart;
            int y = yStart;
            while (true)
            {
                // Gets who marked piece and position.
                var markedBy = pieces[x, y]?.MarkedBy;
                // Increases consecutive if piece is marked by specified player.                
                if (markedBy != null && markedBy.Equals(player))
                    consecutive++;
                // Otherwise reset to 0.
                else
                    consecutive = 0;

                // When consecutive reaches win count, returns true - found consecutive.
                if (consecutive >= winCount)
                    return true;                

                x += xStep;
                y += yStep;

                // Checks for limits.
                if (x < 0 || x >= xLimit || y < 0 || y >= yLimit)
                    break;
            }

            // Didn't find consecutive, returns false.
            return false;
        }

        public bool FindAnyWinning(Game game, TurnInfo turnInfo)
        {
            // Gets position of piece in turn.
            Position position = turnInfo.Piece.Position;

            // Gets all search options.
            var searchValues = Enum.GetValues<JudgeSearchEnum>();
            // Checks whether any line contains consecutive marked pieces for winning.
            return searchValues.Any(value =>            
                this.IsConsecutiveForPlayer(game.Board.Pieces, position, turnInfo.Player, game.WinCount, value)
            );
        }

        public Judgement Judge(Game game, TurnInfo turnInfo)
        {
            // Checks whether someone won.
            if (this.FindAnyWinning(game, turnInfo))
            {
                return new Judgement(Enums.GameStateEnum.SomeoneWon, turnInfo.Player);
            }

            // Checks whether the board is fully marked.
            if (game.Board.IsFullyMarked)
            {
                return new Judgement(Enums.GameStateEnum.Even);
            }

            // Else returns that game is still running.
            return new Judgement(Enums.GameStateEnum.Running);
        }
    }
}
