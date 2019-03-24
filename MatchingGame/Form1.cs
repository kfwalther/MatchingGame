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

        public Form1()
        {
            InitializeComponent();
            // Assign each square a random icon.
            AssignIconsToSquares();
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
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        /// <summary>
        /// This method is an event handler for every label's Click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is already black, do nothing.
                if (clickedLabel.ForeColor == Color.Black)
                {
                    return;
                }
                // Change the clicked label to black to reveal the icon.
                clickedLabel.ForeColor = Color.Black;
            }
        }
    }
}
