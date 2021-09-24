using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameNightmareRealm
{
    public partial class Form1 : Form
    {
        public static Block[][] feild;
        public static Block [] upperLine;
        public static int[] activeBlock = new int[2];
        public static Label labelEndGame;
        public static Timer gameTime;
        public static int stepsCount = 0;
        public static Image[] blocksImage = new Bitmap[5];
        public static Image[] activeBlocksImage = new Bitmap[4]; 
        public Form1()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(0, 255, 255, 255);
            labelEndGame = label1;

            blocksImage[0] = Properties.Resources.Блок0; blocksImage[1] = Properties.Resources.Блок1;
            blocksImage[2] = Properties.Resources.Блок2; blocksImage[3] = Properties.Resources.Блок3;
            blocksImage[4] = Properties.Resources.Блок4;
            activeBlocksImage[0] = Properties.Resources.Блок0Выделенный; activeBlocksImage[1] = Properties.Resources.Блок1Выделенный; 
            activeBlocksImage[2] = Properties.Resources.Блок2Выделенный; activeBlocksImage[3] = Properties.Resources.Блок3Выделенный;

            feild = new Block[6][];
            for (int i = 1; i <= 5; i++)
                feild[i] = new Block[6];
            upperLine = new Block[6];

            feild[1][1] = new Block(button1); feild[1][2] = new Block(button2); feild[1][3] = new Block(button3); feild[1][4] = new Block(button4); feild[1][5] = new Block(button5);
            feild[2][1] = new Block(button6); feild[2][2] = new Block(button7); feild[2][3] = new Block(button8); feild[2][4] = new Block(button9); feild[2][5] = new Block(button10);
            feild[3][1] = new Block(button11); feild[3][2] = new Block(button12); feild[3][3] = new Block(button13); feild[3][4] = new Block(button14); feild[3][5] = new Block(button15);
            feild[4][1] = new Block(button16); feild[4][2] = new Block(button17); feild[4][3] = new Block(button18); feild[4][4] = new Block(button19); feild[4][5] = new Block(button20);
            feild[5][1] = new Block(button21); feild[5][2] = new Block(button22); feild[5][3] = new Block(button23); feild[5][4] = new Block(button24); feild[5][5] = new Block(button25);

            upperLine[1] = new Block(button26); upperLine[2] = new Block(button27); upperLine[3] = new Block(button28); upperLine[4] = new Block(button29); upperLine[5] = new Block(button30);

            StartAndEndGame.startGame(true);
        }



        public static void setStepsCount(int count)
        {
            stepsCount = count;
            
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (labelEndGame.Visible == false)
                ActionsScript.OnClickBlock(sender);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            StartAndEndGame.startGame(false);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
