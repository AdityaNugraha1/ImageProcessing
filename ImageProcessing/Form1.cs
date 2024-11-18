using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage = null;
        private Bitmap processedImage = null;

        private int cumulativeBrightness = 0; // -100 to 100
        private int cumulativeContrast = 100;  // 0 to 200
        private int cumulativeGrayscale = 0;   // 0 to 100
        private bool isInverted = false;

        public Form1()
        {
            InitializeComponent();
            ResetAdjustments();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Import Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap temp = new Bitmap(openFileDialog.FileName);
                        originalImage?.Dispose();
                        processedImage?.Dispose();
                        originalImage = new Bitmap(temp);
                        processedImage = new Bitmap(originalImage);
                        picOriginal.Image = originalImage;
                        picProcessed.Image = processedImage;
                        temp.Dispose();

                        GenerateHistogram(originalImage, picOriginalHistogram);
                        GenerateHistogram(processedImage, picProcessedHistogram);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error importing image: " + ex.Message);
                    }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please import an image first.");
                return;
            }

            //processedImage?.Dispose();
            processedImage = AdjustBrightnessContrastGrayscale(originalImage, cumulativeBrightness, cumulativeContrast, cumulativeGrayscale);

            if (isInverted)
            {
                processedImage = InvertImage(processedImage);
            }
            picProcessed.Image = processedImage;

            GenerateHistogram(processedImage, picProcessedHistogram);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                return;
            }

            ResetAdjustments();

            processedImage?.Dispose();
            processedImage = new Bitmap(originalImage);
            picProcessed.Image = processedImage;

            GenerateHistogram(processedImage, picProcessedHistogram);
        }

        private void ResetAdjustments()
        {
            cumulativeBrightness = 0;
            cumulativeContrast = 100;
            cumulativeGrayscale = 0;

            tbBrightness.Minimum = -100;
            tbBrightness.Maximum = 100;
            tbBrightness.Value = 0;

            tbContrast.Minimum = 0;
            tbContrast.Maximum = 200;
            tbContrast.Value = 100;

            tbGrayscale.Minimum = 0;
            tbGrayscale.Maximum = 100;
            tbGrayscale.Value = 0;

            lblBrightnessValue.Text = "0";
            lblContrastValue.Text = "100";
            lblGrayscaleValue.Text = "0";
            isInverted = false;
        }

        private void tbBrightness_Scroll(object sender, EventArgs e)
        {
            lblBrightnessValue.Text = tbBrightness.Value.ToString();

            cumulativeBrightness = tbBrightness.Value;
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            lblContrastValue.Text = tbContrast.Value.ToString();

            cumulativeContrast = tbContrast.Value;
        }

        private void tbGrayscale_Scroll(object sender, EventArgs e)
        {
            lblGrayscaleValue.Text = tbGrayscale.Value.ToString();

            cumulativeGrayscale = tbGrayscale.Value;
        }

        private Bitmap AdjustBrightnessContrastGrayscale(Bitmap bmp, int brightness, int contrast, int grayscale)
        {
            Bitmap adjusted = new Bitmap(bmp.Width, bmp.Height);

            double contrastFactor = contrast / 100.0; 

            double brightnessFactor = brightness;

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpDataOriginal = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bmpDataAdjusted = adjusted.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(bmpDataOriginal.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] rgbAdjusted = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(bmpDataOriginal.Scan0, rgbValues, 0, bytes);
            bmp.UnlockBits(bmpDataOriginal);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                int b = (int)((rgbValues[i] - 128) * contrastFactor + 128 + brightnessFactor);
                int g = (int)((rgbValues[i + 1] - 128) * contrastFactor + 128 + brightnessFactor);
                int r = (int)((rgbValues[i + 2] - 128) * contrastFactor + 128 + brightnessFactor);

                b = Clamp(b);
                g = Clamp(g);
                r = Clamp(r);

                if (grayscale > 0)
                {
                    double grayFactor = grayscale / 100.0;
                    int gray = (int)(0.3 * r + 0.59 * g + 0.11 * b);
                    r = (int)(r * (1 - grayFactor) + gray * grayFactor);
                    g = (int)(g * (1 - grayFactor) + gray * grayFactor);
                    b = (int)(b * (1 - grayFactor) + gray * grayFactor);
                }

                rgbAdjusted[i] = Clamp(b);
                rgbAdjusted[i + 1] = Clamp(g);
                rgbAdjusted[i + 2] = Clamp(r);
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbAdjusted, 0, bmpDataAdjusted.Scan0, bytes);
            adjusted.UnlockBits(bmpDataAdjusted);

            return adjusted;
        }

        private byte Clamp(int value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;
            return (byte)value;
        }

        private int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private void GenerateHistogram(Bitmap bmp, PictureBox pictureBox)
        {
            int[] grayHistogram = new int[256];

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int stride = bmpData.Stride;
            int bytes = Math.Abs(stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);
            bmp.UnlockBits(bmpData);

            for (int y = 0; y < bmp.Height; y++)
            {
                int row = y * stride;
                for (int x = 0; x < bmp.Width; x++)
                {
                    int idx = row + x * 3;
                    byte b = rgbValues[idx];
                    byte g = rgbValues[idx + 1];
                    byte r = rgbValues[idx + 2];
                    int gray = (int)(r * 0.3 + g * 0.59 + b * 0.11);
                    grayHistogram[gray]++;
                }
            }

            int histogramWidth = 256;
            int histogramHeight = 100;
            Bitmap histogramBitmap = new Bitmap(histogramWidth, histogramHeight);
            using (Graphics g = Graphics.FromImage(histogramBitmap))
            {
                g.Clear(Color.White);

                int max = 0;
                foreach (int val in grayHistogram)
                {
                    if (val > max)
                        max = val;
                }

                float scale = max > 0 ? (float)histogramHeight / max : 1;

                for (int i = 0; i < 256; i++)
                {
                    int barHeight = (int)(grayHistogram[i] * scale);
                    g.DrawLine(Pens.Black, i, histogramHeight, i, histogramHeight - barHeight);
                }
            }

            pictureBox.Image?.Dispose();
            pictureBox.Image = histogramBitmap;
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("Please import and process an image first.");
                return;
            }

            // Invert the current state of the processed image.
            processedImage = InvertImage(processedImage);
            picProcessed.Image = processedImage; // Update the picture box to reflect the change.
            isInverted = !isInverted;

            GenerateHistogram(processedImage, picProcessedHistogram);
        }

        private Bitmap InvertImage(Bitmap bmp)
        {
            Bitmap inverted = new Bitmap(bmp.Width, bmp.Height);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpDataOriginal = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bmpDataInverted = inverted.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(bmpDataOriginal.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] rgbInverted = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(bmpDataOriginal.Scan0, rgbValues, 0, bytes);
            bmp.UnlockBits(bmpDataOriginal);

            for (int i = 0; i < rgbValues.Length; i++)
            {
                rgbInverted[i] = (byte)(255 - rgbValues[i]);
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbInverted, 0, bmpDataInverted.Scan0, bytes);
            inverted.UnlockBits(bmpDataInverted);

            return inverted;
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            tbGrayscale.Value = 100;
            cumulativeGrayscale = 100;
            lblGrayscaleValue.Text = "100";

            if (originalImage == null)
            {
                MessageBox.Show("Please import an image first.");
                return;
            }

            Bitmap adjusted = AdjustBrightnessContrastGrayscale(originalImage, cumulativeBrightness, cumulativeContrast, cumulativeGrayscale);
            picProcessed.Image = adjusted;

            GenerateHistogram(adjusted, picProcessedHistogram);
        }

        private void btnHistogramEqualization_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please import and process an image first.");
                return;
            }

            Bitmap equalized = HistogramEqualization(originalImage);
            processedImage?.Dispose();
            processedImage = equalized;
            picProcessed.Image = processedImage;

            GenerateHistogram(equalized, picProcessedHistogram);
        }

        private Bitmap HistogramEqualization(Bitmap bmp)
        {
            Bitmap equalized = new Bitmap(bmp.Width, bmp.Height);

            Bitmap grayscale = ConvertToGrayscale(bmp);

            int[] histogram = new int[256];
            Rectangle rect = new Rectangle(0, 0, grayscale.Width, grayscale.Height);
            BitmapData bmpData = grayscale.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int stride = bmpData.Stride;
            int bytes = Math.Abs(stride) * grayscale.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);
            grayscale.UnlockBits(bmpData);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                byte gray = rgbValues[i];
                histogram[gray]++;
            }

            float[] cdf = new float[256];
            cdf[0] = histogram[0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + histogram[i];
            }
            
            for (int i = 0; i < 256; i++)
            {
                cdf[i] = cdf[i] / cdf[255];
                cdf[i] = cdf[i] * 255;
                if (cdf[i] > 255) cdf[i] = 255;
                if (cdf[i] < 0) cdf[i] = 0;
            }

            BitmapData bmpDataEqualized = equalized.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            byte[] rgbEqualized = new byte[bytes];

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                byte gray = rgbValues[i];
                byte newGray = (byte)cdf[gray];
                rgbEqualized[i] = newGray;
                rgbEqualized[i + 1] = newGray;
                rgbEqualized[i + 2] = newGray;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbEqualized, 0, bmpDataEqualized.Scan0, bytes);
            equalized.UnlockBits(bmpDataEqualized);

            grayscale.Dispose();

            return equalized;
        }

        private void btnSharpen_Click(object sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("Please import and process an image first.");
                return;
            }

            string method = cmbSharpenMethod.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(method))
            {
                MessageBox.Show("Please select a sharpening method.");
                return;
            }

            SharpenType selectedType = SharpenType.Gaussian;

            switch (method)
            {
                case "Gaussian":
                    selectedType = SharpenType.Gaussian;
                    break;
                case "Average":
                    selectedType = SharpenType.Average;
                    break;
                case "Median":
                    selectedType = SharpenType.Median;
                    break;
                default:
                    MessageBox.Show("Unknown sharpening method selected.");
                    return;
            }

            Bitmap sharpened = SharpenImage(processedImage, selectedType);
            processedImage?.Dispose();
            processedImage = sharpened;
            picProcessed.Image = processedImage;
            
            GenerateHistogram(sharpened, picProcessedHistogram);
        }

        private enum SharpenType
        {
            Gaussian,
            Average,
            Median
        }

        private Bitmap SharpenImage(Bitmap bmp, SharpenType type)
        {
            Bitmap sharpened = new Bitmap(bmp.Width, bmp.Height);

            switch (type)
            {
                case SharpenType.Gaussian:
                    sharpened = ApplyGaussianSharpen(bmp);
                    break;
                case SharpenType.Average:
                    sharpened = ApplyAverageSharpen(bmp);
                    break;
                case SharpenType.Median:
                    sharpened = ApplyMedianSharpen(bmp);
                    break;
            }

            return sharpened;
        }

        private Bitmap ApplyGaussianSharpen(Bitmap bmp)
        {
            double[,] kernel = {
                { -1, -2, -1 },
                { -2, 16, -2 },
                { -1, -2, -1 }
            };
            return ApplyConvolution(bmp, kernel);
        }

        private Bitmap ApplyAverageSharpen(Bitmap bmp)
        {
            double[,] kernel = {
                { -1, -1, -1 },
                { -1, 9, -1 },
                { -1, -1, -1 }
            };
            return ApplyConvolution(bmp, kernel);
        }

        private Bitmap ApplyMedianSharpen(Bitmap bmp)
        {
            Bitmap sharpened = new Bitmap(bmp.Width, bmp.Height);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpDataOriginal = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bmpDataSharpened = sharpened.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int stride = bmpDataOriginal.Stride;
            int bytes = Math.Abs(stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] rgbSharpened = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(bmpDataOriginal.Scan0, rgbValues, 0, bytes);
            bmp.UnlockBits(bmpDataOriginal);

            for (int y = 1; y < bmp.Height - 1; y++)
            {
                for (int x = 1; x < bmp.Width - 1; x++)
                {
                    int idx = y * stride + x * 3;

                    byte[] neighbors = new byte[9];
                    int count = 0;
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int neighborIdx = (y + ky) * stride + (x + kx) * 3;
                            neighbors[count++] = rgbValues[neighborIdx + 2];
                        }
                    }

                    Array.Sort(neighbors);
                    byte median = neighbors[4];

                    rgbSharpened[idx] = median;
                    rgbSharpened[idx + 1] = median;
                    rgbSharpened[idx + 2] = median;
                }
            }

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (y == 0 || y == bmp.Height - 1 || x == 0 || x == bmp.Width - 1)
                    {
                        int idx = y * stride + x * 3;
                        rgbSharpened[idx] = rgbValues[idx];
                        rgbSharpened[idx + 1] = rgbValues[idx + 1];
                        rgbSharpened[idx + 2] = rgbValues[idx + 2];
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbSharpened, 0, bmpDataSharpened.Scan0, bytes);
            sharpened.UnlockBits(bmpDataSharpened);

            return sharpened;
        }

        private Bitmap ApplyConvolution(Bitmap bmp, double[,] kernel)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            Bitmap output = new Bitmap(width, height);

            int kernelWidth = kernel.GetLength(1);
            int kernelHeight = kernel.GetLength(0);
            int kOffsetX = kernelWidth / 2;
            int kOffsetY = kernelHeight / 2;

            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bmpDataOriginal = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOutput = output.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int stride = bmpDataOriginal.Stride;
            int bytes = Math.Abs(stride) * height;
            byte[] rgbValues = new byte[bytes];
            byte[] rgbOutput = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(bmpDataOriginal.Scan0, rgbValues, 0, bytes);
            bmp.UnlockBits(bmpDataOriginal);

            for (int y = kOffsetY; y < height - kOffsetY; y++)
            {
                for (int x = kOffsetX; x < width - kOffsetX; x++)
                {
                    double sumR = 0;
                    double sumG = 0;
                    double sumB = 0;

                    for (int ky = -kOffsetY; ky <= kOffsetY; ky++)
                    {
                        for (int kx = -kOffsetX; kx <= kOffsetX; kx++)
                        {
                            int pixelY = y + ky;
                            int pixelX = x + kx;
                            int idx = pixelY * stride + pixelX * 3;

                            double kernelValue = kernel[ky + kOffsetY, kx + kOffsetX];
                            sumR += rgbValues[idx + 2] * kernelValue;
                            sumG += rgbValues[idx + 1] * kernelValue;
                            sumB += rgbValues[idx] * kernelValue;
                        }
                    }

                    int outIdx = y * stride + x * 3;
                    rgbOutput[outIdx] = Clamp((int)sumB);
                    rgbOutput[outIdx + 1] = Clamp((int)sumG);
                    rgbOutput[outIdx + 2] = Clamp((int)sumR);
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y < kOffsetY || y >= height - kOffsetY || x < kOffsetX || x >= width - kOffsetX)
                    {
                        int idx = y * stride + x * 3;
                        rgbOutput[idx] = rgbValues[idx];
                        rgbOutput[idx + 1] = rgbValues[idx + 1];
                        rgbOutput[idx + 2] = rgbValues[idx + 2];
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbOutput, 0, bmpDataOutput.Scan0, bytes);
            output.UnlockBits(bmpDataOutput);

            return output;
        }

        private void btnEdgeDetection_Click(object sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("Please import and process an image first.");
                return;
            }

            Bitmap edges = EdgeDetection(processedImage);
            processedImage?.Dispose();
            processedImage = edges;
            picProcessed.Image = edges;

            GenerateHistogram(edges, picProcessedHistogram);
        }

        private Bitmap EdgeDetection(Bitmap bmp)
        {
            Bitmap grayscale = ConvertToGrayscale(bmp);
            Bitmap edges = new Bitmap(grayscale.Width, grayscale.Height);

            // Sobel kernels
            int[,] gx = {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            int[,] gy = {
                { -1, -2, -1 },
                {  0,  0,  0 },
                {  1,  2,  1 }
            };

            Rectangle rect = new Rectangle(0, 0, grayscale.Width, grayscale.Height);
            BitmapData bmpDataOriginal = grayscale.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bmpDataEdges = edges.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int stride = bmpDataOriginal.Stride;
            int bytes = Math.Abs(stride) * grayscale.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] rgbEdges = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(bmpDataOriginal.Scan0, rgbValues, 0, bytes);
            grayscale.UnlockBits(bmpDataOriginal);

            for (int y = 1; y < grayscale.Height - 1; y++)
            {
                for (int x = 1; x < grayscale.Width - 1; x++)
                {
                    double pixelX = 0;
                    double pixelY = 0;

                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int idx = (y + ky) * stride + (x + kx) * 3;
                            byte gray = rgbValues[idx];
                            pixelX += gx[ky + 1, kx + 1] * gray;
                            pixelY += gy[ky + 1, kx + 1] * gray;
                        }
                    }

                    double magnitude = Math.Sqrt(pixelX * pixelX + pixelY * pixelY);
                    byte edgeValue = Clamp((int)magnitude);

                    int outIdx = y * stride + x * 3;
                    rgbEdges[outIdx] = edgeValue;
                    rgbEdges[outIdx + 1] = edgeValue;
                    rgbEdges[outIdx + 2] = edgeValue;
                }
            }

            for (int y = 0; y < grayscale.Height; y++)
            {
                for (int x = 0; x < grayscale.Width; x++)
                {
                    if (y == 0 || y == grayscale.Height - 1 || x == 0 || x == grayscale.Width - 1)
                    {
                        int idx = y * stride + x * 3;
                        rgbEdges[idx] = rgbValues[idx];
                        rgbEdges[idx + 1] = rgbValues[idx + 1];
                        rgbEdges[idx + 2] = rgbValues[idx + 2];
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbEdges, 0, bmpDataEdges.Scan0, bytes);
            edges.UnlockBits(bmpDataEdges);

            grayscale.Dispose();

            return edges;
        }

        private void btnDenoise_Click(object sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("Please import and process an image first.");
                return;
            }

            Bitmap denoised = DenoiseImage(processedImage);
            processedImage?.Dispose();
            processedImage = denoised;
            picProcessed.Image = denoised;

            GenerateHistogram(denoised, picProcessedHistogram);
        }

        private Bitmap DenoiseImage(Bitmap bmp)
        {
            return ApplyMedianSharpen(bmp);
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("Please import and process an image first.");
                return;
            }

            string method = cmbBlurMethod.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(method))
            {
                MessageBox.Show("Please select a blurring method.");
                return;
            }

            BlurType selectedType = BlurType.Gaussian;

            switch (method)
            {
                case "Gaussian":
                    selectedType = BlurType.Gaussian;
                    break;
                case "Average":
                    selectedType = BlurType.Average;
                    break;
                case "Median":
                    selectedType = BlurType.Median;
                    break;
                default:
                    MessageBox.Show("Unknown blurring method selected.");
                    return;
            }

            Bitmap blurred = BlurImage(processedImage, selectedType);
            processedImage?.Dispose();
            processedImage = blurred;
            picProcessed.Image = processedImage;

            GenerateHistogram(blurred, picProcessedHistogram);
        }

        private enum BlurType
        {
            Gaussian,
            Average,
            Median
        }

        private Bitmap BlurImage(Bitmap bmp, BlurType type)
        {
            Bitmap blurred = new Bitmap(bmp.Width, bmp.Height);

            switch (type)
            {
                case BlurType.Gaussian:
                    blurred = ApplyGaussianBlur(bmp);
                    break;
                case BlurType.Average:
                    blurred = ApplyAverageBlur(bmp);
                    break;
                case BlurType.Median:
                    blurred = ApplyMedianBlur(bmp);
                    break;
            }

            return blurred;
        }

        private Bitmap ApplyGaussianBlur(Bitmap bmp)
        {
            double[,] kernel = {
                { 1,  4,  7,  4, 1 },
                { 4, 16, 26, 16, 4 },
                { 7, 26, 41, 26, 7 },
                { 4, 16, 26, 16, 4 },
                { 1,  4,  7,  4, 1 }
            };
            double kernelSum = 273;
            for (int i = 0; i < kernel.GetLength(0); i++)
                for (int j = 0; j < kernel.GetLength(1); j++)
                    kernel[i, j] /= kernelSum;

            return ApplyConvolution(bmp, kernel);
        }

        private Bitmap ApplyAverageBlur(Bitmap bmp)
        {
            double[,] kernel = {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            for (int i = 0; i < kernel.GetLength(0); i++)
                for (int j = 0; j < kernel.GetLength(1); j++)
                    kernel[i, j] /= 9;

            return ApplyConvolution(bmp, kernel);
        }

        private Bitmap ApplyMedianBlur(Bitmap bmp)
        {
            Bitmap blurred = new Bitmap(bmp.Width, bmp.Height);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpDataOriginal = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bmpDataBlurred = blurred.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int stride = bmpDataOriginal.Stride;
            int bytes = Math.Abs(stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] rgbBlurred = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(bmpDataOriginal.Scan0, rgbValues, 0, bytes);
            bmp.UnlockBits(bmpDataOriginal);

            for (int y = 1; y < bmp.Height - 1; y++)
            {
                for (int x = 1; x < bmp.Width - 1; x++)
                {
                    int idx = y * stride + x * 3;

                    // Ambil nilai RGB dari piksel tetangga
                    byte[] neighborsR = new byte[9];
                    byte[] neighborsG = new byte[9];
                    byte[] neighborsB = new byte[9];
                    int count = 0;
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int neighborIdx = (y + ky) * stride + (x + kx) * 3;
                            neighborsR[count] = rgbValues[neighborIdx + 2];
                            neighborsG[count] = rgbValues[neighborIdx + 1];
                            neighborsB[count] = rgbValues[neighborIdx];
                            count++;
                        }
                    }

                    Array.Sort(neighborsR);
                    Array.Sort(neighborsG);
                    Array.Sort(neighborsB);

                    byte medianR = neighborsR[4];
                    byte medianG = neighborsG[4];
                    byte medianB = neighborsB[4];

                    rgbBlurred[idx] = medianB;
                    rgbBlurred[idx + 1] = medianG;
                    rgbBlurred[idx + 2] = medianR;
                }
            }

            // Copy border pixels as is
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (y == 0 || y == bmp.Height - 1 || x == 0 || x == bmp.Width - 1)
                    {
                        int idx = y * stride + x * 3;
                        rgbBlurred[idx] = rgbValues[idx];
                        rgbBlurred[idx + 1] = rgbValues[idx + 1];
                        rgbBlurred[idx + 2] = rgbValues[idx + 2];
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbBlurred, 0, bmpDataBlurred.Scan0, bytes);
            blurred.UnlockBits(bmpDataBlurred);

            return blurred;
        }

        private Bitmap ConvertToGrayscale(Bitmap bmp)
        {
            Bitmap grayscale = new Bitmap(bmp.Width, bmp.Height);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpDataOriginal = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bmpDataGrayscale = grayscale.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(bmpDataOriginal.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] rgbGrayscale = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(bmpDataOriginal.Scan0, rgbValues, 0, bytes);
            bmp.UnlockBits(bmpDataOriginal);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                byte b = rgbValues[i];
                byte g = rgbValues[i + 1];
                byte r = rgbValues[i + 2];
                byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);
                rgbGrayscale[i] = gray;
                rgbGrayscale[i + 1] = gray;
                rgbGrayscale[i + 2] = gray;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbGrayscale, 0, bmpDataGrayscale.Scan0, bytes);
            grayscale.UnlockBits(bmpDataGrayscale);

            return grayscale;
        }
    }
}
