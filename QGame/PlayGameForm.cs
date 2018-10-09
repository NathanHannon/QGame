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
        private OpenFileDialog openFile = new OpenFileDialog();

        public PlayGameForm()
        {
            InitializeComponent();
        }

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

        private void DoLoad(string fileName)
        {
            StreamReader loadLevel = new StreamReader(fileName);

            for (int i = 0; i < LevelDesignForm._rowSqaures; i++)
            {
                for (int j = 0; j < LevelDesignForm._columnSquares; j++)
                {
                    String line;
                    while ((line = loadLevel.ReadLine()) != null)
                    {
                        if (LevelDesignForm._square[i, j].Image == Properties.Resources.blank_square)
                        {
                            Controls.Remove(LevelDesignForm._square[i, j]);
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.brick_wall)
                        {
                            loadLevel.ReadLine();
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.red_square)
                        {
                            loadLevel.ReadLine();
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.blue_square)
                        {
                            loadLevel.ReadLine();
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.green_square)
                        {
                            loadLevel.ReadLine();
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.yellow_square)
                        {
                            loadLevel.ReadLine();
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.exit_red)
                        {
                            loadLevel.ReadLine();
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.exit_blue)
                        {
                            loadLevel.ReadLine();
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.exit_green)
                        {
                            loadLevel.ReadLine();
                        }
                        else if (LevelDesignForm._square[i, j].Image == Properties.Resources.exit_yellow)
                        {
                            loadLevel.ReadLine();
                        }
                    }
                }
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
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
                        DoLoad(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Error loading file!");
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

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }
    }
}
