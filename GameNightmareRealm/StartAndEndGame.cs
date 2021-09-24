using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GameNightmareRealm
{
    public static class StartAndEndGame
    {
        public static void startGame(bool firstTime)
        {
            if (firstTime == false)
                for (int i = 1; i <= 5; i++)
                {
                    for (int j = 1; j <= 5; j++)
                        Form1.feild[i][j] = new Block(Form1.feild[i][j].blockButton);
                }

            int[] collumnWithThisColor = new int[4];
            int[] colorsOfTheCollumn = new int[6];

            setColorsOnTopLine(collumnWithThisColor, colorsOfTheCollumn);

            setBlocksInFeild(colorsOfTheCollumn);

            ActionsScript.setBlockActivity(false, Form1.activeBlock);
            Form1.labelEndGame.Visible = false;
        }


        public static bool checkEndGame()
        {
            for (int j = 1; j <= 5; j++)
            {
                int colorCollumn = Form1.upperLine[j].imageNumber;
                if (colorCollumn != 0)
                    for (int i = 1; i <= 5; i++)
                        if (Form1.feild[i][j].imageNumber != colorCollumn)
                            return false;
            }
            return true;
        }



        public static void gameOver()
        {
            ActionsScript.clearPreviousHighlightedBlocks();
            ActionsScript.setBlockActivity(false, Form1.activeBlock);
            Form1.labelEndGame.Visible = true;
        }




        private static void setColorsOnTopLine(int[] collumnWithThisColor,int[] colorsOfTheCollumn)
        {
            Random rnd = new Random();
            int collumnNumber = 0;
            int color = 1;
            do
            {
                collumnNumber = rnd.Next(1, 6);
                if (color <= 3 && collumnWithThisColor[1] != collumnNumber &&
                    collumnWithThisColor[2] != collumnNumber && collumnWithThisColor[3] != collumnNumber)
                {
                    collumnWithThisColor[color] = collumnNumber;
                    color += 1;
                }
            }
            while (color <= 3);

            for (int i = 1; i <= 5; i++)
                Form1.upperLine[i].SetVisibility(false);
            for (int i = 1; i <= 3; i++)
            {
                collumnNumber = collumnWithThisColor[i];
                Form1.upperLine[collumnNumber].SetVisibility(true);
                Form1.upperLine[collumnNumber].SetImage(i);

                colorsOfTheCollumn[collumnNumber] = i;
            }
        }



        private static void setBlocksInFeild(int[] colorsOfTheCollumn)
        {
            Random rnd = new Random();
            int[] colors = { 0, 5, 5, 5};
            int[] unmovedBlocks = new int[] { 3, 3 };
            
            for (int j = 1; j <= 5; j++)
            {
                bool colored = false;
                if (colorsOfTheCollumn[j] > 0) colored = true;

                if (colored == true)
                    for (int i = 1; i <= 5; i++)
                    {
                        int colorInt = rnd.Next(1, 4);//colorsOfTheCollumn[j];//
                        while (colors[colorInt] == 0)
                            colorInt = rnd.Next(1, 4);

                        Form1.feild[i][j].SetImage(colorInt);
                        colors[colorInt] -= 1;
                    }
                int line = 0; bool firstNearClearBlockPassed = false;
                if (unmovedBlocks[0] == 0)  line = 1;
                if (colored == false)
                    for (int i = 1; i <= 5; i++)
                    {
                        if (line == 1 && colorsOfTheCollumn[j - 1] > 0)
                            firstNearClearBlockPassed = true;

                        if (6 - i == unmovedBlocks[line] || 
                            (((firstNearClearBlockPassed == false && line == 1) || rnd.Next(1, 3) == 1) && unmovedBlocks[line] > 0))
                        {
                            if (line == 1 && Form1.feild[i][j - 1].imageNumber == 0 && firstNearClearBlockPassed == false)
                                firstNearClearBlockPassed = true;
                            else if (line == 0 || ((firstNearClearBlockPassed == true || Form1.feild[i][j - 1].imageNumber != 0) && line == 1))
                            {
                                Form1.feild[i][j].SetImage(4);
                                unmovedBlocks[line] -= 1;
                            }
                        }
                    }
            }
        }
    }
}
