using System;
using System.Windows.Forms;

namespace QGame
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Opens a new window to create/edit a level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesign_Click(object sender, EventArgs e)
        {
            var designForm = new LevelDesignForm();
            this.Hide();
            designForm.Show();
        }

        /// <summary>
        ///     Quits Application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Closes Application
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            var playForm = new PlayGameForm();
            this.Hide();
            playForm.Show();
        }
    }
}