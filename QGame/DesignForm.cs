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
        /// <summary>
        /// Initial Board positions.
        /// </summary>
        private const int InitLeft = 20;
        private const int InitWidth = 50;
        private const int InitHeight = 50;
        private const int InitTop = 50;
        private const int SquareGap = 20;

        private PictureBox[,] _square;
        /// <summary>
        /// ENumeration containing Square types
        /// </summary>
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

        private SquareType _squaretype = SquareType.Blank;

        private SaveFileDialog saveFile = new SaveFileDialog();
        private OpenFileDialog openFile = new OpenFileDialog();
        public DesignForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes StreamWriter for SaveFileDialog
        /// </summary>
        /// <param name="fileName"></param>
        private void doSave(string fileName)
        {
            StreamWriter saveLevel = new StreamWriter(fileName);
        }
        /// <summary>
        /// initializes StreamReader for OpenFileDialog
        /// </summary>
        /// <param name="fileName"></param>
        private void doLoad(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
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
        /// <summary>
        /// Opens save file via tool strip button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Creates a new column for every row indicated by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Variable to hold the text for rows
            int rowSqaures = int.Parse(txtRows.Text);
            //Variable to hold the text for columns
            int columnSquares = int.Parse(txtColumns.Text);


            int xAxis = InitLeft;
            int yAxis = InitTop;

            //Generates new picturebox array that holds the textbox numbers
            _square = new PictureBox[columnSquares, rowSqaures];

            

            //Generates a vertical line, with the number of squares coming from the user's input  
            for (int c = 0; c < columnSquares; c++)
            {
                //Generates a horizontal line, with the number of squares coming from the user's input 
                for (int r = 0; r < rowSqaures; r++)
                {
                    _square[c, r] = new PictureBox();

                    _square[c, r].Image = Properties.Resources.blank_square;
                    _square[c, r].Left = xAxis + grpToolbox.Width;
                    _square[c, r].Top = yAxis + txtColumns.Height;
                    _square[c, r].Width = InitWidth;
                    _square[c, r].Height = InitHeight;

                    this.Controls.Add(_square[c, r]);

                    yAxis += SquareGap + InitHeight;

                }
                xAxis += SquareGap + InitWidth;
                yAxis = InitTop;

            }
        }
        /// <summary>
        /// Activates red square toolbox button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRedSquare_Click(object sender, EventArgs e)
        {
            if (_square[0, 0].Image != Properties.Resources.red_square)
            {
                _square[0, 0].Image = Properties.Resources.red_square;
            }
        }
    }
}
