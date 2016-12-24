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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.timerBatch = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.groupBoxCPU = new System.Windows.Forms.GroupBox();
            this.checkBoxH265 = new System.Windows.Forms.CheckBox();
            this.checkBoxThreads = new System.Windows.Forms.CheckBox();
            this.buttonLog = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
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
            this.tabPage2.SuspendLayout();
            this.groupBoxCPU.SuspendLayout();
            this.groupBoxRotate.SuspendLayout();
            this.groupBoxVideoOrAudio.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            this.groupBoxContainer.SuspendLayout();
            this.panelConvert.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panelBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
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
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Name = "panel1";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
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
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Controls.Add(this.groupBoxCPU);
            this.tabPage2.Controls.Add(this.buttonLog);
            this.tabPage2.Controls.Add(this.buttonInfo);
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
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxCPU
            // 
            this.groupBoxCPU.Controls.Add(this.checkBoxH265);
            this.groupBoxCPU.Controls.Add(this.checkBoxThreads);
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
            // checkBoxThreads
            // 
            this.checkBoxThreads.Checked = true;
            this.checkBoxThreads.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.checkBoxThreads, "checkBoxThreads");
            this.checkBoxThreads.Name = "checkBoxThreads";
            this.checkBoxThreads.UseVisualStyleBackColor = true;
            this.checkBoxThreads.CheckedChanged += new System.EventHandler(this.checkBoxThreads_CheckedChanged);
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
            this.panelBatch.BackgroundImage = global::VTC.Properties.Resources.drop_here;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBatch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.NullValue = false;
            this.check_cell.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxCPU.ResumeLayout(false);
            this.groupBoxRotate.ResumeLayout(false);
            this.groupBoxRotate.PerformLayout();
            this.groupBoxVideoOrAudio.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            this.groupBoxContainer.ResumeLayout(false);
            this.groupBoxContainer.PerformLayout();
            this.panelConvert.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox checkBoxThreads;
        private System.Windows.Forms.CheckBox checkBoxH265;
    }
}

