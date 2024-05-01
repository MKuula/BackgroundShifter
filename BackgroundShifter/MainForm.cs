using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BackgroundShifter
{
    public partial class MainForm : Form
    {
        private List<int> cutPoints = new List<int>();
        private Bitmap finalBitmap = null;
        private Bitmap originalBitmap = null;

        public MainForm()
        {
            InitializeComponent();
            Text = Application.ProductName;
            DetermineCutPoints();
        }

        private void openLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Bitmap files (*.bmp)|*.bmp"
            };
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                // Original bitmap
                originalBitmap = new Bitmap(openDialog.FileName);
                pictureBox1.Image = originalBitmap;

                pictureBox2.Image = finalBitmap;

                DrawBitmap();
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (finalBitmap != null)
            {
                e.Graphics.DrawImage(finalBitmap, e.ClipRectangle);
            }
        }

        private void saveLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (finalBitmap != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Bitmap files (*.bmp)|*.bmp"
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                    finalBitmap.Save(saveDialog.FileName);
            }
        }

        private void DetermineCutPoints()
        {
            cutPoints.Clear();
            Random randomizer = new Random();

            // Draw five randomly chosen cutpoints
            for (int i = 0; i < 5; i++)
            {
                int number = randomizer.Next(1, 5);
                cutPoints.Add(number);
            }
        }

        private void DrawBitmap()
        {
            if (originalBitmap != null)
            {
                // Initialize the result bitmap
                finalBitmap = new Bitmap(originalBitmap.Width * cutPoints.Count, originalBitmap.Height);
                Graphics grp = Graphics.FromImage(finalBitmap);

                int widthPos = 0;   // Location of next image
                foreach (int cutPoint in cutPoints)
                {
                    // Locations of lowerpart and upperpart in the destination picture
                    int lowerPart = originalBitmap.Height / cutPoint;
                    int upperPart = originalBitmap.Height - lowerPart;

                    grp.DrawImage(originalBitmap, new Rectangle(widthPos, 0, originalBitmap.Width, upperPart), new Rectangle(0, lowerPart, originalBitmap.Width, upperPart), GraphicsUnit.Pixel);
                    grp.DrawImage(originalBitmap, new Rectangle(widthPos, upperPart, originalBitmap.Width, lowerPart), new Rectangle(0, 0, originalBitmap.Width, lowerPart), GraphicsUnit.Pixel);

                    widthPos += originalBitmap.Width;
                }

                pictureBox2.Invalidate();
            }
        }

        private void recalculateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DetermineCutPoints();
            DrawBitmap();
        }
    }
}
