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

    public partial class DesignForm : Form
    {
        private const int INIT_LEFT = 20;
        private const int INIT_WIDTH = 50;
        private const int INIT_HEIGHT = 50;
        private const int INIT_TOP = 50;
        private const int SQUAREGAP = 20;

        private PictureBox[,] square;

        enum SquareType
        {
            Blank,
            BrickWall,
            RedPlayer,
            BluePlayer,
            GreenPlayer,
            YellowPlayer,
            RedExit,
            BlueExit,
            GreenExit,
            YellowExit
        }
        SquareType squaretype = SquareType.Blank;

        private SaveFileDialog saveFile = new SaveFileDialog();
        private OpenFileDialog openFile = new OpenFileDialog();
        public DesignForm()
        {
            InitializeComponent();
        }

        private void doSave(string fileName)
        {
            StreamWriter saveLevel = new StreamWriter(fileName);
        }

        private void doLoad(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
                        doSave(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving file!");
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

        private void openLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFile.ShowDialog();
            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    try
                    {
                        string fileName = openFile.FileName;
                        doLoad(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading file!");
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Variable to hold the text for rows
            int rowSqaures = int.Parse(txtRows.Text);
            //Variable to hold the text for columns
            int columnSquares = int.Parse(txtColumns.Text);


            int xAxis = INIT_LEFT;
            int yAxis = INIT_TOP;

            //Generates new picturebox array that holds the textbox numbers
            square = new PictureBox[columnSquares, rowSqaures];

            //Creates a new column for every row indicated by the user.

            //Generates a vertical line, with the number of squares coming from the user's input  
            for (int c = 0; c < columnSquares; c++)
            {
                //Generates a horizontal line, with the number of squares coming from the user's input 
                for (int r = 0; r < rowSqaures; r++)
                {
                    square[c, r] = new PictureBox();

                    square[c, r].Image = Properties.Resources.blank_square;
                    square[c, r].Left = xAxis + grpToolbox.Width;
                    square[c, r].Top = yAxis + txtColumns.Height;
                    square[c, r].Width = INIT_WIDTH;
                    square[c, r].Height = INIT_HEIGHT;

                    this.Controls.Add(square[c, r]);

                    //
                    yAxis += SQUAREGAP + INIT_HEIGHT;

                }
                xAxis += SQUAREGAP + INIT_WIDTH;
                yAxis = INIT_TOP;

            }
        }
        //Activates red square toolbox button
        private void btnRedSquare_Click(object sender, EventArgs e)
        {
            if (square[0, 0].Image != Properties.Resources.red_square)
            {
                square[0, 0].Image = Properties.Resources.red_square;
            }
        }
    }
}
