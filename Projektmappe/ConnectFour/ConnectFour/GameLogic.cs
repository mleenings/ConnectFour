/**
 * 
 * Author:              Marcel Leenings
 * Last Modification:   02/2013
 * 
 * Description:
 * The gamelogic of connect four
 * 
 */

//entfernen der unverwendeten usings

using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using ConnectFour.Players;

//namepace geändert
namespace ConnectFour
{
    class GameLogic
    {
        /* requied objects */
        private readonly AI.AI ai;
        private readonly Board board;
        private readonly ArrayList wonButtons = new ArrayList();

        /* default values and constants */
        private readonly Color fieldDefaultColor = Color.WhiteSmoke;
        private readonly Color wonColorBlue = Color.RoyalBlue;
        private readonly Color wonColorRed = Color.Tomato;
        private const string standoff = "Standoff!";

        /* players */
        private readonly Player1 p1= new Player1("Player1");
        public Player P1
                {
            get { return this.p1; }
        }
        private readonly Player2 p2 = new Player2("Player2");
        public Player P2
        {
            get { return this.p2; }
        }

        /* informations of the winner, if there are no winner it is null */
        public Player Winner { get; set; }

        /* color of the active player */
        private Color activePlayerColor = Color.Red;
        public Color ActivePlayerColor
        {
            get { return this.activePlayerColor; }
            set { this.activePlayerColor = value; }
        }

        /* number of... */
        private int numbRows;
        private int numbColumns;
        private int maxMoves;
        private int actualMoves;
        public int ActualMoves
        {
            get { return this.actualMoves; }
            set { this.actualMoves = value; }
        }


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="board"></param>
        public GameLogic(Board board)
        {
          Winner = null;
          this.board = board;
          this.ai = new AI.AI(board, this);
        }


        /// <summary>
        /// click event of a column click event
        /// </summary>
        /// <param name="btn"></param>
        public void ColumnButtonClickEvent(Button btn)
        {
            this.setColumnsAndRows();
            int column = Convert.ToInt32(btn.Text)-1;
            int row = this.calcRow(column);
            if (column >= 0 && row >= 0)
            {
                this.markField(column, row);
                this.switchPlayer();
                this.inkrementActualMoves();
                this.selectWinner(this.checkWinnerColor());
            }
        }

        /// <summary>
        /// make a turn of the AI
        /// </summary>
        public void MoveAI()
        {
            int column = this.ai.CalcAlphaBetaMoveColumn(this.p2);
            this.ai.Move(column, this.p2);
            this.inkrementActualMoves();
            this.selectWinner(this.checkWinnerColor());
            this.switchPlayer();
        }

        /// <summary>
        /// mark a field as occupied with the active player color
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        public void markField(int column, int row)
        {
            this.board.Fields[row, column].BackColor = this.activePlayerColor;
        }

        /// <summary>
        /// calc and return the free row of a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public int calcRow(int col)
        {
            int row = -1;
            for (int i = this.board.Fields.GetLength(0) - 1; i >= 0; i--)
            {
                if (!this.isTakenField(col, i))
                {
                    row = i;
                    break;
                }
            }
            return row;
        }

        /// <summary>
        /// check if a field taken, is a field taken return true otherwise false
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isTakenField(int col, int row)
        {
            Color fieldColor = this.board.Fields[row, col].BackColor;
            return fieldColor == this.p1.Tile.Value || fieldColor == this.p2.Tile.Value;
        }

        /// <summary>
        /// check if somebody has won
        /// </summary>
        /// <returns></returns>
        public Color? checkWinnerColor()
        {
            Button[,] fields = this.board.Fields;
            return ((this.checkWinHorizontal(fields) ?? this.checkWinVertical(fields)) ?? this.checkWinDiagonalDecreasing(fields)) ?? this.checkWinDiagonalAscending(fields);
        }

        /// <summary>
        /// check win horizontal like this: x x x
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private Color? checkWinHorizontal(Button[,] fields)
        {
            for (int row = 0; row < this.numbRows; row++)
            {
                int sum = 1;
                for (int column = 0; column < this.numbColumns - 1; column++)
                {
                    Button fieldAct = fields[row, column];
                    Button fileNext = fields[row, column + 1];
                    Color fieldActColor = fieldAct.BackColor;
                    Color fileNextColor = fileNext.BackColor;
                    if (!fieldActColor.Equals(this.fieldDefaultColor)
                        && (fieldActColor.Equals(this.p1.Tile) && fileNextColor.Equals(this.p1.Tile)
                        || (fieldActColor.Equals(this.p2.Tile) && fileNextColor.Equals(this.p2.Tile))))
                    {
                        sum = sum + 1;
                        this.wonButtons.Add(fieldAct);
                        if (sum >= 4)
                        {
                            this.wonButtons.Add(fileNext);
                            return fieldActColor;
                        }
                    }
                    else
                    {
                        sum = 1;
                        this.wonButtons.Clear();
                    }
                }
            }
            return null;
        }

        /// <summary> 
        ///                                 x
        /// check win vertival like this:   x
        ///                                 x
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private Color? checkWinVertical(Button[,] fields)
        {
            for (int column = 0; column < this.numbColumns; column++)
            {
                int sum = 1;
                for (int row = 0; row < this.numbRows - 1; row++)
                {
                    Button fieldAct = fields[row, column];
                    Button fileNext = fields[row+1, column];
                    Color fieldActColor = fieldAct.BackColor;
                    Color fileNextColor = fileNext.BackColor;
                    if (!fieldActColor.Equals(this.fieldDefaultColor)
                        && (fieldActColor.Equals(this.p1.Tile) && fileNextColor.Equals(this.p1.Tile)
                        || (fieldActColor.Equals(this.p2.Tile) && fileNextColor.Equals(this.p2.Tile))))
                    {
                        sum = sum + 1;
                        this.wonButtons.Add(fieldAct);
                        if (sum >= 4)
                        {
                            this.wonButtons.Add(fileNext);
                            return fieldActColor;
                        }
                    }
                    else
                    {
                        sum = 1;
                        this.wonButtons.Clear();
                    }
                }
            }
            return null;
        }

        /// <summary>                       
        /// check win diagonal decreasing     x
        /// (top left to bottom right)          x
        ///                                       x
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private Color? checkWinDiagonalDecreasing(Button[,] fields)
        {
            for (int row = 0; row <= this.numbRows - 4; row++)
            {
                int sum = 1;
                for (int column = 0; column <= this.numbColumns - 4; column++)
                {
                    for (int k = 0; k <= 4; k++)
                    {
                        Button fieldAct = fields[row + k, column + k];
                        Button fileNext = fields[row + k + 1, column + k + 1];
                        Color fieldActColor = fieldAct.BackColor;
                        Color fileNextColor = fileNext.BackColor;
                        if (!fieldActColor.Equals(this.fieldDefaultColor)
                            && (fieldActColor.Equals(this.p1.Tile) && fileNextColor.Equals(this.p1.Tile)
                            || (fieldActColor.Equals(this.p2.Tile) && fileNextColor.Equals(this.p2.Tile))))
                        {
                            sum = sum + 1;
                            this.wonButtons.Add(fieldAct);
                            if (sum >= 4)
                            {
                                this.wonButtons.Add(fileNext);
                                return fieldActColor;
                            }
                        }
                        else
                        {
                            sum = 1;
                            this.wonButtons.Clear();
                            break;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// check win diagonal decreasing       x
        /// (top right to bottom left)        x
        ///                                 x                   
        /// </summary
        /// <param name="fields"></param>
        /// <returns></returns>
        private Color? checkWinDiagonalAscending(Button[,] fields)
        {
            for (int row = this.numbRows - 1; row >= 4; row--)
            {
                int sum = 1;
                for (int column = 0; column <= this.numbColumns - 4; column++)
                {
                    for (int k = 0; k <= 4; k++)
                    {
                        Button fieldAct = fields[row-k, column+k];
                        Button fileNext = fields[row - k - 1, column + k + 1];
                        Color fieldActColor = fieldAct.BackColor;
                        Color fileNextColor = fileNext.BackColor;
                        if (!fieldActColor.Equals(this.fieldDefaultColor)
                            && (fieldActColor.Equals(this.p1.Tile) && fileNextColor.Equals(this.p1.Tile)
                            || (fieldActColor.Equals(this.p2.Tile) && fileNextColor.Equals(this.p2.Tile))))
                        {
                            sum = sum + 1;
                            this.wonButtons.Add(fieldAct);
                            if (sum >= 4)
                            {
                                this.wonButtons.Add(fileNext);
                                return fieldActColor;
                            }
                        }
                        else
                        {
                            sum = 1;
                            this.wonButtons.Clear();
                            break;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// set the winner based on the game won color
        /// </summary>
        /// <param name="winCol"></param>
        private void selectWinner(Color? winCol)
        {
            if (winCol != null)
            {
                if (winCol.Equals(this.p1.Tile))
                {
                    this.p1.WonRounds += 1;
                    this.Winner = this.p1;
                }
                if (winCol.Equals(this.p2.Tile))
                {
                    this.p2.WonRounds += 1;
                    this.Winner = this.p2;
                }
                this.paintWonButtons();
                this.board.EnableColumnButtons(false);
            }
        }

        /// <summary>
        /// mark the won Buttons
        /// </summary>
        private void paintWonButtons()
        {
            if (this.wonButtons.Count != 0)
            {
                Color? paint = null;
                if (this.Winner.Tile.Equals(Color.Red))
                {
                    paint = this.wonColorRed;
                }
                if (this.Winner.Tile.Equals(Color.Blue))
                {
                    paint = this.wonColorBlue;
                }
                foreach (Button btn in this.wonButtons.Cast<Button>().Where(btn => paint != null))
                {
                    btn.BackColor = (Color)paint;
                }
            }
        }

        /// <summary>
        /// switch the active player
        /// </summary>
        private void switchPlayer()
        {
            this.activePlayerColor = (this.activePlayerColor == this.p1.Tile.Value) ? (Color)this.p2.Tile : (Color)this.p1.Tile;
            this.board.SetActivePlayerButtonColor(this.activePlayerColor);
        }

        /// <summary>
        /// inkrement the number of actual moves
        /// </summary>
        private void inkrementActualMoves()
        {
            this.actualMoves++;
            if (this.actualMoves == this.maxMoves)
            {
                this.Winner = new Player(Color.Black, standoff);
            }
        }

        /// <summary>
        /// set the number of columns and rows
        /// </summary>
        private void setColumnsAndRows()
        {
            this.numbRows = this.board.NumbRows;
            this.numbColumns = this.board.NumbColumns;
            this.maxMoves = this.numbColumns * this.numbRows;
        }

        /// <summary>
        /// reset the won rounds
        /// </summary>
        public void ResetWonRounds()
        {
            this.p1.WonRounds = 0;
            this.p2.WonRounds = 0;
        }

        /// <summary>
        /// set the max depth = level of difficult
        /// </summary>
        /// <param name="maxDepth"></param>
        public void SetDifficult(int maxDepth)
        {
            this.ai.MaxDepth = maxDepth;
        }
    }
}
