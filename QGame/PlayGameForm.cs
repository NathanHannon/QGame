using System;
using System.Windows.Forms;
using System.IO;

namespace QGame
{
    public partial class PlayGameForm: Form
    {
        int numberOfRows;
        int numberOfCols;
        Tile[,] tiles;

        Tile selectedTile;
        public PlayGameForm()
        {
            InitializeComponent();
        }
        private void loadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            numberOfRows = int.Parse(reader.ReadLine());
            numberOfCols = int.Parse(reader.ReadLine());
            tiles = new Tile[numberOfRows, numberOfCols];


            Console.WriteLine(value: $"number of rows: {numberOfRows} number of cols: {numberOfCols}");


            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfCols; j++)
                {
                    int r = int.Parse(reader.ReadLine());
                    int c = int.Parse(reader.ReadLine());
                    int toolType = int.Parse(reader.ReadLine());

                    if (toolType != 0)
                    {
                        Console.WriteLine(value: $"row: {r} col: {c} toolType: {toolType}");

                        Tile t = new Tile();

                        tiles[i, j] = t;

                        t.row = r;
                        t.col = c;
                        t.toolType = (ToolType)toolType;
                        t.BorderStyle = BorderStyle.FixedSingle;
                        t.SizeMode = PictureBoxSizeMode.StretchImage;
                        t.updatePosition();
                        switch (t.toolType)
                        {
                            case ToolType.NONE:
                                break;
                            case ToolType.WALL:
                                t.Image = Properties.Resources.brick_wall;
                                break;
                            case ToolType.RED_DOOR:
                                t.Image = Properties.Resources.exit_red;
                                break;
                            case ToolType.GREEN_DOOR:
                                t.Image = Properties.Resources.exit_green;
                                break;
                            case ToolType.BLUE_DOOR:
                                t.Image = Properties.Resources.exit_blue;
                                break;
                            case ToolType.YELLOW_DOOR:                                
                                t.Image = Properties.Resources.exit_yellow;
                                break;
                            case ToolType.RED_BOX:
                                t.Image = Properties.Resources.red_square;
                                t.Movable = true;
                                break;
                            case ToolType.GREEN_BOX:
                                t.Image = Properties.Resources.red_square;
                                t.Movable = true;
                                break;
                            case ToolType.BLUE_BOX:
                                t.Image = Properties.Resources.blue_square;
                                t.Movable = true;
                                break;
                            case ToolType.YELLOW_BOX:
                                t.Image = Properties.Resources.yellow_square;
                                t.Movable = true;
                                break;
                            default:
                                break;
                        }
                        this.Controls.Add(t);
                        t.Click += T_Click;
                     }
                }
            }
        }

        private Tile findTile(int r, int c)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i,j]!= null && tiles[i,j].row == r && tiles[i,j].col == c)
                    {
                        return tiles[i, j];
                    }
                }
            }
            return null;
        }

        private void T_Click(object sender, EventArgs e)
        {
            selectedTile = (Tile)sender;
        }

        private void removeTilefromArray(Tile t)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (t == tiles[i,j])
                    {
                        tiles[i, j] = null;
                        Console.WriteLine(value: $"row: {t.row} col: {t.col}");
                        return;
                    }
                }
            }
        }
        
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void returnToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainMenu = new MainMenuForm();
            this.Hide();
            mainMenu.Show();
        }
        
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgOpen.FileName = "savegame6.qgame";
            DialogResult r = dlgOpen.ShowDialog();
            switch (r)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    loadFile(dlgOpen.FileName);
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

        private void btnRight_Click(object sender, EventArgs e)
        {
            bool flag = true;
            while (flag)
            {
                try
                {

                    int currentRow = selectedTile.row;
                    int currentCol = selectedTile.col;
                    int futureRow = selectedTile.row;
                    int futureCol = selectedTile.col - 1;

                    //selectedTile.row = futureRow;
                    //selectedTile.col = futureCol;
                    //selectedTile.updatePosition();

                    Tile x = findTile(futureRow, futureCol);
                    if (x == null)
                    {
                        selectedTile.row = futureRow;
                        selectedTile.col = futureCol;
                        selectedTile.updatePosition();
                    }

                    else if (x.toolType == ToolType.RED_DOOR && selectedTile.toolType == ToolType.RED_BOX)
                    {
                        removeTilefromArray(selectedTile);
                        this.Controls.Remove(selectedTile);
                        flag = false;
                    }
                    else if (x.toolType == ToolType.BLUE_DOOR && selectedTile.toolType == ToolType.BLUE_BOX)
                    {
                        removeTilefromArray(selectedTile);
                        this.Controls.Remove(selectedTile);
                        flag = false;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (NullReferenceException)
                {

                    MessageBox.Show(text: $@"Please select a square.", caption: "Error!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            bool flag = true;
            while (flag)
            {
                try
                {

                    int currentRow = selectedTile.row;
                    int currentCol = selectedTile.col;
                    int futureRow = selectedTile.row;
                    int futureCol = selectedTile.col + 1;

                    //selectedTile.row = futureRow;
                    //selectedTile.col = futureCol;
                    //selectedTile.updatePosition();

                    Tile x = findTile(futureRow, futureCol);
                    if (x == null)
                    {
                        selectedTile.row = futureRow;
                        selectedTile.col = futureCol;
                        selectedTile.updatePosition();
                    }
                    else if (x.toolType == ToolType.RED_DOOR && selectedTile.toolType == ToolType.RED_BOX)
                    {
                        removeTilefromArray(selectedTile);
                        this.Controls.Remove(selectedTile);
                        flag = false;
                    }
                    else if (x.toolType == ToolType.BLUE_DOOR && selectedTile.toolType == ToolType.BLUE_BOX)
                    {
                        removeTilefromArray(selectedTile);
                        this.Controls.Remove(selectedTile);
                        flag = false;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (NullReferenceException)
                {

                    MessageBox.Show(text: $@"Please select a square.", caption: "Error!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            bool flag = true;
            while (flag)
            {
                try
                {

                    int currentRow = selectedTile.row;
                    int currentCol = selectedTile.col;
                    int futureRow = selectedTile.row - 1;
                    int futureCol = selectedTile.col;

                    //selectedTile.row = futureRow;
                    //selectedTile.col = futureCol;
                    //selectedTile.updatePosition();

                    Tile x = findTile(futureRow, futureCol);
                    if (x == null)
                    {
                        selectedTile.row = futureRow;
                        selectedTile.col = futureCol;
                        selectedTile.updatePosition();
                    }

                    else if (x.toolType == ToolType.RED_DOOR && selectedTile.toolType == ToolType.RED_BOX)
                    {
                        removeTilefromArray(selectedTile);
                        this.Controls.Remove(selectedTile);
                        flag = false;
                    }
                    else if (x.toolType == ToolType.BLUE_DOOR && selectedTile.toolType == ToolType.BLUE_BOX)
                    {
                        removeTilefromArray(selectedTile);
                        this.Controls.Remove(selectedTile);
                        flag = false;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (NullReferenceException)
                {

                    MessageBox.Show(text: $@"Please select a square.", caption: "Error!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            bool flag = true;
            while (flag)
            {
                try
                {

                    int currentRow = selectedTile.row;
                    int currentCol = selectedTile.col;
                    int futureRow = selectedTile.row + 1;
                    int futureCol = selectedTile.col;

                    //selectedTile.row = futureRow;
                    //selectedTile.col = futureCol;
                    //selectedTile.updatePosition();

                    Tile x = findTile(futureRow, futureCol);
                    if (x == null)
                    {
                        selectedTile.row = futureRow;
                        selectedTile.col = futureCol;
                        selectedTile.updatePosition();
                    }

                    else if (x.toolType == ToolType.RED_DOOR && selectedTile.toolType == ToolType.RED_BOX)
                    {
                        removeTilefromArray(selectedTile);
                        this.Controls.Remove(selectedTile);
                        flag = false;
                    }
                    else if (x.toolType == ToolType.BLUE_DOOR && selectedTile.toolType == ToolType.BLUE_BOX)
                    {
                        removeTilefromArray(selectedTile);
                        this.Controls.Remove(selectedTile);
                        flag = false;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (NullReferenceException)
                {

                    MessageBox.Show(text: $@"Please select a square.", caption: "Error!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
