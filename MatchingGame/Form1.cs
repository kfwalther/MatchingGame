using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {

        // Use this Random object to choose random icons for the squares.
        Random random = new Random();

        // Each of these letters is an interesting icon in the Webdings font,
        // and each icon appears twice in this list.
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        // This points to the first label control that the player chooses, and will be null if nothing is clicked yet.
        Label firstClicked = null;
        // This points to the second label control the player clicks.
        Label secondClicked = null;

        public Form1()
        {
            InitializeComponent();
            // Assign each square a random icon.
            this.AssignIconsToSquares();
        }

        /// <summary>
        /// Assign each icon from the list of icons to a random square.
        /// </summary>
        private void AssignIconsToSquares()
        {
            /** The TableLayoutPanel has 16 labels, and the icon list has 16 icons,
                so an icon is pulled at random from the list and added to each label. */
            foreach (Control control in this.tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {   
                    int randomNumber = this.random.Next(this.icons.Count);
                    iconLabel.Text = this.icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    this.icons.RemoveAt(randomNumber);
                }
            }
        }

        /// <summary>
        /// Check if the user has won by matching all of the icons.
        /// </summary>
        private void CheckForWinner()
        {
            // Loop through each label to check if it is colored black yet.
            foreach (Control control in this.tableLayoutPanel1.Controls)
            {
                Label curLabel = control as Label;
                // Ensure the cast was successful.
                if (curLabel != null)
                {
                    // Check if this label has been matched yet.
                    if (curLabel.ForeColor != Color.Black)
                    {
                        // Not yet matched, no winner yet.
                        return;
                    }
                }
            }

            // If all icons are black, user has won. Close the form.
            MessageBox.Show("You matched all the icons!", "Congratulations");
            this.Close();
        }

        /// <summary>
        /// This method is an event handler for every label's Click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            // Ignore any clicks when the timer is already enabled.
            if (this.timer1.Enabled == true)
            {
                return;
            }

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is already black, do nothing.
                if (clickedLabel.ForeColor == Color.Black)
                {
                    return;
                }

                // Check if this is the first label clicked, reveal the icon.
                if (this.firstClicked == null)
                {
                    this.firstClicked = clickedLabel;
                    // Change the clicked label to black to reveal the icon.
                    clickedLabel.ForeColor = Color.Black;
                    return;
                }

                // If it isn't the first label clicked, the second one has been clicked. Reveal its icon.
                this.secondClicked = clickedLabel;
                clickedLabel.ForeColor = Color.Black;

                // Check here for all icons overturned (a check for winning case). 
                this.CheckForWinner();

                // Check here for matching icons.
                if (this.firstClicked.Text == this.secondClicked.Text)
                {
                    // Found a match, so no need to start the timer.
                    this.firstClicked = null;
                    this.secondClicked = null;
                    return;
                }

                // Since two icons are now shown, start the timer.
                this.timer1.Start();
            }
        }

        /// <summary>
        /// This timer is started when the player selects two icons that do not match. It will 
        /// run for 750ms then turn itself off and hide both selected icons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer.
            this.timer1.Stop();
            // Hide both icons.
            this.firstClicked.ForeColor = this.firstClicked.BackColor;
            this.secondClicked.ForeColor = this.secondClicked.BackColor;
            // Reset the references to the currently-clicked icons.
            this.firstClicked = null;
            this.secondClicked = null;
        }

        
    }
}
