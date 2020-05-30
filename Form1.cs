using System;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace VTC
{
    public partial class Form1 : Form
    {
        //VCT is wrapper for FFmpeg, which is used as process started within this GUI.
        //The code below allow user to create encoding tasks, calls FFmpeg and informs user of progress.
        //As any GUI it tries to be fool proof, but since it is a first version, there may be bugs.
        //It is probably more complicated than needed, but it tries to allow user to change encoding options,
        //by clicking radio buttons, check boxes and drop down boxes, and displaying effect change immediately.
        //Although it is not in the spirit of OO programming, I defined most of the variables as static.
        //Since this app is not large, it makes sense to reserve memory at the beginning and keep it until it runs.
        //Also, it is neccessary when using threads so than values can be exchanged between threads.
        //There are 3 threads used when encoding is started:
        //1. Main thread is GUI control, it starts Background worker to start 
        //2. encoding task list - each task in the list starts
        //3. process that is command which executes ffmpeg with options
        //define variables
        Stopwatch stopwatch = new Stopwatch(); //measure execution time for each job
        static string statustekst = "", std_out = ""; //text to be displayed as info; store part from ffmpeg standard output
        bool duration_found = false; //check if duration of the video or audio is found in ffmpeg output - measures percentage of executed job
        static string percent = ""; //shows perventage of executed task - used for progress bar
        static float total_sec, encoded_sec; //stores total length of video or audio; currently number of encoded seconds
        static string input_stream, input_file, out_file, out_path = "", str_extension, orig_ext, audio_ext; //stores names of input, output files, output path and temp. varr
        static string subtitle_stream, audio_stream = "1";
        static int number_of_rows = 0; //stores number of rows for batch list
        static int ffmpeg_process_id; //process id of started ffmpeg process - used to close it if user cancels or pauses
        static bool canceled = false, video_only = false, audio_only = false; //flags to mark cancel job; if video or audio only is encoded
        static bool add_sub_stream = false, error_in_file = false, use_out_path = false, paused = false, started = false; // paused or started encoding
        static string preset = "veryfast", crf = "23", audio = "libmp3lame", container = "mkv", audiobitrate = "128k"; //options values used as ffmpeg encodin parameters
        static string video = "", audio_part = "", task = ""; //video;audio part of parameters string; ffmpeg command string
        static string video_size = ""; //used if user opts to resize video
        static string vf = ""; //video filter part, used currently to rotate video
        static bool h265 = false; //use H.264 codec or not, controlled by checkBoxH265
        static bool set_fps = false; //set if different target FPS is to be used
        static bool slow_motion = false; //check if video is converted to slow motion from e.g. high FPS video source
        static double fps = 0.00; //initial value for video file fps
        string[] task_list = new string[100]; //all tasks put in a batch list
        string json = "", ffplay_output=""; //ffprobe shows JSON style info about file properties
        string time_position = "2"; //position from which to extract image from video
        Process proc = new System.Diagnostics.Process(); //process that call cmd.exe to execute ffmpeg task
        static string pass_video_info, pass_audio_info, pass_subtitle_info, temp_path; //vars to pass to other infoForm
        static string pass_labelFileName2, pass_labelFormat2, pass_labelDuration2, pass_labelSize2, pass_labelvideobitrate; 
        static bool log = false; //output from ffmpeg visible or not
        static string output_log, out_fps = "";
        Form logForm = new Form();
        // Create the ToolTips and associate with the Form container.
        ToolTip toolTip1 = new ToolTip();
        ToolTip toolTip2 = new ToolTip();
        ToolTip toolTip3 = new ToolTip();
        ToolTip toolTip4 = new ToolTip();
        ToolTip toolTip5 = new ToolTip();
        ToolTip toolTip6 = new ToolTip();
        ToolTip toolTip7 = new ToolTip();
        ToolTip toolTip8 = new ToolTip();
        ToolTip toolTip9 = new ToolTip();
        ToolTip toolTip10 = new ToolTip();
        ToolTip toolTip11 = new ToolTip();
        ToolTip toolTip12 = new ToolTip();
        ToolTip toolTip13 = new ToolTip();
        ToolTip toolTip14 = new ToolTip();
        ToolTip toolTip15 = new ToolTip();
        ToolTip toolTip16 = new ToolTip();
        ToolTip toolTip17 = new ToolTip();
        ToolTip toolTip18 = new ToolTip();
        ToolTip toolTip19 = new ToolTip();
        ToolTip toolTip20 = new ToolTip();
        ToolTip toolTip21 = new ToolTip();
        ToolTip toolTip22 = new ToolTip();
        ToolTip toolTip23 = new ToolTip();
        ToolTip toolTip24 = new ToolTip();
        ToolTip toolTip25 = new ToolTip();
        ToolTip toolTip26 = new ToolTip();
        ToolTip toolTip27 = new ToolTip();
        ToolTip toolTip28 = new ToolTip();
        ToolTip toolTip29 = new ToolTip();
        ToolTip toolTip30 = new ToolTip();
        ToolTip toolTip31 = new ToolTip();
        ToolTip toolTip32 = new ToolTip();
        ToolTip toolTip33 = new ToolTip();
        ToolTip toolTip34 = new ToolTip();
        ToolTip toolTip35 = new ToolTip();
        ToolTip toolTip36 = new ToolTip();
        ToolTip toolTip37 = new ToolTip();
        ToolTip toolTip38 = new ToolTip();
        ToolTip toolTip39 = new ToolTip();
        ToolTip toolTip40 = new ToolTip();
        ToolTip toolTip41 = new ToolTip();
        ToolTip toolTip42 = new ToolTip();
        ToolTip toolTip43 = new ToolTip();
        ToolTip toolTip44 = new ToolTip();
        ToolTip toolTip45 = new ToolTip();

        public Form1()
        {
            // uncomment next line to build for specifig language UI - useful if you have Windows installed in english but you want specific language for app UI
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("nb"); 
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr-Cyrl"); 
            InitializeComponent();
            // Use 'Transcode' tab to repack h.264 containers (MP4 vs MKV), or 'Convert' tab for full range of conversion options.
            //statustekst = "Bruk 'Omkode' til å konvertere raskt MKV til MP4, eller 'Konvertere' for hele spekteret av H.264-alternativer.";
            // Handler for capturing output data from external process ffmpeg
            proc.OutputDataReceived += (sender, args) => DisplayOutput(args.Data);
            proc.ErrorDataReceived += (sender, args) => DisplayOutput(args.Data); //same method used for error data
        }

        public static bool IsLinux
        {       // check if OS is Linux (4, 128) or Mac (6)
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        public Process GetProcByID(int id)
        {       //handy way to get process without raising exception
            Process[] processlist = Process.GetProcesses();
            return processlist.FirstOrDefault(pr => pr.Id == id);
        }
        private void buttonOutTransFile_Click(object sender, EventArgs e)
        {		//raised when user clicks to select output path for transcoding tasks
            try
            {
                FolderBrowserDialog savePath = new FolderBrowserDialog();
                savePath.SelectedPath = out_path; //stores selected path for both transcoding and converting tasks
                savePath.Description = "Choose output file path";
                if (savePath.ShowDialog() == DialogResult.OK)
                {
                    out_path = savePath.SelectedPath + "\\"; //adds it so correct folder is chosen later when file name is appended to the string
                    
                    labelOutTransFile.Text = out_path; 		 //displays selected path so user is aware of the change
                    labelOutConvFile.Text = out_path;
                    buttonMultiTransFile.Enabled = true;	  //now, it is safe to allow user to click this button to select input files
                    buttonRemoveTransPath.Enabled = true;
                    buttonRemoveTransPath.Visible = true;
                    buttonRemoveOutPath.Enabled = true;
                    buttonRemoveOutPath.Visible = true;
                    use_out_path = true;
                    EnableConvButtons();
                }
            }
            catch (Exception x)
            { }
        }
        private void buttonMultiTransFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    input_file = filePath;
                    MultiTransRow();      //process each file to add appropriate command to the list
                    EnableTransButtons();				//enable user to start, stop, select, delete
                    input_file = "";
                }
            }
        }
        private void buttonMultiTransFile_Click(object sender, EventArgs e)
        {		//raised when user clicks to select input files
            string[] input_list = new string[16383];	//defines max number of files selected from the same folder
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C://";
            openFileDialog.Filter = "H.264 or H.265 files|*.m4v;*.mp4;*mkv;*.avi;*.mpg;*.divx;*.mov;*.wmv";	//sets filter of displayed files
            openFileDialog.Multiselect = true;							//allows to select more files at once
            openFileDialog.Title = "Choose video files to transcode";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                input_list = openFileDialog.FileNames;	//populate list with selected file names
                foreach (string value in input_list)
                {									//process each file name string to automatically define output names
                    input_file = value;
                    MultiTransRow();      //process each file to add appropriate command to the list
                    EnableTransButtons();				//enable user to start, stop, select, delete
                    input_file = "";
                }
                buttonInfo.Visible = false;
            }
        }
        private void MultiTransRow()
        {
            try
            {
                int str_position = input_file.LastIndexOf('.') + 1;	//find position of '.' to determine file extension
                str_extension = input_file.Substring(str_position);	//store found file extension
                if (!checkBoxKeepExtension.Checked)    //Change extansion only if box unchecked
                {
                    switch (str_extension)
                    {                                                   //decide what to do for each extension
                        case "mp4":         //if extension is MP4, output will be MKV
                            str_extension = "1.mkv";
                            break;
                        case "m4v":         //if extension is MvV, output will be MKV
                            str_extension = "1.mkv";
                            break;
                        case "mkv":         //if extension is MKV, output will be MP4
                            str_extension = "1.mp4";
                            break;
                        default:            //default extension is MKV, altough more correct would be to skip!!!!
                            str_extension = "1.mkv";
                            break;
                    }
                }
                else
                    str_extension = "2." + str_extension;
                str_position = input_file.LastIndexOf("\\") + 1;	//find where is the last folder mark
                string in_file = input_file.Substring(str_position);//after that there is a file name
                if (!use_out_path)           //if out path not set, use the same as input file
                {
                    out_path = input_file.Substring(0, str_position);
                    //labelOutConvFile.Text = out_path;
                    //labelOutTransFile.Text = out_path;
                }
                else
                    out_path = labelOutTransFile.Text;
                str_position = in_file.LastIndexOf('.') + 1;	//get position just before extension
                in_file = in_file.Substring(0, str_position);	//set temp var in_file with input file name
                out_file = out_path + in_file;					//set temp var out_file as selected path + input file name
                string _subs = " -map 0:s? ";     //include all subs streams
                if (checkBoxTransRemoveSubtitle.Checked)
                    _subs = " -map -0:s? ";  //remove all subs streams
                string _copy_all_streams = " -map 0:v? -map 0:a? ";  //include all v&a streams
                if (!checkBoxTranscodeAllStreams.Checked)
                {
                    _copy_all_streams = " -map 0:v:" + numericUpDownVideoNr.Value + "? -map 0:a:" + numericUpDownAudioNr.Value + "? ";  //include only 1st v&a streams

                }
                string command = "";
                if (!IsLinux)
                    command = "ffmpeg -y -i \"" + input_file + "\" " + _copy_all_streams + _subs + " -c copy \"" + out_file + str_extension + "\"";//define ffmpeg command
                else
                    command = " -y -i \"" + input_file + "\" " + _copy_all_streams + _subs + " -c copy \"" + out_file + str_extension + "\""; //Linux mono
                number_of_rows++;								//increase counter so we know how many files in the list are
                DataGridViewRow tempRow = new DataGridViewRow();//define row that will store command
                DataGridViewCell check_cell = new DataGridViewCheckBoxCell(false);//define each column i a row -cell
                DataGridViewCell No_cell = new DataGridViewTextBoxCell();		  //number of a row
                DataGridViewCell task_cell = new DataGridViewTextBoxCell();		  //task string column
                check_cell.Value = false;			//set that row is not checked for deletion
                No_cell.Value = number_of_rows;		//number of a row = current number from list
                task_cell.Value = command;			//put ffmpeg command string
                tempRow.Cells.Add(check_cell);		//add all column values to the temp row
                tempRow.Cells.Add(No_cell);
                tempRow.Cells.Add(task_cell);
                dataGridViewBatch.Rows.Add(tempRow);	//add new temp row to the batch list
            }
            catch (Exception x)
            { }
        }
        private int ffplay_test(string input)
        {           //start ffplay to test stream
            try
            {
                System.Diagnostics.ProcessStartInfo procffplay;
                if (!IsLinux)
                    procffplay = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " \"" + input + "\""); // Windows: define Process Info to assing to the process
                else
                    procffplay = new System.Diagnostics.ProcessStartInfo("./ffplay", " \"" + input + "\""); // for Linux with mono
                // The following commands are needed to redirect the standard output and standard error.
                ffplay_output = "";  // reset ffplay log from cmd output
                log = false;
                buttonLogRec.PerformClick();
                /*
                procffplay.RedirectStandardError = true;
                procffplay.RedirectStandardOutput = true;
                procffplay.RedirectStandardInput = false; ;
                procffplay.UseShellExecute = false;
                procffplay.CreateNoWindow = false;  */
                procffplay.RedirectStandardError = false;
                procffplay.RedirectStandardOutput = false;
                procffplay.RedirectStandardInput = false;
                procffplay.UseShellExecute = true;
                procffplay.CreateNoWindow = false;
                Process ffproc = new Process();
                ffproc.StartInfo = procffplay;
                //ffproc.ErrorDataReceived += (sender, args) => ffplayOutput(args.Data);
                
                ffproc.Start();             //start the ffplay

                //ffproc.BeginErrorReadLine();

                //ffproc.WaitForExit();          //since it is started as separate thread, GUI will continue separately, but we wait here before starting next task
                //ffproc.CancelErrorRead();
                /*if (ffplay_output.Contains("Invalid") || ffplay_output.Contains("error"))
                {
                    richTextBox3.Text = ffplay_output;
                    return -1;
                }
                else
                {
                    richTextBox3.Text = ffplay_output;
                    return 0;
                }*/
                return 0;
            }
            catch (Exception ex)
            {
                statustekst = ex.Message;
                richTextBox3.Text += statustekst;
                return -1;
            }
        }
        void ffplayOutput(string output)
        {       //read output sent from ffplay
            try
            {
                ffplay_output += output; //put it in string to be parsed to get stream info
            }
            catch (Exception x)
            {
                //statustekst = "ERROR:" + x.Message;
            }
        }
        private int ffprobe(string input)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procffprobe;
                if (!IsLinux)
                    procffprobe = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " ffprobe -v quiet -print_format json -show_format -show_streams \"" +  input +"\"");// Windows: define Process Info to assing to the process
                else
                    procffprobe = new System.Diagnostics.ProcessStartInfo("./ffprobe", " -v quiet -print_format json -show_format -show_streams \"" +  input + "\""); // for Linux with mono
                // The following commands are needed to redirect the standard output and standard error.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procffprobe.RedirectStandardOutput = true;
                procffprobe.RedirectStandardInput = true;
                procffprobe.RedirectStandardError = true;
                procffprobe.UseShellExecute = false;
                procffprobe.CreateNoWindow = true;	// Do not create the black window.
                procffprobe.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);//set path of vtc.exe same as ffmpeg.exe

                //proc.StartInfo = procStartffmpeg;   // Now we assign process its ProcessStartInfo and start it
                Process ffprobeproc = new Process();
                ffprobeproc.StartInfo = procffprobe;
                ffprobeproc.OutputDataReceived += (sender, args) => ffprobeOutput(args.Data);
                ffprobeproc.ErrorDataReceived += (sender, args) => ffprobeOutput(args.Data); //same method used for error data
                ffprobeproc.Start();				//start the ffprobe
                ffprobeproc.BeginOutputReadLine();	// Set our event handler to asynchronously read the sort output.
                ffprobeproc.BeginErrorReadLine();
                ffprobeproc.WaitForExit();          //since it is started as separate thread, GUI will continue separately, but we wait here before starting next task
                temp_path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".jpg";
                ffprobeproc.CancelOutputRead();	//stop reading redirected standard output
                ffprobeproc.CancelErrorRead();
                
                //Thread.Sleep(500);
                return 0;					//0 means OK, not used so far
            }
            catch (Exception ex)
            {
                statustekst = ex.Message;
                return -1;					//-1 means NOT OK, not used so far
                //statustekst = "ERROR:" + ex.Message;
            }
        }
        void ffprobeOutput(string output)
        {       //read output sent from ffprobe
            try
            {
                json += output; //put it in string to be parsed to get file info
            }
            catch (Exception x)
            {
                //statustekst = "ERROR:" + x.Message;
            }
        }
         private void ffmpeg_extract_jpeg(string tstamp)
        {           //start ffmpeg process in separate thread to extract image from video file at specified position
            try
            {
                System.Diagnostics.ProcessStartInfo procff;
                if (!IsLinux)
                    procff = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " ffmpeg -ss " + tstamp + " -i \"" + input_file + "\" -y -qscale:v 2 -vframes 1 \"" +temp_path);// Windows: define Process Info to assing to the process
                else
                    procff = new System.Diagnostics.ProcessStartInfo("./ffmpeg", " -ss " + tstamp + " -i \"" + input_file + "\" -y -qscale:v 2 -vframes 1 " +temp_path); // for Linux with mono
				// The following commands are needed to redirect the standard output and standard error.
				// This means that it will be redirected to the Process.StandardOutput StreamReader.
				procff.RedirectStandardError = false;
				procff.RedirectStandardOutput = false;
				procff.RedirectStandardInput = false; ;
				procff.UseShellExecute = false;
				procff.CreateNoWindow = true;	// Do not create the black window.
				procff.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);//set path of vtc.exe same as ffmpeg.exe

				//proc.StartInfo = procStartffmpeg;   // Now we assign process its ProcessStartInfo and start it
				Process ffproc = new Process();
				ffproc.StartInfo = procff;
				ffproc.Start();				//start the ffprobe
				ffproc.WaitForExit();
            }
            catch (Exception ex)
            {
                statustekst = ex.Message;
            }
        } 
        private void extract_jpeg()
        {
            try
            {
                BackgroundWorker jpeg = new BackgroundWorker();					 //new instance of Background worker
                jpeg.WorkerReportsProgress = true;
                jpeg.DoWork += jpeg_DoWork;											 //handler for starting thread
                jpeg.RunWorkerCompleted += jpeg_RunWorkerCompleted;					 //handler for finishing thread
                jpeg.RunWorkerAsync();    //start job as separate thread
            }
            catch (Exception x)
            {

            }
        }
        private void jpeg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {					//new thread started, here we define process start, etc.
                Thread.Sleep(900);
                ffmpeg_extract_jpeg(time_position);	//extract image screenshot in this func								
            }
            catch (Exception x)
            {
                statustekst = x.Message;
            }
        }
        private void jpeg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void timerBatch_Tick(object sender, EventArgs e)
        {						//timer ticks every 1 sec to display progress, messages, etc. when encoding
            try
            {

                if (canceled)
                {						//cancel if flag set by Cancel method
                    afterCancelOrFinish();
                    toolStripStatusLabel1.Text = statustekst;
                    richTextBox3.Text = output_log;
                }
                else
                {				//display elapsed time, output from ffmpeg
                    toolStripStatusLabel1.Text = "Time: " + stopwatch.Elapsed.ToString(@"hh\:mm\:ss") + "s  | " + statustekst;
                    toolStripProgressBar1.Value = (int)((encoded_sec / total_sec) * 100);//set percentage for displaying progress of current task
                    richTextBox3.Text = output_log;
                }

            }
            catch (Exception ex)
            {
                statustekst = ex.Message;
            }
        }
        private int batchTask(string current_task)
        {			//called when starting each ffmpeg encoding task, passed task string as parameter
            try
            {
                System.Diagnostics.ProcessStartInfo procStartffmpeg;
                if (!IsLinux)
                    procStartffmpeg = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + current_task);// Windows: define Process Info to assing to the process
                else
                    procStartffmpeg = new System.Diagnostics.ProcessStartInfo("./ffmpeg", current_task); // for Linux with mono
                // The following commands are needed to redirect the standard output and standard error.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartffmpeg.RedirectStandardOutput = true;
                procStartffmpeg.RedirectStandardInput = true;
                procStartffmpeg.RedirectStandardError = true;
                procStartffmpeg.UseShellExecute = false;
                procStartffmpeg.CreateNoWindow = true;	// Do not create the black window.
                procStartffmpeg.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);//set path of vtc.exe same as ffmpeg.exe

                proc.StartInfo = procStartffmpeg;   // Now we assign process its ProcessStartInfo and start it

                proc.Start();				//start the ffmpeg
                ffmpeg_process_id = proc.Id;//remember process id so that it can be closed if user cancels
                Thread.Sleep(500);			//wait a little bit - prevent glitches for concurrent threads
                proc.BeginOutputReadLine();	// Set our event handler to asynchronously read the sort output.
                proc.BeginErrorReadLine();
                proc.WaitForExit();			//since it is started as separate thread, GUI will continue separately, but we wait here before starting next task
                proc.CancelOutputRead();	//stop reading redirected standard output
                proc.CancelErrorRead();
                return 0;					//0 means OK, not used so far
            }
            catch (Exception ex)
            {
                statustekst = ex.Message;
                return -1;					//-1 means NOT OK, not used so far
                //statustekst = "ERROR:" + ex.Message;
            }
        }
        void DisplayOutput(string output)
        {									//called by task thread to read std out from process and set values to be displayed when timer event fires
            try
            {
                if (!duration_found)		//read line by line std out until duration of the video or audio is found
                {
                    if (output.Contains("Duration:"))
                    {									//ok, here is duration, remember it as total time
                        std_out = output.Substring(output.IndexOf("Duration:") + 10, 8);		//always at same position within std out line
                        total_sec = TimeSpan.ParseExact(std_out, "hh\\:mm\\:ss", null).Ticks;	//set format of duration as TimeSpan
                        duration_found = true;	//flag that duration is found, we may skip it for the rest of the current std out
                    }
                }
                else if (output != null)
                {							//after duration found, read progress for each std out line
                    if (output.Contains("time="))
                    {						//in each line we search for occurence of time value
                        std_out = output.Substring(output.IndexOf("time=") + 5, 8);	//time value is at this position
                        encoded_sec = TimeSpan.ParseExact(std_out, "hh\\:mm\\:ss", null).Ticks;	//set format of current time
                        percent = ((encoded_sec / total_sec) * 100).ToString("0.00");	//calculate percentage
                        statustekst = " " + percent + "%   |  " + output;	//define text to display with calculated values
                    }
                    else if (output.Contains("Conversion failed!"))
                    {
                        error_in_file = true; //set to warn that file failed to convert
                        statustekst = output;
                    }
                    else if (!output.Contains("To ignore this"))
                        statustekst = output; //catch any error message
                }
                output_log += output + "\n";
                
            }
            catch (Exception x)
            {
                statustekst = "ERROR:" + x.Message;
            }
        }

        private void buttonStartQueue_Click(object sender, EventArgs e)
        {									//handler for user clicking to start encoding of batch list
            try
            {
                // first start of task list (not before started or paused)
                // populate task list from Grid and start execution
                if (!started && !paused)
                {
                    started = true;
                    buttonStartQueue.Text = "Pause ||";
                    richTextBox3.Text = "";
                    output_log = "";
                    buttonLog.Visible = true;
                    buttonLog.Enabled = true;
                    buttonLog2.Visible = true;
                    buttonLog2.Enabled = true;
                    DataGridViewCell check_cell = new DataGridViewCheckBoxCell(true);//new instance of check cell
                    DataGridViewRow row = new DataGridViewRow();                     //new temp row
                    BackgroundWorker bg = new BackgroundWorker();                    //new instance of Background worker
                    bg.WorkerReportsProgress = true;
                    bg.DoWork += bg_DoWork;                                          //handler for starting thread
                    bg.RunWorkerCompleted += bg_RunWorkerCompleted;                  //handler for finishing thread
                    canceled = false;                                                //our new job is not yet canceled
                    statustekst = "Job started";
                    toolStripProgressBar1.Value = 0;                                 //initial progress
                    toolStripProgressBar1.Maximum = 100;                             //max progress possible - 100%
                    stopwatch.Reset();                                               //reset measured time
                    stopwatch.Start();                                               //start measuring time
                    timerBatch.Interval = 1000;                                      //display progress every second
                    timerBatch.Enabled = true;                                       //start displaying progress
                    DisableButtonsWhenEncoding();                                    //prevent user to add, delete, etc. while encoding is running
                    for (int i = 0; i < number_of_rows; i++)
                    {           //for each task in the list, read command string value
                        task_list[i] = dataGridViewBatch.Rows[i].Cells[2].Value.ToString();
                    }
                    bg.RunWorkerAsync();    //start job as separate thread
                }
                else if (started && !paused)  // task list is started but not paused, set it to paused, change button caption and send Pause to ffmpeg proces
                {
                    paused = true;
                    buttonStartQueue.Text = "Resume >";
                    buttonStartQueue.BackColor = System.Drawing.Color.SteelBlue;
                    proc.StandardInput.Write((char) 13);
                    Thread.Sleep(300);
                }
                else // task list is started and paused, set it to resumed, change button caption and send Resume code to ffmpeg proces
                {
                    paused = false;
                    buttonStartQueue.Text = "Pause ||";
                    buttonStartQueue.BackColor = System.Drawing.Color.Transparent;
                    proc.StandardInput.Write((char) 10);
                    Thread.Sleep(300);
                }

            }
            catch (Exception ex)
            {					//in case something goes wrong, stop timers and enable user control
                toolStripStatusLabel1.Text = "ERROR: " + ex.ToString() + statustekst;
                afterCancelOrFinish();
            }
        }
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {					//new thread started, here we define process start, etc.
                DataGridViewCell check_cell = new DataGridViewCheckBoxCell(true);//needed to mark task checked when each job finishes
                DataGridViewRow row = new DataGridViewRow();
                statustekst = "";								//empty messages at the beginning
                for (int i = 0; i < number_of_rows; i++)
                {
                    if (!canceled)
                    {												//if not by any chance user marked as canceled
                        task = task_list[i];						//read next command string from task list
                        dataGridViewBatch.Rows[i].Selected = true;	//mark row in GUI so user knows which one is processed
                        duration_found = false;						//reset flag from previous task
                        ffmpeg_process_id = batchTask(task);		//start encoding, process has already finished so this var can be reused
                        check_cell.Value = true;					//set check in GUI that this job is finished
                        row = dataGridViewBatch.Rows[i];
                        row.Cells["check_cell"].Value = check_cell.Value;
                        row.Selected = false; 						//unselect this row in the list
                        stopwatch.Restart();						//restart measuring time for next job
                    }
                }
                //finished = true;
            }
            catch (Exception x)
            {
                ffmpeg_process_id = -1;
                statustekst = x.Message;
                afterCancelOrFinish();
            }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (statustekst.Contains("kb/s") || statustekst.Contains("mux") || statustekst.Contains("global headers:") || statustekst.Contains("Qavg:"))
            {
                statustekst = "Encoding finished!   " + statustekst;    //message when thread finishes with all jobs
                canceled = true;
            }
            else
            {
                statustekst = "Encoding aborted!    " + statustekst;
                canceled = true;
            }
            if (error_in_file)
            {
                MessageBox.Show("At least one file failed to convert. Check output file sizes: usually the very small one (only few kB) is not converted for some reason, e.g. missing header, etc.");
                error_in_file = false;
            }
            afterCancelOrFinish(); 
        }

        private void afterCancelOrFinish()
        {
            try
            {
                stopwatch.Stop();
                timerBatch.Enabled = false;
                buttonStartQueue.Text = "Start";
                EnableButtonsAfterEncoding();//enable buttons so user can edit tasks
                toolStripProgressBar1.Value = 0;
                toolStripStatusLabel1.Text = statustekst;
                canceled = false;
                paused = false;
                started = false;
            }
            catch (Exception x)
            {
                statustekst = x.Message;
                paused = false;
                started = false;
            }
        }
        private void buttonCancelBatch_Click(object sender, EventArgs e)
        {
            try
            {				//user clicks to cancel encoding
                DialogResult result = MessageBox.Show("All your jobs will be canceled!\nHowever, your queue will remain available for editing.\nDo you want to proceed?", "Queued jobs cancel", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    canceled = true;
                    afterCancelOrFinish();					//if confirms cancel call method to stop all jobs
                    toolStripStatusLabel1.Text = "Encoding canceled after " + stopwatch.Elapsed.ToString(@"hh\:mm\:ss") + "s ";
                    proc.StandardInput.Write('q');  //sending 'q' to ffmpeg gracefully stops encoding and closes parent cmd window (hidden)
                    Thread.Sleep(900);
                    proc.CancelErrorRead();         //stop reading std out
                    proc.CancelOutputRead();        //stop reading std error
                    Process p = Process.GetProcessesByName("ffmpeg").FirstOrDefault(); // find current ffmpeg process
                    p.Kill(); // and kill it
                    Thread.Sleep(900);
                }
            }
            catch (Exception ex)
            {
                statustekst = ex.Message;
            }
        }

        private void DisableButtonsWhenEncoding()
        {									//disable user interaction with controls while encoding in progress
            panelConvert.Enabled = false;
            panelTranscode.Enabled = false;
            groupBoxOptions.Enabled = false;
            buttonCancelBatch.Enabled = true;
            //buttonStartQueue.Enabled = false;
            buttonDeleteQueue.Enabled = false;
            buttonAddBatchConv.Enabled = false;
            buttonInputConvFile.Enabled = false;
            buttonMultiConvFiles.Enabled = false;
            //buttonOutConvFile.Enabled = false;
            buttonOutTransFile.Enabled = false;
            buttonMultiTransFile.Enabled = false;
            groupBoxAudio.Enabled = false;
            groupBoxContainer.Enabled = false;
            groupBoxVideoOrAudio.Enabled = false;
            buttonAddSubtitle.Enabled = false;
            buttonInfo.Visible = false;
            groupBoxVideoSize.Enabled = false;
            groupBoxSlow.Enabled = false;
            groupBoxRotate.Enabled = false;
            groupBoxCPU.Enabled = false;
            comboBoxAudioStreamNo.Enabled = false;
        }
        private void EnableButtonsAfterEncoding()
        {									//enable user interaction
            panelConvert.Enabled = true;
            panelTranscode.Enabled = true;
            groupBoxOptions.Enabled = true;
            buttonCancelBatch.Enabled = false;
            buttonStartQueue.Enabled = true;
            buttonDeleteQueue.Enabled = true;
            buttonAddBatchConv.Enabled = true;
            buttonInputConvFile.Enabled = true;
            buttonMultiConvFiles.Enabled = true;
            //buttonOutConvFile.Enabled = true;
            buttonOutTransFile.Enabled = true;
            buttonMultiTransFile.Enabled = true;
            groupBoxAudio.Enabled = true;
            groupBoxContainer.Enabled = true;
            groupBoxVideoOrAudio.Enabled = true;
            buttonAddSubtitle.Enabled = true;
            buttonStartQueue.BackColor = System.Drawing.Color.Transparent;
            groupBoxVideoSize.Enabled = true;
            groupBoxSlow.Enabled = true;
            groupBoxRotate.Enabled = true;
            groupBoxCPU.Enabled = true;
            comboBoxAudioStreamNo.Enabled = true;
        }
        private void ReadParametersFromGUI()
        {
            try
            {					//called whenever user clicks options controls to store new values in variables
                if (checkBoxVideoOnly.Checked)
                {
                    video_only = true;
                    audio_only = false;
                    groupBoxAudio.Enabled = false;
                    comboBoxAudioStreamNo.Enabled = false;
                    str_extension = orig_ext;
                }
                else
                {
                    video_only = false;
                    groupBoxAudio.Enabled = true;
                    comboBoxAudioStreamNo.Enabled = true;
                }

                if (checkBoxAudioOnly.Checked)
                {
                    audio_only = true;
                    video_only = false;
                    groupBoxContainer.Enabled = false;
                    groupBoxRotate.Enabled = false;
                    groupBoxCPU.Enabled = false;
                    groupBoxVideoSize.Enabled = false;
                    groupBoxSlow.Enabled = false;
                }
                else
                {
                    audio_only = false;
                    groupBoxContainer.Enabled = true;
                    groupBoxRotate.Enabled = true;
                    groupBoxCPU.Enabled = true;
                    groupBoxVideoSize.Enabled = true;
                    groupBoxSlow.Enabled = true;
                    str_extension = orig_ext;
                }
                if (checkBoxAudioOnly.Checked)
                    buttonAddSubtitle.Enabled = false;
                else
                    buttonAddSubtitle.Enabled = true;
                //
                if (radioButtonMP3.Checked)
                {
                    audio = "libmp3lame";
                    audio_ext = "mp3";
                }
                else if (radioButtonAAC.Checked)
                {
                    audio = "aac";
                    audio_ext = "aac";
                }
                else audio = " copy";
                //
                if (radioButtonMKV.Checked)
                {
                    container = "mkv";
                }
                else if (radioButtonMP4.Checked)
                {
                    container = "mp4";
                }
                else container = " copy";
                //
                if (checkBox180.Checked)
                {
                    if (vf != "")
                        vf += ",\"rotate=PI\"";
                    else
                        vf = " -vf \"rotate=PI\"";
                }
                if (checkBox90clockwise.Checked)
                {
                    if (vf != "")
                        vf += "\"rotate=PI/2\"";
                    else
                        vf = " -vf \"rotate=PI/2\"";
                }
                if (checkBox90counterclockwise.Checked)
                {
                    if (vf != "")
                        vf += "\"rotate=-PI/2\"";
                    else
                        vf = " -vf \"rotate=-PI/2\"";
                }
                //
                preset = comboBoxPreset.SelectedItem.ToString();
                //
                crf = comboBoxQuality.SelectedItem.ToString();
                //
                audiobitrate = comboBoxAudioBitRate.SelectedItem.ToString();
                // check if user wants to resize video and apply VF filter value
                if (radioButton_1080p.Checked)
                {
                    if (vf != "")
                        vf += ",scale=1920:-2";//value -2 means if because some filters want to have multiplicator of 2 (some even 4)
                    else
                        vf = " -vf scale=1920:-2";
                }
                else if (radioButton_720p.Checked)
                {
                    if (vf != "")
                        vf += ",scale=1280:-2";
                    else
                        vf = " -vf scale=1280:-2";
                }
                else if (radioButton_480p.Checked)
                {
                    if (vf != "")
                        vf += ",scale=720:-2";
                    else
                        vf = " -vf scale=720:-2";
                }
                else if (radioButton_No_Video_Resize.Checked)
                {
                    video_size = "";
                }
                else video_size = "";

            }
            catch (Exception x)
            {

            }
        }
        private string SetupConversionOptions()
        {
            try
            {				//the most important part of preparing values passed as ffmpeg arguments
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = "."; //use . as number separator as ffmpeg requests it
                string ext = "";		//initial file extension
                string input_srt = "";
                string srt_options = "";
                string stream_option = " -map 0:0 -map 0:" + audio_stream + "?"; //used when user selects audio stream and/or subtitle stream
                vf = "";
                string input_fps = ""; //if option to set input FPS is used
                out_fps = ""; //if option to set output FPS is used. i.e. creation of slow motion video
                ReadParametersFromGUI();//read options set by user on GUI
                // Test if target FPS is to be set differently from source video
                if (set_fps)
                {
                    out_fps = " -r " + textBoxFPSout.Text;
                }
                // Test if input FPS rate is high speed and needs to be normalized, used in conjunction with target FPS
                if (slow_motion)
                {
                    out_fps = " -r " + textBoxFPSout.Text;
                    if (vf != "")
                        vf += ",setpts=" + Convert.ToDouble(textBoxSlowFPS.Text).ToString(nfi) + "*PTS";
                    else
                        vf = " -vf setpts=" + Convert.ToDouble(textBoxSlowFPS.Text).ToString(nfi) + "*PTS";
                }
                if (str_extension == "mp3" || str_extension == "aac" || str_extension == "ac3" || str_extension == "wma" || str_extension == "wav" || str_extension == "flac")		//if input file is audio file, then set options so the only audio ouput is produced
                {
                    audio_only = true;
                    video_only = false;
                }

                string ff;				//temp var to store ffmpeg command string
                if (audio_only)			//audio only file is produced
                {
                    container = " -vn";//put option to exclude video stream
                    input_fps = "";
                    out_fps = "";
                    vf = "";
                }
                if (video_only)
                    audio = " -an";		//set audio option to exclude audio stream
                if (audio != " copy" && audio != " -an")					//if audio not excluded or copied
                    audio_part = " -c:a " + audio + " -b:a " + audiobitrate;	//define audio options as read from GUI
                else
                {
                    if (audio == " copy")
                        audio_part = " -c:a" + audio;	//set option to copy audio stream
                    else
                        audio_part = audio;				//otherwise complete audio part as excluded, maybe this is redundant?!
                }
                if (container != " copy" && container != " -vn")
                {										//if video not excluded or copied set video codec
                    if (h265)   //check first if H.265 selected
                    {
                        ext = container;
                        video = " -c:v libx265 -pix_fmt yuv420p -preset " + preset + " -crf " + crf;
                    }
                    else        //otherwise use H.264
                    {
                        ext = container;
                        video = " -c:v libx264 -preset " + preset + " -crf " + crf;
                    }
                }										//set it like defined on GUI
                else
                {
                    //otherwise
                    if (audio_only)
                    {
                        ext = audio_ext;				//audio extension if audio only
                        video = container;				//video part as defined in previous audio_only check
                    }
                    else
                    {									//not audio only, so it is copy video
                        str_extension = orig_ext;		//use original file extension - copy option
                        ext = str_extension;
                        video = " -c:v" + container;
                    }
                }
                if (container == " copy" && vf != "")
                {
                    video = "";  //if user decides to resize video with copy option, this will prevent error message by encoder
                }
                // Test if there is an input srt to be added as a stream
                if (add_sub_stream && !audio_only)
                {
                    input_srt = " -f srt -i \"" + subtitle_stream + "\" ";
                    stream_option += " -map 1:0";
                    if (ext == "mp4")
                        srt_options = " -c:s mov_text";
                    else if (ext == "mkv")
                        srt_options = " -c:s srt";
                }
                // complete string to be passed to process start
                if (!IsLinux)
                    ff = "ffmpeg "+ "-y" + input_fps + " -i \"" + input_file + "\"" + input_srt + stream_option + video + vf + " " + audio_part + srt_options + out_fps + " \"" + out_file + "1." + ext + "\""; // Windows
                else
                    ff = " " + "-y" + input_fps + " -i \"" + input_file + "\"" + input_srt + stream_option + video + vf + " " + audio_part + srt_options + out_fps + " \"" + out_file + "1." + ext + "\""; //Linux

                return ff;
            }
            catch (Exception x)
            { return "null"; }
        }

        private void buttonMultiConvFiles_Click(object sender, EventArgs e)
        {						//handler when user decides to add multiple files for conversion
            string[] input_list = new string[16383];//var to fill in with user selection
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Video files|*.m4v;*.mp4;*mkv;*.avi;*.mpg;*.divx;*.mov;*.wmv|Audio files|*.mp3;*.wma;*.wav;*.aac;*.ac3;*.flac|All files|*.*";						//filters for various video and audio files
            openFileDialog.Title = "Choose video or audio files to convert";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                input_list = openFileDialog.FileNames;		//populate list with file names
                foreach (string value in input_list)
                {
                    input_file = value;						//read file names one by one
                    MultiConvRow();
                    buttonStartQueue.Enabled = true;					//ok, we have at least 1 row, allow user to start encoding
                    buttonUnselectAll.Enabled = true;					//allow user to edit list
                    buttonSellectAllQueue.Enabled = true;
                    input_file = "";
                }
                buttonInfo.Visible = false;
            }
        }
        private void buttonMultiConvFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    input_file = filePath;
                    MultiConvRow();                     //process each file to add appropriate command to the list
                    buttonStartQueue.Enabled = true;					//ok, we have at least 1 row, allow user to start encoding
                    buttonUnselectAll.Enabled = true;					//allow user to edit list
                    buttonSellectAllQueue.Enabled = true;				//enable user to start, stop, select, delete
                    input_file = "";
                }
                buttonInfo.Visible = false;
            }
        }
        private void dataGridViewBatch_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    input_file = filePath;
                    if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
                        MultiConvRow();                                 //process each file to add appropriate command to the list
                    else
                        MultiTransRow();
                    buttonStartQueue.Enabled = true;					//ok, we have at least 1 row, allow user to start encoding
                    buttonUnselectAll.Enabled = true;					//allow user to edit list
                    buttonSellectAllQueue.Enabled = true;				//enable user to start, stop, select, delete
                    input_file = "";
                }
                buttonInfo.Visible = false;
            }
        }
        private void MultiConvRow()
        {
            try
            {
                int str_position = input_file.LastIndexOf('.') + 1;	//find where extension starts
                str_extension = input_file.Substring(str_position);	//define file extension
                orig_ext = str_extension;							//store it so it is not lost in later manipulation
                str_position = input_file.LastIndexOf("\\") + 1;	//find where file name begins
                if (!use_out_path)           //if no out path set by user, use the same path as input file
                {
                    out_path = input_file.Substring(0, str_position);
                    //labelOutConvFile.Text = out_path;
                    //labelOutTransFile.Text = out_path;
                }
                else
                    out_path = labelOutConvFile.Text;
                string in_file = input_file.Substring(str_position);//input file name
                str_position = in_file.LastIndexOf('.') + 1;		//get where extension starts
                in_file = in_file.Substring(0, str_position);       //get just file name without extension

                out_file = out_path + in_file;						//build output file name from input file name
                subtitle_stream = "";                               //don't use subtitles for many files
                add_sub_stream = false;
                string command = SetupConversionOptions();			//get ffmpeg command for that file
                number_of_rows++;									//increase for another job in the list
                DataGridViewRow tempRow = new DataGridViewRow();					//new instances to store additional row
                DataGridViewCell check_cell = new DataGridViewCheckBoxCell(false);
                DataGridViewCell No_cell = new DataGridViewTextBoxCell();
                DataGridViewCell task_cell = new DataGridViewTextBoxCell();
                check_cell.Value = false;							//define values for new row
                No_cell.Value = number_of_rows;
                task_cell.Value = command;							//put command string in a new cell
                tempRow.Cells.Add(check_cell);
                tempRow.Cells.Add(No_cell);
                tempRow.Cells.Add(task_cell);
                dataGridViewBatch.Rows.Add(tempRow);				//add row to batch task
            }
            catch (Exception x)
            { }
        }
        private void buttonInputConvFile_Click(object sender, EventArgs e)
        {                   //user clicks to select 1 input file
            //h265 = false;
            //checkBoxH265.Checked = false;
            time_position = "5";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files|*.*|Video files|*.m4v;*.mp4;*mkv;*.avi;*.mpg;*.divx;*.mov;*.wmv|Audio files|*.mp3;*.wma;*.wav;*.aac;*.ac3;*.flac";
            openFileDialog.Title = "Choose video or audio file to convert";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fps = 0.00;
                toolStripStatusLabel1.Text = "Please wait, loading file info!";
                input_file = openFileDialog.FileName;				//code here is more or less repeated from other button click
                int str_position = input_file.LastIndexOf('.') + 1;
                str_extension = input_file.Substring(str_position);
                orig_ext = str_extension;
                str_position = input_file.LastIndexOf("\\") + 1;
                if (out_path == null || out_path == "")
                {
                    out_path = input_file.Substring(0, str_position);//just in case it is empty take input file vaule as a replacement
                    //labelOutConvFile.Text = out_path;
                    //labelOutTransFile.Text = out_path;
                }
                string in_file = input_file.Substring(str_position);
                str_position = in_file.LastIndexOf('.') + 1;
                in_file = in_file.Substring(0, str_position);// + str_extension;

                out_file = out_path + in_file;
                richTextBoxConv.Text = SetupConversionOptions();
                labelInputConvFile.Text = input_file;
                FileProperties(); //async run of ffprobe to get file info
				Thread.Sleep(1000);//wait for file info
				extract_jpeg();
				Thread.Sleep(100);
                EnableConvButtons();
                buttonInfo.Visible = true;
                buttonInfo.Enabled = true;
                checkBoxSlowFPS.Checked = false;
                checkBoxSetFPS.Checked = false;
                toolStripStatusLabel1.Text = "Done. File info loaded.";
            }

        }
        private void FileProperties()
        {
            try
            {
                json = "";
                fps = 0.00;
                
                BackgroundWorker ff = new BackgroundWorker();					 //new instance of Background worker
                ff.WorkerReportsProgress = true;
                ff.DoWork += ff_DoWork;											 //handler for starting thread
                ff.RunWorkerCompleted += ff_RunWorkerCompleted;					 //handler for finishing thread
                ff.RunWorkerAsync();    //start job as separate thread
            }
            catch(Exception x)
            {

            }
        }
        private void ff_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {					//new thread started, here we define process start, etc.
                int ffprobe_id = ffprobe(input_file);	//start ffprobe in this func								
            }
            catch (Exception x)
            {
                statustekst = x.Message;
            }
        }
        private string checkNull(dynamic stringForCheck)
        {
            try
            {
                if (stringForCheck == null)
                    return "";
                else
                    return stringForCheck;
            }
            catch (Exception x)
            {
                string msg = x.Message;
                return "";
            }
        }
        private void ff_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {   //it sorts out file info data after ffprobe parses it and fills in variables to pass to infoForm
            try
            {
                int count_aud_streams, count_sub_streams;
                dynamic JSON_helper;
                bool video_exists;
                time_position = "4";
                pass_video_info = "";
                pass_audio_info = "";
                pass_subtitle_info = "";
                pass_labelFormat2 = "";
                pass_labelSize2 = "";
                pass_labelFileName2 = "";
                pass_labelDuration2 = "";
                count_aud_streams = Regex.Matches(json, "\"audio\"").Count;
                count_sub_streams = Regex.Matches(json, "\"subtitle\"").Count;
                Dictionary<int, string> comboSource = new Dictionary<int, string>(); //create new collection for combo
                for (int i = 1; i <= count_aud_streams; i++)
                {
                    comboSource.Add(i, i.ToString()); //add stream numbers sequentially
                }
                //After adding values to Dictionary, use this as combobox datasource.
                if (count_aud_streams > 0)
                {
                    comboBoxAudioStreamNo.DataSource = new BindingSource(comboSource, null);
                    comboBoxAudioStreamNo.DisplayMember = "Value";
                    comboBoxAudioStreamNo.ValueMember = "Key";
                }
                file_info File_info = new file_info { };
                video_info Video_info = new video_info { };
                audio_info[] Audio_info = new audio_info[count_aud_streams];
                subtitle_info[] Subtitle_info = new subtitle_info[count_sub_streams];
                double duration = 0.0;
                video_exists = (Regex.Matches(json, "\"video\"").Count > 0);
                JSON_helper = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                string j_duration="";
                try
                {
                    j_duration = JSON_helper.format.duration;
                }
                catch (RuntimeBinderException)
                {}
                if (j_duration != "" && j_duration != null)
                {
                    duration = Convert.ToDouble(j_duration);
                    time_position = String.Format("{0:0}", duration / 8);
                }
                File_info.filename = JSON_helper.format.filename;
                File_info.size = JSON_helper.format.size / 1048576;
                pass_labelFileName2 = File_info.filename;
                pass_labelSize2 = String.Format("{0:0.0}", File_info.size.ToString()) + " MB";
                
                if (video_exists)
                {
                    try
                    {
                        Video_info.codec_long_name = JSON_helper.streams[0].codec_long_name;
                    }
                    catch (RuntimeBinderException)
                    { Video_info.codec_long_name = ""; }
                    try
                    {
                        Video_info.profile = JSON_helper.streams[0].profile;
                    }
                    catch (RuntimeBinderException) { Video_info.profile = ""; }
                    try
                    {
                        Video_info.width = JSON_helper.streams[0].coded_width;
                    }
                    catch (RuntimeBinderException) { Video_info.width = 0; }
                    try
                    {
                        Video_info.height = JSON_helper.streams[0].coded_height;
                    }
                    catch (RuntimeBinderException) { Video_info.height = 0; }
                    try
                    {
                        Video_info.r_frame_rate = JSON_helper.streams[0].r_frame_rate;
                    }
                    catch (RuntimeBinderException) { Video_info.r_frame_rate = ""; }
                    if (Video_info.codec_long_name.Contains("HEVC"))
                    {
                        h265 = true;
                        checkBoxH265.Checked = true;
                    }
                    else
                    {
                        h265 = false;
                        checkBoxH265.Checked = false;
                    }
                    double v_duration = 0.0;
                    try
                    {
                        v_duration = Convert.ToDouble(JSON_helper.streams[0].duration);
                    }
                    catch (RuntimeBinderException)
                    { v_duration = 0.0; }
                    if (v_duration != 0.0)
                    {
                        Video_info.duration = v_duration;
                        duration = Video_info.duration;
                        time_position = String.Format("{0:0}", duration / 8);
                    }
                    else
                        Video_info.duration = duration;
                    TimeSpan dur = TimeSpan.FromSeconds(Video_info.duration);
                    string j_bitrate = "";
                    try
                    {
                        j_bitrate = JSON_helper.streams[0].bit_rate;
                    }
                    catch (RuntimeBinderException)
                    { }
                    if (j_bitrate != "" && j_duration != null)
                        Video_info.bit_rate = Convert.ToDouble(j_bitrate);
                    else
                        Video_info.bit_rate = 0.0;
                    //double framerate;
                    string fr;
                    DataTable dt = new DataTable();
                    var framerate = dt.Compute(Video_info.r_frame_rate, "");
                    fr = String.Format("{0:0.00}", framerate);
                    pass_video_info = "Stream: 0\nCodec: \t" + Video_info.codec_long_name + "\nProfile: \t" + Video_info.profile +
                        "\nWxH: \t" + Video_info.width + "x" + Video_info.height + " \t" +
                        fr + " fps";
                    if (fr != "")
                    {
                        fps = Convert.ToDouble(fr);
                        textBoxFPSout.Text = fr;
                    }
                    else
                    {
                        fps = 0.00;
                        textBoxFPSout.Text = "0";
                    }
                    pass_labelDuration2 = dur.ToString(@"h\:mm\:ss");
                    pass_labelvideobitrate = String.Format("{0:0}", Video_info.bit_rate / 1000) + " kb/s";
                    string j_passLabelFormat = "";
                    try
                    {
                        j_passLabelFormat = JSON_helper.streams[0].codec_tag_string;
                    }
                    catch (RuntimeBinderException)
                    { }
                    if (j_passLabelFormat != "" && j_passLabelFormat !=null)
                        pass_labelFormat2 = j_passLabelFormat;
                    else
                        pass_labelFormat2 = Video_info.codec_long_name.Substring(0, 10);
                    //time_position = String.Format("{0:0}", Video_info.duration / 8);
                }
                else //no video, just audio
                {
                    for (int i = 0; i <= count_aud_streams - 1; i++)
                    {
                        Audio_info[i] = new audio_info();   //Initialize new object
                        try
                        {
                            Audio_info[i].codec_long_name = JSON_helper.streams[i].codec_long_name;
                        }
                        catch (RuntimeBinderException)
                        { Audio_info[i].codec_long_name = ""; }
                        try
                        {
                            Audio_info[i].channel_layout = JSON_helper.streams[i].channel_layout;
                        }
                        catch (RuntimeBinderException)
                        { Audio_info[i].channel_layout = ""; }
                        string j_audioDuration = "";
                        try
                        {
                            j_audioDuration = JSON_helper.streams[i].duration;
                        }
                        catch (RuntimeBinderException)
                        { }
                        if (j_audioDuration != "" && j_audioDuration!=null)
                        {
                            Audio_info[i].duration = j_audioDuration;
                            Audio_info[i].duration = Audio_info[i].duration.Substring(0, Audio_info[i].duration.IndexOf('.'));
                            double sec = Convert.ToDouble(Audio_info[i].duration);
                            TimeSpan ts = TimeSpan.FromSeconds(sec);
                            Audio_info[i].duration = String.Format("{0:g}", ts);
                        }
                        else
                            Audio_info[i].duration = duration.ToString();
                        try
                        {
                            Audio_info[i].bit_rate = Convert.ToDouble(JSON_helper.streams[i].bit_rate);
                        }
                        catch (RuntimeBinderException)
                        { Audio_info[i].bit_rate = 0.0; }
                        pass_audio_info += "Stream: " + i + "\nCodec: \t" + Audio_info[i].codec_long_name +
                            "\nBit rate: \t" + String.Format("{0:0}", Audio_info[i].bit_rate / 1000) + " kb/s\nDuration: \t" +
                            Audio_info[i].duration + "\t Channels: " + Audio_info[i].channel_layout + "\n\n";
                        
                    }
                    pass_labelvideobitrate = String.Format("{0:0.00}", Audio_info[0].bit_rate / 1024) + " kb/s";
                    pass_labelFormat2 = Audio_info[0].codec_long_name;
                    pass_labelDuration2 = Audio_info[0].duration;
                    fps = 0.00;
                    textBoxFPSout.Text = "0";
                }

                if (count_aud_streams > 0 && video_exists)
                {
                    for (int i = 1; i <= count_aud_streams; i++)
                    {
                        Audio_info[i - 1] = new audio_info();   //Initialize new object
                        try
                        {
                            Audio_info[i - 1].codec_long_name = JSON_helper.streams[i].codec_long_name;
                        }
                        catch (RuntimeBinderException)
                        { Audio_info[i - 1].codec_long_name = ""; }
                        try
                        {
                            Audio_info[i - 1].channel_layout = JSON_helper.streams[i].channel_layout;
                        }
                        catch (RuntimeBinderException)
                        { Audio_info[i - 1].channel_layout = ""; }
                        try
                        {
                            j_duration = JSON_helper.streams[i].duration;
                        }
                        catch (RuntimeBinderException)
                        { j_duration = ""; }
                        if (j_duration != "" && j_duration != null)
                        {
                            Audio_info[i - 1].duration = j_duration;
                            Audio_info[i - 1].duration = Audio_info[i - 1].duration.Substring(0, Audio_info[i - 1].duration.IndexOf('.'));
                            double sec = Convert.ToDouble(Audio_info[i - 1].duration);
                            TimeSpan ts = TimeSpan.FromSeconds(sec);
                            Audio_info[i - 1].duration = String.Format("{0:g}", ts);
                        }
                        else
                            Audio_info[i - 1].duration = duration.ToString();
                        string j_bitrate = "";
                        try
                        {
                            j_bitrate = JSON_helper.streams[i].bit_rate;
                        }
                        catch (RuntimeBinderException)
                        { }
                        if (j_bitrate != "" && j_bitrate !=null )
                            Audio_info[i - 1].bit_rate = Convert.ToDouble(j_bitrate);
                        pass_audio_info += "Stream: " + i + "\nCodec: \t" + Audio_info[i - 1].codec_long_name +
                            "\nBit rate: \t" + String.Format("{0:0}", Audio_info[i - 1].bit_rate / 1000) + " kb/s\nDuration: \t" +
                            Audio_info[i - 1].duration + "\nLanguage: \t";
                        try
                        {
                            Audio_info[i - 1].language = JSON_helper.streams[i].tags.language;
                        }
                        catch (RuntimeBinderException)
                        { Audio_info[i - 1].language = ""; }
                        pass_audio_info += Audio_info[i - 1].language +
                            "\t Channels: " + Audio_info[i - 1].channel_layout + "\n\n";
                    }
                }
                if (count_sub_streams > 0)
                {
                    for (int i = 1; i <= count_sub_streams; i++)
                    {
                        Subtitle_info[i - 1] = new subtitle_info(); //Initialize new object
                        try
                        {
                            Subtitle_info[i - 1].codec_long_name = JSON_helper.streams[i + count_aud_streams].codec_name;
                        }
                        catch (RuntimeBinderException)
                        { Subtitle_info[i - 1].codec_long_name = ""; }
                        try
                        {
                            Subtitle_info[i - 1].language = JSON_helper.streams[i + count_aud_streams].tags.language;
                        }
                        catch (RuntimeBinderException)
                        { Subtitle_info[i - 1].language = ""; }
                        pass_subtitle_info += "Stream: " + i + "\nLanguage: \t" +
                            Subtitle_info[i - 1].language + "\nCodec: \t" + Subtitle_info[i - 1].codec_long_name + "\n\n";
                    }
                }
                buttonInfo.Visible = true;
            }
            catch (Exception x)
            {
                string msg = x.Message;
                //buttonInfo.Visible = true;
            }
        }

        private string ToString(dynamic format)
        {
            throw new NotImplementedException();
        }

        private void buttonInputConvFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //h265 = false;
                //checkBoxH265.Checked = false;
                toolStripStatusLabel1.Text = "Please wait, loading file info!";
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                input_file = files[0];
                int str_position = input_file.LastIndexOf('.') + 1;
                str_extension = input_file.Substring(str_position);
                orig_ext = str_extension;
                str_position = input_file.LastIndexOf("\\") + 1;
                if (out_path == null || out_path == "")
                {
                    out_path = input_file.Substring(0, str_position);//just in case it is empty take input file vaule as a replacement
                    //labelOutConvFile.Text = out_path;
                    //labelOutTransFile.Text = out_path;
                }
                string in_file = input_file.Substring(str_position);
                str_position = in_file.LastIndexOf('.') + 1;
                in_file = in_file.Substring(0, str_position);// + str_extension;

                out_file = out_path + in_file;
                richTextBoxConv.Text = SetupConversionOptions();
                labelInputConvFile.Text = input_file;
                time_position = "5";
                fps = 0.00;
                FileProperties();
                Thread.Sleep(1000);//wait for file info
                extract_jpeg();
				EnableConvButtons();
                buttonInfo.Visible = true;
                buttonInfo.Enabled = true;
                toolStripStatusLabel1.Text = "Done. File info loaded.";
            }
        }
        private void buttonOutConvFile_Click(object sender, EventArgs e)
        {									//user clicks to select where to save files after encoding
            FolderBrowserDialog savePath = new FolderBrowserDialog();
            savePath.SelectedPath = out_path;
            savePath.Description = "Choose output file path";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                use_out_path = true;
                out_path = savePath.SelectedPath + "\\";		//store selected path to var
                labelOutConvFile.Text = out_path;				//let the user knows by writing it to GUI
                labelOutTransFile.Text = out_path;              //the same var is also for transcoding jobs
                                                                ////allow user interaction - to select multiple input files
                richTextBoxConv.Text = SetupConversionOptions();
                EnableConvButtons();
                buttonMultiTransFile.Enabled = true;
                buttonRemoveOutPath.Enabled = true;
                buttonRemoveOutPath.Visible = true;
                buttonRemoveTransPath.Enabled = true;
                buttonRemoveTransPath.Visible = true;
                if (input_file == "" || input_file == null)
                    buttonAddBatchConv.Enabled = false;         //but not allow to add task to the list if input file is empty

            }

        }

        private void buttonAddBatchConv_Click(object sender, EventArgs e)
        {								//after selecting input, output and options for conversion of 1 files user adds it to a list
            try
            {
                number_of_rows++;		//another row in a list
                DataGridViewRow tempRow = new DataGridViewRow();					//temp rows to store values to be added
                DataGridViewCell check_cell = new DataGridViewCheckBoxCell(false);
                DataGridViewCell No_cell = new DataGridViewTextBoxCell();
                DataGridViewCell task_cell = new DataGridViewTextBoxCell();
                check_cell.Value = false;
                No_cell.Value = number_of_rows;
                task_cell.Value = richTextBoxConv.Text;		//task command string is copied from richTextBoxConv
                tempRow.Cells.Add(check_cell);
                tempRow.Cells.Add(No_cell);
                tempRow.Cells.Add(task_cell);
                dataGridViewBatch.Rows.Add(tempRow);		//new row added to batch list
                //labelOutConvFile.Text = out_path;
                labelInputConvFile.Text = "";
                EnableButtonsAfterEncoding();				//allow user to use buttons to start, edit tasks
            }
            catch (Exception ex)
            { }
        }

        private void comboBoxPreset_SelectedIndexChanged(object sender, EventArgs e)
        {			//selects predefined values for encoder option
            preset = comboBoxPreset.SelectedItem.ToString();
            richTextBoxConv.Text = SetupConversionOptions();	//stores the change & sets up other options
        }

        private void comboBoxQuality_SelectedIndexChanged(object sender, EventArgs e)
        {			//selects predefined video encoding quality
            crf = comboBoxQuality.SelectedItem.ToString();
            richTextBoxConv.Text = SetupConversionOptions();	//stores the change & sets up other options
        }

        private void comboBoxAudioBitRate_SelectedIndexChanged(object sender, EventArgs e)
        {			//selects predefined audio bit rate
            audiobitrate = comboBoxAudioBitRate.SelectedItem.ToString();
            richTextBoxConv.Text = SetupConversionOptions();	//stores the change & sets up other options
        }

        private void radioButtonMKV_CheckedChanged(object sender, EventArgs e)
        {			//selects MKV as container for video files
            richTextBoxConv.Text = SetupConversionOptions();	//stores the change & sets up other options
        }

        private void radioButtonMP4_CheckedChanged(object sender, EventArgs e)
        {			//selects MP4 as video container
            richTextBoxConv.Text = SetupConversionOptions();	//stores the change & sets up other options
        }
        private void radioButtonCopyVideo_CheckedChanged(object sender, EventArgs e)
        {			//selects option to copy video stream from input file
            richTextBoxConv.Text = SetupConversionOptions();	//stores the change & sets up other options
        }
        private void radioButtonMP3_CheckedChanged(object sender, EventArgs e)
        {           //selects MP3 audio encoding
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void radioButtonAAC_CheckedChanged(object sender, EventArgs e)
        {           //selects AAC audio encoding
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void radioButtonCopyAudio_CheckedChanged(object sender, EventArgs e)
        {           //selects audio stream copy from input file
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void comboBoxAudioStreamNo_SelectedIndexChanged(object sender, EventArgs e)
        {           //select which audio stream to encode in output file, useful if encoding multiple audio file
            audio_stream = comboBoxAudioStreamNo.Text;
            if (audio_stream.Contains(","))
                audio_stream = "1";
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void RadioButton_1080p_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxConv.Text = SetupConversionOptions(); //resize input video
        }

        private void RadioButton_720p_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxConv.Text = SetupConversionOptions(); //resize input video
        }

        private void RadioButton_480p_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxConv.Text = SetupConversionOptions(); //resize input video
        }

        private void RadioButton_No_Video_Resize_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxConv.Text = SetupConversionOptions(); //resize input video
        }

        private void buttonDeleteQueue_Click(object sender, EventArgs e)
        {           //delete all selected tasks in the list
            try
            {
                int count = dataGridViewBatch.RowCount; //how many items in the list
                for (int j = count - 1; j >= 0; j--)
                {
                    DataGridViewRow row = new DataGridViewRow();//set temp row
                    row = dataGridViewBatch.Rows[j];
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {                                           //if check box set, remove row
                        dataGridViewBatch.Rows.Remove(row);
                        number_of_rows--;                       //now we have 1 row less than before
                    }
                }
                if (dataGridViewBatch.Rows.Count == 0)
                    buttonStartQueue.Enabled = false;
                toolStripStatusLabel1.Text = "Row(s) deleted";
            }
			catch (Exception x)
			{
				string m = x.Message;
			}
        }

        private void buttonSellectAllQueue_Click(object sender, EventArgs e)
        {               //selects all items in the list
            try
            {
                DataGridViewCell check_cell = new DataGridViewCheckBoxCell(true);
                check_cell.Value = true;        //new value for check_cell
                foreach (DataGridViewRow row in dataGridViewBatch.Rows)
                {
                    row.Cells["check_cell"].Value = check_cell.Value;   //check all cells
                }
            }
            catch { Exception x; }
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (!log)
            {
                richTextBox3.Height = dataGridViewBatch.Height +5;
                richTextBox3.Width = dataGridViewBatch.Width;
                richTextBox3.Visible = true;
                log = true;
                buttonLog.BackColor = System.Drawing.Color.SteelBlue;
                buttonLog2.BackColor = System.Drawing.Color.SteelBlue;
                buttonLogRec.BackColor = System.Drawing.Color.SteelBlue;
                buttonLog.Text = ">";
                buttonLogRec.Text = ">";
            }
            else
            {
                richTextBox3.Height = 0;
                richTextBox3.Width = 0;
                richTextBox3.Visible = false;
                log = false;
                buttonLog.BackColor = System.Drawing.Color.Transparent;
                buttonLog2.BackColor = System.Drawing.Color.Transparent;
                buttonLogRec.BackColor = System.Drawing.Color.Transparent;
                buttonLog.Text = "<";
                buttonLogRec.Text = "<";
            }
        }

        private void buttonLog2_Click(object sender, EventArgs e)
        {
            if (!log)
            {
                richTextBox3.Height = dataGridViewBatch.Height +5;
                richTextBox3.Width = dataGridViewBatch.Width;
                richTextBox3.Visible = true;
                log = true;
                buttonLog2.BackColor = System.Drawing.Color.SteelBlue;
                buttonLog.BackColor = System.Drawing.Color.SteelBlue;
                buttonLogRec.BackColor = System.Drawing.Color.SteelBlue;
            }
            else
            {
                richTextBox3.Height = 0;
                richTextBox3.Width = 0;
                richTextBox3.Visible = false;
                log = false;
                buttonLog2.BackColor = System.Drawing.Color.Transparent;
                buttonLog.BackColor = System.Drawing.Color.Transparent;
                buttonLogRec.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {               //deselect all items in the list
            try
            {
                DataGridViewCell check_cell = new DataGridViewCheckBoxCell(true);
                check_cell.Value = false;
                foreach (DataGridViewRow row in dataGridViewBatch.Rows)
                {
                    row.Cells["check_cell"].Value = check_cell.Value;
                }
            }
            catch { Exception x; }
        }

        private void checkBoxH265_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxH265.Checked)
            {
                h265 = true;  // use h.265 codec
                crf = "28";   // set quality factor for h.265, equivalent to 23 for h.264
                comboBoxQuality.SelectedItem = "28";
            }
            else
            {
                h265 = false; // use h.264
                crf = "23";   // set quality factor for h.264, equivalent to 20 for SD
                comboBoxQuality.SelectedItem = "23";
            }
            richTextBoxConv.Text = SetupConversionOptions();//now setup new options
        }

        private void checkBoxSetFPS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSetFPS.Checked)
            {
                textBoxFPSout.Enabled = true;

                if (fps == 0.00)        // FPS is NOT read from file, so warn the user with red color
                {
                    textBoxFPSout.BackColor = System.Drawing.Color.Red;
                    textBoxFPSout.Text = "0";
                }
                else                    // FPS is read from file, so use either slow motion or custom FPS
                {
                    textBoxFPSout.BackColor = System.Drawing.SystemColors.Window;
                    textBoxFPSout.Text = fps.ToString();
                    checkBoxSlowFPS.Checked = false;  // slow motion dowsn't make sense when custom FPS used
                }
                labelFPSout.Enabled = true;
                set_fps = true;
            }
            else
            {
                textBoxFPSout.Enabled = false;
                labelFPSout.Enabled = false;
                textBoxFPSout.BackColor = System.Drawing.SystemColors.Window;
                set_fps = false;
                if (fps != 0.00 && !checkBoxSlowFPS.Checked) // no slow motion used - use FPS from file
                    textBoxFPSout.Text = fps.ToString();
            }
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void checkBoxSlowFPS_CheckedChanged(object sender, EventArgs e)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = "."; //use . as number separator as ffmpeg requests it
            if (checkBoxSlowFPS.Checked)
            {
                textBoxSlowFPS.Enabled = true;
                labelSlowFPS.Enabled = true;
                slow_motion = true;
                
                if (fps != 0.00)
                {
                    textBoxFPSout.Text = (fps / Convert.ToDouble(textBoxSlowFPS.Text)).ToString(nfi);
                    checkBoxSetFPS.Checked = false;    // FPS known from file, only usage of slow motion divider makes sense
                }
            }
            else
            {
                textBoxSlowFPS.Enabled = false;
                labelSlowFPS.Enabled = false;
                slow_motion = false;
                if (fps != 0.00)
                    textBoxFPSout.Text = fps.ToString(nfi); // return original FPS value
            }
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void buttonTestStream_Click(object sender, EventArgs e)
        {
            ffplay_test(textBoxStream.Text);
        }

        private void buttonLogRec_Click(object sender, EventArgs e)
        {
            if (!log)
            {
                richTextBox3.Height = dataGridViewBatch.Height + 5;
                richTextBox3.Width = dataGridViewBatch.Width;
                richTextBox3.Visible = true;
                log = true;
                buttonLog.BackColor = System.Drawing.Color.SteelBlue;
                buttonLog2.BackColor = System.Drawing.Color.SteelBlue;
                buttonLogRec.BackColor = System.Drawing.Color.SteelBlue;
                buttonLog.Text = ">";
                buttonLogRec.Text = ">";
            }
            else
            {
                richTextBox3.Height = 0;
                richTextBox3.Width = 0;
                richTextBox3.Visible = false;
                log = false;
                buttonLog.BackColor = System.Drawing.Color.Transparent;
                buttonLog2.BackColor = System.Drawing.Color.Transparent;
                buttonLogRec.BackColor = System.Drawing.Color.Transparent;
                buttonLog.Text = "<";
                buttonLogRec.Text = "<";
            }
        }

        private void buttonCheckStream_Click(object sender, EventArgs e)
        {
            buttonCheckStream.Image = VTC.Properties.Resources._15;
            buttonCheckStream.Text = "";
            json = "";
            //ffprobe(textBoxStream.Text);
            BackgroundWorker ffp = new BackgroundWorker();                    //new instance of Background worker
            ffp.WorkerReportsProgress = true;
            ffp.DoWork += ff_DoFFprobeWork;                                          //handler for starting thread
            ffp.RunWorkerCompleted += ffprobe_RunWorkerCompleted;                  //handler for finishing thread
            ffp.RunWorkerAsync();    //start job as separate thread
            log = false;
            buttonLogRec.PerformClick();
            
        }

        private void ff_DoFFprobeWork(object sender, DoWorkEventArgs e)
        {
            try
            {					//new thread started, here we define process start, etc.
                int ffprobe_id = ffprobe(textBoxStream.Text);	//start ffprobe in this func								
            }
            catch (Exception x)
            {
                statustekst = x.Message;
            }
        }
        private void ffprobe_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {   //it gets ffprobe data after stream check
            try
            {
                richTextBox3.Text = json;
                buttonCheckStream.Image = null;
                buttonCheckStream.Text = "Check Stream";
                if (json != "{}")
                {
                    buttonStreamSavePath.Enabled = true;
                    buttonStartRec.Visible = true;
                    buttonStartRec.Enabled = true;
                }
                else
                {
                    richTextBox3.Text += "\n Stream not found!";
                    buttonStreamSavePath.Enabled = false;
                    buttonStartRec.Visible = false;
                    buttonStartRec.Enabled = false;
                }
            }
            catch (Exception x)
            { }
        }
        private void textBoxFPSout_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFPSout.Text == "0")
            {
                textBoxFPSout.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textBoxFPSout.BackColor = System.Drawing.SystemColors.Window;
                //set_fps = true;
            }
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void textBoxSlowFPS_TextChanged(object sender, EventArgs e)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = "."; //use . as number separator as ffmpeg requests it
            if (fps != 0.00)
                textBoxFPSout.Text = (fps / Convert.ToDouble(textBoxSlowFPS.Text)).ToString(nfi);
            
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void checkBoxTranscodeAllStreams_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTranscodeAllStreams.Checked)
                groupBoxTransGroupStreams.Enabled = false;
            else
                groupBoxTransGroupStreams.Enabled = true;
        }


        private void buttonRemoveOutPath_Click(object sender, EventArgs e)
        {
            out_path = "";
            use_out_path = false;
            buttonRemoveOutPath.Enabled = false;
            buttonRemoveOutPath.Visible = false;
            buttonRemoveTransPath.Enabled = false;
            buttonRemoveTransPath.Visible = false;
            labelOutConvFile.Text = "";
            labelOutTransFile.Text = "";
            //richTextBoxConv.Text = SetupConversionOptions();
        }

        private void buttonRemoveTransPath_Click(object sender, EventArgs e)
        {
            out_path = "";
            use_out_path = false;
            buttonRemoveOutPath.Enabled = false;
            buttonRemoveOutPath.Visible = false;
            buttonRemoveTransPath.Enabled = false;
            buttonRemoveTransPath.Visible = false;
            labelOutConvFile.Text = "";
            labelOutTransFile.Text = "";
        }

        private void checkBoxVideoOnly_CheckedChanged(object sender, EventArgs e)
        {               //select to encode file with video stream only
            if (checkBoxVideoOnly.Checked)
            {
                checkBoxAudioOnly.Checked = false;  //cannot have audio only when we have video only
            }
            richTextBoxConv.Text = SetupConversionOptions();//now setup new options
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            Form2 infoForm = new Form2(pass_video_info, pass_audio_info, pass_subtitle_info, pass_labelFileName2, pass_labelFormat2, pass_labelDuration2, pass_labelSize2, pass_labelvideobitrate, temp_path);
            infoForm.Show();
        }
        private void buttonInfo_MouseDown(object sender, MouseEventArgs e)
        {
            buttonInfo.BackgroundImage = VTC.Properties.Resources.button_over;
        }
        private void buttonInfo_MouseUp(object sender, MouseEventArgs e)
        {
            buttonInfo.BackgroundImage = VTC.Properties.Resources.button;
        }
        private void buttonInfo_Enter(object sender, EventArgs e)
        {
            buttonInfo.BackgroundImage = VTC.Properties.Resources.button_high;
        }
        private void buttonInfo_Leave(object sender, EventArgs e)
        {
            buttonInfo.BackgroundImage = VTC.Properties.Resources.button;
        }
        private void checkBoxAudioOnly_CheckedChanged(object sender, EventArgs e)
        {               //select to encode file with audio stream only
            if (checkBoxAudioOnly.Checked)
            {
                checkBoxVideoOnly.Checked = false;  //cannot have video only when we have audio only
            }
            richTextBoxConv.Text = SetupConversionOptions();
        }
        private void buttonMultiTransFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void buttonMultiConvFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        private void dataGridViewBatch_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        private void buttonInputConvFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //set event handlers for Drag&Drop onto the Input File(s) buttons and dataGridViewBatch
            this.dataGridViewBatch.DragDrop += new DragEventHandler(dataGridViewBatch_DragDrop);
            this.dataGridViewBatch.DragEnter += new DragEventHandler(dataGridViewBatch_DragEnter);
            this.buttonMultiTransFile.DragDrop += new DragEventHandler(buttonMultiTransFile_DragDrop);
            this.buttonMultiTransFile.DragEnter += new DragEventHandler(buttonMultiTransFile_DragEnter);
            this.buttonMultiConvFiles.DragDrop += new DragEventHandler(buttonMultiConvFiles_DragDrop);
            this.buttonMultiConvFiles.DragEnter += new DragEventHandler(buttonMultiConvFiles_DragEnter);
            this.buttonInputConvFile.DragDrop += new DragEventHandler(buttonInputConvFile_DragDrop);
            this.buttonInputConvFile.DragEnter += new DragEventHandler(buttonInputConvFile_DragEnter);
            SetToolTips();
            //disable buttons while the list is empty, but enable output path buttons
            //DisableButtonsWhenEncoding();       //initialy, many buttons are disabled until user enters file paths
            buttonOutConvFile.Enabled = true;
            buttonOutTransFile.Enabled = true;
            buttonCancelBatch.Enabled = false;
            buttonStartQueue.Enabled = false;
        }
        private void SetToolTips()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr-Cyrl");

            // TooTips for specific buttons
            // Commented tips for Serbian
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 500;
            toolTip2.ReshowDelay = 500;
            toolTip2.ShowAlways = true;
            toolTip3.AutoPopDelay = 5000;
            toolTip3.InitialDelay = 500;
            toolTip3.ReshowDelay = 500;
            toolTip3.ShowAlways = true;

            toolTip4.AutoPopDelay = 5000;
            toolTip4.InitialDelay = 500;
            toolTip4.ReshowDelay = 500;
            toolTip4.ShowAlways = true;
            toolTip6.AutoPopDelay = 5000;
            toolTip6.InitialDelay = 500;
            toolTip6.ReshowDelay = 500;
            toolTip6.ShowAlways = true;
            toolTip9.AutoPopDelay = 5000;
            toolTip9.InitialDelay = 500;
            toolTip9.ReshowDelay = 500;
            toolTip9.ShowAlways = true;
            toolTip10.AutoPopDelay = 5000;
            toolTip10.InitialDelay = 500;
            toolTip10.ReshowDelay = 500;
            toolTip10.ShowAlways = true;
            toolTip11.AutoPopDelay = 5000;
            toolTip11.InitialDelay = 500;
            toolTip11.ReshowDelay = 500;
            toolTip11.ShowAlways = true;
            toolTip12.AutoPopDelay = 5000;
            toolTip12.InitialDelay = 500;
            toolTip12.ReshowDelay = 500;
            toolTip12.ShowAlways = true;
            toolTip13.AutoPopDelay = 5000;
            toolTip13.InitialDelay = 500;
            toolTip13.ReshowDelay = 500;
            toolTip13.ShowAlways = true;
            toolTip14.AutoPopDelay = 5000;
            toolTip14.InitialDelay = 500;
            toolTip14.ReshowDelay = 500;
            toolTip14.ShowAlways = true;
            toolTip15.AutoPopDelay = 5000;
            toolTip15.InitialDelay = 500;
            toolTip15.ReshowDelay = 500;
            toolTip15.ShowAlways = true;
            toolTip16.AutoPopDelay = 5000;
            toolTip16.InitialDelay = 500;
            toolTip16.ReshowDelay = 500;
            toolTip16.ShowAlways = true;
            toolTip18.AutoPopDelay = 5000;
            toolTip18.InitialDelay = 500;
            toolTip18.ReshowDelay = 500;
            toolTip18.ShowAlways = true;
            toolTip19.AutoPopDelay = 5000;
            toolTip19.InitialDelay = 500;
            toolTip19.ReshowDelay = 500;
            toolTip19.ShowAlways = true;
            toolTip20.AutoPopDelay = 5000;
            toolTip20.InitialDelay = 500;
            toolTip20.ReshowDelay = 500;
            toolTip20.ShowAlways = true;
            toolTip21.AutoPopDelay = 5000;
            toolTip21.InitialDelay = 500;
            toolTip21.ReshowDelay = 500;
            toolTip21.ShowAlways = true;
            toolTip22.AutoPopDelay = 5000;
            toolTip22.InitialDelay = 500;
            toolTip22.ReshowDelay = 500;
            toolTip22.ShowAlways = true;
            toolTip23.AutoPopDelay = 5000;
            toolTip23.InitialDelay = 500;
            toolTip23.ReshowDelay = 500;
            toolTip23.ShowAlways = true;
            toolTip24.AutoPopDelay = 5000;
            toolTip24.InitialDelay = 500;
            toolTip24.ReshowDelay = 500;
            toolTip24.ShowAlways = true;
            toolTip25.AutoPopDelay = 5000;
            toolTip25.InitialDelay = 500;
            toolTip25.ReshowDelay = 500;
            toolTip25.ShowAlways = true;
            toolTip26.AutoPopDelay = 5000;
            toolTip26.InitialDelay = 500;
            toolTip26.ReshowDelay = 500;
            toolTip26.ShowAlways = true;
            toolTip27.AutoPopDelay = 5000;
            toolTip27.InitialDelay = 500;
            toolTip27.ReshowDelay = 500;
            toolTip27.ShowAlways = true;
            toolTip28.AutoPopDelay = 5000;
            toolTip28.InitialDelay = 500;
            toolTip28.ReshowDelay = 500;
            toolTip28.ShowAlways = true;
            toolTip29.AutoPopDelay = 5000;
            toolTip29.InitialDelay = 500;
            toolTip29.ReshowDelay = 500;
            toolTip29.ShowAlways = true;
            toolTip30.AutoPopDelay = 5000;
            toolTip30.InitialDelay = 500;
            toolTip30.ReshowDelay = 500;
            toolTip30.ShowAlways = true;
            toolTip31.AutoPopDelay = 5000;
            toolTip31.InitialDelay = 500;
            toolTip31.ReshowDelay = 500;
            toolTip31.ShowAlways = true;
            toolTip32.AutoPopDelay = 5000;
            toolTip32.InitialDelay = 500;
            toolTip32.ReshowDelay = 500;
            toolTip32.ShowAlways = true;
            toolTip33.AutoPopDelay = 5000;
            toolTip33.InitialDelay = 500;
            toolTip33.ReshowDelay = 500;
            toolTip33.ShowAlways = true;
            toolTip34.AutoPopDelay = 5000;
            toolTip34.InitialDelay = 500;
            toolTip34.ReshowDelay = 500;
            toolTip34.ShowAlways = true;
            toolTip35.AutoPopDelay = 5000;
            toolTip35.InitialDelay = 500;
            toolTip35.ReshowDelay = 500;
            toolTip35.ShowAlways = true;
            toolTip36.AutoPopDelay = 5000;
            toolTip36.InitialDelay = 500;
            toolTip36.ReshowDelay = 500;
            toolTip36.ShowAlways = true;
            toolTip37.AutoPopDelay = 5000;
            toolTip37.InitialDelay = 500;
            toolTip37.ReshowDelay = 500;
            toolTip37.ShowAlways = true;
            toolTip38.AutoPopDelay = 7000;
            toolTip38.InitialDelay = 500;
            toolTip38.ReshowDelay = 500;
            toolTip38.ShowAlways = true;
            toolTip39.AutoPopDelay = 7000;
            toolTip39.InitialDelay = 100;
            toolTip39.ReshowDelay = 500;
            toolTip39.ShowAlways = true;
            toolTip40.AutoPopDelay = 7000;
            toolTip40.InitialDelay = 100;
            toolTip40.ReshowDelay = 500;
            toolTip40.ShowAlways = true;
            toolTip41.AutoPopDelay = 7000;
            toolTip41.InitialDelay = 100;
            toolTip41.ReshowDelay = 500;
            toolTip41.ShowAlways = true;
            toolTip42.AutoPopDelay = 7000;
            toolTip42.InitialDelay = 100;
            toolTip42.ReshowDelay = 500;
            toolTip42.ShowAlways = true;
            toolTip43.AutoPopDelay = 7000;
            toolTip43.InitialDelay = 100;
            toolTip43.ReshowDelay = 500;
            toolTip43.ShowAlways = true;
            toolTip44.AutoPopDelay = 7000;
            toolTip44.InitialDelay = 100;
            toolTip44.ReshowDelay = 500;
            toolTip44.ShowAlways = true;
            toolTip45.AutoPopDelay = 7000;
            toolTip45.InitialDelay = 100;
            toolTip45.ReshowDelay = 500;
            toolTip45.ShowAlways = true;

            switch (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2))
            {
                case "en":
                    toolTip1.SetToolTip(this.tabPage1, "Select this tab if you want to repack MP4/M4V container to MKV or vice versa.\nDepending on your choice, program will automatically choose the other container's extension.");
                    toolTip2.SetToolTip(this.tabPage2, "Select this tab if you want to convert different types of audio or video files to other formats.\nYou can chhose files individually (button on the left) or multiple (upper right button) and add them to batch job list.\nYou can edit list, change ffmpeg options manually.\nYou can choose to have video only or audio only (e.g. to extract mp3).\nYou can choose quality, conversion speed, etc.\nOr, just select defaults.");
                    toolTip3.SetToolTip(this.buttonHelp, "Opens PDF help document stored in VTC.exe installation folder.");
                    toolTip4.SetToolTip(this.buttonOutTransFile, "Select output path where you want to save transcoded file(s).\nThe file name will be given AUTOMATICALLY by adding\n'1.' to the INPUT file name(s) that you select afterwards.");
                    toolTip6.SetToolTip(this.buttonMultiTransFile, "Select one or more files to be repacked to MKV or MP4,\ndepending on choice of input files format.\nBatch job list will be populated automatically.\nAfterwards, you can add more files to the job list from this tab or convert tab.\nYou can also drop files on this button.\nIMPORTANT HINT: SELECT OPTIONS BELOW FIRST, THEN SELECT FILES!!!");
                    toolTip9.SetToolTip(this.buttonStartQueue, "Click when you are done creating you job list.\nAll jobs in job list are executed in sequential order.\nPause if you need to perform some other task on the PC.");
                    toolTip10.SetToolTip(this.buttonCancelBatch, "Click to cancel execution of all jobs\nYour job list will remain if you want to manually edit it afterwards.");
                    toolTip11.SetToolTip(this.buttonSellectAllQueue, "Click to select all jobs for deletion.\n NOTE: This will not delete, button 'Delete' will delete selected jobs.");
                    toolTip12.SetToolTip(this.buttonUnselectAll, "Click to unselect all jobs in the list.");
                    toolTip13.SetToolTip(this.buttonDeleteQueue, "Click to delete all selected jobs.\nBefore that, use check boxes to select those that you want to delete.");
                    toolTip14.SetToolTip(this.buttonInputConvFile, "Select input file of various formats of audio or video files.\nPay attention to filters in dialog window.\nThat file will be converted depending on options selected after selecting a file.\nYou can also drop your file onto the button.\nIF YOU WANT TO OUTPUT TO DIFFERENT FOLDER, SELECT OUTPUT PATH FIRST!");
                    toolTip15.SetToolTip(this.buttonOutConvFile, "Select output path where converted files will be saved.\nBUT AFTER THAT YOU MUST SELECT INPUT FILE OR DROP FILE THERE!\nFile name will be generated from input file by adding\n    '1.' to the end of file.\nIf you want to change file name, use the TEXT BOX BELOW TO MANUALLY enter name after you selected options.");
                    toolTip16.SetToolTip(this.buttonMultiConvFiles, "Select more files to be converted\nWITH SAME OPTIONS DEFINED ON THIS TAB BEFORE CLICKING THIS BUTTON.\nBatch job list will be populated automatically.\nYou can also drop files onto this button.\nSELECT OPTIONS FIRST, THEN ADD FILES VIA THIS BUTTON!!!");
                    toolTip18.SetToolTip(this.richTextBoxConv, "When changing options, ffmpeg command is generated in this box.\nYou can tweak ffmpeg options manually if you are advanced user.\nWhen you are happy with command, you can click 'Add To Batch File List'.");
                    toolTip19.SetToolTip(this.buttonAddBatchConv, "When you select all options, click here to add job to the job list.\nAfterwards, you can select new options or keep the same for new job,\nor just click 'Start' to start encoding jobs in the list.");
                    toolTip20.SetToolTip(this.panelBatch, "The jobs that you added are displayed here.\nYou can drag and drop multiple files here (same effect as dropping files on Multiple Files button).\nIf you changed your mind regarding some options,\nyou can edit ffmpeg command directly in this table.\nWhen you are done building list, click 'Start' to process the queue.");
                    toolTip21.SetToolTip(this.checkBoxAudioOnly, "Select if you want to extract only audio from the input file.");
                    toolTip22.SetToolTip(this.checkBoxVideoOnly, "Select if you want to extract only video from the input file.");
                    toolTip23.SetToolTip(this.radioButtonMKV, "Select if you want to encode video as MKV.");
                    toolTip24.SetToolTip(this.radioButtonMP4, "Select if you want to encode video as MP4.");
                    toolTip25.SetToolTip(this.radioButtonMP3, "Select if you want to encode audio as MP3.");
                    toolTip26.SetToolTip(this.radioButtonAAC, "Select if you want to encode audio as AAC.");
                    toolTip27.SetToolTip(this.radioButtonCopyAudio, "Select if you want to copy original audio stream without changing.");
                    toolTip28.SetToolTip(this.radioButtonCopyVideo, "Select if you want to copy original video stream without changing.");
                    toolTip29.SetToolTip(this.comboBoxAudioBitRate, "Select bitrate for audio stream selected (AAC or MP3).\nNot relevant if 'audio copy' option used.");
                    toolTip30.SetToolTip(this.comboBoxPreset, "Select encoding preset speed.\nIMPORTANT: this determines encoding speed but also the size of the output file.\nFor smallest file choose the slowest you can bear!\nNot relevant if 'video copy' selected.");
                    toolTip31.SetToolTip(this.comboBoxQuality, "Select video quality.\nFor SD sources, 19-21 is excellent quality range.\nFor HD sources, 21-24 is normal range.\nYou can leave defaults to if you are happy with output quality,\nor experiment a little bit to find the best value for you.\nNot relevant if 'video copy' selected.");
                    toolTip32.SetToolTip(this.buttonAddSubtitle, "Add from .SRT file to mux as a stream.\nIGNORED WHEN USING MULTIPLE FILES.");
                    toolTip33.SetToolTip(this.checkBox180, "Rotate video 180 degrees, like in case when you hold phone in landscape mode when recording, but turned upside down.");
                    toolTip34.SetToolTip(this.checkBox90clockwise, "Rotate video 90 degrees clockwise.");
                    toolTip35.SetToolTip(this.checkBox90counterclockwise, "Rotate video 90 degrees counter clockwise.");
                    toolTip36.SetToolTip(this.comboBoxAudioStreamNo, "IMPORTANT: if audio stream doesn't exist, FIRST stream will be used.\nIf single file selected via Input File button, only existing streams will be displayed.");
                    toolTip37.SetToolTip(this.buttonInfo, "Show details about selected input file.");
                    toolTip38.SetToolTip(this.checkBoxH265, "H265 rules!!! Output will be encoded as H265 HEVC.");
                    toolTip39.SetToolTip(this.textBoxFPSout, "Enter desired FPS for output video. Note that if input video is, for example 120, and output FPS is 30, then every 4th frame is encoded and playback speed will be normal.");
                    toolTip40.SetToolTip(this.textBoxSlowFPS, "Enter how many times you need to slow down. You can click \"Input File\" button, you will get info on actual frame rate.");
                    toolTip41.SetToolTip(this.checkBoxTransRemoveSubtitle, "If embedded subtitle exists in the input file,\nthen you can remove it from output file with this option.\nUseful if FFmpeg THROWS an ERROR.");
                    toolTip42.SetToolTip(this.groupBoxVideoSize, "Try to resize video to Full HD, 720p or SD with option to have ratio multiple of 2. You can also manually enter resize values in the box below. If it fails, check the log messages.");
                    toolTip43.SetToolTip(this.checkBoxTranscodeAllStreams, "Try to copy all streams from original to output (map -0: option). If it FAILS, then remove from batch, and try without this option.\n If UNCHECKED, ENTER STREAM NUMBERS TO BE ENCODED TO THE RIGHT.\nUseful if you want to REMOVE ADDITIONAL AUDIO STREAMS.");
                    toolTip44.SetToolTip(this.checkBoxKeepExtension, "Do NOT change file extension (if it's MP4 it stays, the same for other containers).\nUseful if you want to extract only 1st video, audio and keep file type.\nUSE TOGETHER WITH UNCHECKED option above - DO NOT copy all video&audio).");
                    toolTip45.SetToolTip(this.buttonLog, "Click to display or hide the FFmpeg log.");

                    break;
                case "sr":
                    toolTip1.SetToolTip(this.tabPage1, "На овом табу можете препаковати MKV-->MP4 и обрнуто.\nАко изаберете MKV, програм ће аутоматски изабрати MP4 и обрнуто.");
                    toolTip2.SetToolTip(this.tabPage2, "На овом табу можете направити пуну конверзију различитих формата (AVI, DIVX, XVID, WMV, OGG, FLAC, итд.) у MKV,MP4,AAC,MP3.\nФајлове бирате појединачно (дугме горе лијево) или више одједном (дугме горе десно) и додајете их на листу са десне стране. Можете мијењати листу ручно, као и ffmgeg команду у прозорчићу лијево. Такође можете извући само слику или звук и додати титл у видео фајл.");
                    toolTip3.SetToolTip(this.buttonHelp, "Отвара ПДФ документ, само на енглеском!");
                    toolTip4.SetToolTip(this.buttonOutTransFile, "Изаберите путању гдје ћете снимити резултат конверзије. Име фајла је аутоматски одређено\nтако ШТО ЋЕ СЕ ДОДАТИ .1 НА ПОСТОЈЕЋЕ ИМЕ које ћете изабрати након што одредите гдје снимате фајл. Ако не изаберете гдје ћете га сачувати, биће аутоматски сачуван у истом фолдеру као и оргинални фајл.");
                    toolTip6.SetToolTip(this.buttonMultiTransFile, "Изаберите 1 или више фајлова да се препакују из MKV-->MP4 или MP4-->MKV. Зависно од типа улазног фајла, екстензија MKV или MP4 се одређује аутоматски.");
                    toolTip9.SetToolTip(this.buttonStartQueue, "Кад направите листу за кодовање, кликните да се изврше редом један по један.\nДоле можете пратити извршавање задатака.");
                    toolTip10.SetToolTip(this.buttonCancelBatch, "Кликните да прекинете извршавање свих задатака.");
                    toolTip11.SetToolTip(this.buttonSellectAllQueue, "Кликните да означите задатке за скидање са листе. Ово их неће уклонити.\nДугме Бриши ће их обрисати неповратно са листе.");
                    toolTip12.SetToolTip(this.buttonUnselectAll, "Кликните да скинете селекцију свих фајлова.");
                    toolTip13.SetToolTip(this.buttonDeleteQueue, "Кликните да обришете означене задатке.\nОзначити их можете или појединачним кликтањем на листи или думетом Означи.");
                    toolTip14.SetToolTip(this.buttonInputConvFile, "Изаберите улазне фајлове различитих видео или аудио формата.\nОбратите пажњу на филтере код бирања фајлова.\nЗависно од формата улазног фајла, биће изабран формат излазног, нпр. ако је аудио фајл, биће изабран MP3, итд. Можете такође ОДВУЋИ ВИШЕ ФАЈЛОВА НА ОВО ДУГМЕ.");
                    toolTip15.SetToolTip(this.buttonOutConvFile, "Изаберите путању гдје ћете сачувати конвертоване фајлове.\nТек након тога треба изабрати фајлове које желите да конвертујете!");
                    toolTip16.SetToolTip(this.buttonMultiConvFiles, "Изаберите ВИШЕ ФАЈЛОВА за конверзију, али имајте на уму да ће\nСВИ БИТИ КОДОВАНИ СА ИСТИМ ОПЦИЈАМА КОЈЕ СТЕ ПРИЈЕ ТОГА ИЗАБРАЛИ!!!\nЛиста ће се аутоматски попунити (ово је за ултра, мега гига брзу конверзију). Можете такође да превучете фајлове ба ово дугме!");
                    toolTip18.SetToolTip(this.richTextBoxConv, "Кад мијењате опције, мијења се и команда испод.\nМожете ручно мијењати опције у прозору и онда кликнути Додај на листу.");
                    toolTip19.SetToolTip(this.buttonAddBatchConv, "Кад изаберете опције, кликните да додате задатак на листу десно.\nНакон тога опције остају за слиједећи задатак или их можете промијенити.");
                    toolTip20.SetToolTip(this.panelBatch, "Задаци се приказују у овој табели. Можете превући више фајлова директно у ову листу.\nКад желите да прекодујете све задатке, кликните на Старт.");
                    toolTip21.SetToolTip(this.checkBoxAudioOnly, "Изаберите ако желите да снимите само звук.");
                    toolTip22.SetToolTip(this.checkBoxVideoOnly, "Изаберите ако желите само слику без звука.");
                    toolTip23.SetToolTip(this.radioButtonMKV, "Фајл ће бити сачуван у формату MKV.");
                    toolTip24.SetToolTip(this.radioButtonMP4, "Фајл ће бити сачуван у формату MP4.");
                    toolTip25.SetToolTip(this.radioButtonMP3, "Аудио ће бити у формату MP3.");
                    toolTip26.SetToolTip(this.radioButtonAAC, "Аудио ће бити у формату AAC.");
                    toolTip27.SetToolTip(this.radioButtonCopyAudio, "Аудио ће бити копиран у излазни фајл без промјене.");
                    toolTip28.SetToolTip(this.radioButtonCopyVideo, "Видео ће бити копиран у излазни фајл без промјене.\nКорисно ако улазни фајл није MP3, па једноставно прекодујете аудио.");
                    toolTip29.SetToolTip(this.comboBoxAudioBitRate, "Битска брзина за аудио. Занемарено ако се изабере опција Ориг.");
                    toolTip30.SetToolTip(this.comboBoxPreset, "Важна опција за квалитет и величину фајла.\nАко желите мањи фајл бирајте што спорије (slow).");
                    toolTip31.SetToolTip(this.comboBoxQuality, "Најважнија опција за квалитет видеа.\nЗа ХД филмове 23 је одлично,\nза ХД са телефона, 25-26 даје мали фајл доброг квалитета,\nза СД филмове 20 је одлично, 22 даје мали фајл доброг квалитета. Мало испробајте да видите шта вам одговара, па онда увијек користите те вриједности до којих дођете емпиријски.");
                    toolTip32.SetToolTip(this.buttonAddSubtitle, "Додаје титл из вањског .SRT фајла у убацује га у видео.\nКорисно за репродукцију на неким уређајима или кад желите да држите само један фајл без додатних екстерних титлова.");
                    toolTip33.SetToolTip(this.checkBox180, "Ротирај слику 180 степени, нпр. кад држиш телефон наопако.");
                    toolTip34.SetToolTip(this.checkBox90clockwise, "Ротирај слику 90 степени удесно.");
                    toolTip35.SetToolTip(this.checkBox90counterclockwise, "Ротирај слику 90 степени улијево.");
                    toolTip36.SetToolTip(this.comboBoxAudioStreamNo, "IMPORTANT: if audio stream doesn't exist, FIRST stream will be used.\nIf single file selected via Input File button, only existing streams will be displayed.");
                    toolTip37.SetToolTip(this.buttonInfo, "Show details about selected input file.");
                    toolTip38.SetToolTip(this.checkBoxH265, "H.265 !!! Видео ће бити кодован у новом кодеку који даје 2 пута мањи фајл и исти или бољи квалитет.");
                    break;
                case "nb":
                    toolTip1.SetToolTip(this.tabPage1, "Velg denne kategorien hvis du ønsker å pakke MP4 / M4V container til MKV eller vice versa. \nAvhengig av ditt valg, vil programmet automatisk velge den andre filen forlengelse.");
                    toolTip2.SetToolTip(this.tabPage2, "Velg denne kategorien hvis du ønsker å konvertere ulike typer lyd- eller videofiler til andre formater.\nDu kan velge filer individuelt (knappen til venstre) eller flere (øvre høyre knapp) og legge dem til batch jobblisten.\nDu kan redigere listen, endre FFMPEG alternativene manuelt.\nDu kan velge å ha kun video eller kun lyd (f.eks for å hente mp3).\nDu kan velge kvalitet, konvertering hastighet, etc.\nEller bare velge mislighold.");
                    toolTip3.SetToolTip(this.buttonHelp, "Åpner PDF hjelp dokument lagret i installasjonsmappen.");
                    toolTip4.SetToolTip(this.buttonOutTransFile, "Velg utgang banen der du vil lagre transkodet filen (e).\nFilnavnet vil bli gitt automatisk ved å legge til '1.' til navnet inndatafilen (e) du velge etterpå.");
                    toolTip6.SetToolTip(this.buttonMultiTransFile, "Velg en eller flere filer som skal pakkes om til MKV eller MP4, avhengig av valg av input filer format.\nBatch jobb Listen fylles ut automatisk.\nEtterpå kan du legge til flere filer på jobblisten fra denne kategorien eller konvertere kategorien.\nDu kan også slippe filer på denne knappen.");
                    toolTip9.SetToolTip(this.buttonStartQueue, "Klikk når du er ferdig med å lage listen\nAlle jobber i jobblisten er utført i kronologisk rekkefølge.");
                    toolTip10.SetToolTip(this.buttonCancelBatch, "Klikk for å avbryte kjøringen av alle jobber.\nListen vil forbli hvis du ønsker å manuelt redigere det etterpå.");
                    toolTip11.SetToolTip(this.buttonSellectAllQueue, "Klikk for å velge alle jobber for sletting \n. MERK: Dette vil ikke slette, knappen 'Slett' vil slette valgte jobbene.");
                    toolTip12.SetToolTip(this.buttonUnselectAll, "Klikk for å velge bort alle jobber i listen.");
                    toolTip13.SetToolTip(this.buttonDeleteQueue, "Klikk for å slette alle de valgte jobbene.\nFør det, bruker avmerkingsbokser til å velge de som du vil slette.");
                    toolTip14.SetToolTip(this.buttonInputConvFile, "Velg inndatafilen av ulike formater av lyd- eller videofiler.\nTa hensyn til filtre i dialogvinduet.\nDen filen vil bli konvertert, avhengig av alternativer valgte etter å ha valgt en fil. \nDu kan også slippe filen til knappen.");
                    toolTip15.SetToolTip(this.buttonOutConvFile, "Velg utgang banen der konverterte filene skal lagres.\nMen etter at må du velge INPUT fil eller DROP FIL THERE!\nFilnavn vil bli generert fra inngang fil ved å legge '1.' til slutten av filen.\nHvis du vil endre filnavnet, bruke tekstboksen under for å manuelt skrive inn navn ETTER at du har valgt alternativer.");
                    toolTip16.SetToolTip(this.buttonMultiConvFiles, "Velge flere filer som skal konverteres MED SAMME ALTERNATIVENE defineres under denne fanen FØR DU KLIKKE på denne knappen.\nBatch jobblisten fylles ut automatisk.\nDu kan også slippe filer på denne knappen.");
                    toolTip18.SetToolTip(this.richTextBoxConv, "Når bytte valg, er ffmpeg kommando generert i denne boksen. Du kan justere FFMPEG alternativer manuelt hvis du er avansert bruker. Når du er fornøyd med kommandoen, kan du klikke knappen 'Legg til batch fil listen'.");
                    toolTip19.SetToolTip(this.buttonAddBatchConv, "Når du velger alle alternativene, klikk her for å legge jobben til jobblisten.\nEtterpå kan du velge nye alternativer eller beholde den samme for ny jobb, eller bare klikk 'Start' for å starte koding filer i listen.");
                    toolTip20.SetToolTip(this.panelBatch, "De jobbene som du har lagt vises her.\n.\nDu kan slippe mange filer her.\nHvis du har endret ditt sinn om noen alternativer, kan du redigere ffmpeg kommandoen direkte i denne tabellen.\nNår du er ferdig med å bygge listen, klikk på 'Start' for å behandle køen.");
                    toolTip21.SetToolTip(this.checkBoxAudioOnly, "Velg om du ønsker å trekke ut bare lyd fra inndatafilen.");
                    toolTip22.SetToolTip(this.checkBoxVideoOnly, "Velg om du ønsker å trekke ut bare video fra inndatafilen.");
                    toolTip23.SetToolTip(this.radioButtonMKV, "Velg om du ønsker å kode video som MKV.");
                    toolTip24.SetToolTip(this.radioButtonMP4, "Velg om du ønsker å kode video som MP4.");
                    toolTip25.SetToolTip(this.radioButtonMP3, "Velg om du ønsker å kode lyd som MP3.");
                    toolTip26.SetToolTip(this.radioButtonAAC, "Velg om du ønsker å kode lyd som AAC.");
                    toolTip27.SetToolTip(this.radioButtonCopyAudio, "Velg om du vil kopiere originale audio strøm uten å endre.");
                    toolTip28.SetToolTip(this.radioButtonCopyVideo, "Velg om du vil kopiere originale video strøm uten å endre.");
                    toolTip29.SetToolTip(this.comboBoxAudioBitRate, "Velg bitrate for lyd strøm valgt (AAC eller MP3). \nIkke relevant hvis 'kopi lyd' alternativet brukes.");
                    toolTip30.SetToolTip(this.comboBoxPreset, "Velg koding forhåndsinnstilt hastighet.\nVIKTIG: Dette bestemmer koding hastighet, men også størrelsen på utdatafilen.\nFor minste fil velger den tregeste du orker!\nIkke relevant hvis 'kopi video' valgt.");
                    toolTip31.SetToolTip(this.comboBoxQuality, "Velg videokvalitet. For SD-kilder, er 19-21 utmerket kvalitet rekkevidde. For HD-kilder, er 21-24 normalområdet.\nDu kan la standardinnstillingene til hvis du er fornøyd med utskriftskvaliteten, eller eksperimentere litt for å finne den beste verdi for deg.\nIkke relevant hvis 'kopi video' valgt.");
                    toolTip32.SetToolTip(this.buttonAddSubtitle, "Legg fra .SRT fil til mux som en strøm. Ignorert når BRUKES FLERE FILER .");
                    toolTip33.SetToolTip(this.checkBox180, "Roter video 180 grader, som i tilfelle når du holder telefonen i landskapsmodus når du tar opp, men snudde opp ned.");
                    toolTip34.SetToolTip(this.checkBox90clockwise, "Roter video 90 grader med klokken.");
                    toolTip35.SetToolTip(this.checkBox90counterclockwise, "Roter video 90 grader mot klokken.");
                    toolTip36.SetToolTip(this.comboBoxAudioStreamNo, "IMPORTANT: if audio stream doesn't exist, FIRST stream will be used.\nIf single file selected via Input File button, only existing streams will be displayed.");
                    toolTip37.SetToolTip(this.buttonInfo, "Show details about selected input file.");
                    toolTip38.SetToolTip(this.checkBoxH265, "H265 er den besten!!! Filen skal vaere kodert som H265 HEVC.");
                    break;

            }
        }
        private void buttonAbout_Click(object sender, EventArgs e)
        {               //display about box
            AboutBoxZ about = new AboutBoxZ();
            about.ShowDialog();
        }
        private void DisableConvButtons()
        {               //disable buttons on Convert tab
            panelConvert.Enabled = false;
            groupBoxOptions.Enabled = false;
            buttonDeleteQueue.Enabled = false;
            buttonAddBatchConv.Enabled = false;
            buttonInputConvFile.Enabled = false;
            buttonMultiConvFiles.Enabled = false;
            buttonOutConvFile.Enabled = false;
            groupBoxAudio.Enabled = false;
            groupBoxContainer.Enabled = false;
            groupBoxVideoOrAudio.Enabled = false;
            buttonAddSubtitle.Enabled = false;
            buttonInfo.Enabled = false;
            checkBoxSetFPS.Enabled = false;
            checkBoxSlowFPS.Enabled = false;
            groupBoxVideoSize.Enabled = false;
            groupBoxSlow.Enabled = false;
            groupBoxRotate.Enabled = false;
            groupBoxCPU.Enabled = false;
            comboBoxAudioStreamNo.Enabled = false;
        }
        private void EnableConvButtons()
        {               //enable buttons on Convert tab
            panelConvert.Enabled = true;
            groupBoxOptions.Enabled = true;
            buttonDeleteQueue.Enabled = true;
            buttonAddBatchConv.Enabled = true;
            buttonInputConvFile.Enabled = true;
            buttonMultiConvFiles.Enabled = true;
            buttonOutConvFile.Enabled = true;
            groupBoxAudio.Enabled = true;
            groupBoxContainer.Enabled = true;
            groupBoxVideoOrAudio.Enabled = true;
            buttonAddSubtitle.Enabled = true;
            checkBoxSetFPS.Enabled = true;
            checkBoxSlowFPS.Enabled = true;
            groupBoxVideoSize.Enabled = true;
            groupBoxSlow.Enabled = true;
            groupBoxRotate.Enabled = true;
            groupBoxCPU.Enabled = true;
            comboBoxAudioStreamNo.Enabled = true;
        }
        private void DisableTransButtons()
        {               //disable buttons on Transcode tab
            panelTranscode.Enabled = false;
            buttonOutTransFile.Enabled = false;
            buttonMultiTransFile.Enabled = false;
            buttonSellectAllQueue.Enabled = false;
            buttonStartQueue.Enabled = false;
            buttonUnselectAll.Enabled = false;
            buttonDeleteQueue.Enabled = false;
            groupBoxTransGroupStreams.Enabled = false;

        }
        private void EnableTransButtons()
        {               //enable buttons on Transcode tab
            panelTranscode.Enabled = true;
            buttonOutTransFile.Enabled = true;
            buttonMultiTransFile.Enabled = true;
            buttonSellectAllQueue.Enabled = true;
            buttonStartQueue.Enabled = true;
            buttonUnselectAll.Enabled = true;
            buttonDeleteQueue.Enabled = true;
            groupBoxTransGroupStreams.Enabled = true;
        }

        private void buttonHelp_Click_1(object sender, EventArgs e)
        {               //open PDF document shipped in the same folder as VTC.exe
            try
            {
                System.Diagnostics.ProcessStartInfo procStartPdf =
                    new System.Diagnostics.ProcessStartInfo(@"vct_help.pdf");
                procStartPdf.WorkingDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                // Now we assign its ProcessStartInfo and start it
                System.Diagnostics.Process.Start(procStartPdf);
            }
            catch (Exception x)
            { }
        }

        private void buttonAddSubtitle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Subtitle files|*.srt|All files|*.*";
            openFileDialog.Title = "Choose srt file to add as a subtitle stream to the movie";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                subtitle_stream = openFileDialog.FileName;
                buttonRemoveSubtitle.Enabled = true;
                buttonRemoveSubtitle.Visible = true;
                add_sub_stream = true;
                labelAddSubtitle.Text = subtitle_stream;
                richTextBoxConv.Text = SetupConversionOptions();
            }
        }
        private void buttonRemoveSubtitle_Click(object sender, EventArgs e)
        {
            subtitle_stream = "";
            add_sub_stream = false;
            buttonRemoveSubtitle.Enabled = false;
            buttonRemoveSubtitle.Visible = false;
            labelAddSubtitle.Text = "Select srt subtitle stream file.";
            richTextBoxConv.Text = SetupConversionOptions();
        }
        private void checkBox180_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox180.Checked)
            {
                checkBox90clockwise.Checked = false;
                checkBox90counterclockwise.Checked = false;
            }
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void checkBox90clockwise_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox90clockwise.Checked)
            {
                checkBox180.Checked = false;
                checkBox90counterclockwise.Checked = false;
            }
            richTextBoxConv.Text = SetupConversionOptions();
        }

        private void checkBox90counterclockwise_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox90counterclockwise.Checked)
            {
                checkBox180.Checked = false;
                checkBox90clockwise.Checked = false;
            }
            richTextBoxConv.Text = SetupConversionOptions();
        }
        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            richTextBox3.SelectionStart = richTextBox3.Text.Length;
            // scroll it automatically
            richTextBox3.ScrollToCaret();
        }

    }
    public class audio_info
    {
        #region Properties
        public string codec_long_name { get; set; }
        public double bit_rate { get; set; }
        public string duration { get; set; }
        public string language { get; set; }
        public string channel_layout { get; set; }
        #endregion
    }
    public class subtitle_info
    {
        #region Properties
        public string codec_long_name { get; set; }
        public string language { get; set; }
        #endregion
    }
    public class video_info
    {
        #region Properties
        public double duration { get; set; }
        public string codec_long_name { get; set; }
        public double bit_rate { get; set; }
        public string profile { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string r_frame_rate { get; set; }
        #endregion
    }
    public class file_info
    {
        #region Properties
        public string filename { get; set; }
        public double size { get; set; }
        #endregion
    }
}

