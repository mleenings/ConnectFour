/**
 * 
 * Author:              Marcel Leenings
 * Version:             1.0
 * Last Modification:   02/2013
 * 
 * Description:
 * The form/ GUI logic of connect four
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectFour;
using ConnectFour.Players;
using Microsoft.VisualBasic;

namespace VierGewinnt
{
    public partial class Connect4Form : Form
    {
        /* objects for the game */
        private Board board = null;
        private GameLogic gameLogic = null;

        /* array for all column buttons */
        private Button[] columnButtons = new Button[7];

        /* number of rows and colums */
        private int numbRows = -1;
        private int numbColumns = -1;

        /* center between button newGame and label results for the player labels */
        int centerForLabel;

        /* min and max sizes for the field */
        private const int minRows = 4;
        private const int minColumns = 4;
        private const int maxRows = 20;
        private const int maxColumns = 20;

        /* constant strings */
        private const string player1 = "Player1";
        private const string player2 = "Player2";
        private const string computer = "Computer";
        private const string inputBoxTextNewName = "Enter your Name:";
        private const string inputBoxTitleNewName = "New Name";
        private const string new_line = "\n";
        private const string inputBoxTextLevDiff ="Please choose the level of difficulty.\n0 is easy and 5 is hard.";
        private const string inputBoxTitleLevDiff ="Level Of Difficulty";
        private const string inputBoxDefTextLevDiff ="5";

        /* actual mode */
        private bool isP1VsP2 = true;
        int levOfDiff = 5;


        /// <summary>
        /// default constructor
        /// </summary>
        public Connect4Form()
        {
            InitializeComponent();
            resizeLabelPlayer();
            board = new Board(this);
            gameLogic = new GameLogic(board);
        }


        /// <summary>
        /// click event to create a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            string strNumbRows = textBoxRow.Text;
            string strNumbColumns = textBoxColumn.Text;
            if (!string.IsNullOrEmpty(strNumbRows) || !string.IsNullOrEmpty(strNumbColumns))
            {    
                try
                {
                    numbRows = Convert.ToInt32(strNumbRows);
                    numbColumns = Convert.ToInt32(strNumbColumns);
                }
                catch (Exception)
                {
                    // ignore
                }
                if (numbRows >= minRows && numbColumns >= minColumns && numbRows <= maxRows && numbColumns <= maxColumns)
                {
                    initNewGame((Button)sender);
                    if (radioButtonP1vsP2.Checked)
                    {
                        initP1VsP2();
                        isP1VsP2 = true;
                    }
                    else
                    {
                        initP1VsPC();
                        isP1VsP2 = false;
                    }
                    buttonActivePlayer.BackColor = gameLogic.ActivePlayerColor;
                }
            }
        }

        /// <summary>
        /// click event to make a turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ColumnButtonClickEvent(object sender, EventArgs e)
        {
            board.EnableColumnButtons(false);
            Button columnButton = (Button)sender;
            gameLogic.ColumnButtonClickEvent(columnButton);
            this.Update();
            Player winner = gameLogic.Winner;
            if (winner == null)
            {
                if (!isP1VsP2)
                {
                    gameLogic.MoveAI();
                }
            }
            board.EnableColumnButtons(true);
            winner = gameLogic.Winner;
            if (winner != null)
            {
                initWinnerLabel(winner);
                board.EnableColumnButtons(false);
            }
        }

        /// <summary>
        /// double click event to reset the results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelResult_DoubleClick(object sender, EventArgs e)
        {
            gameLogic.ResetWonRounds();
            initLabelResult();
        }

        /// <summary>
        /// double click event to change the name of player1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelPlayer1_DoubleClick(object sender, EventArgs e)
        {
            string newName = getNewNameWithInputBox(labelPlayer1.Text);
            if (!string.IsNullOrEmpty(newName))
            {
                labelPlayer1.Text = newName;
                gameLogic.P1.Name = newName;
                resizeLabelPlayer();
            }
        }

        /// <summary>
        /// double click event to change the name of player2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelPlayer2_DoubleClick(object sender, EventArgs e)
        {
            string newName = getNewNameWithInputBox(labelPlayer2.Text);
            if (!string.IsNullOrEmpty(newName))
            {
                labelPlayer2.Text = newName;
                gameLogic.P2.Name = newName;
                resizeLabelPlayer();
            }
        }

        /// <summary>
        /// change the level of difficult
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelLevOfDiff_Click(object sender, EventArgs e)
        {
            int iDiff = -1;
            string sDiff = iDiff.ToString();
            while (iDiff < 0 || iDiff > 5)
            {
                sDiff = Microsoft.VisualBasic.Interaction.InputBox(inputBoxTextLevDiff, inputBoxTitleLevDiff, inputBoxDefTextLevDiff);
                if (string.IsNullOrEmpty(sDiff))
                {
                    iDiff = 5;
                    break;
                }
                try
                {
                    iDiff = Convert.ToInt32(sDiff);
                }
                catch (Exception)
                {
                    // ignore
                }
            }
            levOfDiff = iDiff;
        }

        /// <summary>
        /// change the visible of the label to change the level of difficult
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonPvsPC_CheckedChanged(object sender, EventArgs e)
        {
            bool vis = labelLevOfDiff.Visible;
            labelLevOfDiff.Visible = (vis == true) ? false : true;
        }

        /// <summary>
        /// click event to show the help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelHelp_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("Change Names:").Append(new_line);
            msg.Append("With a double click of the name you can change it.").Append(new_line);
            msg.Append("When you change the game mode the names will be reset.").Append(new_line);
            msg.Append(new_line);
            msg.Append("Clear Results:").Append(new_line);
            msg.Append("With a double of the results you can clear it.").Append(new_line);
            msg.Append(new_line);
            msg.Append("Set Level Of Difficult:").Append(new_line);
            msg.Append("With a click of the exclamation point right of the game mode.");
            MessageBox.Show(msg.ToString(), "Game Information",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// initialise all things for a new game
        /// </summary>
        /// <param name="buttonNewGame"></param>
        private void initNewGame(Button buttonNewGame)
        {
            board.FillBoardWithFields(buttonNewGame, numbRows, numbColumns);
            gameLogic.SetDifficult(levOfDiff);
            gameLogic.ActivePlayerColor = Color.Red;
            gameLogic.ActualMoves = 0;
            gameLogic.Winner = null;
            initLabelResult();
            initCenterFormLabel();
        }

        /// <summary>
        /// initialise the right label with right names when are the mode P1 vs P2
        /// </summary>
        private void initP1VsP2()
        {
            // if the radio button change use the normal text
            if (isP1VsP2 == false)
            {
                initLabelPlayer2(player2);
                labelPlayer1.Text = player1;
                gameLogic.P1.Name = player1;
                gameLogic.P2.Name = player2;
            }
            // if the radio button equal use the old text
            else
            {
                string namePlayer2 = labelPlayer2.Text;
                string namePlayer1 = labelPlayer1.Text;
                initLabelPlayer2(namePlayer2);
                gameLogic.P1.Name = namePlayer1;
                gameLogic.P2.Name = namePlayer2;
            }
            resizeLabelPlayer();
        }

        /// <summary>
        /// initialise the right label with right names when are the mode P1 vs PC
        /// </summary>
        private void initP1VsPC()
        {
            // if the radio button change use the normal text
            if (isP1VsP2 == true)
            {
                labelPlayer1.Text = player1;
                initLabelPlayer2(computer);
                gameLogic.P2.Name = computer;
            }
            // if the radio button equal use the old text
            else
            {
                string nameP2 = labelPlayer2.Text;
                initLabelPlayer2(nameP2);
                gameLogic.P2.Name = nameP2;
            }
            resizeLabelPlayer();
        }

        /// <summary>
        /// resize the label to the center
        /// </summary>
        private void resizeLabelPlayer()
        {
            labelVS.Location = new Point(centerForLabel, labelVS.Location.Y);
            labelPlayer1.Location = new Point(labelVS.Location.X - labelPlayer1.Size.Width, labelVS.Location.Y);
            labelPlayer2.Location = new Point(labelVS.Location.X + labelVS.Size.Width, labelVS.Location.Y);
        }

        /// <summary>
        /// calc the center for the labels: labelWinner, labelPlayer1, labelPlayer2
        /// </summary>
        private void initCenterFormLabel()
        {
            centerForLabel = (labelResult.Location.X - (buttonNewGame.Location.X + buttonNewGame.Size.Width));
        }

        /// <summary>
        /// initialise the label for results
        /// </summary>
        private void initLabelResult()
        {
            labelResult.Text = string.Format("{0}:{1}", gameLogic.P1.WonRounds, gameLogic.P2.WonRounds);
            labelResult.Visible = true;
        }

        /// <summary>
        /// initialise the label for Winner
        /// </summary>
        /// <param name="winner"></param>
        private void initWinnerLabel(Player winner)
        {
            string suffix = "";
            if (!winner.Tile.Equals(Color.Black))
            {
                suffix = " wins!";
            }
            labelPlayer1.Visible = false;
            labelPlayer2.Visible = false;
            labelVS.Visible = false;
            labelResult.Visible = false;
            labelWinner.Text = winner.Name + suffix;
            labelWinner.ForeColor = (Color)winner.Tile;
            labelWinner.Visible = true;
            labelWinner.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            labelWinner.Location = new Point(centerForLabel, labelWinner.Location.Y);
        }

        /// <summary>
        /// initialise the label for Player2
        /// </summary>
        /// <param name="playerName"></param>
        private void initLabelPlayer2(string playerName) {
            labelPlayer1.ForeColor = Color.Red;
            labelPlayer1.Visible = true;
            labelVS.Visible = true;
            labelPlayer2.Text = playerName;
            labelPlayer2.ForeColor = Color.Blue;
            labelPlayer2.Visible = true;
            labelWinner.Visible = false;
        }

        /// <summary>
        /// Create an inputbox and returns the entered name.
        /// Max. length of the name: 10
        /// </summary>
        /// <returns></returns>
        private string getNewNameWithInputBox(string oldPlayer)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(inputBoxTextNewName, inputBoxTitleNewName, oldPlayer);
            return name.Substring(0,name.Length>=10?10:name.Length);
        }
    }
}
