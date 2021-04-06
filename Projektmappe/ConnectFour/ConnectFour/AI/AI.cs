/**
 * Author:              Marcel Leenings
 * Last Modification:   02/2013
 * 
 * Description:
 * This artificial intelligence uses the apha–beta pruning.
 * It is a optimized version of the minimax algorithm which is a standard method
 * for search the optimal move for games with two opposing players.
 * 
 * More information of the alogorithm eg Wikipedia:
 * http://en.wikipedia.org/wiki/Alpha%E2%80%93beta_pruning and
 * http://en.wikipedia.org/wiki/Minimax#Minimax_algorithm_with_alternate_moves
 * 
 */

using ConnectFour.Players;
using System.Drawing;

namespace ConnectFour.AI
{
    class AI
    {
        /* max value for infinity */
        private const int maxValue = 1000000;

        /* max score */
        private const int maxScore = 100;

        /* 0-5; 5 is hard; how deep to search */
        private int maxDepth = 5;
        public int MaxDepth
        {
            set { this.maxDepth = value; }
        }

        /* required objects */
        private readonly Board board;
        private readonly GameLogic gameLogic;
        private readonly AIBoard aiBoard;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="board"></param>
        /// <param name="gameLogic"></param>
        public AI(Board board, GameLogic gameLogic)
        {
            this.board = board;
            this.gameLogic = gameLogic;
            this.aiBoard = new AIBoard(board, gameLogic);
        }

        /// <summary>
        /// calc and return the best column for the next turn
        /// with the alpha-beta-algorithm
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int CalcAlphaBetaMoveColumn(Player player)
        {
            // Go through all possible moves and get the score

            // possible for P1 but here not used
            if (player.Equals(this.gameLogic.P1))
            {
                //It is player P1's (Human) turn, he will try max the score
                int maxScore = -maxValue;
                int maxScoreMove = 0;
                for (int column = 0; column < this.board.NumbColumns; column++)
                    if (this.aiBoard.CanMove(column))
                    {
                        int row = this.aiBoard.Move(column, this.gameLogic.P1);
                        int score = this.alphabeta(this.gameLogic.P2);

                        if (score >= maxScore)
                        {
                            maxScore = score;
                            maxScoreMove = column;
                        }
                        this.aiBoard.UndoMove(row,column);
                    }
                return maxScoreMove;
            }
            else if (player.Equals(this.gameLogic.P2))
            {
                //It is player P2's (Computer) turn, he will try min the score
                int minScore = maxValue;
                int minScoreMove = 0;
                for (int column = 0; column < this.board.NumbColumns; column++)
                {
                    if (this.aiBoard.CanMove(column))
                    {
                        int row = this.aiBoard.Move(column, this.gameLogic.P2);
                        int score = this.alphabeta(this.gameLogic.P1);

                        if (score < minScore)
                        {
                            minScore = score;
                            minScoreMove = column;
                        }
                        this.aiBoard.UndoMove(row, column);
                    }
                }
                return minScoreMove;
            }
            return 0;
        }

        /// <summary>
        /// boarding method for the alpha-beta-algorithm
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private int alphabeta(Player player)
        {
            return this.alphabeta(player, -maxValue, maxValue, 0);
        }

        /// <summary>
        /// recursive method for the alpha-beta-algorithm
        /// </summary>
        /// <param name="player"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        private int alphabeta(Player player, int alpha, int beta, int depth)
        {
            //Check if there's a current winner
            Color? winColor = this.gameLogic.checkWinnerColor();
            if (this.gameLogic.P1.Tile.Equals(winColor))
            {
                return maxScore;
            }
          if (this.gameLogic.P2.Tile.Equals(winColor))
          {
            return -maxScore;
          }

          if (depth>= this.maxDepth)
            {
                //cannot recurese more, and do not an end to the game
                //Return the score of the current table
                return this.aiBoard.GetScore();
            }

            if (player.Equals(this.gameLogic.P1))
            {
                for (int column = 0; column < this.board.NumbColumns; column++)
                    if (this.aiBoard.CanMove(column))
                    {
                        int row = this.aiBoard.Move(column,this.gameLogic.P1);
                        int score = this.alphabeta(this.gameLogic.P2, alpha, beta, depth+1);
                        this.aiBoard.UndoMove(row, column);
                        if (score > alpha)
                        {
                            alpha = score;
                        }
                        if (alpha >= beta)
                        {
                            return alpha;
                        }
                    }
                return alpha;
            }
            else if (player.Equals(this.gameLogic.P2))
            {
                //It is player P2's (Computer) turn, he will try min the score
                for (int column = 0; column < this.board.NumbColumns; column++)
                    if (this.aiBoard.CanMove(column))
                    {
                        int row = this.Move(column, this.gameLogic.P2);
                        int score = this.alphabeta(this.gameLogic.P1, alpha, beta, depth + 1);
                        this.aiBoard.UndoMove(row, column);
                        if (score < beta)
                        {
                            beta = score;
                        }
                        if (alpha >= beta)
                        {
                            return beta;
                        }
                    }
                return beta;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// move method to make a turn
        /// it is ideal used for a ai turn
        /// </summary>
        /// <param name="column"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public int Move(int column, Player player)
        {
            return this.aiBoard.Move(column, player);
        }
    }
}