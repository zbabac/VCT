namespace VTC
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panelInfo = new System.Windows.Forms.Panel();
            this.groupBoxFileInfo = new System.Windows.Forms.GroupBox();
            this.labelFileName2 = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFormat2 = new System.Windows.Forms.Label();
            this.labelBitrate = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelSize2 = new System.Windows.Forms.Label();
            this.labelDuration2 = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelVidStreams = new System.Windows.Forms.Label();
            this.labelAudStreams = new System.Windows.Forms.Label();
            this.labelSubStreams = new System.Windows.Forms.Label();
            this.richTextBoxVideoStr = new System.Windows.Forms.RichTextBox();
            this.panelInfo.SuspendLayout();
            this.groupBoxFileInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            this.panelInfo.AutoScroll = true;
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.groupBoxFileInfo);
            this.panelInfo.Controls.Add(this.pictureBox1);
            this.panelInfo.Location = new System.Drawing.Point(399, 12);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(293, 465);
            this.panelInfo.TabIndex = 0;
            // 
            // groupBoxFileInfo
            // 
            this.groupBoxFileInfo.Controls.Add(this.labelFileName2);
            this.groupBoxFileInfo.Controls.Add(this.labelFormat);
            this.groupBoxFileInfo.Controls.Add(this.label1);
            this.groupBoxFileInfo.Controls.Add(this.labelFormat2);
            this.groupBoxFileInfo.Controls.Add(this.labelBitrate);
            this.groupBoxFileInfo.Controls.Add(this.labelDuration);
            this.groupBoxFileInfo.Controls.Add(this.labelSize2);
            this.groupBoxFileInfo.Controls.Add(this.labelDuration2);
            this.groupBoxFileInfo.Controls.Add(this.labelSize);
            this.groupBoxFileInfo.Location = new System.Drawing.Point(6, 236);
            this.groupBoxFileInfo.Name = "groupBoxFileInfo";
            this.groupBoxFileInfo.Size = new System.Drawing.Size(278, 222);
            this.groupBoxFileInfo.TabIndex = 11;
            this.groupBoxFileInfo.TabStop = false;
            this.groupBoxFileInfo.Text = "File Details";
            // 
            // labelFileName2
            // 
            this.labelFileName2.AutoSize = true;
            this.labelFileName2.Location = new System.Drawing.Point(6, 27);
            this.labelFileName2.Name = "labelFileName2";
            this.labelFileName2.Size = new System.Drawing.Size(36, 17);
            this.labelFileName2.TabIndex = 2;
            this.labelFileName2.Text = "path";
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Location = new System.Drawing.Point(6, 67);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(52, 17);
            this.labelFormat.TabIndex = 3;
            this.labelFormat.Text = "Format";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "xxxx kb/s";
            // 
            // labelFormat2
            // 
            this.labelFormat2.AutoSize = true;
            this.labelFormat2.Location = new System.Drawing.Point(91, 67);
            this.labelFormat2.Name = "labelFormat2";
            this.labelFormat2.Size = new System.Drawing.Size(87, 17);
            this.labelFormat2.TabIndex = 4;
            this.labelFormat2.Text = "format string";
            // 
            // labelBitrate
            // 
            this.labelBitrate.AutoSize = true;
            this.labelBitrate.Location = new System.Drawing.Point(6, 189);
            this.labelBitrate.Name = "labelBitrate";
            this.labelBitrate.Size = new System.Drawing.Size(49, 17);
            this.labelBitrate.TabIndex = 9;
            this.labelBitrate.Text = "Bitrate";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(6, 111);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(62, 17);
            this.labelDuration.TabIndex = 5;
            this.labelDuration.Text = "Duration";
            // 
            // labelSize2
            // 
            this.labelSize2.AutoSize = true;
            this.labelSize2.Location = new System.Drawing.Point(91, 151);
            this.labelSize2.Name = "labelSize2";
            this.labelSize2.Size = new System.Drawing.Size(50, 17);
            this.labelSize2.TabIndex = 8;
            this.labelSize2.Text = "xxx MB";
            // 
            // labelDuration2
            // 
            this.labelDuration2.AutoSize = true;
            this.labelDuration2.Location = new System.Drawing.Point(91, 111);
            this.labelDuration2.Name = "labelDuration2";
            this.labelDuration2.Size = new System.Drawing.Size(68, 17);
            this.labelDuration2.TabIndex = 6;
            this.labelDuration2.Text = "hh:mm:ss";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(6, 151);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(59, 17);
            this.labelSize.TabIndex = 7;
            this.labelSize.Text = "File size";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.InitialImage = global::VTC.Properties.Resources.splash;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelVidStreams, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelAudStreams, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSubStreams, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxVideoStr, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.5625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.4375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 465);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelVidStreams
            // 
            this.labelVidStreams.AutoSize = true;
            this.labelVidStreams.Location = new System.Drawing.Point(5, 2);
            this.labelVidStreams.Name = "labelVidStreams";
            this.labelVidStreams.Size = new System.Drawing.Size(93, 17);
            this.labelVidStreams.TabIndex = 0;
            this.labelVidStreams.Text = "Video Stream";
            // 
            // labelAudStreams
            // 
            this.labelAudStreams.AutoSize = true;
            this.labelAudStreams.Location = new System.Drawing.Point(5, 140);
            this.labelAudStreams.Name = "labelAudStreams";
            this.labelAudStreams.Size = new System.Drawing.Size(100, 17);
            this.labelAudStreams.TabIndex = 1;
            this.labelAudStreams.Text = "Audio Streams";
            // 
            // labelSubStreams
            // 
            this.labelSubStreams.AutoSize = true;
            this.labelSubStreams.Location = new System.Drawing.Point(5, 296);
            this.labelSubStreams.Name = "labelSubStreams";
            this.labelSubStreams.Size = new System.Drawing.Size(111, 17);
            this.labelSubStreams.TabIndex = 2;
            this.labelSubStreams.Text = "Subtitle Streams";
            // 
            // richTextBoxVideoStr
            // 
            this.richTextBoxVideoStr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxVideoStr.Location = new System.Drawing.Point(2, 33);
            this.richTextBoxVideoStr.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxVideoStr.Name = "richTextBoxVideoStr";
            this.richTextBoxVideoStr.ReadOnly = true;
            this.richTextBoxVideoStr.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxVideoStr.Size = new System.Drawing.Size(384, 96);
            this.richTextBoxVideoStr.TabIndex = 3;
            this.richTextBoxVideoStr.Text = "Stream No. x\\nFrame size\\t1280x720";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 483);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form2";
            this.panelInfo.ResumeLayout(false);
            this.groupBoxFileInfo.ResumeLayout(false);
            this.groupBoxFileInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBitrate;
        private System.Windows.Forms.Label labelSize2;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelDuration2;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelFormat2;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Label labelFileName2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxFileInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelVidStreams;
        private System.Windows.Forms.Label labelAudStreams;
        private System.Windows.Forms.Label labelSubStreams;
        private System.Windows.Forms.RichTextBox richTextBoxVideoStr;
    }
}