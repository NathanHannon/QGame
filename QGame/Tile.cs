using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGame
{
    public enum ToolType
    {
        NONE,
        WALL,
        RED_DOOR,
        GREEN_DOOR,
        BLUE_DOOR,
        YELLOW_DOOR,
        RED_BOX,
        GREEN_BOX,
        BLUE_BOX,
        YELLOW_BOX,
        BLANK_BOX
    }
    public class Tile : PictureBox
    {
        public int row;
        public int col;
        public ToolType toolType;
        public bool Movable = false;

        private const int INIT_LEFT = 100;
        private const int INIT_TOP = 100;
        private const int WIDTH = 50;
        private const int HEIGHT = 50;

        public void updatePosition()
        {
            this.Left = INIT_LEFT + WIDTH * col;
            this.Top = INIT_TOP + HEIGHT * row;
            this.Width = WIDTH;
            this.Height = HEIGHT;
        }

    }
}
