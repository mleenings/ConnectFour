/**
 * Author:              Marcel Leenings
 * Version:             1.0
 * Last Modification:   02/2013
 * 
 * Description:
 * The game board logic of connect four
 * 
 */

using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using VierGewinnt;

namespace ConnectFour
{
    class Board
    {
        /* default values and constants */
        private const int distField2FormX = 12; // distance from the left side of the form
        private int distField2FormY; // distance from the upper side of the form
        private const int fieldSize = 40;
        private const int fieldDistance = 2;    // distance of between two fields
        private const int distFromBtnNewGame = 30;  // buttonNewGame is the anchor point from there the fields location are calc
        private const int colBtnHeight = 30;
        private const int slideField = fieldSize + fieldDistance;

        /* default color of the fields*/
        private readonly Color fieldDefaultColor = Color.WhiteSmoke;
        public Color FieldDefaultColor
        {
            get { return this.fieldDefaultColor; }
        }

        /* number of Rows and Columns */
        private int numbRows;
        public int NumbRows
        {
            get { return this.numbRows; }
        }
        private int numbColumns;
        public int NumbColumns
        {
            get { return this.numbColumns; }
        }

        /* min Height and Width of the Connect4Form */
        private readonly int minHeight;
        private readonly int minWidth;

        /* the fields as a array of buttons */
        private Button[,] fields;
        public Button[,] Fields
        {
            set { this.fields = value; }
            get { return this.fields; }
        }

        /* all column buttons saved in a array */
        private Button[] columnButtons;

        /* requied object */
        private Connect4Form connect4 = null;


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="connectFour"></param>
        public Board(Connect4Form connectFour)
        {
            this.connect4 = connectFour;
            this.minHeight = this.connect4.Height;
            this.minWidth = this.connect4.Width;
        }


        /// <summary>
        /// fill the board with fields and column buttons
        /// </summary>
        /// <param name="buttonNewGame"></param>
        /// <param name="numbRows"></param>
        /// <param name="numbColumns"></param>
        public void FillBoardWithFields(Button buttonNewGame, int numbRows, int numbColumns)
        {
            this.numbRows = numbRows;
            this.numbColumns = numbColumns;
            this.removeOldFields();
            this.Fields = new Button[numbRows, numbColumns];

            // calc the start location of the fields, buttonNewGame is the anchor
            this.distField2FormY = buttonNewGame.Location.Y + distFromBtnNewGame;
            int calcHeight = (numbRows + 1) * slideField + this.minHeight;
            int calcWidth = numbColumns * slideField + colBtnHeight;
            this.connect4.Height = calcHeight< this.minHeight? this.minHeight:calcHeight;
            this.connect4.Width = calcWidth < this.minWidth ? this.minWidth:calcWidth;

            int x = distField2FormX;
            int y = this.distField2FormY;
            for (int i = 0; i < this.Fields.GetLength(0); i++)
            {
                for (int j = 0; j < this.Fields.GetLength(1); j++)
                {
                    this.Fields[i, j] = this.generateNewField(i, j, x, y);
                    x += slideField;
                }
                x = distField2FormX;
                y += slideField;
            }

            this.fillColumnButtons(numbColumns);
        }

        /// <summary>
        /// fill the field with the column buttons and save in an array
        /// </summary>
        /// <param name="numbRows"></param>
        private void fillColumnButtons(int numbRows)
        {
            int x = distField2FormX;
            int y = this.distField2FormY + this.fields.GetLength(0) * (slideField)+fieldDistance;

            this.columnButtons= new Button[numbRows];
            for (int i = 0; i < this.columnButtons.Length; i++)
            {
                this.columnButtons[i] = this.generateColumnButton(i+1, x, y);
                x += slideField;
            }
        }

        /// <summary>
        /// generate and return a column button
        /// </summary>
        /// <param name="i"></param> the number of the column
        /// <param name="x"></param> x location of the button
        /// <param name="y"></param> y location of the button
        /// <returns></returns>
        private Button generateColumnButton(int i, int x, int y)
        {
            Button btn = new Button
            {
                Size = new Size(fieldSize, colBtnHeight),
                Location = new Point(x, y),
                Name = "buttonColumn" + i,
                Text = i.ToString(),
                Visible = true,
                Enabled = true
            };
            btn.Click += this.connect4.ColumnButtonClickEvent;
            this.connect4.Controls.Add(btn);
            return btn;
        }

        /// <summary>
        /// generate and return a button for the field
        /// </summary>
        /// <param name="i"></param> row name
        /// <param name="j"></param> column name
        /// <param name="x"></param> x location
        /// <param name="y"></param> y location
        /// <returns></returns>
        private Button generateNewField(int i, int j, int x, int y)
        {
            Button btn = new Button
            {
                BackColor = this.fieldDefaultColor,
                Size = new Size(fieldSize, fieldSize),
                Location = new Point(x, y),
                Name = "field" + i + j,
                Visible = true,
                Enabled = false
            };
            this.connect4.Controls.Add(btn);
            return btn;
        }

        /// <summary>
        /// remove the old fields from the form for a new size or similar
        /// </summary>
        private void removeOldFields()
        {
            if (this.Fields != null)
            {
                for (int i = 0; i < this.Fields.GetLength(0); i++)
                {
                    for (int j = 0; j < this.Fields.GetLength(1); j++)
                    {
                        this.connect4.Controls.Remove(this.Fields[i, j]);
                    }
                }
            }
            if (this.columnButtons != null)
            {
                foreach (Button btn in this.columnButtons)
                {
                    this.connect4.Controls.Remove(btn);
                }
            }
        }

        /// <summary>
        /// enable or disable all column buttons
        /// </summary>
        /// <param name="enable"></param>
        public void EnableColumnButtons(bool enable)
        {
            foreach(Button b in this.columnButtons)
            {
                b.Enabled = enable;
            }
        }

        /// <summary>
        /// reset all field colors to the default field color
        /// </summary>
        public void ResetFieldsColor()
        {
            for (int i = 0; i < this.fields.GetLength(0); i++)
            {
                for (int j = 0; j < this.fields.GetLength(1); j++)
                {
                    this.fields[i, j].BackColor = this.fieldDefaultColor;
                }
            }
        }

        /// <summary>
        /// change the active player button color to the active player
        /// </summary>
        /// <param name="activePlayerColor"></param>
        public void SetActivePlayerButtonColor(Color activePlayerColor)
        {
            Button btn = (Button)this.connect4.Controls.Find("buttonActivePlayer", true).FirstOrDefault();
            if (btn != null)
            {
                btn.BackColor = activePlayerColor;
            }
        }
    }
}
