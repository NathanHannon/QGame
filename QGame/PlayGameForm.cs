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
    public partial class PlayGameForm : Form
    {

        public PlayGameForm()
        {
            InitializeComponent();
        }

        
        public Tile[,] _loadedTile;
        private readonly Tile _player = new Tile();
        private readonly Tile _wall = new Tile();

        private SquareType _squaretype = SquareType.Blank;

        private readonly OpenFileDialog _openFile = new OpenFileDialog();


        /// <summary>
        /// Load file function
        /// </summary>
        /// <param name="fileName"></param>
        private void DoLoad(string fileName)
        {

            StreamReader openLevel = new StreamReader(fileName);
            for (int i = 0; i < LevelDesignForm.RowSqaures; i++)
            {
                for (int j = 0; j < LevelDesignForm.ColumnSquares; j++)
                {
                    LevelDesignForm.Square[i, j].SquareType = (SquareType)Enum.Parse(typeof(SquareType), openLevel.ReadLine());
                }
            }
            openLevel.Close();
            MessageBox.Show("Game Loaded Successfully!", "GameLoaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openFile.Filter = "Text Files (*.txt|*.txt)";
            _openFile.DefaultExt = "txt";
            _openFile.AddExtension = true;
            DialogResult result = _openFile.ShowDialog();
            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    try
                    {
                        string fileName = _openFile.FileName;
                        DoLoad(fileName);

                    }
                    catch (Exception loadFailure)
                    {
                        MessageBox.Show(@"Please enter a file name!", @"Error saving file!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }

        }

        private void returnToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainMenu = new MainMenuForm();
            this.Hide();
            mainMenu.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            _player.Left += 20;
            btnLeft.Enabled = !_player.Bounds.IntersectsWith(_wall.Bounds);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            _player.Top -= 20;
            btnDown.Enabled = !_player.Bounds.IntersectsWith(_wall.Bounds);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            _player.Top += 20;
            btnUp.Enabled = !_player.Bounds.IntersectsWith(_wall.Bounds);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _player.Left -= 20;
            btnRight.Enabled = !_player.Bounds.IntersectsWith(_wall.Bounds);
        }
    }
}
