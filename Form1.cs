using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Globalization;

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
        static string input_file, out_file, out_path = "", str_extension, orig_ext, audio_ext; //stores names of input, output files, output path and temp. varr
        static string subtitle_stream, audio_stream = "1";
        static int number_of_rows = 0; //stores number of rows for batch list
        static int ffmpeg_process_id; //process id of started ffmpeg process - used to close it if user cancels
        static bool canceled = false, video_only = false, audio_only = false; //flags to mark cancel job; if video or audio only is encoded
        static bool add_sub_stream = false;
        static string preset = "veryfast", crf = "23", audio = "libmp3lame", container = "mkv", audiobitrate = "128k"; //options values used as ffmpeg encodin parameters
        static string video = "", audio_part = "", task = ""; //video;audio part of parameters string; ffmpeg command string
        static string vf = ""; //video filter part, used currently to rotate video
        string[] task_list = new string[100]; //all tasks put in a batch list
        Process proc = new System.Diagnostics.Process(); //process that call cmd.exe to execute ffmpeg task
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
        public Process GetProcByID(int id)
        {		//handy way to get process without raising exception
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
            openFileDialog.Filter = "H.264 files|*.mp4;*.mkv;*.m4v";	//sets filter of displayed files
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

            }
        }
        private void MultiTransRow()
        {
            try
            {
                int str_position = input_file.LastIndexOf('.') + 1;	//find position of '.' to determine file extension
                str_extension = input_file.Substring(str_position);	//store found file extension
                switch (str_extension)
                {													//decide what to do for each extension
                    case "mp4":			//if extension is MP4, output will be MKV
                        str_extension = "1.mkv";
                        break;
                    case "m4v":			//if extension is MvV, output will be MKV
                        str_extension = "1.mkv";
                        break;
                    case "mkv":			//if extension is MKV, output will be MP4
                        str_extension = "1.mp4";
                        break;
                    default:			//default extension is MKV, altough more correct would be to skip!!!!
                        str_extension = "1.mkv";
                        break;
                }
                str_position = input_file.LastIndexOf("\\") + 1;	//find where is the last folder mark
                string in_file = input_file.Substring(str_position);//after that there is a file name
                if (out_path == null || out_path == "")
                {
                    out_path = input_file.Substring(0, str_position);//just in case it is empty take input file vaule as a replacement
                    labelOutConvFile.Text = out_path;
                    labelOutTransFile.Text = out_path;
                }
                str_position = in_file.LastIndexOf('.') + 1;	//get position just before extension
                in_file = in_file.Substring(0, str_position);	//set temp var in_file with input file name
                out_file = out_path + in_file;					//set temp var out_file as selected path + input file name
                string command = "ffmpeg -y -i \"" + input_file + "\" -c:v copy -c:a copy \"" + out_file + str_extension + "\"";//define ffmpeg command
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
            {  }
        }
        private void timerBatch_Tick(object sender, EventArgs e)
        {						//timer ticks every 1 sec to display progress, messages, etc.
            try
            {
                if (canceled)
                {						//cancel if flag set by Cancel method
                    stopwatch.Stop();			//stop measuring elapsed time
                    timerBatch.Enabled = false;	//disable timer
                    EnableButtonsAfterEncoding();//enable buttons so user can edit tasks
                    toolStripStatusLabel1.Text = statustekst;
                    toolStripProgressBar1.Value = 0;//set progress to zero
                    
                }
                    
                else
                {				//display elapsed time, output from ffmpeg
                    toolStripStatusLabel1.Text = "Time: " + stopwatch.Elapsed.ToString(@"hh\:mm\:ss") + "s  | " + statustekst;
                    toolStripProgressBar1.Value = (int)((encoded_sec / total_sec) * 100);//set percentage for displaying progress of current task
                }
            }
            catch (Exception ex)
            {
            }
        }
        private int batchTask(string current_task)
        {			//called when starting each ffmpeg encoding task, passed task string as parameter
            try
            {
                System.Diagnostics.ProcessStartInfo procStartffmpeg =
                new System.Diagnostics.ProcessStartInfo("cmd", "/c " + current_task);//define Process Info to assing to the process
                // The following commands are needed to redirect the standard output and standard error.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartffmpeg.RedirectStandardOutput = true;
                procStartffmpeg.RedirectStandardInput = true;
                procStartffmpeg.RedirectStandardError = true;
                procStartffmpeg.UseShellExecute = false;	
                procStartffmpeg.CreateNoWindow = true;	// Do not create the black window.
                procStartffmpeg.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);//set path of vtc.exe same as ffmpeg.exe
                
                proc.StartInfo = procStartffmpeg;	// Now we assign process its ProcessStartInfo and start it
                
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
                return -1;					//-1 means NOT OK, not used so far
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
                else
                {							//after duration found, read progress for each std out line
                    if (output.Contains("time="))
                    {						//in each line we search for occurence of time value
                        std_out = output.Substring(output.IndexOf("time=") + 5, 8);	//time value is at this position
                        encoded_sec = TimeSpan.ParseExact(std_out, "hh\\:mm\\:ss", null).Ticks;	//set format of current time
                        percent = ((encoded_sec / total_sec) * 100).ToString("0.00");	//calculate percentage
                        statustekst = " " + percent + "%   |  " + output;	//define text to display with calculated values
                    }
                }
            }
            catch (Exception x)
            {}
        }
        
        private void buttonStartQueue_Click(object sender, EventArgs e)
        {									//handler for user clicking to start encoding of batch list
            try
            {
                DataGridViewCell check_cell = new DataGridViewCheckBoxCell(true);//new instance of check cell
                DataGridViewRow row = new DataGridViewRow();					 //new temp row
                BackgroundWorker bg = new BackgroundWorker();					 //new instance of Background worker
                bg.WorkerReportsProgress = true;
                bg.DoWork += bg_DoWork;											 //handler for starting thread
                bg.RunWorkerCompleted += bg_RunWorkerCompleted;					 //handler for finishing thread
                canceled = false;												 //our new job is not yet canceled
                statustekst = "Job started";
                toolStripProgressBar1.Value = 0;								 //initial progress
                toolStripProgressBar1.Maximum = 100;							 //max progress possible - 100%
                stopwatch.Reset();												 //reset measured time
                stopwatch.Start();												 //start measuring time
                timerBatch.Interval = 1000;										 //display progress every second
                timerBatch.Enabled = true;										 //start displaying progress
                DisableButtonsWhenEncoding();									 //prevent user to add, delete, etc. while encoding is running
                for (int i = 0; i < number_of_rows; i++)
                {			//for each task in the list, read command string value
                    task_list[i] = dataGridViewBatch.Rows[i].Cells[2].Value.ToString();
                }
                bg.RunWorkerAsync();	//start job as separate thread
                      
            }
            catch (Exception ex)
            {					//in case something goes wrong, stop timers and enable user control
                toolStripStatusLabel1.Text = "ERROR: " + ex.ToString() + statustekst;
                stopwatch.Stop();
                timerBatch.Enabled = false;
                EnableButtonsAfterEncoding();
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
                        if (ffmpeg_process_id == -1)
                            cancelbatch();							//call cancel if error occured
                        check_cell.Value = true;					//set check in GUI that this job is finished
                        row = dataGridViewBatch.Rows[i];
                        row.Cells["check_cell"].Value = check_cell.Value;
                        row.Selected = false; 						//unselect this row in the list
                        stopwatch.Restart();						//restart measuring time for next job
                    }
                }
                canceled = true;									
            }
            catch (Exception x)
            {
                ffmpeg_process_id = -1;
            }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statustekst = "Encoding Finished!";	//message when thread finishes with all jobs
            
        }
        private void cancelbatch()
        {
            try
            {
					//called when user decides to cancel encoding
                    canceled = true;
                    stopwatch.Stop();
                    timerBatch.Enabled = false;
                    proc.StandardInput.Write('q');	//sending 'q' to ffmpeg gracefully stops encoding and closes parent cmd window (hidden)
                    proc.CancelErrorRead();			//stop reading std out
                    proc.CancelOutputRead();		//stop reading std error
                    toolStripProgressBar1.Value = 0;//reset progress
            }
            catch (Exception x)
            { }
        }
        private void buttonCancelBatch_Click(object sender, EventArgs e)
        {
            try
            {				//user clicks to cancel encoding
                DialogResult result = MessageBox.Show("All your jobs will be canceled!\nHowever, your queue will remain available for editing.\nDo you want to proceed?", "Queued jobs cancel", MessageBoxButtons.OKCancel);
                if(result == DialogResult.OK)
                {		
                    cancelbatch();					//if confirms calncel call method to stop all jobs
                    EnableButtonsAfterEncoding();	//gives user control
                    toolStripStatusLabel1.Text = "Encoding canceled after " + stopwatch.Elapsed.ToString(@"hh\:mm\:ss") + "s ";
                }
            }
            catch (Exception ex)
            { }
        }

        private void DisableButtonsWhenEncoding()
        {									//disable user interaction with controls while encoding in progress
            panelConvert.Enabled = false;
            panelTranscode.Enabled = false;
            groupBoxOptions.Enabled = false;
            buttonCancelBatch.Enabled = true;
            buttonStartQueue.Enabled = false;
            buttonDeleteQueue.Enabled = false;
            buttonAddBatchConv.Enabled = false;
            buttonInputConvFile.Enabled = false;
            buttonMultiConvFiles.Enabled = false;
            buttonOutConvFile.Enabled = false;
            buttonOutTransFile.Enabled = false;
            buttonMultiTransFile.Enabled = false;
            groupBoxAudio.Enabled = false;
            groupBoxContainer.Enabled = false;
            groupBoxVideoOrAudio.Enabled = false;
            buttonAddSubtitle.Enabled = false;
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
            buttonOutConvFile.Enabled = true;
            buttonOutTransFile.Enabled = true;
            buttonMultiTransFile.Enabled = true;
            groupBoxAudio.Enabled = true;
            groupBoxContainer.Enabled = true;
            groupBoxVideoOrAudio.Enabled = true;
            buttonAddSubtitle.Enabled = true;
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
                    str_extension = orig_ext;
                }
                else
                {
                    video_only = false;
                    groupBoxAudio.Enabled = true;
                }
                if (checkBoxAudioOnly.Checked)
                {
                    audio_only = true;
                    video_only = false;
                    groupBoxContainer.Enabled = false;
                }
                else
                {
                    audio_only = false;
                    groupBoxContainer.Enabled = true;
                    str_extension = orig_ext;
                }
                if (checkBoxVideoOnly.Checked || checkBoxAudioOnly.Checked)
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
                    audio = "libvo_aacenc";
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
                    vf = " -vf \"vflip\" ";
                if (checkBox90clockwise.Checked)
                    vf = " -vf \"transpose=1\" ";
                if (checkBox90counterclockwise.Checked)
                    vf = " -vf \"transpose=2\" ";
                //
                preset = comboBoxPreset.SelectedItem.ToString();
                //
                crf = comboBoxQuality.SelectedItem.ToString();
                //
                audiobitrate = comboBoxAudioBitRate.SelectedItem.ToString();
            }
            catch (Exception x)
            {

            }
        }
        private string SetupConversionOptions()
        {
            try
            {				//the most important part of preparing values passed as ffmpeg arguments
                string ext = "";		//initial file extension
                string input_srt = "";
                string srt_options = "";
                string stream_option = " -map 0:0 -map 0:"+audio_stream; //used when user selects audio stream and/or subtitle stream
                vf = "";
                ReadParametersFromGUI();//read options set by user on GUI
                if (str_extension == "mp3" || str_extension == "aac" || str_extension == "ac3" || str_extension == "wma" || str_extension == "wav" || str_extension == "flac")		//if input file is audio file, then set options so the only audio ouput is produced
                { 
                    audio_only = true; 
                    video_only = false;
                }
                
                string ff;				//temp var to store ffmpeg command string
                if (audio_only)			//audio only file is produced
                {
                    container = " -vn";//put option to exclude video stream
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
                {										//if video not excluded or copied
                    ext = container;
                    video = " -c:v libx264 -preset " + preset + " -crf " + crf;
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
                // Test if there is an input srt to be added as a stream
                if (add_sub_stream && !audio_only && !video_only)
                {
                    input_srt = " -f srt -i \"" + subtitle_stream + "\" ";
                    stream_option += " -map 1:0";
                    if (ext == "mp4")
                        srt_options = " -c:s mov_text";
                    else if (ext == "mkv")
                        srt_options = " -c:s srt";
                }
                // complete string to be passed to process start
                ff = "ffmpeg -y -i \"" + input_file + "\"" + input_srt + stream_option + video + vf
                        + audio_part + srt_options + " \"" + out_file +"1." + ext + "\"";
                
                return ff;
            }
            catch (Exception x)
            {return "null"; }
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
                if (out_path == null || out_path == "")
                {
                    out_path = input_file.Substring(0, str_position);//just in case it is empty take input file vaule as a replacement
                    labelOutConvFile.Text = out_path;
                    labelOutTransFile.Text = out_path;
                }
                string in_file = input_file.Substring(str_position);//input file name
                str_position = in_file.LastIndexOf('.') + 1;		//get where extension starts
                in_file = in_file.Substring(0, str_position);		//get just file name without extension
                
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
        {					//user clicks to select 1 input file
            
			OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video files|*.m4v;*.mp4;*mkv;*.avi;*.mpg;*.divx;*.mov;*.wmv|Audio files|*.mp3;*.wma;*.wav;*.aac;*.ac3;*.flac|All files|*.*";
            openFileDialog.Title = "Choose video or audio file to convert";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                input_file = openFileDialog.FileName;				//code here is more or less repeated from other button click
                int str_position= input_file.LastIndexOf('.') + 1;
                str_extension = input_file.Substring(str_position);
                orig_ext = str_extension;
                str_position = input_file.LastIndexOf("\\") + 1;
                if (out_path == null || out_path == "")
                {
                    out_path = input_file.Substring(0, str_position);//just in case it is empty take input file vaule as a replacement
                    labelOutConvFile.Text = out_path;
                    labelOutTransFile.Text = out_path;
                }
                string in_file = input_file.Substring(str_position);
                str_position = in_file.LastIndexOf('.') + 1;
                in_file = in_file.Substring(0, str_position);// + str_extension;
                
                out_file = out_path + in_file;
                richTextBoxConv.Text = SetupConversionOptions();
                labelInputConvFile.Text = input_file;
                EnableConvButtons();
            }
            
        }
        private void buttonInputConvFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    input_file = files[0];
                    int str_position = input_file.LastIndexOf('.') + 1;
                    str_extension = input_file.Substring(str_position);
                    orig_ext = str_extension;
                    str_position = input_file.LastIndexOf("\\") + 1;
                    if (out_path == null || out_path == "")
                    {
                        out_path = input_file.Substring(0, str_position);//just in case it is empty take input file vaule as a replacement
                        labelOutConvFile.Text = out_path;
                        labelOutTransFile.Text = out_path;
                    }
                    string in_file = input_file.Substring(str_position);
                    str_position = in_file.LastIndexOf('.') + 1;
                    in_file = in_file.Substring(0, str_position);// + str_extension;
                    
                    out_file = out_path + in_file;
                    richTextBoxConv.Text = SetupConversionOptions();
                    labelInputConvFile.Text = input_file;
                    EnableConvButtons();
            }
        }
        private void buttonOutConvFile_Click(object sender, EventArgs e)
        {									//user clicks to select where to save files after encoding
            FolderBrowserDialog savePath = new FolderBrowserDialog();
            savePath.SelectedPath = out_path;
            savePath.Description = "Choose output file path";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                out_path = savePath.SelectedPath + "\\";		//store selected path to var
                labelOutConvFile.Text = out_path;				//let the user knows by writing it to GUI
                labelOutTransFile.Text = out_path;				//the same var is also for transcoding jobs
                			////allow user interaction - to select multiple input files
                EnableConvButtons();
                buttonMultiTransFile.Enabled = true;
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
                labelOutConvFile.Text = out_path;			
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
            richTextBoxConv.Text = SetupConversionOptions();
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
            }
            catch { Exception x; }
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

        private void checkBoxVideoOnly_CheckedChanged(object sender, EventArgs e)
        {               //select to encode file with video stream only
            if (checkBoxVideoOnly.Checked)
            {
                checkBoxAudioOnly.Checked = false;  //cannot have audio only when we have video only
            }
            richTextBoxConv.Text = SetupConversionOptions();//now setup new options
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

        private void richTextBoxConv_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewBatch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void buttonMultiConvFiles_DragEnter(object sender, DragEventArgs e)
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
            //set event handlers for Drag&Drop onto the Inpu File(s) buttons
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

            switch (Thread.CurrentThread.CurrentUICulture.Name.Substring(0,2))
            {
                case "en":
                toolTip1.SetToolTip(this.tabPage1, "Select this tab if you want to repack MP4/M4V container to MKV or vice versa.\nDepending on your choice, program will automatically choose the other container's extension.");
                toolTip2.SetToolTip(this.tabPage2, "Select this tab if you want to convert different types of audio or video files to other formats.\nYou can chhose files individually (button on the left) or multiple (upper right button) and add them to batch job list.\nYou can edit list, change ffmpeg options manually.\nYou can choose to have video only or audio only (e.g. to extract mp3).\nYou can choose quality, conversion speed, etc.\nOr, just select defaults.");
                toolTip3.SetToolTip(this.buttonHelp, "Opens PDF help document stored in VTC.exe installation folder.");
                toolTip4.SetToolTip(this.buttonOutTransFile, "Select output path where you want to save transcoded file(s).\nThe file name will be given AUTOMATICALLY by adding\n'1.' to the INPUT file name(s) that you select afterwards.");
                toolTip6.SetToolTip(this.buttonMultiTransFile, "Select one or more files to be repacked to MKV or MP4,\ndepending on choice of input files format.\nBatch job list will be populated automatically.\nAfterwards, you can add more files to the job list from this tab or convert tab.\nYou can also drop files on this button.");
                toolTip9.SetToolTip(this.buttonStartQueue, "Click when you are done creating you job list.\nAll jobs in job list are executed in sequential order.");
                toolTip10.SetToolTip(this.buttonCancelBatch, "Click to cancel execution of all jobs\nYour job list will remain if you want to manually edit it afterwards.");
                toolTip11.SetToolTip(this.buttonSellectAllQueue, "Click to select all jobs for deletion.\n NOTE: This will not delete, button 'Delete' will delete selected jobs.");
                toolTip12.SetToolTip(this.buttonUnselectAll, "Click to unselect all jobs in the list.");
                toolTip13.SetToolTip(this.buttonDeleteQueue, "Click to delete all selected jobs.\nBefore that, use check boxes to select those that you want to delete.");
                toolTip14.SetToolTip(this.buttonInputConvFile, "Select input file of various formats of audio or video files.\nPay attention to filters in dialog window.\nThat file will be converted depending on options selected after selecting a file.\nYou can also drop your file onto the button.");
                toolTip15.SetToolTip(this.buttonOutConvFile, "Select output path where converted files will be saved.\nBUT AFTER THAT YOU MUST SELECT INPUT FILE OR DROP FILE THERE!\nFile name will be generated from input file by adding\n    '1.' to the end of file.\nIf you want to change file name, use the TEXT BOX BELOW TO MANUALLY enter name after you selected options.");
                toolTip16.SetToolTip(this.buttonMultiConvFiles, "Select more files to be converted\nWITH SAME OPTIONS DEFINED ON THIS TAB BEFORE CLICKING THIS BUTTON.\nBatch job list will be populated automatically.\nYou can also drop files onto this button.");
                toolTip18.SetToolTip(this.richTextBoxConv, "When changing options, ffmpeg command is generated in this box.\nYou can tweak ffmpeg options manually if you are advanced user.\nWhen you are happy with command, you can click 'Add To Batch File List'.");
                toolTip19.SetToolTip(this.buttonAddBatchConv, "When you select all options, click here to add job to the job list.\nAfterwards, you can select new options or keep the same for new job,\nor just click 'Start' to start encoding jobs in the list.");
                toolTip20.SetToolTip(this.dataGridViewBatch, "The jobs that you added are displayed here.\nYou can delete one or more of them if you don't want them.\nIf you changed your mind regarding some options,\nyou can edit ffmpeg command directly in this table.\nWhen you are done building list, click 'Start' to process the queue.");
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
                toolTip36.SetToolTip(this.comboBoxAudioStreamNo, "IMPORTANT: audio stream MUST EXIST or the encoding wil fail!\nProgram doesn't check for audio stream existence (at least not in this version).");
                break;
                case "sr" :
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
                toolTip20.SetToolTip(this.dataGridViewBatch, "Задаци се приказују у овој табели. Можете их брисати, додавати или мијењати директно у табели.\nКад желите да прекодујете све задатке, кликните на Старт.");
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
                toolTip36.SetToolTip(this.comboBoxAudioStreamNo, "IMPORTANT: audio stream MUST EXIST or the encoding wil fail!\nProgram doesn't check for audio stream existence (at least not in this version).");
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
                toolTip20.SetToolTip(this.dataGridViewBatch, "De jobbene som du har lagt vises her.\nDu kan slette en eller flere av dem hvis du ikke vil ha dem.\nHvis du har endret ditt sinn om noen alternativer, kan du redigere ffmpeg kommandoen direkte i denne tabellen.\nNår du er ferdig med å bygge listen, klikk på 'Start' for å behandle køen.");
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
                    toolTip36.SetToolTip(this.comboBoxAudioStreamNo, "IMPORTANT: audio stream MUST EXIST or the encoding wil fail!\nProgram doesn't check for audio stream existence (at least not in this version).");
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
            if(checkBox180.Checked)
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


    }
    
}

