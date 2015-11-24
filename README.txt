v1.4.2	FIXED CONVERTING TO MP3 BUG, ADDED DRAG&DROP TO THE LIST

VCT is frontend for ffmpeg tool which, if you are reading this, is the greatest tool for video/audio files manipulation
It is also command line tool, so it may be inconvenient for those users that can only work with some kind of GUI.
I've created this tool because I needed some app that can help me convert my entire video library quickly to the H.264. Handbrake can do it, but I have to click to every file, select path, etc.

I wanted to achieve 4 goals:
1. to have ability to manually edit any command option of ffmpeg
2. ability to transcode MP4 to MKV and vice versa (thus full length movie transcoding take 2 minutes compared to 2 hours of full conversion)
3. ability to set conversion options and then drag many files onto the VCT to encode them all with same options
4. ability to encode each video (or audio) separately and to add them all to batch list  (kinda like Handbrake)


Licensed under Apache v2.0, so you are free to use the source code for any purpose you like, open source or commercial.

If you find a bug, or you have an issue, please use discussion board to contact me. If you use GitHub, you can open issue there.
If program is declared an open source, it doesn't mean that there is no support. On contrary, you can contact developer directly and get the most out of it!

VCT has its limitations: 
- when you define options and drop multiple files "Multiple Input Files" button or to the list, you can't use subtitles;
- you can only encode file with single audio stream;
- if there is subtitle stream inside input file, it will not be copied to output;
- if selecting audio stream, you must know how many streams there are and which one is the one you need (you can check that with VLC).

That's why I left option to manually edit ffmpeg command, for all of you that know, or are willing to learn this tool. You can also manually edit commands in batch list.

I have plans to include ffprobe in order to parse the input file and find all streams within, but it will take some time to develop and I will have to redesign the whole app.

Quick tips for common usage:

I use this tool regularly for 2 tasks
	
- 1 to full convert bunch of HD files from smartphone (they are too big, 1 minute - 200 MB). I use preset "slower", quality "25" and get 5-10 times smaller files without loosing quality - you can experiment with values - for SD video, use quality "21";
	
- 2 to transcode MKV movies to MP4 quickly without changing quality. Just select all of them in Windows Explorer and drag them to the button "Input File(s) to Transcode" on "Transcode" tab. Then just click "Start". It takes 2-5 minutes per movie (depending on the length of the movie, avg. movie is 90+ minutes long);
	
If you want files to be stored in different folder than input files, then select first "output path" where you want to store the new video or audio files, then you will be able to select which files you want to convert/transcode ("Input files" or "Multiple files").
	
You can use drag&drop instead to click "Input File(s)..." buttons. Just drag file(s) on those buttons from Windows Explorer.

Latest version 1.4.2 - update: FIXED CONVERTING TO MP3 BUG, ADDED DRAG&DROP TO THE LIST

Content:
 - Features
 - GIT source code location
 - Change logs
 - Known issues
 - Prerequisities
 - Visual Studio usage
 - Monodevelop Linux usage
 - Linux usage

GIT:
To get latest source, please use GIT either on GITHUB or SF!
https://sourceforge.net/projects/videoconvertertranscoder/

Added git repository. It is now preferred method to get source code. To clone use:

git clone https://github.com/zbabac/VCT.git

Please contact me via discussion board if you want to collaborate or send me an email: zlatko.babic@mail.com.

Change log since v1.4.2:
- fixed encoding of mp3 files
- added drag&drop files to the list
- added option to select which audio stream you want to include into output file
- improved messages in status bar, when all jobs are done, message warns user if some file(s) failed to encode

Change log since v1.3.0:
- added option to rotate video 180, 90, -90 degrees in case you hold camera upside down, etc.

Change log since v1.2.1:
- added localization for norwegian - bokmål
- norsk: Jeg har bare startet å lære norsk, så tilgi meg hvis det er feil! Du kan kontakte med meg hvis du ønsker å samarbeide!

Change log since v1.2.0:
- added localization for Serbian - latin nad Serbian -cyrillic
- serbian: srpska verzija u VCT_setup_srpski.exe za one koji nemaju Windows na srpskom 
- localization enabled in source code so new languages can be added via xlf resource files
- ability in source to set UI language and have localized version on an english Windows (just uncomment 1 line)

Change log since v1.1.0:

-fixed minor issue when adding multiple files for conversion added the same subtitle to all videos - subtitle option disabled when adding multiple files
-new installer created with Null Soft Installer; setup_nsis.nsi installer script included with source code
-updated PDF help

Change log since v1.0.0:
-added possibility to mux srt subtitle file as a stream in both MKV and MP4 files. I haven't tested if this works with iPad, but it works with VLC and some TVs.

Change log since v0.9.6:
- added drag&Drop to 3 buttons for input files (1 on Transcode tab, and 2 on Convert tab): input files can be dropped there instead of clicking for File Dialog;
- changed behaviour of buttons: it is no longer needed to select Output Path first - if Input files are selected first, then Output Path is selected as the same as input files path;
- added value "26" to the quality factor list at Convert tab.

Features:
- 2 tabs: Transcode and Convert

- Transcode tab: select multiple files (mkv, m4v or mp4) and add them to batch list for automatic conversion to other video container (mp4/m4v --> mkv, mkv --> mp4)

- Convert tab: 2 options to convert - either by setting options then selecting multiple files (mixture of audio and video files) - or by selecting files one by one, for each file different options possible
- selection of options: encode quality, encode speed, audio bitrate, create video file only, create audio file only, stream copy
- option to select which audio stream to encode (for multi language movies)
- option to insert .SRT subtitle as a stream in the video file (soft subtitles)
- advanced options: it is possible to manually edit ffmpeg command in the text box, or directly in the batch tasks list
- conversion tasks are stored in a list which can be edited (command edit, select, delete task):
- you don't have to start encoding immediately after adding from "Transcode" or "Convert" tabs
	- you can add one or more files with different options several times by choosing 1 input file each time or/and selecting multiple files at once,
	- only after you populate your list completely, by clicking "Start" all tasks will be executed,
- conversion can be canceled,
- encoding progress displayed in status bar
- help included with installtion and with source code

Help/walkthrough is available in both Binary installation and Source. When installed, Start menu folder is created with links to VCT.exe, help (pdf), license and uninstall option. 



Known issues:
Avast on XP could block setup execution with strange messages like: "path could not be found...". Please scan VCT_setup.exe with AV program, then disable file shield and run setup again. It could be the case with other AV software.
On Windows 7 and 8, there is DEP active and once you confirm that you want to run the setup, it will install without problems.

Antivirus software can cause problems after installation. Windows can give message: "windows cannot access the specified device path or file you may not have appropriate permissions". Avast antivirus is blocking execution. If you are worried about security, please scan this app first or compile it yourself from the source. However, there is simple remendy to overcome this problem, please check the following link:
http://www.getavast.net/support/stop-blocking-a-program/
You basically need to add scanning exclusion to the installation path, default is: "C:\Program Files (x86)\VCT" or "C:\Program Files\VCT".

Update: new Avast version uses Deep scan at first run, so everything is ok.
Update 2: Windows 8 will try to prevent installation. After you scan setup file, click on "install anyway".

Prerequisities:
If you download setup, all neccessary dependencies are installed (ffpmeg, pdf help), except .NET 4.0 client profile. Please download it from Microsoft.
Some antivirus programs (mine is Avast) will complain that "File reputation/prevalence is low". It will be sandboxed. This is due to the fact that application does not have commercial signature. If you are worried about it, please scan it first. There is no virus, full source code is available. After checking, you can instruct your antivirus to execute anyway, or in case of Avast on Windows XP, you need to disable shield (after scanning first, of course) in order to install program.

Visual Studio usage:
Source code files created by VS 2013 Express Edition for Desktop, so just unpack and opeb the solution with VS. However you can create project in VS 2010 (tested) or VS 2012, just create a new folder and copy all files except *.sln and *.suo to that folder. Then, simply open VCT.csproj with your version of Visual Studio.
Whenever I add new version I provide the latest ffmpeg.exe static build compiled by zeranoe, but if you want a more recent one, just download and replace the existing one. License, download paths are mentioned in About box.

Linux mono usage

#You must have mono installed to run .NET application.
#For Debian systems (Ubuntu, Mint, etc.) run:

sudo apt-get install mono-complete

#For another distributions, just search: mono <distro_name> installation.
#After that, unpack VCT_Linux_mono_binary.zip to directory fo your choice. I will give example as if you put it in your home dir. Use sudo bash if permissions are inadequate.
#Open terminal and go to dir. where VCT_Linux_mono_binary.zip is saved, usually Downloads:

cd $HOME/Downloads
unzip VCT_Linux_mono_binary.zip -d $HOME 	#$HOME is destination dir.
cd $HOME/VCT_mono							#new dir. is created by name VCT_mono
chmod 777 *									#allow all users permissions and exec rights to ffmpeg

#add ffmpeg to path if you don't have it installed:

PATH=$PATH:/$HOME/VCT_mono

#or add that line permanently to your profile at $HOME/.profile - just put the above line at the end of the .profile file.
#you can now run:

mono VCT.exe

#or create launcher at desktop or menu.
- it should display MS Windows like Window
- I haven't resolved yet encoding progress under Linux- only elapsed time is displayed, but don't worry, it is working just fine!

