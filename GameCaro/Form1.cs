using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();
            ChessBoard = new ChessBoardManager(pnlChessBoard, txbPlayerName, pctbMark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            loadGame();
        }
        void loadGame()
        {
            prcbCoolDown.Step = Cons.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;

            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;
         
            NewGame();
        }
        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            if (ChessBoard.CurrentPlayer== 0)
            {
                MessageBox.Show("Chúc mừng " + ChessBoard.Player[1].Name + " đã chiến thắng " + ChessBoard.Player[ChessBoard.CurrentPlayer].Name + " !!");
            }
            else if (ChessBoard.CurrentPlayer == 1)
            {
                MessageBox.Show("Chúc mừng " + ChessBoard.Player[0].Name + " đã chiến thắng " + ChessBoard.Player[ChessBoard.CurrentPlayer].Name + " !!");
            }
        }

        void NewGame()
        {
            prcbCoolDown.Value = 0;
            tmCoolDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.DrawChessBoard();
        }
        void Quit()
        {
              Application.Exit();
        }
        void Undo()
        {
            ChessBoard.Undo();
        }

        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();
            prcbCoolDown.Value = 0;
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pctbAvatar_Click(object sender, EventArgs e)
        {

        }

        private void pnlChessBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txbPlayerName_TextChanged(object sender, EventArgs e)
        {

        }
        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();

            if(prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
              
                EndGame();
               
            }    
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }
        public void setCoolDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inputForm = new Form();
            var inputTextBox = new TextBox();
            var confirmButton = new Button();

            inputForm.Text = "Set Cool Down Time";
            inputTextBox.Location = new Point(10, 10);
            inputTextBox.Text = Cons.COOL_DOWN_TIME.ToString();
            confirmButton.Location = new Point(10, 40);
            confirmButton.Text = "OK";
            confirmButton.DialogResult = DialogResult.OK;
            inputForm.Controls.Add(inputTextBox);
            inputForm.Controls.Add(confirmButton);
            inputForm.AcceptButton = confirmButton;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                int coolDownTime;
                if (int.TryParse(inputTextBox.Text, out coolDownTime))
                {
                    // Set the cool down time
                    Cons.COOL_DOWN_TIME = coolDownTime;
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid integer value.");
                }
            }
            loadGame();
        }
        public void setNumberInALineToWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inputForm = new Form();
            var inputTextBox = new TextBox();
            var confirmButton = new Button();

            inputForm.Text = "Set Number in a line to win";
            inputTextBox.Location = new Point(10, 10);
            inputTextBox.Text = Cons.NUMBER_IN_LINE.ToString();
            confirmButton.Location = new Point(10, 40);
            confirmButton.Text = "OK";
            confirmButton.DialogResult = DialogResult.OK;
            inputForm.Controls.Add((inputTextBox));
            inputForm.Controls.Add(confirmButton);
            inputForm.AcceptButton = confirmButton;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                int numberInLine;
                if (int.TryParse(inputTextBox.Text, out numberInLine) && numberInLine >= 3)
                {
                    Cons.NUMBER_IN_LINE = numberInLine;
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid integer value.");
                }
                label1.Text = Cons.NUMBER_IN_LINE + " in a line to win";
            }
            loadGame();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có thể lựa chọn 1 trong 2 chế độ chơi:\n\n- Player vs Player\n\n- Player vs COM\n\nSau khi nhập đầy đủ tên người chơi và nhấn nút OK.\n\nBạn sẽ được quay lại màn hình chính.");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Caro Chess @2023 \nNgô Thành Đạt \nNguyễn Gia Khánh \nLê Minh Duy Khang");
        }
    }
}
