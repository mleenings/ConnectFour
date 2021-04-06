using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VierGewinnt
{
    public partial class Form1 : Form
    {

        // board as array
        private Button[,] board = new Button[7,7];

        private Color defCol = Color.Gray;
        private const int defBtnSize = 40;
        private const int BtnDist = 7;
        private Color P1Col = Color.Blue;
        private Color P2Col = Color.Red;


        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    fillBoardWithButtons();
        //}

        private void fillBoardWithButtons()
        {
            int x = 12;
            int y = 124;
            int slideButton = defBtnSize + BtnDist;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = generateNewButton(i,j,x,y);
                    x += slideButton;
                }
                y += slideButton;
            }
        }

        private Button generateNewButton(int i, int j, int x, int y)
        {
            Button btn = new Button();
            btn.BackColor = defCol;
            btn.Size = new Size(defBtnSize, defBtnSize);
            btn.Location = new Point(x, y);
            btn.Name = "button" + i + j;
            btn.Visible = true;
            //btn.Click += new System.EventHandler(this.Button_Click);
            this.Controls.Add(btn);
            return btn;
        }

        private void resetBoardColor()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].BackColor = defCol;
                }
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            fillBoardWithButtons();
            //resetBoardColor();
        }

        private void labelGewonnen_Click(object sender, EventArgs e)
        {

        }

        public EventHandler Button_Click { get; set; }
    }
}
