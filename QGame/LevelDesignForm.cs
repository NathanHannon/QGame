using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QGame
{

    public partial class LevelDesignForm : Form
    {
        /// <summary>
        /// Initial Board positions.
        /// </summary>
        private const int InitLeft = 20;
        private const int InitWidth = 50;
        private const int InitHeight = 50;
        private const int InitTop = 50;
        private const int SquareGap = 20;

        private PictureBox[,] _square;
        private int _rowSqaures;
        private int _columnSquares;
        
        /// <summary>
        /// ENumeration containing Square types
        /// </summary>
        enum SquareType
        {
            Blank,
            BrickWall,
            RedSquare,
            BlueSquare,
            GreenSquare,
            YellowSquare,
            RedExit,
            BlueExit,
            GreenExit,
            YellowExit
        }

        private SquareType _squaretype = SquareType.Blank;

        private SaveFileDialog saveFile = new SaveFileDialog();

        public LevelDesignForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes StreamWriter for SaveFileDialog
        /// </summary>
        /// <param name="fileName"></param>
        private void DoSave(string fileName)
        {
            StreamWriter saveLevel = new StreamWriter(fileName);
            saveLevel.WriteLine(_rowSqaures);
            saveLevel.WriteLine(_columnSquares);
            
            for (int i = 0; i < _rowSqaures; i++)
            {
                for (int j = 0; j < _columnSquares; j++)
                {
                    saveLevel.WriteLine(i);
                    saveLevel.WriteLine(j);
                    if (_square[i,j].Image == Properties.Resources.blank_square)
                    {
                        saveLevel.WriteLine((int)SquareType.Blank);
                    }
                    else if (_square[i,j].Image == Properties.Resources.brick_wall)
                    {
                        saveLevel.WriteLine((int)SquareType.BrickWall);
                    }
                    else if(_square[i, j].Image == Properties.Resources.red_square)
                    {
                        saveLevel.WriteLine((int)SquareType.RedSquare);
                    }
                    else if(_square[i, j].Image == Properties.Resources.blue_square)
                    {
                        saveLevel.WriteLine((int)SquareType.BlueSquare);       
                    }
                    else if(_square[i, j].Image == Properties.Resources.green_square)
                    {
                        saveLevel.WriteLine((int)SquareType.GreenSquare);       
                    }
                    else if(_square[i, j].Image == Properties.Resources.yellow_square)
                    {
                        saveLevel.WriteLine((int)SquareType.YellowSquare);       
                    }
                    else if(_square[i, j].Image == Properties.Resources.exit_red)
                    {
                        saveLevel.WriteLine((int)SquareType.RedExit);       
                    }
                    else if(_square[i, j].Image == Properties.Resources.exit_blue)
                    {
                        saveLevel.WriteLine((int)SquareType.BlueExit);       
                    }
                    else if(_square[i, j].Image == Properties.Resources.exit_green)
                    {
                        saveLevel.WriteLine((int)SquareType.GreenExit);       
                    }
                    else if(_square[i, j].Image == Properties.Resources.exit_yellow)
                    {
                        saveLevel.WriteLine((int)SquareType.YellowExit);       
                    }
                }
            }
        }
        /// <summary>
        /// Exits program via tool strip button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Saves level via tool strip button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFile.ShowDialog();
            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    try
                    {
                        string fileName = saveFile.FileName;
                        DoSave(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Error saving file!");
                    }
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Creates a new column for every row indicated by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //Variable to hold the text for rows
                _rowSqaures = int.Parse(txtRows.Text);
                //Variable to hold the text for columns
                _columnSquares = int.Parse(txtColumns.Text);

                int xAxis = InitLeft;
                int yAxis = InitTop;

                //Generates new picturebox array that holds the textbox numbers
                _square = new PictureBox[_columnSquares, _rowSqaures];

                //Generates a vertical line, with the number of squares coming from the user's input  
                for (int c = 0; c < _columnSquares; c++)
                {
                    //Generates a horizontal line, with the number of squares coming from the user's input 
                    for (int r = 0; r < _rowSqaures; r++)
                    {
                        _square[c, r] = new PictureBox();

                        _square[c, r].Image = Properties.Resources.blank_square;
                        _square[c, r].Left = xAxis + grpToolbox.Width;
                        _square[c, r].Top = yAxis + txtColumns.Height;
                        _square[c, r].Width = InitWidth;
                        _square[c, r].Height = InitHeight;
                        _square[c, r].Click += square_click;

                       
                        Controls.Add(_square[c, r]);

                        yAxis += SquareGap + InitHeight;

                    }
                    xAxis += SquareGap + InitWidth;
                    yAxis = InitTop;
                }
            }
            //Checks for valid formatting, and throws an error if the input isn't a digit.
            catch (FormatException)
            {

                MessageBox.Show(@"Please enter a number.", @"Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void square_click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            switch (_squaretype)
            {
                case SquareType.Blank:
                    break;
                case SquareType.BrickWall:
                    p.Image = Properties.Resources.brick_wall;
                    break;
                case SquareType.RedSquare:
                    p.Image = Properties.Resources.red_square;
                    break;
                case SquareType.BlueSquare:
                    p.Image = Properties.Resources.blank_square;
                    break;
                case SquareType.GreenSquare:
                    p.Image = Properties.Resources.green_square;
                    break;
                case SquareType.YellowSquare:
                    p.Image = Properties.Resources.yellow_square;
                    break;
                case SquareType.RedExit:
                    p.Image = Properties.Resources.exit_red;
                    break;
                case SquareType.BlueExit:
                    p.Image = Properties.Resources.exit_blue;
                    break;
                case SquareType.GreenExit:
                    p.Image = Properties.Resources.exit_green;
                    break;
                case SquareType.YellowExit:
                    p.Image = Properties.Resources.exit_yellow;
                    break;
                default:
                    break;
            }
        }
        private void btnBlank_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.Blank;
        }

        private void btnBrickWall_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.BrickWall;
        }

        private void btnRedSquare_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.RedSquare;
        }

        private void btnBlueSquare_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.BlueSquare;
        }

        private void btnGreenSquare_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.GreenSquare;
        }

        private void btnYellowSquare_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.YellowSquare;
        }

        private void btnRedExit_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.RedExit;
        }

        private void btnBlueExit_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.BlueExit;
        }

        private void btnGreenExit_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.GreenExit;
        }

        private void btnYellowExit_Click(object sender, EventArgs e)
        {
            _squaretype = SquareType.YellowExit;
        }




        //TODO:Add events for other buttons when Visual Studio can be used.
    }
}
