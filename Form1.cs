﻿using INFOIBV.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace INFOIBV
{
    partial class INFOIBV : Form
    {
        private Bitmap InputImage;
        private Bitmap OutputImage;

        public INFOIBV(IImageOperation[] items)
        {
            InitializeComponent();
            this.chooseProcessor.Items.Clear();
            this.chooseProcessor.Items.AddRange(items);
            this.chooseProcessor.SelectedIndex = 0;
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            if (openImageDialog.ShowDialog() == DialogResult.OK)             // Open File Dialog
            {
                string file = openImageDialog.FileName;                     // Get the file name
                imageFileName.Text = file;                                  // Show file name
                if (InputImage != null) InputImage.Dispose();               // Reset image
                InputImage = new Bitmap(file);                              // Create new Bitmap from file

                if (InputImage.Size.Height <= 0 || InputImage.Size.Width <= 0 ||
                    InputImage.Size.Height > 1048 || InputImage.Size.Width > 1048) // Dimension check
                    MessageBox.Show("Error in image dimensions (have to be > 0 and <= 512)");
                else {
                    var h = new Histogram(InputImage);
                    pictureBox1.Image = (Image)InputImage;                 // Display input image
                    histogram1.Image = (Image)h.RenderHistogram(2);
                }

            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (InputImage == null) return;                                 // Get out if no input image
            if (OutputImage != null) OutputImage.Dispose();                 // Reset output image
            pictureBox2.Image = null;
            histogram2.Image = null;
            this.Refresh();

            var op = (IImageOperation)chooseProcessor.SelectedItem;
            var t = new Thread(() =>
            {
                OutputImage = op.Process(InputImage, progressBar);
                var h = new Histogram(OutputImage);
                pictureBox2.Image = (Image)OutputImage;                         // Display output image
                histogram2.Image = (Image)h.RenderHistogram(2);
                progressBar.Visible = false;                                    // Hide progress bar
            });
            t.Start();


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (OutputImage == null) return;                                // Get out if no output image
            if (saveImageDialog.ShowDialog() == DialogResult.OK)
                OutputImage.Save(saveImageDialog.FileName);                 // Save the output image
        }

    }
}
