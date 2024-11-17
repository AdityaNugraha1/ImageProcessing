namespace ImageProcessing
{
    partial class Form1
    {
 
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picProcessed;
        private System.Windows.Forms.PictureBox picOriginalHistogram;
        private System.Windows.Forms.PictureBox picProcessedHistogram;
        private System.Windows.Forms.GroupBox groupBoxAdjustments;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.Label lblBrightnessValue;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.Label lblContrastValue;
        private System.Windows.Forms.TrackBar tbGrayscale;
        private System.Windows.Forms.Label lblGrayscale;
        private System.Windows.Forms.Label lblGrayscaleValue;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBoxOperations;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Button btnHistogramEqualization;
        private System.Windows.Forms.ComboBox cmbSharpenMethod;
        private System.Windows.Forms.Button btnSharpen;
        private System.Windows.Forms.ComboBox cmbBlurMethod;
        private System.Windows.Forms.Button btnBlur;
        private System.Windows.Forms.Button btnEdgeDetection;
        private System.Windows.Forms.Button btnDenoise;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                originalImage?.Dispose();
                processedImage?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.btnImport = new System.Windows.Forms.Button();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picProcessed = new System.Windows.Forms.PictureBox();
            this.picOriginalHistogram = new System.Windows.Forms.PictureBox();
            this.picProcessedHistogram = new System.Windows.Forms.PictureBox();
            this.groupBoxAdjustments = new System.Windows.Forms.GroupBox();
            this.lblGrayscaleValue = new System.Windows.Forms.Label();
            this.lblGrayscale = new System.Windows.Forms.Label();
            this.tbGrayscale = new System.Windows.Forms.TrackBar();
            this.lblContrastValue = new System.Windows.Forms.Label();
            this.lblBrightnessValue = new System.Windows.Forms.Label();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.lblContrast = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBoxOperations = new System.Windows.Forms.GroupBox();
            this.btnDenoise = new System.Windows.Forms.Button();
            this.btnEdgeDetection = new System.Windows.Forms.Button();
            this.btnBlur = new System.Windows.Forms.Button();
            this.cmbBlurMethod = new System.Windows.Forms.ComboBox();
            this.btnSharpen = new System.Windows.Forms.Button();
            this.cmbSharpenMethod = new System.Windows.Forms.ComboBox();
            this.btnHistogramEqualization = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginalHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessedHistogram)).BeginInit();
            this.groupBoxAdjustments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGrayscale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            this.groupBoxOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(581, 171);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(120, 104);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import \r\nImage";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginal.Location = new System.Drawing.Point(184, 69);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(380, 250);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 1;
            this.picOriginal.TabStop = false;
            // 
            // picProcessed
            // 
            this.picProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProcessed.Location = new System.Drawing.Point(719, 69);
            this.picProcessed.Name = "picProcessed";
            this.picProcessed.Size = new System.Drawing.Size(380, 250);
            this.picProcessed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProcessed.TabIndex = 2;
            this.picProcessed.TabStop = false;
            // 
            // picOriginalHistogram
            // 
            this.picOriginalHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginalHistogram.Location = new System.Drawing.Point(184, 346);
            this.picOriginalHistogram.Name = "picOriginalHistogram";
            this.picOriginalHistogram.Size = new System.Drawing.Size(380, 150);
            this.picOriginalHistogram.TabIndex = 3;
            this.picOriginalHistogram.TabStop = false;
            // 
            // picProcessedHistogram
            // 
            this.picProcessedHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProcessedHistogram.Location = new System.Drawing.Point(719, 346);
            this.picProcessedHistogram.Name = "picProcessedHistogram";
            this.picProcessedHistogram.Size = new System.Drawing.Size(380, 150);
            this.picProcessedHistogram.TabIndex = 4;
            this.picProcessedHistogram.TabStop = false;
            // 
            // groupBoxAdjustments
            // 
            this.groupBoxAdjustments.Controls.Add(this.lblGrayscaleValue);
            this.groupBoxAdjustments.Controls.Add(this.lblGrayscale);
            this.groupBoxAdjustments.Controls.Add(this.tbGrayscale);
            this.groupBoxAdjustments.Controls.Add(this.lblContrastValue);
            this.groupBoxAdjustments.Controls.Add(this.lblBrightnessValue);
            this.groupBoxAdjustments.Controls.Add(this.tbContrast);
            this.groupBoxAdjustments.Controls.Add(this.tbBrightness);
            this.groupBoxAdjustments.Controls.Add(this.lblContrast);
            this.groupBoxAdjustments.Controls.Add(this.lblBrightness);
            this.groupBoxAdjustments.Controls.Add(this.btnApply);
            this.groupBoxAdjustments.Controls.Add(this.btnReset);
            this.groupBoxAdjustments.Location = new System.Drawing.Point(284, 557);
            this.groupBoxAdjustments.Name = "groupBoxAdjustments";
            this.groupBoxAdjustments.Size = new System.Drawing.Size(776, 137);
            this.groupBoxAdjustments.TabIndex = 5;
            this.groupBoxAdjustments.TabStop = false;
            this.groupBoxAdjustments.Text = "Adjustments";
            // 
            // lblGrayscaleValue
            // 
            this.lblGrayscaleValue.AutoSize = true;
            this.lblGrayscaleValue.Location = new System.Drawing.Point(420, 105);
            this.lblGrayscaleValue.Name = "lblGrayscaleValue";
            this.lblGrayscaleValue.Size = new System.Drawing.Size(14, 16);
            this.lblGrayscaleValue.TabIndex = 9;
            this.lblGrayscaleValue.Text = "0";
            // 
            // lblGrayscale
            // 
            this.lblGrayscale.AutoSize = true;
            this.lblGrayscale.Location = new System.Drawing.Point(20, 105);
            this.lblGrayscale.Name = "lblGrayscale";
            this.lblGrayscale.Size = new System.Drawing.Size(69, 16);
            this.lblGrayscale.TabIndex = 8;
            this.lblGrayscale.Text = "Grayscale";
            // 
            // tbGrayscale
            // 
            this.tbGrayscale.Location = new System.Drawing.Point(100, 95);
            this.tbGrayscale.Maximum = 100;
            this.tbGrayscale.Name = "tbGrayscale";
            this.tbGrayscale.Size = new System.Drawing.Size(300, 56);
            this.tbGrayscale.TabIndex = 7;
            this.tbGrayscale.TickFrequency = 10;
            this.tbGrayscale.Scroll += new System.EventHandler(this.tbGrayscale_Scroll);
            // 
            // lblContrastValue
            // 
            this.lblContrastValue.AutoSize = true;
            this.lblContrastValue.Location = new System.Drawing.Point(420, 70);
            this.lblContrastValue.Name = "lblContrastValue";
            this.lblContrastValue.Size = new System.Drawing.Size(28, 16);
            this.lblContrastValue.TabIndex = 6;
            this.lblContrastValue.Text = "100";
            // 
            // lblBrightnessValue
            // 
            this.lblBrightnessValue.AutoSize = true;
            this.lblBrightnessValue.Location = new System.Drawing.Point(420, 35);
            this.lblBrightnessValue.Name = "lblBrightnessValue";
            this.lblBrightnessValue.Size = new System.Drawing.Size(14, 16);
            this.lblBrightnessValue.TabIndex = 5;
            this.lblBrightnessValue.Text = "0";
            // 
            // tbContrast
            // 
            this.tbContrast.Location = new System.Drawing.Point(100, 60);
            this.tbContrast.Maximum = 200;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(300, 56);
            this.tbContrast.TabIndex = 4;
            this.tbContrast.TickFrequency = 20;
            this.tbContrast.Value = 100;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbBrightness
            // 
            this.tbBrightness.Location = new System.Drawing.Point(100, 25);
            this.tbBrightness.Maximum = 100;
            this.tbBrightness.Minimum = -100;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(300, 56);
            this.tbBrightness.TabIndex = 1;
            this.tbBrightness.TickFrequency = 20;
            this.tbBrightness.Scroll += new System.EventHandler(this.tbBrightness_Scroll);
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Location = new System.Drawing.Point(20, 70);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(56, 16);
            this.lblContrast.TabIndex = 3;
            this.lblContrast.Text = "Contrast";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(20, 35);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(70, 16);
            this.lblBrightness.TabIndex = 0;
            this.lblBrightness.Text = "Brightness";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.GreenYellow;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(500, 25);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 34);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(500, 65);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 37);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBoxOperations
            // 
            this.groupBoxOperations.Controls.Add(this.btnDenoise);
            this.groupBoxOperations.Controls.Add(this.btnEdgeDetection);
            this.groupBoxOperations.Controls.Add(this.btnBlur);
            this.groupBoxOperations.Controls.Add(this.cmbBlurMethod);
            this.groupBoxOperations.Controls.Add(this.btnSharpen);
            this.groupBoxOperations.Controls.Add(this.cmbSharpenMethod);
            this.groupBoxOperations.Controls.Add(this.btnHistogramEqualization);
            this.groupBoxOperations.Controls.Add(this.btnInvert);
            this.groupBoxOperations.Location = new System.Drawing.Point(284, 706);
            this.groupBoxOperations.Name = "groupBoxOperations";
            this.groupBoxOperations.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxOperations.Size = new System.Drawing.Size(776, 138);
            this.groupBoxOperations.TabIndex = 6;
            this.groupBoxOperations.TabStop = false;
            this.groupBoxOperations.Text = "Image Processing Operations";
            // 
            // btnDenoise
            // 
            this.btnDenoise.Location = new System.Drawing.Point(620, 100);
            this.btnDenoise.Name = "btnDenoise";
            this.btnDenoise.Size = new System.Drawing.Size(140, 30);
            this.btnDenoise.TabIndex = 8;
            this.btnDenoise.Text = "Denoise";
            this.btnDenoise.UseVisualStyleBackColor = true;
            this.btnDenoise.Click += new System.EventHandler(this.btnDenoise_Click);
            // 
            // btnEdgeDetection
            // 
            this.btnEdgeDetection.Location = new System.Drawing.Point(10, 100);
            this.btnEdgeDetection.Name = "btnEdgeDetection";
            this.btnEdgeDetection.Size = new System.Drawing.Size(150, 30);
            this.btnEdgeDetection.TabIndex = 6;
            this.btnEdgeDetection.Text = "Edge Detection";
            this.btnEdgeDetection.UseVisualStyleBackColor = true;
            this.btnEdgeDetection.Click += new System.EventHandler(this.btnEdgeDetection_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.Location = new System.Drawing.Point(400, 100);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(100, 30);
            this.btnBlur.TabIndex = 7;
            this.btnBlur.Text = "Blur";
            this.btnBlur.UseVisualStyleBackColor = true;
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // cmbBlurMethod
            // 
            this.cmbBlurMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlurMethod.FormattingEnabled = true;
            this.cmbBlurMethod.Items.AddRange(new object[] {
            "Gaussian",
            "Average",
            "Median"});
            this.cmbBlurMethod.Location = new System.Drawing.Point(510, 105);
            this.cmbBlurMethod.Name = "cmbBlurMethod";
            this.cmbBlurMethod.Size = new System.Drawing.Size(100, 24);
            this.cmbBlurMethod.TabIndex = 6;
            // 
            // btnSharpen
            // 
            this.btnSharpen.Location = new System.Drawing.Point(400, 25);
            this.btnSharpen.Name = "btnSharpen";
            this.btnSharpen.Size = new System.Drawing.Size(100, 30);
            this.btnSharpen.TabIndex = 5;
            this.btnSharpen.Text = "Sharpen";
            this.btnSharpen.UseVisualStyleBackColor = true;
            this.btnSharpen.Click += new System.EventHandler(this.btnSharpen_Click);
            // 
            // cmbSharpenMethod
            // 
            this.cmbSharpenMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSharpenMethod.FormattingEnabled = true;
            this.cmbSharpenMethod.Items.AddRange(new object[] {
            "Gaussian",
            "Average",
            "Median"});
            this.cmbSharpenMethod.Location = new System.Drawing.Point(510, 30);
            this.cmbSharpenMethod.Name = "cmbSharpenMethod";
            this.cmbSharpenMethod.Size = new System.Drawing.Size(100, 24);
            this.cmbSharpenMethod.TabIndex = 4;
            // 
            // btnHistogramEqualization
            // 
            this.btnHistogramEqualization.Location = new System.Drawing.Point(230, 25);
            this.btnHistogramEqualization.Name = "btnHistogramEqualization";
            this.btnHistogramEqualization.Size = new System.Drawing.Size(160, 30);
            this.btnHistogramEqualization.TabIndex = 2;
            this.btnHistogramEqualization.Text = "Histogram Equalization";
            this.btnHistogramEqualization.UseVisualStyleBackColor = true;
            this.btnHistogramEqualization.Click += new System.EventHandler(this.btnHistogramEqualization_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(10, 25);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(100, 30);
            this.btnInvert.TabIndex = 0;
            this.btnInvert.Text = "Invert";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Foto Asli\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(834, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 38);
            this.label2.TabIndex = 8;
            this.label2.Text = "Foto Hasil";
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(581, 322);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(120, 104);
            this.btn_export.TabIndex = 9;
            this.btn_export.Text = "Export Image";
            this.btn_export.UseMnemonic = false;
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // Form1
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1283, 653);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxOperations);
            this.Controls.Add(this.groupBoxAdjustments);
            this.Controls.Add(this.picProcessedHistogram);
            this.Controls.Add(this.picOriginalHistogram);
            this.Controls.Add(this.picProcessed);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.btnImport);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Digital Image Processing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginalHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessedHistogram)).EndInit();
            this.groupBoxAdjustments.ResumeLayout(false);
            this.groupBoxAdjustments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGrayscale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            this.groupBoxOperations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_export;
    }
}
