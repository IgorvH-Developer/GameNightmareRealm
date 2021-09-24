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
    public static class ActionsScript
    {
        public static void OnClickBlock(object sender)
        {
            int[] currentBlockPosition = new int[2];
            if (sender is Button)
                currentBlockPosition = Block.DetermineBlockPosition(sender as Button);
            else
            {
                setBlockActivity(false, Form1.activeBlock);// clearActiveBlock();
                clearPreviousHighlightedBlocks();
                
            }

            int currM = currentBlockPosition[0], currN = currentBlockPosition[1];
            if (currM != 0 && Form1.feild[currM][currN].imageNumber <= 3)
            {
                if (Form1.feild[currM][currN].imageNumber >= 1 && SecondClickOnSameBlock(currentBlockPosition) == false)
                {
                    clearPreviousHighlightedBlocks();
                    highlightBlocksAvailableToMove(currentBlockPosition, false, new int[] { 0, 0 });
                }

                if (FirstClickOnBlocks())
                    setBlockActivity(true, currentBlockPosition);
                else if (SecondClickOnSameBlock(currentBlockPosition) == false)
                {
                    if (Form1.feild[currM][currN].availablePlaceToMove &&
                        Form1.feild[Form1.activeBlock[0]][Form1.activeBlock[1]].imageNumber != (int)Block.blockImageNumber.empty)
                        ChangePositionsOfBlocks(currentBlockPosition);

                    int pm = Form1.activeBlock[0], pn = Form1.activeBlock[1];
                    setBlockActivity(false, Form1.activeBlock);
                    setBlockActivity(true, currentBlockPosition);

                    clearPreviousHighlightedBlocks();
                    int m = currentBlockPosition[0], n = currentBlockPosition[1];
                    if (Form1.feild[currM][currN].imageNumber >= 1)
                        highlightBlocksAvailableToMove(currentBlockPosition, false, new int[] { 0, 0 });
                    
                    if (StartAndEndGame.checkEndGame() == true)
                        StartAndEndGame.gameOver();
                }
                else
                {
                    setBlockActivity(false, Form1.activeBlock);
                    clearPreviousHighlightedBlocks();
                }

            }
        }




        public static void setBlockActivity(bool active, int[] blockPosition)
        {
            if (blockPosition[0] != 0 && blockPosition[1] != 0)
                Form1.feild[blockPosition[0]][blockPosition[1]].setActivity(active);
            if (active == false)
                Form1.activeBlock = new int[2];
            else
                Form1.activeBlock = new int[] { blockPosition[0], blockPosition[1] };
        }


        private static void ChangePositionsOfBlocks(int[] freeBlockPosition)
        {
            int freeM = freeBlockPosition[0], freeN = freeBlockPosition[1];
            int activeM = Form1.activeBlock[0], activeN = Form1.activeBlock[1];

            //Button buttonOfAnimation = Form1.feild[activeM][activeN].blockButton;

            Form1.feild[freeM][freeN].SetImage(Form1.feild[activeM][activeN].imageNumber);
            Form1.feild[activeM][activeN].SetImage(0);

        }



        private static void highlightBlocksAvailableToMove(int[] currBlockPos, bool highlightThisBlock, int[] prevBlockPos)
        {
            int m = currBlockPos[0], n = currBlockPos[1];
            int prevM = prevBlockPos[0], prevN = prevBlockPos[1];

            if (highlightThisBlock)
                Form1.feild[m][n].setAvailabilityToPlaceBlock(true);

            if (m != 1) if (Form1.feild[m - 1][n].imageNumber == 0 && Form1.feild[m - 1][n].availablePlaceToMove == false) highlightBlocksAvailableToMove(new int[] { m - 1, n}, true, new int[] { m,n});
            if (m != 5) if (Form1.feild[m + 1][n].imageNumber == 0 && Form1.feild[m + 1][n].availablePlaceToMove == false)  highlightBlocksAvailableToMove(new int[] { m + 1, n }, true, new int[] { m,n});
            if (n != 1) if (Form1.feild[m][n - 1].imageNumber == 0 && Form1.feild[m][n - 1].availablePlaceToMove == false) highlightBlocksAvailableToMove(new int[] { m, n - 1}, true, new int[] { m,n});
            if (n != 5) if (Form1.feild[m][n + 1].imageNumber == 0 && Form1.feild[m][n + 1].availablePlaceToMove == false) highlightBlocksAvailableToMove(new int[] { m, n + 1 }, true,new  int[] { m,n});
        }



        public static void clearPreviousHighlightedBlocks()
        {
            for (int i = 1; i <= 5; i++)
                for (int j = 1; j <= 5; j++)
                    if (Form1.feild[i][j].availablePlaceToMove == true)
                        Form1.feild[i][j].setAvailabilityToPlaceBlock(false);
                
        }



        private static bool FirstClickOnBlocks()
        {
            if (Form1.activeBlock[0] == 0 && Form1.activeBlock[1] == 0)
                return true;
            else
                return false;
        }


        private static bool SecondClickOnSameBlock(int[] currentBlockPosition)
        {
            if (currentBlockPosition[0] == Form1.activeBlock[0] && currentBlockPosition[1] == Form1.activeBlock[1])
                return true;
            else
                return false;
        }

    }
}
