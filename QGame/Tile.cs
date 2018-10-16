﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGame
{
    public class Tile : PictureBox
    {
        public int row;
        public int col;
        public SquareType squareType; 
    }
}