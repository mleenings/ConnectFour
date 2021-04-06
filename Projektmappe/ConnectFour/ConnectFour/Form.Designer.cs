namespace VierGewinnt
{
    partial class Connect4Form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connect4Form));
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelLevOfDiff = new System.Windows.Forms.Label();
            this.radioButtonPvsPC = new System.Windows.Forms.RadioButton();
            this.radioButtonP1vsP2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxColumn = new System.Windows.Forms.TextBox();
            this.textBoxRow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonActivePlayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelVS = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelWinner = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(12, 100);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelLevOfDiff);
            this.groupBox1.Controls.Add(this.radioButtonPvsPC);
            this.groupBox1.Controls.Add(this.radioButtonP1vsP2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxColumn);
            this.groupBox1.Controls.Add(this.textBoxRow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonActivePlayer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 82);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Info";
            // 
            // labelLevOfDiff
            // 
            this.labelLevOfDiff.AutoSize = true;
            this.labelLevOfDiff.Location = new System.Drawing.Point(272, 51);
            this.labelLevOfDiff.Name = "labelLevOfDiff";
            this.labelLevOfDiff.Size = new System.Drawing.Size(10, 13);
            this.labelLevOfDiff.TabIndex = 7;
            this.labelLevOfDiff.Text = "!";
            this.labelLevOfDiff.Visible = false;
            this.labelLevOfDiff.Click += new System.EventHandler(this.labelLevOfDiff_Click);
            // 
            // radioButtonPvsPC
            // 
            this.radioButtonPvsPC.AutoSize = true;
            this.radioButtonPvsPC.Location = new System.Drawing.Point(181, 49);
            this.radioButtonPvsPC.Name = "radioButtonPvsPC";
            this.radioButtonPvsPC.Size = new System.Drawing.Size(88, 17);
            this.radioButtonPvsPC.TabIndex = 6;
            this.radioButtonPvsPC.Text = "Player vs. PC";
            this.radioButtonPvsPC.UseVisualStyleBackColor = true;
            this.radioButtonPvsPC.CheckedChanged += new System.EventHandler(this.radioButtonPvsPC_CheckedChanged);
            // 
            // radioButtonP1vsP2
            // 
            this.radioButtonP1vsP2.AutoSize = true;
            this.radioButtonP1vsP2.Checked = true;
            this.radioButtonP1vsP2.Location = new System.Drawing.Point(55, 49);
            this.radioButtonP1vsP2.Name = "radioButtonP1vsP2";
            this.radioButtonP1vsP2.Size = new System.Drawing.Size(115, 17);
            this.radioButtonP1vsP2.TabIndex = 6;
            this.radioButtonP1vsP2.TabStop = true;
            this.radioButtonP1vsP2.Text = "Player1 vs. Player2";
            this.radioButtonP1vsP2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Modus:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "x";
            // 
            // textBoxColumn
            // 
            this.textBoxColumn.Location = new System.Drawing.Point(252, 17);
            this.textBoxColumn.Name = "textBoxColumn";
            this.textBoxColumn.Size = new System.Drawing.Size(24, 20);
            this.textBoxColumn.TabIndex = 3;
            this.textBoxColumn.Text = "7";
            // 
            // textBoxRow
            // 
            this.textBoxRow.Location = new System.Drawing.Point(210, 17);
            this.textBoxRow.MaxLength = 2;
            this.textBoxRow.Name = "textBoxRow";
            this.textBoxRow.Size = new System.Drawing.Size(24, 20);
            this.textBoxRow.TabIndex = 3;
            this.textBoxRow.Text = "6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Board Size:";
            // 
            // buttonActivePlayer
            // 
            this.buttonActivePlayer.Enabled = false;
            this.buttonActivePlayer.Location = new System.Drawing.Point(82, 15);
            this.buttonActivePlayer.Name = "buttonActivePlayer";
            this.buttonActivePlayer.Size = new System.Drawing.Size(44, 23);
            this.buttonActivePlayer.TabIndex = 1;
            this.buttonActivePlayer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Player:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(140, 105);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(42, 13);
            this.labelPlayer1.TabIndex = 7;
            this.labelPlayer1.Text = "Player1";
            this.labelPlayer1.Visible = false;
            this.labelPlayer1.DoubleClick += new System.EventHandler(this.labelPlayer1_DoubleClick);
            // 
            // labelVS
            // 
            this.labelVS.AutoSize = true;
            this.labelVS.Location = new System.Drawing.Point(178, 105);
            this.labelVS.Name = "labelVS";
            this.labelVS.Size = new System.Drawing.Size(21, 13);
            this.labelVS.TabIndex = 8;
            this.labelVS.Text = "vs.";
            this.labelVS.Visible = false;
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(197, 105);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(42, 13);
            this.labelPlayer2.TabIndex = 9;
            this.labelPlayer2.Text = "Player2";
            this.labelPlayer2.Visible = false;
            this.labelPlayer2.DoubleClick += new System.EventHandler(this.labelPlayer2_DoubleClick);
            // 
            // labelWinner
            // 
            this.labelWinner.AutoSize = true;
            this.labelWinner.Location = new System.Drawing.Point(160, 104);
            this.labelWinner.Name = "labelWinner";
            this.labelWinner.Size = new System.Drawing.Size(41, 13);
            this.labelWinner.TabIndex = 10;
            this.labelWinner.Text = "Winner";
            this.labelWinner.Visible = false;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(261, 105);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(22, 13);
            this.labelResult.TabIndex = 11;
            this.labelResult.Text = "0:0";
            this.labelResult.Visible = false;
            this.labelResult.DoubleClick += new System.EventHandler(this.labelResult_DoubleClick);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(302, 0);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(13, 13);
            this.labelHelp.TabIndex = 12;
            this.labelHelp.Text = "?";
            this.labelHelp.Click += new System.EventHandler(this.labelHelp_Click);
            // 
            // Connect4Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(317, 142);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelWinner);
            this.Controls.Add(this.labelVS);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Connect4Form";
            this.Text = "Connect Four";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonActivePlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxColumn;
        private System.Windows.Forms.TextBox textBoxRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonPvsPC;
        private System.Windows.Forms.RadioButton radioButtonP1vsP2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelVS;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelWinner;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Label labelLevOfDiff;
    }
}

