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
        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.Label lblBrightnessValue;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.Label lblContrastValue;
        private System.Windows.Forms.TrackBar tbGrayscale;
        private System.Windows.Forms.Label lblGrayscaleValue;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnReset;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnImport = new System.Windows.Forms.Button();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picProcessed = new System.Windows.Forms.PictureBox();
            this.picOriginalHistogram = new System.Windows.Forms.PictureBox();
            this.picProcessedHistogram = new System.Windows.Forms.PictureBox();
            this.lblGrayscaleValue = new System.Windows.Forms.Label();
            this.tbGrayscale = new System.Windows.Forms.TrackBar();
            this.lblContrastValue = new System.Windows.Forms.Label();
            this.lblBrightnessValue = new System.Windows.Forms.Label();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDenoise = new System.Windows.Forms.Button();
            this.btnEdgeDetection = new System.Windows.Forms.Button();
            this.btnBlur = new System.Windows.Forms.Button();
            this.cmbBlurMethod = new System.Windows.Forms.ComboBox();
            this.btnSharpen = new System.Windows.Forms.Button();
            this.cmbSharpenMethod = new System.Windows.Forms.ComboBox();
            this.btnHistogramEqualization = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginalHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessedHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGrayscale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(112, 57);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(200, 130);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import \r\nImage";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picOriginal.BackgroundImage")));
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginal.Location = new System.Drawing.Point(116, 330);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(262, 149);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 1;
            this.picOriginal.TabStop = false;
            // 
            // picProcessed
            // 
            this.picProcessed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picProcessed.BackgroundImage")));
            this.picProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProcessed.Location = new System.Drawing.Point(492, 322);
            this.picProcessed.Name = "picProcessed";
            this.picProcessed.Size = new System.Drawing.Size(263, 150);
            this.picProcessed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProcessed.TabIndex = 2;
            this.picProcessed.TabStop = false;
            // 
            // picOriginalHistogram
            // 
            this.picOriginalHistogram.BackColor = System.Drawing.Color.White;
            this.picOriginalHistogram.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picOriginalHistogram.BackgroundImage")));
            this.picOriginalHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginalHistogram.Location = new System.Drawing.Point(101, 557);
            this.picOriginalHistogram.Name = "picOriginalHistogram";
            this.picOriginalHistogram.Size = new System.Drawing.Size(288, 191);
            this.picOriginalHistogram.TabIndex = 3;
            this.picOriginalHistogram.TabStop = false;
            // 
            // picProcessedHistogram
            // 
            this.picProcessedHistogram.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picProcessedHistogram.BackgroundImage")));
            this.picProcessedHistogram.Location = new System.Drawing.Point(479, 557);
            this.picProcessedHistogram.Name = "picProcessedHistogram";
            this.picProcessedHistogram.Size = new System.Drawing.Size(287, 191);
            this.picProcessedHistogram.TabIndex = 4;
            this.picProcessedHistogram.TabStop = false;
            // 
            // lblGrayscaleValue
            // 
            this.lblGrayscaleValue.AutoSize = true;
            this.lblGrayscaleValue.Location = new System.Drawing.Point(1205, 515);
            this.lblGrayscaleValue.Name = "lblGrayscaleValue";
            this.lblGrayscaleValue.Size = new System.Drawing.Size(14, 16);
            this.lblGrayscaleValue.TabIndex = 9;
            this.lblGrayscaleValue.Text = "0";
            // 
            // tbGrayscale
            // 
            this.tbGrayscale.Location = new System.Drawing.Point(951, 499);
            this.tbGrayscale.Maximum = 100;
            this.tbGrayscale.Name = "tbGrayscale";
            this.tbGrayscale.Size = new System.Drawing.Size(244, 56);
            this.tbGrayscale.TabIndex = 7;
            this.tbGrayscale.TickFrequency = 10;
            this.tbGrayscale.Scroll += new System.EventHandler(this.tbGrayscale_Scroll);
            // 
            // lblContrastValue
            // 
            this.lblContrastValue.AutoSize = true;
            this.lblContrastValue.Location = new System.Drawing.Point(1205, 432);
            this.lblContrastValue.Name = "lblContrastValue";
            this.lblContrastValue.Size = new System.Drawing.Size(28, 16);
            this.lblContrastValue.TabIndex = 6;
            this.lblContrastValue.Text = "100";
            // 
            // lblBrightnessValue
            // 
            this.lblBrightnessValue.AutoSize = true;
            this.lblBrightnessValue.Location = new System.Drawing.Point(1205, 346);
            this.lblBrightnessValue.Name = "lblBrightnessValue";
            this.lblBrightnessValue.Size = new System.Drawing.Size(14, 16);
            this.lblBrightnessValue.TabIndex = 5;
            this.lblBrightnessValue.Text = "0";
            // 
            // tbContrast
            // 
            this.tbContrast.Location = new System.Drawing.Point(952, 416);
            this.tbContrast.Maximum = 200;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(243, 56);
            this.tbContrast.TabIndex = 4;
            this.tbContrast.TickFrequency = 20;
            this.tbContrast.Value = 100;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbBrightness
            // 
            this.tbBrightness.Location = new System.Drawing.Point(952, 332);
            this.tbBrightness.Maximum = 100;
            this.tbBrightness.Minimum = -100;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(243, 56);
            this.tbBrightness.TabIndex = 1;
            this.tbBrightness.TickFrequency = 20;
            this.tbBrightness.Scroll += new System.EventHandler(this.tbBrightness_Scroll);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.GreenYellow;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(1272, 459);
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
            this.btnReset.Location = new System.Drawing.Point(1272, 378);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 37);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDenoise
            // 
            this.btnDenoise.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDenoise.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDenoise.Location = new System.Drawing.Point(1005, 589);
            this.btnDenoise.Name = "btnDenoise";
            this.btnDenoise.Size = new System.Drawing.Size(150, 30);
            this.btnDenoise.TabIndex = 8;
            this.btnDenoise.Text = "Denoise";
            this.btnDenoise.UseVisualStyleBackColor = false;
            this.btnDenoise.Click += new System.EventHandler(this.btnDenoise_Click);
            // 
            // btnEdgeDetection
            // 
            this.btnEdgeDetection.BackColor = System.Drawing.Color.DarkCyan;
            this.btnEdgeDetection.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEdgeDetection.Location = new System.Drawing.Point(821, 589);
            this.btnEdgeDetection.Name = "btnEdgeDetection";
            this.btnEdgeDetection.Size = new System.Drawing.Size(150, 30);
            this.btnEdgeDetection.TabIndex = 6;
            this.btnEdgeDetection.Text = "Edge Detection";
            this.btnEdgeDetection.UseVisualStyleBackColor = false;
            this.btnEdgeDetection.Click += new System.EventHandler(this.btnEdgeDetection_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBlur.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBlur.Location = new System.Drawing.Point(1005, 700);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(150, 30);
            this.btnBlur.TabIndex = 7;
            this.btnBlur.Text = "Blur";
            this.btnBlur.UseVisualStyleBackColor = false;
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // cmbBlurMethod
            // 
            this.cmbBlurMethod.BackColor = System.Drawing.Color.DarkCyan;
            this.cmbBlurMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlurMethod.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbBlurMethod.FormattingEnabled = true;
            this.cmbBlurMethod.Items.AddRange(new object[] {
            "Gaussian",
            "Average",
            "Median"});
            this.cmbBlurMethod.Location = new System.Drawing.Point(1171, 700);
            this.cmbBlurMethod.Name = "cmbBlurMethod";
            this.cmbBlurMethod.Size = new System.Drawing.Size(100, 24);
            this.cmbBlurMethod.TabIndex = 6;
            // 
            // btnSharpen
            // 
            this.btnSharpen.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSharpen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSharpen.Location = new System.Drawing.Point(1005, 646);
            this.btnSharpen.Name = "btnSharpen";
            this.btnSharpen.Size = new System.Drawing.Size(150, 30);
            this.btnSharpen.TabIndex = 5;
            this.btnSharpen.Text = "Sharpen";
            this.btnSharpen.UseVisualStyleBackColor = false;
            this.btnSharpen.Click += new System.EventHandler(this.btnSharpen_Click);
            // 
            // cmbSharpenMethod
            // 
            this.cmbSharpenMethod.BackColor = System.Drawing.Color.DarkCyan;
            this.cmbSharpenMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSharpenMethod.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbSharpenMethod.FormattingEnabled = true;
            this.cmbSharpenMethod.Items.AddRange(new object[] {
            "Gaussian",
            "Average",
            "Median"});
            this.cmbSharpenMethod.Location = new System.Drawing.Point(1171, 652);
            this.cmbSharpenMethod.Name = "cmbSharpenMethod";
            this.cmbSharpenMethod.Size = new System.Drawing.Size(100, 24);
            this.cmbSharpenMethod.TabIndex = 4;
            // 
            // btnHistogramEqualization
            // 
            this.btnHistogramEqualization.BackColor = System.Drawing.Color.DarkCyan;
            this.btnHistogramEqualization.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHistogramEqualization.Location = new System.Drawing.Point(821, 700);
            this.btnHistogramEqualization.Name = "btnHistogramEqualization";
            this.btnHistogramEqualization.Size = new System.Drawing.Size(150, 30);
            this.btnHistogramEqualization.TabIndex = 2;
            this.btnHistogramEqualization.Text = "Histogram Equalization";
            this.btnHistogramEqualization.UseVisualStyleBackColor = false;
            this.btnHistogramEqualization.Click += new System.EventHandler(this.btnHistogramEqualization_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.BackColor = System.Drawing.Color.DarkCyan;
            this.btnInvert.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInvert.Location = new System.Drawing.Point(821, 646);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(150, 30);
            this.btnInvert.TabIndex = 0;
            this.btnInvert.Text = "Invert";
            this.btnInvert.UseVisualStyleBackColor = false;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(1112, 58);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(200, 130);
            this.btn_export.TabIndex = 9;
            this.btn_export.Text = "Export Image";
            this.btn_export.UseMnemonic = false;
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // Form1
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Ivory;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1422, 763);
            this.Controls.Add(this.cmbBlurMethod);
            this.Controls.Add(this.btnBlur);
            this.Controls.Add(this.btnDenoise);
            this.Controls.Add(this.lblGrayscaleValue);
            this.Controls.Add(this.cmbSharpenMethod);
            this.Controls.Add(this.btnSharpen);
            this.Controls.Add(this.btnEdgeDetection);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.lblContrastValue);
            this.Controls.Add(this.tbGrayscale);
            this.Controls.Add(this.lblBrightnessValue);
            this.Controls.Add(this.btnHistogramEqualization);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tbContrast);
            this.Controls.Add(this.picProcessedHistogram);
            this.Controls.Add(this.tbBrightness);
            this.Controls.Add(this.picOriginalHistogram);
            this.Controls.Add(this.picProcessed);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.btnImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Digital Image Processing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginalHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessedHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGrayscale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_export;
    }
}
