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
        private SquareType _squaretype = SquareType.Blank;
        private OpenFileDialog openFile = new OpenFileDialog();
        private Tile player = new Tile();
        private Tile wall = new Tile();

        /// <summary>
        /// Load file function
        /// </summary>
        /// <param name="fileName"></param>
        private void DoLoad(string fileName)
        {

            StreamReader openFile = new StreamReader(fileName);
            for (int i = 0; i < LevelDesignForm._rowSqaures; i++)
            {
                for (int j = 0; j < LevelDesignForm._columnSquares; j++)
                {
                    LevelDesignForm._square[i, j].squareType = (SquareType)Enum.Parse(typeof(SquareType), openFile.ReadLine());
                }
            }
            openFile.Close();
            MessageBox.Show("Game Loaded Successfully!", "GameLoaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFile.ShowDialog();
            openFile.Filter = "Text Files (*.txt|*.txt)";
            openFile.DefaultExt = "txt";
            openFile.AddExtension = true;
            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    try
                    {
                        string fileName = openFile.FileName;
                        DoLoad(fileName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Please enter a file name!", @"Error saving file!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                    break;
                case DialogResult.Cancel:
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
            player.Left += 20;
            if (player.Bounds.IntersectsWith(wall.Bounds))
            {
                btnLeft.Enabled = false;
            }
            else btnLeft.Enabled = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            player.Top -= 20;
            if (player.Bounds.IntersectsWith(wall.Bounds))
            {
                btnDown.Enabled = false;
            }
            else btnDown.Enabled = true;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            player.Top += 20;
            if (player.Bounds.IntersectsWith(wall.Bounds))
            {
                btnUp.Enabled = false;
            }
            else btnUp.Enabled = true;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            player.Left -= 20;
            if (player.Bounds.IntersectsWith(wall.Bounds))
            {
                btnRight.Enabled = false;
            }
            else btnRight.Enabled = true;
        }
    }
}
