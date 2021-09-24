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
    

    public class Block
    {
        public enum blockImageNumber : int
        {
            empty = 0,      // Color.FromArgb(255,224,224,224)
            block1 = 1,
            block2 = 2,
            block3 = 3,
            unmovedBlock = 4
        }
        public readonly Button blockButton;
        public int imageNumber;
        public bool visible;
        public bool active, availablePlaceToMove;

        public Block(Button blockButton)
        {
            this.blockButton = blockButton;
            this.SetVisibility(true);
            this.SetImage(0);
            this.active = false;
            this.availablePlaceToMove = false;
        }


        public void setActivity(bool active)
        {
            this.active = active;
            if (imageNumber >= 1 && imageNumber <= 3)
                if (active == false)
                    blockButton.Image = Form1.blocksImage[imageNumber];
                else
                    blockButton.Image = Form1.activeBlocksImage[imageNumber];
        }


        public void setAvailabilityToPlaceBlock(bool availablePlaceToMove)
        {
            this.availablePlaceToMove = availablePlaceToMove;
            if (imageNumber == 0)
                if (availablePlaceToMove == false)
                    blockButton.Image = Form1.blocksImage[0];
                else
                    blockButton.Image = Form1.activeBlocksImage[0];
        }


        public void SetVisibility(bool visible)
        {
            this.visible = visible;
            blockButton.Visible = visible;
        }

        public void SetImage(int imageNumber)
        {
            this.imageNumber = imageNumber;
            blockButton.Image = Form1.blocksImage[imageNumber];
            //if (imageNumber <= 3)
                //blockButton.Image = Properties.Resources.Блок0Выделенный; //Form1.activeBlocksImage[imageNumber];
        }

        public void SetImage(Image img)
        {
            blockButton.Image = img;
            for (int i = 0; i <= 4; i++)
                if (img == Form1.blocksImage[i] || (i >= 0 && i <= 3 && img == Form1.activeBlocksImage[i]))
                    this.imageNumber = i;
        }


        public static int[] DetermineBlockPosition(Button button)
        {
            int m = 0, n = 0;
            int buttonNumber = int.Parse(button.Name.Substring(6));
            
            if (buttonNumber <= 25)
            {
                m = (buttonNumber - 1) / 5 + 1;
                if (buttonNumber % 5 == 0)
                    n = 5;
                else
                    n = buttonNumber % 5;
            }
            return new int[] { m, n };
        }
    }
}
