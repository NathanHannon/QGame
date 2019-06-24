/*
 * Created By: Nathan Hannon   
 * Creation Date: Oct 12, 2018
 * File Name: LevelDesignForm.cs 
 */

using System;
using System.Windows.Forms;
using System.IO;

namespace QGame
{
    public partial class LevelDesignForm : Form
    {
        /// <summary>
        /// Initial Board positions.
        /// </summary>
        private const byte InitLeft = 20;
        private const byte InitWidth = 50;
        private const byte InitHeight = 50;
        private const byte InitTop = 50;
        private const byte SquareGap = 20;

        public static Tile[,] _square;
        public static ushort _rowSqaures;
        public static ushort _columnSquares;
        private static string _directoryPath = @"C:\QGame\Saves\";
        
        /// <summary>
        /// Enumeration containing Square types
        /// </summary>
        

        private ToolType _tooltype = ToolType.NONE;

        private SaveFileDialog _saveFile = new SaveFileDialog()
        {
            DefaultExt = "txt",
            Filter = "text file (*.txt)|*.txt|All files (*.*)|*.*",
            AddExtension = true,
            FileName = "SaveGame.txt",
            Title = "Please select a file",
            InitialDirectory = _directoryPath
        };

        public LevelDesignForm()
        {
            InitializeComponent();
        }

        private void LevelDesignForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        }

        /// <summary>
        /// Initializes StreamWriter for SaveFileDialog
        /// </summary>
        /// <param name="fileName"></param>
        private static void DoSave(string fileName)
        {
            StreamWriter saveFile = new StreamWriter(fileName);
            saveFile.WriteLine(_rowSqaures);
            saveFile.WriteLine(_columnSquares);
            
            for (ushort i = 0; i < _rowSqaures; i++)
            {
                for (ushort j = 0; j < _columnSquares; j++)
                {
                    saveFile.WriteLine(i);
                    saveFile.WriteLine(j);
                    saveFile.WriteLine((ushort)_square[i, j].toolType);
                }
            }
            saveFile.Close();
            MessageBox.Show(@"Game Saved Successfully!", "Game Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult result = _saveFile.ShowDialog();
            
            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    try
                    {
                        string fileName = _saveFile.FileName;
                        DoSave(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Please enter a save file name!", @"Error saving file!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
                    throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Returns to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainMenu = new MainMenuForm();
            Hide();
            mainMenu.Show();
        }
        /// <summary>
        /// Creates a new column for every row indicated by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //TODO: Add Exception for uneven row/column inputs
            try
            {
                //Variable to hold the text for rows
                _rowSqaures = ushort.Parse(txtRows.Text);
                //Variable to hold the text for columns
                _columnSquares = ushort.Parse(txtColumns.Text);

                ushort xAxis = InitLeft;
                ushort yAxis = InitTop;

                //Generates new picturebox array that holds the textbox numbers
                _square = new Tile[_columnSquares, _rowSqaures];

                //Generates a vertical line, with the number of squares coming from the user's input  
                for (ushort r = 0; r < _rowSqaures; r++)
                {
                    //Generates a horizontal line, with the number of squares coming from the user's input 
                    
                        for (ushort c = 0; c < _columnSquares; c++)
                        {
                            _square[r, c] = new Tile();

                            _square[r, c].Left = xAxis + grpToolbox.Width;
                            _square[r, c].Top = yAxis + txtColumns.Height;
                            _square[r, c].Width = InitWidth;
                            _square[r, c].Height = InitHeight;
                            _square[r, c].BorderStyle = BorderStyle.FixedSingle;
                            _square[r, c].row = r;
                            _square[r, c].col = c;
                            _square[r, c].toolType = ToolType.NONE;

                            _square[r, c].Click += square_click;

                            Controls.Add(_square[r, c]);

                            yAxis += InitHeight;

                        }
                    xAxis += InitWidth;
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
           Tile p = (Tile)sender;
            p.toolType = _tooltype;
            switch (_tooltype)
            {
                case ToolType.NONE:
                    break;
                case ToolType.WALL:
                    p.Image = Properties.Resources.brick_wall;
                    break;
                case ToolType.RED_BOX:
                    p.Image = Properties.Resources.red_square;
                    break;
                case ToolType.BLUE_BOX:
                    p.Image = Properties.Resources.blue_square;
                    break;
                case ToolType.GREEN_BOX:
                    p.Image = Properties.Resources.green_square;
                    break;
                case ToolType.YELLOW_BOX:
                    p.Image = Properties.Resources.yellow_square;
                    break;
                case ToolType.RED_DOOR:
                    p.Image = Properties.Resources.exit_red;
                    break;
                case ToolType.BLUE_DOOR:
                    p.Image = Properties.Resources.exit_blue;
                    break;
                case ToolType.GREEN_DOOR:
                    p.Image = Properties.Resources.exit_green;
                    break;
                case ToolType.YELLOW_DOOR:
                    p.Image = Properties.Resources.exit_yellow;
                    break;
            }
        }
        private void btnBlank_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.BLANK_BOX;
        }

        private void btnBrickWall_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.WALL;
        }

        private void btnRedSquare_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.RED_BOX;
        }

        private void btnBlueSquare_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.BLUE_BOX;
        }

        private void btnGreenSquare_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.GREEN_BOX;
        }

        private void btnYellowSquare_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.YELLOW_BOX;
        }

        private void btnRedExit_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.RED_DOOR;
        }

        private void btnBlueExit_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.BLUE_DOOR;
        }

        private void btnGreenExit_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.GREEN_DOOR;
        }

        private void btnYellowExit_Click(object sender, EventArgs e)
        {
            _tooltype = ToolType.YELLOW_DOOR;
        }
    }
}
