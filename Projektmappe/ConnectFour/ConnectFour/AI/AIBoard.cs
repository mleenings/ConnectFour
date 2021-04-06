/**
 * 
 * Author:              Marcel Leenings
 * Last Modification:   02/2013
 * 
 * Description:
 * The functionalities that have to do with the game board, but are only required for the AI
 * 
 */

using ConnectFour.Players;
using System.Drawing;

namespace ConnectFour.AI
{
    class AIBoard
    {
        /* required objects */
        private Board board;
        private GameLogic gameLogic;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="board"></param>
        /// <param name="gameLogic"></param>
        public AIBoard(Board board, GameLogic gameLogic)
        {
            this.board = board;
            this.gameLogic = gameLogic;
        }

        /// <summary>
        /// if a turn in the column possible return true otherwise false
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public bool CanMove(int column)
        {
            return this.board.Fields[0, column].BackColor.Equals(this.board.FieldDefaultColor);
        }

        /// <summary>
        /// calc of the column the right row and occupies this with the color of player
        /// </summary>
        /// <param name="column"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public int Move(int column, Player player)
        {
            for (int row = this.board.NumbRows - 1; row >= 0; row--)
            {
                if (this.board.Fields[row, column].BackColor.Equals(this.board.FieldDefaultColor))
                {
                    this.board.Fields[row, column].BackColor = (Color)player.Tile;
                    return row;
                }
            }
            return -1;
        }

        /// <summary>
        /// move undo
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void UndoMove(int row, int column)
        {
            this.board.Fields[row, column].BackColor = this.board.FieldDefaultColor;
        }

        /// <summary>
        /// calc and return the score of the field
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            int score = 0;
            //Pieces in the middle score higher pieces at the edges
            //a example how the positions are scored:
            //
            //¦1¦2¦3¦4¦3¦2¦1¦
            //¦2¦3¦4¦5¦4¦3¦2¦
            //¦3¦4¦5¦6¦5¦4¦3¦
            //¦2¦3¦4¦5¦4¦3¦2¦
            //¦1¦2¦3¦4¦3¦2¦1¦
            //¦0¦1¦2¦3¦2¦1¦0¦
            //+-------------+

            for (int column = 0; column < this.board.NumbColumns; column++)
            {
                int columnscore = (this.board.NumbColumns / 2) - column;
                if (columnscore < 0)
                {
                    columnscore = -columnscore;
                }
                columnscore = (this.board.NumbColumns / 2) - columnscore;

                //Count the number of pieces in each and score accordingly
                for (int row = this.board.NumbRows - 1; row >= 0; row--)
                {
                    int rowscore = (this.board.NumbRows / 2) - row;
                    if (rowscore < 0)
                        rowscore = -rowscore;
                    rowscore = (this.board.NumbRows / 2) - rowscore;

                    Color actualFielColor = this.board.Fields[row, column].BackColor;
                    if (actualFielColor.Equals(this.gameLogic.P1.Tile))
                    {
                        score += columnscore + rowscore;
                    }
                    else if (actualFielColor.Equals(this.gameLogic.P2.Tile))
                    {
                        score -= columnscore + rowscore;
                    }
                }
            }

            return score;
        }
    }
}
