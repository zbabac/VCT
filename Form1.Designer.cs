using System;

namespace VTC
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.timerBatch = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxCopyTimePeriod = new System.Windows.Forms.GroupBox();
            this.textBoxCopyDuration = new System.Windows.Forms.TextBox();
            this.labelCopyDuration = new System.Windows.Forms.Label();
            this.checkBoxCopyDuration = new System.Windows.Forms.CheckBox();
            this.textBoxFromTime = new System.Windows.Forms.TextBox();
            this.labelFromTime = new System.Windows.Forms.Label();
            this.groupBoxTransGroupStreams = new System.Windows.Forms.GroupBox();
            this.numericUpDownAudioNr = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVideoNr = new System.Windows.Forms.NumericUpDown();
            this.labelTransAudioNr = new System.Windows.Forms.Label();
            this.labelTransVideoNr = new System.Windows.Forms.Label();
            this.checkBoxKeepExtension = new System.Windows.Forms.CheckBox();
            this.checkBoxTranscodeAllStreams = new System.Windows.Forms.CheckBox();
            this.buttonRemoveTransPath = new System.Windows.Forms.Button();
            this.checkBoxTransRemoveSubtitle = new System.Windows.Forms.CheckBox();
            this.buttonLog2 = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.labelMultiTransFile = new System.Windows.Forms.Label();
            this.buttonMultiTransFile = new System.Windows.Forms.Button();
            this.panelTranscode = new System.Windows.Forms.Panel();
            this.labelOutTransFile = new System.Windows.Forms.Label();
            this.labelInputTransFile = new System.Windows.Forms.Label();
            this.buttonOutTransFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.groupBoxVideoSize = new System.Windows.Forms.GroupBox();
            this.radioButton_No_Video_Resize = new System.Windows.Forms.RadioButton();
            this.radioButton_480p = new System.Windows.Forms.RadioButton();
            this.radioButton_720p = new System.Windows.Forms.RadioButton();
            this.radioButton_1080p = new System.Windows.Forms.RadioButton();
            this.buttonRemoveOutPath = new System.Windows.Forms.Button();
            this.groupBoxSlow = new System.Windows.Forms.GroupBox();
            this.checkBoxSlowFPS = new System.Windows.Forms.CheckBox();
            this.checkBoxSetFPS = new System.Windows.Forms.CheckBox();
            this.labelSlowFPS = new System.Windows.Forms.Label();
            this.textBoxSlowFPS = new System.Windows.Forms.TextBox();
            this.labelFPSout = new System.Windows.Forms.Label();
            this.textBoxFPSout = new System.Windows.Forms.TextBox();
            this.groupBoxCPU = new System.Windows.Forms.GroupBox();
            this.checkBoxH265 = new System.Windows.Forms.CheckBox();
            this.buttonLog = new System.Windows.Forms.Button();
            this.comboBoxAudioStreamNo = new System.Windows.Forms.ComboBox();
            this.labelAudioStream = new System.Windows.Forms.Label();
            this.groupBoxRotate = new System.Windows.Forms.GroupBox();
            this.checkBox90counterclockwise = new System.Windows.Forms.CheckBox();
            this.checkBox90clockwise = new System.Windows.Forms.CheckBox();
            this.checkBox180 = new System.Windows.Forms.CheckBox();
            this.buttonRemoveSubtitle = new System.Windows.Forms.Button();
            this.labelAddSubtitle = new System.Windows.Forms.Label();
            this.buttonAddSubtitle = new System.Windows.Forms.Button();
            this.groupBoxVideoOrAudio = new System.Windows.Forms.GroupBox();
            this.checkBoxAudioOnly = new System.Windows.Forms.CheckBox();
            this.checkBoxVideoOnly = new System.Windows.Forms.CheckBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.labelPreset = new System.Windows.Forms.Label();
            this.labelQuality = new System.Windows.Forms.Label();
            this.labelAudio = new System.Windows.Forms.Label();
            this.comboBoxPreset = new System.Windows.Forms.ComboBox();
            this.comboBoxAudioBitRate = new System.Windows.Forms.ComboBox();
            this.comboBoxQuality = new System.Windows.Forms.ComboBox();
            this.groupBoxAudio = new System.Windows.Forms.GroupBox();
            this.radioButtonCopyAudio = new System.Windows.Forms.RadioButton();
            this.radioButtonMP3 = new System.Windows.Forms.RadioButton();
            this.radioButtonAAC = new System.Windows.Forms.RadioButton();
            this.groupBoxContainer = new System.Windows.Forms.GroupBox();
            this.radioButtonCopyVideo = new System.Windows.Forms.RadioButton();
            this.radioButtonMP4 = new System.Windows.Forms.RadioButton();
            this.radioButtonMKV = new System.Windows.Forms.RadioButton();
            this.labelTextBoxConv = new System.Windows.Forms.Label();
            this.labelOutConvFile = new System.Windows.Forms.Label();
            this.labelInputConvFile = new System.Windows.Forms.Label();
            this.buttonAddBatchConv = new System.Windows.Forms.Button();
            this.buttonMultiConvFiles = new System.Windows.Forms.Button();
            this.panelConvert = new System.Windows.Forms.Panel();
            this.richTextBoxConv = new System.Windows.Forms.RichTextBox();
            this.buttonOutConvFile = new System.Windows.Forms.Button();
            this.buttonInputConvFile = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.richTextBoxStreamCommand = new System.Windows.Forms.RichTextBox();
            this.labelSaveStreamPath = new System.Windows.Forms.Label();
            this.buttonStreamSavePath = new System.Windows.Forms.Button();
            this.buttonCheckStream = new System.Windows.Forms.Button();
            this.buttonLogRec = new System.Windows.Forms.Button();
            this.buttonStartRec = new System.Windows.Forms.Button();
            this.buttonPlayStream = new System.Windows.Forms.Button();
            this.textBoxStream = new System.Windows.Forms.TextBox();
            this.labelStream = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panelBatch = new System.Windows.Forms.Panel();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.buttonUnselectAll = new System.Windows.Forms.Button();
            this.buttonSellectAllQueue = new System.Windows.Forms.Button();
            this.dataGridViewBatch = new System.Windows.Forms.DataGridView();
            this.check_cell = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.no_cell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task_cell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDeleteQueue = new System.Windows.Forms.Button();
            this.buttonCancelBatch = new System.Windows.Forms.Button();
            this.buttonStartQueue = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxCopyTimePeriod.SuspendLayout();
            this.groupBoxTransGroupStreams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAudioNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVideoNr)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBoxVideoSize.SuspendLayout();
            this.groupBoxSlow.SuspendLayout();
            this.groupBoxCPU.SuspendLayout();
            this.groupBoxRotate.SuspendLayout();
            this.groupBoxVideoOrAudio.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            this.groupBoxContainer.SuspendLayout();
            this.panelConvert.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panelBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(7, 3, 1, 3);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            // 
            // timerBatch
            // 
            this.timerBatch.Interval = 1000;
            this.timerBatch.Tick += new System.EventHandler(this.timerBatch_Tick);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Name = "panel1";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBoxCopyTimePeriod);
            this.tabPage1.Controls.Add(this.groupBoxTransGroupStreams);
            this.tabPage1.Controls.Add(this.checkBoxKeepExtension);
            this.tabPage1.Controls.Add(this.checkBoxTranscodeAllStreams);
            this.tabPage1.Controls.Add(this.buttonRemoveTransPath);
            this.tabPage1.Controls.Add(this.checkBoxTransRemoveSubtitle);
            this.tabPage1.Controls.Add(this.buttonLog2);
            this.tabPage1.Controls.Add(this.buttonHelp);
            this.tabPage1.Controls.Add(this.buttonAbout);
            this.tabPage1.Controls.Add(this.labelMultiTransFile);
            this.tabPage1.Controls.Add(this.buttonMultiTransFile);
            this.tabPage1.Controls.Add(this.panelTranscode);
            this.tabPage1.Controls.Add(this.labelOutTransFile);
            this.tabPage1.Controls.Add(this.labelInputTransFile);
            this.tabPage1.Controls.Add(this.buttonOutTransFile);
            this.tabPage1.Name = "tabPage1";
            // 
            // groupBoxCopyTimePeriod
            // 
            this.groupBoxCopyTimePeriod.Controls.Add(this.textBoxCopyDuration);
            this.groupBoxCopyTimePeriod.Controls.Add(this.labelCopyDuration);
            this.groupBoxCopyTimePeriod.Controls.Add(this.checkBoxCopyDuration);
            this.groupBoxCopyTimePeriod.Controls.Add(this.textBoxFromTime);
            this.groupBoxCopyTimePeriod.Controls.Add(this.labelFromTime);
            resources.ApplyResources(this.groupBoxCopyTimePeriod, "groupBoxCopyTimePeriod");
            this.groupBoxCopyTimePeriod.Name = "groupBoxCopyTimePeriod";
            this.groupBoxCopyTimePeriod.TabStop = false;
            // 
            // textBoxCopyDuration
            // 
            resources.ApplyResources(this.textBoxCopyDuration, "textBoxCopyDuration");
            this.textBoxCopyDuration.Name = "textBoxCopyDuration";
            this.textBoxCopyDuration.TextChanged += new System.EventHandler(this.textBoxCopyDuration_TextChanged);
            // 
            // labelCopyDuration
            // 
            resources.ApplyResources(this.labelCopyDuration, "labelCopyDuration");
            this.labelCopyDuration.Name = "labelCopyDuration";
            // 
            // checkBoxCopyDuration
            // 
            resources.ApplyResources(this.checkBoxCopyDuration, "checkBoxCopyDuration");
            this.checkBoxCopyDuration.Name = "checkBoxCopyDuration";
            this.checkBoxCopyDuration.UseVisualStyleBackColor = true;
            this.checkBoxCopyDuration.CheckedChanged += new System.EventHandler(this.checkBoxCopyDuration_CheckedChanged);
            // 
            // textBoxFromTime
            // 
            resources.ApplyResources(this.textBoxFromTime, "textBoxFromTime");
            this.textBoxFromTime.Name = "textBoxFromTime";
            this.textBoxFromTime.TextChanged += new System.EventHandler(this.textBoxFromTime_TextChanged);
            // 
            // labelFromTime
            // 
            resources.ApplyResources(this.labelFromTime, "labelFromTime");
            this.labelFromTime.Name = "labelFromTime";
            // 
            // groupBoxTransGroupStreams
            // 
            this.groupBoxTransGroupStreams.Controls.Add(this.numericUpDownAudioNr);
            this.groupBoxTransGroupStreams.Controls.Add(this.numericUpDownVideoNr);
            this.groupBoxTransGroupStreams.Controls.Add(this.labelTransAudioNr);
            this.groupBoxTransGroupStreams.Controls.Add(this.labelTransVideoNr);
            resources.ApplyResources(this.groupBoxTransGroupStreams, "groupBoxTransGroupStreams");
            this.groupBoxTransGroupStreams.Name = "groupBoxTransGroupStreams";
            this.groupBoxTransGroupStreams.TabStop = false;
            // 
            // numericUpDownAudioNr
            // 
            resources.ApplyResources(this.numericUpDownAudioNr, "numericUpDownAudioNr");
            this.numericUpDownAudioNr.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownAudioNr.Name = "numericUpDownAudioNr";
            // 
            // numericUpDownVideoNr
            // 
            resources.ApplyResources(this.numericUpDownVideoNr, "numericUpDownVideoNr");
            this.numericUpDownVideoNr.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownVideoNr.Name = "numericUpDownVideoNr";
            // 
            // labelTransAudioNr
            // 
            resources.ApplyResources(this.labelTransAudioNr, "labelTransAudioNr");
            this.labelTransAudioNr.Name = "labelTransAudioNr";
            // 
            // labelTransVideoNr
            // 
            resources.ApplyResources(this.labelTransVideoNr, "labelTransVideoNr");
            this.labelTransVideoNr.Name = "labelTransVideoNr";
            // 
            // checkBoxKeepExtension
            // 
            resources.ApplyResources(this.checkBoxKeepExtension, "checkBoxKeepExtension");
            this.checkBoxKeepExtension.Name = "checkBoxKeepExtension";
            this.checkBoxKeepExtension.UseVisualStyleBackColor = true;
            // 
            // checkBoxTranscodeAllStreams
            // 
            resources.ApplyResources(this.checkBoxTranscodeAllStreams, "checkBoxTranscodeAllStreams");
            this.checkBoxTranscodeAllStreams.Name = "checkBoxTranscodeAllStreams";
            this.checkBoxTranscodeAllStreams.UseVisualStyleBackColor = true;
            this.checkBoxTranscodeAllStreams.CheckedChanged += new System.EventHandler(this.checkBoxTranscodeAllStreams_CheckedChanged);
            // 
            // buttonRemoveTransPath
            // 
            resources.ApplyResources(this.buttonRemoveTransPath, "buttonRemoveTransPath");
            this.buttonRemoveTransPath.FlatAppearance.BorderSize = 0;
            this.buttonRemoveTransPath.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonRemoveTransPath.Name = "buttonRemoveTransPath";
            this.buttonRemoveTransPath.UseVisualStyleBackColor = true;
            this.buttonRemoveTransPath.Click += new System.EventHandler(this.buttonRemoveTransPath_Click);
            // 
            // checkBoxTransRemoveSubtitle
            // 
            resources.ApplyResources(this.checkBoxTransRemoveSubtitle, "checkBoxTransRemoveSubtitle");
            this.checkBoxTransRemoveSubtitle.Checked = true;
            this.checkBoxTransRemoveSubtitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTransRemoveSubtitle.Name = "checkBoxTransRemoveSubtitle";
            this.checkBoxTransRemoveSubtitle.UseVisualStyleBackColor = true;
            // 
            // buttonLog2
            // 
            this.buttonLog2.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLog2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.buttonLog2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            resources.ApplyResources(this.buttonLog2, "buttonLog2");
            this.buttonLog2.Name = "buttonLog2";
            this.buttonLog2.UseVisualStyleBackColor = true;
            this.buttonLog2.Click += new System.EventHandler(this.buttonLog2_Click);
            // 
            // buttonHelp
            // 
            resources.ApplyResources(this.buttonHelp, "buttonHelp");
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click_1);
            // 
            // buttonAbout
            // 
            resources.ApplyResources(this.buttonAbout, "buttonAbout");
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // labelMultiTransFile
            // 
            resources.ApplyResources(this.labelMultiTransFile, "labelMultiTransFile");
            this.labelMultiTransFile.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelMultiTransFile.Name = "labelMultiTransFile";
            // 
            // buttonMultiTransFile
            // 
            this.buttonMultiTransFile.AllowDrop = true;
            resources.ApplyResources(this.buttonMultiTransFile, "buttonMultiTransFile");
            this.buttonMultiTransFile.Name = "buttonMultiTransFile";
            this.buttonMultiTransFile.UseVisualStyleBackColor = true;
            this.buttonMultiTransFile.Click += new System.EventHandler(this.buttonMultiTransFile_Click);
            // 
            // panelTranscode
            // 
            resources.ApplyResources(this.panelTranscode, "panelTranscode");
            this.panelTranscode.Name = "panelTranscode";
            // 
            // labelOutTransFile
            // 
            resources.ApplyResources(this.labelOutTransFile, "labelOutTransFile");
            this.labelOutTransFile.Name = "labelOutTransFile";
            // 
            // labelInputTransFile
            // 
            resources.ApplyResources(this.labelInputTransFile, "labelInputTransFile");
            this.labelInputTransFile.Name = "labelInputTransFile";
            // 
            // buttonOutTransFile
            // 
            resources.ApplyResources(this.buttonOutTransFile, "buttonOutTransFile");
            this.buttonOutTransFile.Name = "buttonOutTransFile";
            this.buttonOutTransFile.UseVisualStyleBackColor = true;
            this.buttonOutTransFile.Click += new System.EventHandler(this.buttonOutTransFile_Click);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.buttonPlay);
            this.tabPage2.Controls.Add(this.groupBoxVideoSize);
            this.tabPage2.Controls.Add(this.buttonRemoveOutPath);
            this.tabPage2.Controls.Add(this.groupBoxSlow);
            this.tabPage2.Controls.Add(this.groupBoxCPU);
            this.tabPage2.Controls.Add(this.buttonLog);
            this.tabPage2.Controls.Add(this.comboBoxAudioStreamNo);
            this.tabPage2.Controls.Add(this.labelAudioStream);
            this.tabPage2.Controls.Add(this.groupBoxRotate);
            this.tabPage2.Controls.Add(this.buttonRemoveSubtitle);
            this.tabPage2.Controls.Add(this.labelAddSubtitle);
            this.tabPage2.Controls.Add(this.buttonAddSubtitle);
            this.tabPage2.Controls.Add(this.groupBoxVideoOrAudio);
            this.tabPage2.Controls.Add(this.groupBoxOptions);
            this.tabPage2.Controls.Add(this.groupBoxAudio);
            this.tabPage2.Controls.Add(this.groupBoxContainer);
            this.tabPage2.Controls.Add(this.labelTextBoxConv);
            this.tabPage2.Controls.Add(this.labelOutConvFile);
            this.tabPage2.Controls.Add(this.labelInputConvFile);
            this.tabPage2.Controls.Add(this.buttonAddBatchConv);
            this.tabPage2.Controls.Add(this.buttonMultiConvFiles);
            this.tabPage2.Controls.Add(this.panelConvert);
            this.tabPage2.Controls.Add(this.buttonOutConvFile);
            this.tabPage2.Controls.Add(this.buttonInputConvFile);
            this.tabPage2.Controls.Add(this.buttonInfo);
            this.tabPage2.Name = "tabPage2";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Image = global::VTC.Properties.Resources.play;
            resources.ApplyResources(this.buttonPlay, "buttonPlay");
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // groupBoxVideoSize
            // 
            this.groupBoxVideoSize.Controls.Add(this.radioButton_No_Video_Resize);
            this.groupBoxVideoSize.Controls.Add(this.radioButton_480p);
            this.groupBoxVideoSize.Controls.Add(this.radioButton_720p);
            this.groupBoxVideoSize.Controls.Add(this.radioButton_1080p);
            resources.ApplyResources(this.groupBoxVideoSize, "groupBoxVideoSize");
            this.groupBoxVideoSize.Name = "groupBoxVideoSize";
            this.groupBoxVideoSize.TabStop = false;
            // 
            // radioButton_No_Video_Resize
            // 
            this.radioButton_No_Video_Resize.Checked = true;
            resources.ApplyResources(this.radioButton_No_Video_Resize, "radioButton_No_Video_Resize");
            this.radioButton_No_Video_Resize.Name = "radioButton_No_Video_Resize";
            this.radioButton_No_Video_Resize.TabStop = true;
            this.radioButton_No_Video_Resize.UseVisualStyleBackColor = true;
            this.radioButton_No_Video_Resize.CheckedChanged += new System.EventHandler(this.RadioButton_No_Video_Resize_CheckedChanged);
            // 
            // radioButton_480p
            // 
            resources.ApplyResources(this.radioButton_480p, "radioButton_480p");
            this.radioButton_480p.Name = "radioButton_480p";
            this.radioButton_480p.UseVisualStyleBackColor = true;
            this.radioButton_480p.CheckedChanged += new System.EventHandler(this.RadioButton_480p_CheckedChanged);
            // 
            // radioButton_720p
            // 
            resources.ApplyResources(this.radioButton_720p, "radioButton_720p");
            this.radioButton_720p.Name = "radioButton_720p";
            this.radioButton_720p.UseVisualStyleBackColor = true;
            this.radioButton_720p.CheckedChanged += new System.EventHandler(this.RadioButton_720p_CheckedChanged);
            // 
            // radioButton_1080p
            // 
            resources.ApplyResources(this.radioButton_1080p, "radioButton_1080p");
            this.radioButton_1080p.Name = "radioButton_1080p";
            this.radioButton_1080p.UseVisualStyleBackColor = true;
            this.radioButton_1080p.CheckedChanged += new System.EventHandler(this.RadioButton_1080p_CheckedChanged);
            // 
            // buttonRemoveOutPath
            // 
            resources.ApplyResources(this.buttonRemoveOutPath, "buttonRemoveOutPath");
            this.buttonRemoveOutPath.FlatAppearance.BorderSize = 0;
            this.buttonRemoveOutPath.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonRemoveOutPath.Name = "buttonRemoveOutPath";
            this.buttonRemoveOutPath.UseVisualStyleBackColor = true;
            this.buttonRemoveOutPath.Click += new System.EventHandler(this.buttonRemoveOutPath_Click);
            // 
            // groupBoxSlow
            // 
            this.groupBoxSlow.Controls.Add(this.checkBoxSlowFPS);
            this.groupBoxSlow.Controls.Add(this.checkBoxSetFPS);
            this.groupBoxSlow.Controls.Add(this.labelSlowFPS);
            this.groupBoxSlow.Controls.Add(this.textBoxSlowFPS);
            this.groupBoxSlow.Controls.Add(this.labelFPSout);
            this.groupBoxSlow.Controls.Add(this.textBoxFPSout);
            resources.ApplyResources(this.groupBoxSlow, "groupBoxSlow");
            this.groupBoxSlow.Name = "groupBoxSlow";
            this.groupBoxSlow.TabStop = false;
            // 
            // checkBoxSlowFPS
            // 
            resources.ApplyResources(this.checkBoxSlowFPS, "checkBoxSlowFPS");
            this.checkBoxSlowFPS.Name = "checkBoxSlowFPS";
            this.checkBoxSlowFPS.UseVisualStyleBackColor = true;
            this.checkBoxSlowFPS.CheckedChanged += new System.EventHandler(this.checkBoxSlowFPS_CheckedChanged);
            // 
            // checkBoxSetFPS
            // 
            resources.ApplyResources(this.checkBoxSetFPS, "checkBoxSetFPS");
            this.checkBoxSetFPS.Name = "checkBoxSetFPS";
            this.checkBoxSetFPS.UseVisualStyleBackColor = true;
            this.checkBoxSetFPS.CheckedChanged += new System.EventHandler(this.checkBoxSetFPS_CheckedChanged);
            // 
            // labelSlowFPS
            // 
            resources.ApplyResources(this.labelSlowFPS, "labelSlowFPS");
            this.labelSlowFPS.Name = "labelSlowFPS";
            // 
            // textBoxSlowFPS
            // 
            resources.ApplyResources(this.textBoxSlowFPS, "textBoxSlowFPS");
            this.textBoxSlowFPS.Name = "textBoxSlowFPS";
            this.textBoxSlowFPS.TextChanged += new System.EventHandler(this.textBoxSlowFPS_TextChanged);
            // 
            // labelFPSout
            // 
            resources.ApplyResources(this.labelFPSout, "labelFPSout");
            this.labelFPSout.Name = "labelFPSout";
            // 
            // textBoxFPSout
            // 
            resources.ApplyResources(this.textBoxFPSout, "textBoxFPSout");
            this.textBoxFPSout.Name = "textBoxFPSout";
            this.textBoxFPSout.TextChanged += new System.EventHandler(this.textBoxFPSout_TextChanged);
            // 
            // groupBoxCPU
            // 
            this.groupBoxCPU.Controls.Add(this.checkBoxH265);
            resources.ApplyResources(this.groupBoxCPU, "groupBoxCPU");
            this.groupBoxCPU.Name = "groupBoxCPU";
            this.groupBoxCPU.TabStop = false;
            // 
            // checkBoxH265
            // 
            resources.ApplyResources(this.checkBoxH265, "checkBoxH265");
            this.checkBoxH265.Name = "checkBoxH265";
            this.checkBoxH265.UseVisualStyleBackColor = true;
            this.checkBoxH265.CheckedChanged += new System.EventHandler(this.checkBoxH265_CheckedChanged);
            // 
            // buttonLog
            // 
            this.buttonLog.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.buttonLog, "buttonLog");
            this.buttonLog.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.buttonLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.UseVisualStyleBackColor = false;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // comboBoxAudioStreamNo
            // 
            this.comboBoxAudioStreamNo.FormattingEnabled = true;
            this.comboBoxAudioStreamNo.Items.AddRange(new object[] {
            resources.GetString("comboBoxAudioStreamNo.Items"),
            resources.GetString("comboBoxAudioStreamNo.Items1"),
            resources.GetString("comboBoxAudioStreamNo.Items2"),
            resources.GetString("comboBoxAudioStreamNo.Items3"),
            resources.GetString("comboBoxAudioStreamNo.Items4"),
            resources.GetString("comboBoxAudioStreamNo.Items5"),
            resources.GetString("comboBoxAudioStreamNo.Items6"),
            resources.GetString("comboBoxAudioStreamNo.Items7"),
            resources.GetString("comboBoxAudioStreamNo.Items8")});
            resources.ApplyResources(this.comboBoxAudioStreamNo, "comboBoxAudioStreamNo");
            this.comboBoxAudioStreamNo.Name = "comboBoxAudioStreamNo";
            this.comboBoxAudioStreamNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioStreamNo_SelectedIndexChanged);
            // 
            // labelAudioStream
            // 
            resources.ApplyResources(this.labelAudioStream, "labelAudioStream");
            this.labelAudioStream.Name = "labelAudioStream";
            // 
            // groupBoxRotate
            // 
            this.groupBoxRotate.Controls.Add(this.checkBox90counterclockwise);
            this.groupBoxRotate.Controls.Add(this.checkBox90clockwise);
            this.groupBoxRotate.Controls.Add(this.checkBox180);
            resources.ApplyResources(this.groupBoxRotate, "groupBoxRotate");
            this.groupBoxRotate.Name = "groupBoxRotate";
            this.groupBoxRotate.TabStop = false;
            // 
            // checkBox90counterclockwise
            // 
            resources.ApplyResources(this.checkBox90counterclockwise, "checkBox90counterclockwise");
            this.checkBox90counterclockwise.Name = "checkBox90counterclockwise";
            this.checkBox90counterclockwise.UseVisualStyleBackColor = true;
            this.checkBox90counterclockwise.CheckedChanged += new System.EventHandler(this.checkBox90counterclockwise_CheckedChanged);
            // 
            // checkBox90clockwise
            // 
            resources.ApplyResources(this.checkBox90clockwise, "checkBox90clockwise");
            this.checkBox90clockwise.Name = "checkBox90clockwise";
            this.checkBox90clockwise.UseVisualStyleBackColor = true;
            this.checkBox90clockwise.CheckedChanged += new System.EventHandler(this.checkBox90clockwise_CheckedChanged);
            // 
            // checkBox180
            // 
            resources.ApplyResources(this.checkBox180, "checkBox180");
            this.checkBox180.Name = "checkBox180";
            this.checkBox180.UseVisualStyleBackColor = true;
            this.checkBox180.CheckedChanged += new System.EventHandler(this.checkBox180_CheckedChanged);
            // 
            // buttonRemoveSubtitle
            // 
            resources.ApplyResources(this.buttonRemoveSubtitle, "buttonRemoveSubtitle");
            this.buttonRemoveSubtitle.FlatAppearance.BorderSize = 0;
            this.buttonRemoveSubtitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonRemoveSubtitle.Name = "buttonRemoveSubtitle";
            this.buttonRemoveSubtitle.UseVisualStyleBackColor = true;
            this.buttonRemoveSubtitle.Click += new System.EventHandler(this.buttonRemoveSubtitle_Click);
            // 
            // labelAddSubtitle
            // 
            resources.ApplyResources(this.labelAddSubtitle, "labelAddSubtitle");
            this.labelAddSubtitle.Name = "labelAddSubtitle";
            // 
            // buttonAddSubtitle
            // 
            resources.ApplyResources(this.buttonAddSubtitle, "buttonAddSubtitle");
            this.buttonAddSubtitle.Name = "buttonAddSubtitle";
            this.buttonAddSubtitle.UseVisualStyleBackColor = true;
            this.buttonAddSubtitle.Click += new System.EventHandler(this.buttonAddSubtitle_Click);
            // 
            // groupBoxVideoOrAudio
            // 
            this.groupBoxVideoOrAudio.Controls.Add(this.checkBoxAudioOnly);
            this.groupBoxVideoOrAudio.Controls.Add(this.checkBoxVideoOnly);
            resources.ApplyResources(this.groupBoxVideoOrAudio, "groupBoxVideoOrAudio");
            this.groupBoxVideoOrAudio.Name = "groupBoxVideoOrAudio";
            this.groupBoxVideoOrAudio.TabStop = false;
            // 
            // checkBoxAudioOnly
            // 
            resources.ApplyResources(this.checkBoxAudioOnly, "checkBoxAudioOnly");
            this.checkBoxAudioOnly.Name = "checkBoxAudioOnly";
            this.checkBoxAudioOnly.UseVisualStyleBackColor = true;
            this.checkBoxAudioOnly.CheckedChanged += new System.EventHandler(this.checkBoxAudioOnly_CheckedChanged);
            // 
            // checkBoxVideoOnly
            // 
            resources.ApplyResources(this.checkBoxVideoOnly, "checkBoxVideoOnly");
            this.checkBoxVideoOnly.Name = "checkBoxVideoOnly";
            this.checkBoxVideoOnly.UseVisualStyleBackColor = true;
            this.checkBoxVideoOnly.CheckedChanged += new System.EventHandler(this.checkBoxVideoOnly_CheckedChanged);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.labelPreset);
            this.groupBoxOptions.Controls.Add(this.labelQuality);
            this.groupBoxOptions.Controls.Add(this.labelAudio);
            this.groupBoxOptions.Controls.Add(this.comboBoxPreset);
            this.groupBoxOptions.Controls.Add(this.comboBoxAudioBitRate);
            this.groupBoxOptions.Controls.Add(this.comboBoxQuality);
            resources.ApplyResources(this.groupBoxOptions, "groupBoxOptions");
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.TabStop = false;
            // 
            // labelPreset
            // 
            resources.ApplyResources(this.labelPreset, "labelPreset");
            this.labelPreset.Name = "labelPreset";
            // 
            // labelQuality
            // 
            resources.ApplyResources(this.labelQuality, "labelQuality");
            this.labelQuality.Name = "labelQuality";
            // 
            // labelAudio
            // 
            resources.ApplyResources(this.labelAudio, "labelAudio");
            this.labelAudio.Name = "labelAudio";
            // 
            // comboBoxPreset
            // 
            this.comboBoxPreset.FormattingEnabled = true;
            this.comboBoxPreset.Items.AddRange(new object[] {
            resources.GetString("comboBoxPreset.Items"),
            resources.GetString("comboBoxPreset.Items1"),
            resources.GetString("comboBoxPreset.Items2"),
            resources.GetString("comboBoxPreset.Items3"),
            resources.GetString("comboBoxPreset.Items4"),
            resources.GetString("comboBoxPreset.Items5"),
            resources.GetString("comboBoxPreset.Items6"),
            resources.GetString("comboBoxPreset.Items7")});
            resources.ApplyResources(this.comboBoxPreset, "comboBoxPreset");
            this.comboBoxPreset.Name = "comboBoxPreset";
            this.comboBoxPreset.SelectedIndexChanged += new System.EventHandler(this.comboBoxPreset_SelectedIndexChanged);
            // 
            // comboBoxAudioBitRate
            // 
            this.comboBoxAudioBitRate.FormattingEnabled = true;
            this.comboBoxAudioBitRate.Items.AddRange(new object[] {
            resources.GetString("comboBoxAudioBitRate.Items"),
            resources.GetString("comboBoxAudioBitRate.Items1"),
            resources.GetString("comboBoxAudioBitRate.Items2"),
            resources.GetString("comboBoxAudioBitRate.Items3"),
            resources.GetString("comboBoxAudioBitRate.Items4"),
            resources.GetString("comboBoxAudioBitRate.Items5"),
            resources.GetString("comboBoxAudioBitRate.Items6"),
            resources.GetString("comboBoxAudioBitRate.Items7")});
            resources.ApplyResources(this.comboBoxAudioBitRate, "comboBoxAudioBitRate");
            this.comboBoxAudioBitRate.Name = "comboBoxAudioBitRate";
            this.comboBoxAudioBitRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioBitRate_SelectedIndexChanged);
            // 
            // comboBoxQuality
            // 
            this.comboBoxQuality.FormattingEnabled = true;
            this.comboBoxQuality.Items.AddRange(new object[] {
            resources.GetString("comboBoxQuality.Items"),
            resources.GetString("comboBoxQuality.Items1"),
            resources.GetString("comboBoxQuality.Items2"),
            resources.GetString("comboBoxQuality.Items3"),
            resources.GetString("comboBoxQuality.Items4"),
            resources.GetString("comboBoxQuality.Items5"),
            resources.GetString("comboBoxQuality.Items6"),
            resources.GetString("comboBoxQuality.Items7"),
            resources.GetString("comboBoxQuality.Items8"),
            resources.GetString("comboBoxQuality.Items9"),
            resources.GetString("comboBoxQuality.Items10"),
            resources.GetString("comboBoxQuality.Items11"),
            resources.GetString("comboBoxQuality.Items12"),
            resources.GetString("comboBoxQuality.Items13"),
            resources.GetString("comboBoxQuality.Items14")});
            resources.ApplyResources(this.comboBoxQuality, "comboBoxQuality");
            this.comboBoxQuality.Name = "comboBoxQuality";
            this.comboBoxQuality.SelectedIndexChanged += new System.EventHandler(this.comboBoxQuality_SelectedIndexChanged);
            // 
            // groupBoxAudio
            // 
            this.groupBoxAudio.Controls.Add(this.radioButtonCopyAudio);
            this.groupBoxAudio.Controls.Add(this.radioButtonMP3);
            this.groupBoxAudio.Controls.Add(this.radioButtonAAC);
            resources.ApplyResources(this.groupBoxAudio, "groupBoxAudio");
            this.groupBoxAudio.Name = "groupBoxAudio";
            this.groupBoxAudio.TabStop = false;
            // 
            // radioButtonCopyAudio
            // 
            resources.ApplyResources(this.radioButtonCopyAudio, "radioButtonCopyAudio");
            this.radioButtonCopyAudio.Name = "radioButtonCopyAudio";
            this.radioButtonCopyAudio.TabStop = true;
            this.radioButtonCopyAudio.UseVisualStyleBackColor = true;
            this.radioButtonCopyAudio.CheckedChanged += new System.EventHandler(this.radioButtonCopyAudio_CheckedChanged);
            // 
            // radioButtonMP3
            // 
            resources.ApplyResources(this.radioButtonMP3, "radioButtonMP3");
            this.radioButtonMP3.Checked = true;
            this.radioButtonMP3.Name = "radioButtonMP3";
            this.radioButtonMP3.TabStop = true;
            this.radioButtonMP3.UseVisualStyleBackColor = true;
            this.radioButtonMP3.CheckedChanged += new System.EventHandler(this.radioButtonMP3_CheckedChanged);
            // 
            // radioButtonAAC
            // 
            resources.ApplyResources(this.radioButtonAAC, "radioButtonAAC");
            this.radioButtonAAC.Name = "radioButtonAAC";
            this.radioButtonAAC.UseVisualStyleBackColor = true;
            this.radioButtonAAC.CheckedChanged += new System.EventHandler(this.radioButtonAAC_CheckedChanged);
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.Controls.Add(this.radioButtonCopyVideo);
            this.groupBoxContainer.Controls.Add(this.radioButtonMP4);
            this.groupBoxContainer.Controls.Add(this.radioButtonMKV);
            resources.ApplyResources(this.groupBoxContainer, "groupBoxContainer");
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.TabStop = false;
            // 
            // radioButtonCopyVideo
            // 
            resources.ApplyResources(this.radioButtonCopyVideo, "radioButtonCopyVideo");
            this.radioButtonCopyVideo.Name = "radioButtonCopyVideo";
            this.radioButtonCopyVideo.TabStop = true;
            this.radioButtonCopyVideo.UseVisualStyleBackColor = true;
            this.radioButtonCopyVideo.CheckedChanged += new System.EventHandler(this.radioButtonCopyVideo_CheckedChanged);
            // 
            // radioButtonMP4
            // 
            resources.ApplyResources(this.radioButtonMP4, "radioButtonMP4");
            this.radioButtonMP4.Name = "radioButtonMP4";
            this.radioButtonMP4.TabStop = true;
            this.radioButtonMP4.UseVisualStyleBackColor = true;
            this.radioButtonMP4.CheckedChanged += new System.EventHandler(this.radioButtonMP4_CheckedChanged);
            // 
            // radioButtonMKV
            // 
            resources.ApplyResources(this.radioButtonMKV, "radioButtonMKV");
            this.radioButtonMKV.Checked = true;
            this.radioButtonMKV.Name = "radioButtonMKV";
            this.radioButtonMKV.TabStop = true;
            this.radioButtonMKV.UseVisualStyleBackColor = true;
            this.radioButtonMKV.CheckedChanged += new System.EventHandler(this.radioButtonMKV_CheckedChanged);
            // 
            // labelTextBoxConv
            // 
            resources.ApplyResources(this.labelTextBoxConv, "labelTextBoxConv");
            this.labelTextBoxConv.Name = "labelTextBoxConv";
            // 
            // labelOutConvFile
            // 
            resources.ApplyResources(this.labelOutConvFile, "labelOutConvFile");
            this.labelOutConvFile.Name = "labelOutConvFile";
            // 
            // labelInputConvFile
            // 
            resources.ApplyResources(this.labelInputConvFile, "labelInputConvFile");
            this.labelInputConvFile.Name = "labelInputConvFile";
            // 
            // buttonAddBatchConv
            // 
            resources.ApplyResources(this.buttonAddBatchConv, "buttonAddBatchConv");
            this.buttonAddBatchConv.Name = "buttonAddBatchConv";
            this.buttonAddBatchConv.UseVisualStyleBackColor = true;
            this.buttonAddBatchConv.Click += new System.EventHandler(this.buttonAddBatchConv_Click);
            // 
            // buttonMultiConvFiles
            // 
            this.buttonMultiConvFiles.AllowDrop = true;
            resources.ApplyResources(this.buttonMultiConvFiles, "buttonMultiConvFiles");
            this.buttonMultiConvFiles.Name = "buttonMultiConvFiles";
            this.buttonMultiConvFiles.UseVisualStyleBackColor = true;
            this.buttonMultiConvFiles.Click += new System.EventHandler(this.buttonMultiConvFiles_Click);
            // 
            // panelConvert
            // 
            resources.ApplyResources(this.panelConvert, "panelConvert");
            this.panelConvert.Controls.Add(this.richTextBoxConv);
            this.panelConvert.Name = "panelConvert";
            // 
            // richTextBoxConv
            // 
            this.richTextBoxConv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.richTextBoxConv, "richTextBoxConv");
            this.richTextBoxConv.Name = "richTextBoxConv";
            // 
            // buttonOutConvFile
            // 
            resources.ApplyResources(this.buttonOutConvFile, "buttonOutConvFile");
            this.buttonOutConvFile.Name = "buttonOutConvFile";
            this.buttonOutConvFile.UseVisualStyleBackColor = true;
            this.buttonOutConvFile.Click += new System.EventHandler(this.buttonOutConvFile_Click);
            // 
            // buttonInputConvFile
            // 
            this.buttonInputConvFile.AllowDrop = true;
            resources.ApplyResources(this.buttonInputConvFile, "buttonInputConvFile");
            this.buttonInputConvFile.Name = "buttonInputConvFile";
            this.buttonInputConvFile.UseVisualStyleBackColor = true;
            this.buttonInputConvFile.Click += new System.EventHandler(this.buttonInputConvFile_Click);
            // 
            // buttonInfo
            // 
            resources.ApplyResources(this.buttonInfo, "buttonInfo");
            this.buttonInfo.BackgroundImage = global::VTC.Properties.Resources.button;
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.UseVisualStyleBackColor = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            this.buttonInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonInfo_MouseDown);
            this.buttonInfo.MouseEnter += new System.EventHandler(this.buttonInfo_Enter);
            this.buttonInfo.MouseLeave += new System.EventHandler(this.buttonInfo_Leave);
            this.buttonInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonInfo_MouseUp);
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.richTextBoxStreamCommand);
            this.tabPage4.Controls.Add(this.labelSaveStreamPath);
            this.tabPage4.Controls.Add(this.buttonStreamSavePath);
            this.tabPage4.Controls.Add(this.buttonCheckStream);
            this.tabPage4.Controls.Add(this.buttonLogRec);
            this.tabPage4.Controls.Add(this.buttonStartRec);
            this.tabPage4.Controls.Add(this.buttonPlayStream);
            this.tabPage4.Controls.Add(this.textBoxStream);
            this.tabPage4.Controls.Add(this.labelStream);
            this.tabPage4.Name = "tabPage4";
            // 
            // richTextBoxStreamCommand
            // 
            this.richTextBoxStreamCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.richTextBoxStreamCommand, "richTextBoxStreamCommand");
            this.richTextBoxStreamCommand.Name = "richTextBoxStreamCommand";
            // 
            // labelSaveStreamPath
            // 
            resources.ApplyResources(this.labelSaveStreamPath, "labelSaveStreamPath");
            this.labelSaveStreamPath.Name = "labelSaveStreamPath";
            // 
            // buttonStreamSavePath
            // 
            resources.ApplyResources(this.buttonStreamSavePath, "buttonStreamSavePath");
            this.buttonStreamSavePath.Name = "buttonStreamSavePath";
            this.buttonStreamSavePath.UseVisualStyleBackColor = true;
            this.buttonStreamSavePath.Click += new System.EventHandler(this.buttonStreamSavePath_Click);
            // 
            // buttonCheckStream
            // 
            resources.ApplyResources(this.buttonCheckStream, "buttonCheckStream");
            this.buttonCheckStream.Name = "buttonCheckStream";
            this.buttonCheckStream.UseVisualStyleBackColor = true;
            this.buttonCheckStream.Click += new System.EventHandler(this.buttonCheckStream_Click);
            // 
            // buttonLogRec
            // 
            resources.ApplyResources(this.buttonLogRec, "buttonLogRec");
            this.buttonLogRec.Name = "buttonLogRec";
            this.buttonLogRec.UseVisualStyleBackColor = true;
            this.buttonLogRec.Click += new System.EventHandler(this.buttonLogRec_Click);
            // 
            // buttonStartRec
            // 
            resources.ApplyResources(this.buttonStartRec, "buttonStartRec");
            this.buttonStartRec.Name = "buttonStartRec";
            this.buttonStartRec.UseVisualStyleBackColor = true;
            this.buttonStartRec.Click += new System.EventHandler(this.buttonStartRec_Click);
            // 
            // buttonPlayStream
            // 
            resources.ApplyResources(this.buttonPlayStream, "buttonPlayStream");
            this.buttonPlayStream.Name = "buttonPlayStream";
            this.buttonPlayStream.UseVisualStyleBackColor = true;
            this.buttonPlayStream.Click += new System.EventHandler(this.buttonTestStream_Click);
            // 
            // textBoxStream
            // 
            this.textBoxStream.AllowDrop = true;
            resources.ApplyResources(this.textBoxStream, "textBoxStream");
            this.textBoxStream.Name = "textBoxStream";
            // 
            // labelStream
            // 
            resources.ApplyResources(this.labelStream, "labelStream");
            this.labelStream.Name = "labelStream";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Name = "panel2";
            // 
            // tabControl2
            // 
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.panelBatch);
            this.tabPage3.Name = "tabPage3";
            // 
            // panelBatch
            // 
            resources.ApplyResources(this.panelBatch, "panelBatch");
            this.panelBatch.BackColor = System.Drawing.SystemColors.Control;
            this.panelBatch.Controls.Add(this.richTextBox3);
            this.panelBatch.Controls.Add(this.buttonUnselectAll);
            this.panelBatch.Controls.Add(this.buttonSellectAllQueue);
            this.panelBatch.Controls.Add(this.dataGridViewBatch);
            this.panelBatch.Controls.Add(this.buttonDeleteQueue);
            this.panelBatch.Controls.Add(this.buttonCancelBatch);
            this.panelBatch.Controls.Add(this.buttonStartQueue);
            this.panelBatch.Name = "panelBatch";
            // 
            // richTextBox3
            // 
            resources.ApplyResources(this.richTextBox3, "richTextBox3");
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // buttonUnselectAll
            // 
            resources.ApplyResources(this.buttonUnselectAll, "buttonUnselectAll");
            this.buttonUnselectAll.Name = "buttonUnselectAll";
            this.buttonUnselectAll.UseVisualStyleBackColor = true;
            this.buttonUnselectAll.Click += new System.EventHandler(this.buttonUnselectAll_Click);
            // 
            // buttonSellectAllQueue
            // 
            resources.ApplyResources(this.buttonSellectAllQueue, "buttonSellectAllQueue");
            this.buttonSellectAllQueue.Name = "buttonSellectAllQueue";
            this.buttonSellectAllQueue.UseVisualStyleBackColor = true;
            this.buttonSellectAllQueue.Click += new System.EventHandler(this.buttonSellectAllQueue_Click);
            // 
            // dataGridViewBatch
            // 
            this.dataGridViewBatch.AllowDrop = true;
            this.dataGridViewBatch.AllowUserToAddRows = false;
            this.dataGridViewBatch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBatch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.dataGridViewBatch, "dataGridViewBatch");
            this.dataGridViewBatch.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewBatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check_cell,
            this.no_cell,
            this.task_cell});
            this.dataGridViewBatch.Name = "dataGridViewBatch";
            this.dataGridViewBatch.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // check_cell
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.NullValue = false;
            this.check_cell.DefaultCellStyle = dataGridViewCellStyle12;
            this.check_cell.Frozen = true;
            resources.ApplyResources(this.check_cell, "check_cell");
            this.check_cell.Name = "check_cell";
            this.check_cell.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // no_cell
            // 
            this.no_cell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.no_cell.Frozen = true;
            resources.ApplyResources(this.no_cell, "no_cell");
            this.no_cell.MaxInputLength = 255;
            this.no_cell.Name = "no_cell";
            this.no_cell.ReadOnly = true;
            this.no_cell.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.no_cell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // task_cell
            // 
            this.task_cell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.task_cell, "task_cell");
            this.task_cell.Name = "task_cell";
            this.task_cell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // buttonDeleteQueue
            // 
            resources.ApplyResources(this.buttonDeleteQueue, "buttonDeleteQueue");
            this.buttonDeleteQueue.Name = "buttonDeleteQueue";
            this.buttonDeleteQueue.UseVisualStyleBackColor = true;
            this.buttonDeleteQueue.Click += new System.EventHandler(this.buttonDeleteQueue_Click);
            // 
            // buttonCancelBatch
            // 
            resources.ApplyResources(this.buttonCancelBatch, "buttonCancelBatch");
            this.buttonCancelBatch.Name = "buttonCancelBatch";
            this.buttonCancelBatch.UseVisualStyleBackColor = true;
            this.buttonCancelBatch.Click += new System.EventHandler(this.buttonCancelBatch_Click);
            // 
            // buttonStartQueue
            // 
            resources.ApplyResources(this.buttonStartQueue, "buttonStartQueue");
            this.buttonStartQueue.Name = "buttonStartQueue";
            this.buttonStartQueue.UseVisualStyleBackColor = true;
            this.buttonStartQueue.Click += new System.EventHandler(this.buttonStartQueue_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxCopyTimePeriod.ResumeLayout(false);
            this.groupBoxCopyTimePeriod.PerformLayout();
            this.groupBoxTransGroupStreams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAudioNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVideoNr)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxVideoSize.ResumeLayout(false);
            this.groupBoxSlow.ResumeLayout(false);
            this.groupBoxSlow.PerformLayout();
            this.groupBoxCPU.ResumeLayout(false);
            this.groupBoxRotate.ResumeLayout(false);
            this.groupBoxVideoOrAudio.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            this.groupBoxContainer.ResumeLayout(false);
            this.groupBoxContainer.PerformLayout();
            this.panelConvert.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panelBatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timerBatch;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Label labelMultiTransFile;
        private System.Windows.Forms.Button buttonMultiTransFile;
        private System.Windows.Forms.Panel panelTranscode;
        private System.Windows.Forms.Label labelOutTransFile;
        private System.Windows.Forms.Label labelInputTransFile;
        private System.Windows.Forms.Button buttonOutTransFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxRotate;
        private System.Windows.Forms.CheckBox checkBox90counterclockwise;
        private System.Windows.Forms.CheckBox checkBox90clockwise;
        private System.Windows.Forms.CheckBox checkBox180;
        private System.Windows.Forms.Button buttonRemoveSubtitle;
        private System.Windows.Forms.Label labelAddSubtitle;
        private System.Windows.Forms.Button buttonAddSubtitle;
        private System.Windows.Forms.GroupBox groupBoxVideoOrAudio;
        private System.Windows.Forms.CheckBox checkBoxAudioOnly;
        private System.Windows.Forms.CheckBox checkBoxVideoOnly;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Label labelPreset;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.Label labelAudio;
        private System.Windows.Forms.ComboBox comboBoxPreset;
        private System.Windows.Forms.ComboBox comboBoxAudioBitRate;
        private System.Windows.Forms.ComboBox comboBoxQuality;
        private System.Windows.Forms.GroupBox groupBoxAudio;
        private System.Windows.Forms.RadioButton radioButtonCopyAudio;
        private System.Windows.Forms.RadioButton radioButtonMP3;
        private System.Windows.Forms.RadioButton radioButtonAAC;
        private System.Windows.Forms.GroupBox groupBoxContainer;
        private System.Windows.Forms.RadioButton radioButtonCopyVideo;
        private System.Windows.Forms.RadioButton radioButtonMP4;
        private System.Windows.Forms.RadioButton radioButtonMKV;
        private System.Windows.Forms.Label labelTextBoxConv;
        private System.Windows.Forms.Label labelOutConvFile;
        private System.Windows.Forms.Label labelInputConvFile;
        private System.Windows.Forms.Button buttonAddBatchConv;
        private System.Windows.Forms.Button buttonMultiConvFiles;
        private System.Windows.Forms.Panel panelConvert;
        private System.Windows.Forms.RichTextBox richTextBoxConv;
        private System.Windows.Forms.Button buttonOutConvFile;
        private System.Windows.Forms.Button buttonInputConvFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panelBatch;
        private System.Windows.Forms.Button buttonUnselectAll;
        private System.Windows.Forms.Button buttonSellectAllQueue;
        private System.Windows.Forms.DataGridView dataGridViewBatch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_cell;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_cell;
        private System.Windows.Forms.DataGridViewTextBoxColumn task_cell;
        private System.Windows.Forms.Button buttonDeleteQueue;
        private System.Windows.Forms.Button buttonCancelBatch;
        private System.Windows.Forms.Button buttonStartQueue;
        private System.Windows.Forms.ComboBox comboBoxAudioStreamNo;
        private System.Windows.Forms.Label labelAudioStream;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Button buttonLog2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.GroupBox groupBoxCPU;
        private System.Windows.Forms.CheckBox checkBoxH265;
        private System.Windows.Forms.GroupBox groupBoxSlow;
        private System.Windows.Forms.Label labelSlowFPS;
        private System.Windows.Forms.TextBox textBoxSlowFPS;
        private System.Windows.Forms.Label labelFPSout;
        private System.Windows.Forms.TextBox textBoxFPSout;
        private System.Windows.Forms.CheckBox checkBoxSlowFPS;
        private System.Windows.Forms.CheckBox checkBoxSetFPS;
        private System.Windows.Forms.CheckBox checkBoxTransRemoveSubtitle;
        private System.Windows.Forms.Button buttonRemoveOutPath;
        private System.Windows.Forms.Button buttonRemoveTransPath;
        private System.Windows.Forms.GroupBox groupBoxVideoSize;
        private System.Windows.Forms.RadioButton radioButton_480p;
        private System.Windows.Forms.RadioButton radioButton_720p;
        private System.Windows.Forms.RadioButton radioButton_1080p;
        private System.Windows.Forms.RadioButton radioButton_No_Video_Resize;
        private System.Windows.Forms.CheckBox checkBoxTranscodeAllStreams;
        private System.Windows.Forms.CheckBox checkBoxKeepExtension;
        private System.Windows.Forms.GroupBox groupBoxTransGroupStreams;
        private System.Windows.Forms.Label labelTransAudioNr;
        private System.Windows.Forms.Label labelTransVideoNr;
        private System.Windows.Forms.NumericUpDown numericUpDownAudioNr;
        private System.Windows.Forms.NumericUpDown numericUpDownVideoNr;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonPlayStream;
        private System.Windows.Forms.TextBox textBoxStream;
        private System.Windows.Forms.Label labelStream;
        private System.Windows.Forms.Button buttonStartRec;
        private System.Windows.Forms.Button buttonLogRec;
        private System.Windows.Forms.Button buttonCheckStream;
        private System.Windows.Forms.Label labelSaveStreamPath;
        private System.Windows.Forms.Button buttonStreamSavePath;
        private System.Windows.Forms.RichTextBox richTextBoxStreamCommand;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.GroupBox groupBoxCopyTimePeriod;
        private System.Windows.Forms.TextBox textBoxCopyDuration;
        private System.Windows.Forms.Label labelCopyDuration;
        private System.Windows.Forms.CheckBox checkBoxCopyDuration;
        private System.Windows.Forms.TextBox textBoxFromTime;
        private System.Windows.Forms.Label labelFromTime;
    }
}

