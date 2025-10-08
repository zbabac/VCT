#Sticky info for Linux:
Since new version needs ffplay and it can't be found as a static build for Linux, you have to both install ffmpeg package and copy the binaries that I included, ffmpeg and ffprobe manually to /usr/bin/.  
#I created script to automate installations: `install_vct_apt.sh` for Debian, Ubuntu;  
#`install_vct_yum.sh` for Fedora, Centos, etc. 
**Just download it, run and it will download all prerequisites and install VCT in your home dir.**  
For other distros you need to do it manually. Please scroll to the end of this file to see how, and read INSTALL_README.txt included with download to learn how.  

** 64-bit MacOS don't work with recent mono releases: WinForms are not ported to 64-bit, so it doesn't work. That's why I didn't include it in main release. Older Macs (I have OSX Lion 10.7) seem to work with some GUI rendering issues. Plase try the Windows release with Crossover for Mac on new Macs, although performance is not on par with natively compiled ffmpeg binaries.

# v1.10.0.0 added option "keep subtitles", ffmpeg bump to v8.0

### You can download binaries and source code from Sourceforge:
https://sourceforge.net/projects/videoconvertertranscoder/files/

### and source code from GITHUB, plus releases with binaries:
https://github.com/zbabac/VCT

**VCT is _frontend_ for `ffmpeg` tool which I believe, is the best tool for video/audio files manipulation
It is command line tool, so it may be inconvenient for those users that can only work with some kind of GUI.
I've created this tool because I needed some app that can help me convert my entire video library quickly to the H.264 or H.265. Handbrake can do it, but I have to click to every file, select path, etc.**

## I wanted to achieve 4 goals:

_1. to have ability to manually edit any command option of ffmpeg_

_2. ability to transcode MP4 to MKV and vice versa (thus full length movie transcoding take 2 minutes compared to 2 hours of full conversion)_

_3. ability to set conversion options and then drag many files onto the VCT to encode them all with same options_

_4. ability to encode each video (or audio) separately and to add them all to batch list  (kinda like Handbrake)_

Licensed under Apache v2.0, so you are free to use the source code for any purpose you like, open source or commercial. Just be kind and mention the source!

If you find a bug, or you have an issue, _please use discussion board_ to contact me. If you use GitHub, you can open issue there.
If program is declared an open source, it doesn't mean that there is no support. On contrary, you can contact developer directly and get the most out of it!

**IMPORTANT NOTE about FPS options**: if input video file is loaded via "Input File" button, then exact FPS is loaded from file. 
In that case, either "Slow Motion" or "Set FPS" can make sense, not both.
But, if you first set options, and then load bunch of files via "Multiple Input Files", then you must know files FPS and how much to slow down.
In that case, both check boxes can be used, but, BE CAREFUL, or the result may not be satisfactory!
If you load audio file (mp3, aac, etc.), those 2 check boxes are ignored, but they can be set as preparations for the next bunch of files loaded via "Multiple Input Files".
In any case, if using "Multiple Input Files" option to load bunch of files to be encoded with same options,
you MUST SET ALL OPTIONS FIRST, THEN CLICK TO LOAD FILES.

**NOTE FOR LINUX**: Please go to the bottom of this readme to see how to install.
Source code for Linux is the same, in theory you could use `monodevelop` to build and test but I never tried it.

**If you want to use precompiled binaries with Linux, I strongly suggest to use automated installation scripts `install_vct_apt.sh` and `install_vct_yum.sh`. They will download end unpack VCT to `~/VCT_mono/` and copy ffplay, ffmpeg and ffprobe to `/usr/bin/` and set correct permissions. You can also manually unpack `VCT_Linux_mono_binary.zip` to some other location (read those scripts and modify them to your needs).
**I am now mainly using Linux and I can confirm that VCT with Mono gives superior performance, since native Linux FFmpeg binary is used.**

## VCT has its limitations: 
- when you define options and drop multiple files "Multiple Input Files" button or to the list, you can't use subtitles;
- you can only encode file with single audio stream, unless you edit the FFmpeg command manually;
- if there is subtitle stream inside input file, it will not be copied to output, unless you edit command manually (planned for next major release);
- if selecting audio stream when dropping multiple files, you must know how many streams there are and which one is the one you need (if selecting files one by one, you can use Info button to check codec data).

That's why I left option to _manually edit ffmpeg command_, for all of you that know, or are willing to learn this tool. _You can also manually edit commands in batch list._

ffprobe is included in 1.5.0 so when you click `Input File`, it is parsed and `Info` button apears. You can click it so see codec details and thumbnail from video. This could have been acieved with ffmpeg, but ffprobe produces JSON output and I wanted to play with it; and it was fun!

## Quick tips for common usage:

**I use this tool regularly for 2 tasks**
	
- _1 to full convert bunch of HD files from smartphone_ (they are too big, 1 minute - 200 MB). At `Convert` Tab use preset `slower`, quality `25` and get 5-10 times smaller files without loosing quality - you can experiment with values - for SD video, use quality `21` - then select multiple files and drag them to the list of button `Multiple Input Files`
	
- _2 to transcode MKV movies to MP4 quickly without changing quality_. Set few options first, like stream numbers, etc. and then just select all of them in Windows Explorer and drag them to the button `Input File(s) to Transcode` on `Transcode` tab. Then just click `Start`. It takes 1-3 minutes per movie (depending on the length of the movie, avg. movie is 90+ minutes long);
	
If you want files to be stored in different folder than input files, then select first `Output path` where you want to store the new video or audio files, then you will be able to select which files you want to convert/transcode (`Input files` or `Multiple files`).
	
You can use **drag&drop** instead to click "Input File(s)..." buttons. Just drag file(s) on those buttons from Windows Explorer.

**Latest version 1.9.7**



## Content:

 - Features
 - GIT source code location
 - Change logs
 - Known issues
 - Prerequisities
 - Visual Studio usage
 - Monodevelop Linux usage
 - Linux usage

### Features:
- 3 tabs: Transcode, Convert and Record

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
- Pause/Resume encoding tasks
- File Info button to display attributes and Play button to open new window and play media file

- Record tab: enter address (link) of the Internet or local stream
- check stream and display stream attributes in JSON format (codec, streams, title, etc)
- play live stream in separate window
- each recording or playing process is run in separate window, user can perform other tasks like Transcode or Convert

Help/walkthrough is available in both Binary installation and Source. When installed, Start menu folder is created with links to VCT.exe, help (pdf), license and uninstall option. 


### GIT:
To get latest source, please use GIT either on GITHUB or SF!
https://sourceforge.net/projects/videoconvertertranscoder/

Added git repository. It is now preferred method to get source code. To clone use:

`git clone https://github.com/zbabac/VCT.git`

Please contact me via discussion board if you want to collaborate or send me an email: zlatko.babic@mail.com.

### Change log
# v1.10.0.0 added option "keep subtitles", ffmpeg bump to v8.0  
On the GUI only check box "Keep Subtitle" is added, but it is applied for Transcode as well as Multiple Files options. When checked, you will copy all subtitles to the output file. This doesn't apply when you add external subtitle, so take care of that. You can keep subtitles and add a new one ONLY by manual edit of the ffmpeg command.
ffmpeg is updated to the lates version 8.0 "Huffman".

# v1.9.7 Functionality the same as 1.9.5.6. but with updated GUI look: Windows and Linux with mono have similar look; fixed issues with lower resolutions (works from 1200x800 and higher); for res. 1920x1080 and higher works with scaling up to 150%.

# v1.9.6.2 The same as 1.9.5.7, but with a fix for Linux exceptions with mono 6.8-6.12 and with .NET framework 4.8  and updated Newtonsoft dll.

# v1.9.5.7 Copy specific time range to output in Transcode Tab, works also in Convert tab
- **When copying only certain time range in Convert tab, pay attention that it is possible only for some scenarios:   
	-**e.g. copy streams with resize option
	-**copy video stream and encoding audio stream
	-**it DOES NOT WORK with some full video encodings
- **Fix of copy from specific time to output in Transcode tab 
- **Bug fix for task list when some task is deleted

# v1.9.5.6 Streaming feature in Record tab: 
- **Comeback of copy from specific time to output in Transcode tab 
- **Unlimited number of encoding tasks allowed (in the list on the right side)   
- **New Tab `Record` is introduced for vieweing and recording audio and/or video streams (from Internet or local network)
- **Experimental use introduced FFPlay for playing streams, Play button added to `Convert` tab as well - separate window is opened for playing asynchronously - you can continue working in the main window
- **Since it is still experimental, only basic selection is possible (user can still manually edit ffmpeg command before recording):
- **if Audio file is selected to record streaming, then simple copy from stream to the file is given, if you want full conversion on-the-fly, then you must enter options manually for the ffmpeg command
- **if Video is selected to record streaming, then options are given to record video in 5 minute segments - if you want to record in a single, large file, then modify the command before clicking Start Recording
- **Check Stream button will display stream information in the log panel at the right side - format is JSON, so you can see what codec is used and thus choose appropriate file format
- **Source code for Linux mono and Windows forms has finaly converged and it is now the same. Difference is in file naming conventions (slash and backslash, and ffmpeg calls). Runtime check is used to decide if the Linux (or Mac) or Windows is the running platform. For performace reasons, You can of course use Linux (or Mac) Mono, instead of Wine. I use it now predominantly on Linux Debian 9 in the cloud, so that I don't occupy my own PC 
- **Linux can't play stream or file because ffplay is not staticaly built and dependencies are not met. You have to install ffmpeg package:
`sudo apt-get install ffmpeg` and copy included ffmpeg and ffprobe to the /usr/bin/

# v1.9.3   
- **Transcode all streams option "-map 0:v -map 0:a" to try to copy all streams (including multiple audio streams, thanks to user McCoy for suggestion). If it fails, then simply delete the batch task and remove check box for that option on Transcode tab
- **If this option is unchecked, then you have option to choose which video and audio stream will be copied to output; by default, first video and audio stream is copied
- **Keep file extension - useful with option above unchecked: only first video and first audio is copied and file extension (e.g. MP4) is preserved
- **Remove subtitle usage extended with 2 above options: in most of the cases, subtitle is not compatible in MKV and MP4 containers; it is by default set to remove subtitle stream, but you've left with option to keep it

# v1.9.2.0 

- **Added video resize option (1920, 1280 and 720 width preset)**, minor GUI changes, last XP UPGRADE to 1.9.2 as separate download
- H.265 is by default encoded as 8-bit so it can be run on modest HW (Raspberry Pi)
- Linux updated to 1.9.2
- Windows XP as separate download (this is the last XP version)


Changelog since v1.9.0

- **Start/Pause/Resume** button allows to _pause_ encoding tasks in case you want to do something else on your PC and then _resume_ encoding
- removed _CPU_ option since it is obsolete with new ffmpeg version	

Changelog since v1.8.1.0

- added option to remove embedded subtitle from source, since there were problems noticed with some files (e.g. subtitle stream positioned before audio stream)
- added "Remove Output Path" button; before, it was neccessary to close the app to change output path
- fixed all errors that caused file info not to display some audio or video info
- compiled as 64-bit application and included ffmpeg and ffprobe v4.0.2 64-bit binaries from zeranoe
- removed "strict experimental" for audio encoding, since it is obsolete with new ffmpeg

Changelog since v1.7.0	

- feature to set output FPS rate and to create slow motion video from high FPS source, 
- corrected minor bug "Info" button not visible

Changelog since v1.6.1

- support for new AAC codec, 
- strict experimental option added for compatibility with XP

Changelog since v1.6.0.1
	
- support for H.265 (HEVC) - check box added at Convert tab next to the CPU check box 
- H.265 already supported at Transcode tab
- if single file opened, automatically detected H.265 codec
- new Quality settings added for H.265 - 28 (h265) approx. corresponds to 23 (h264) or 20 for SD

### Known issues:
Avast on XP could block setup execution with strange messages like: "path could not be found...". Please scan VCT_setup.exe with AV program, then disable file shield and run setup again. It could be the case with other AV software.
On Windows 7 and 8, there is DEP active and once you confirm that you want to run the setup, it will install without problems.

Antivirus software can cause problems after installation. Windows can give message: "windows cannot access the specified device path or file you may not have appropriate permissions". Avast antivirus is blocking execution. If you are worried about security, please scan this app first or compile it yourself from the source.  
You basically need to add scanning exclusion to the installation path, default is: "C:\Program Files (x86)\VCT" or "C:\Program Files\VCT".

**Update**: new Avast version uses Deep scan at first run, so everything is ok.

**Update 2**: Windows 8 and 10 will try to prevent installation. After you scan setup file, click Advanced, then click `install anyway`.


### Prerequisities:
If you download setup, all neccessary dependencies are installed (ffpmeg, pdf help), except **.NET 4.8 Framework. It is included with Windows 10, bu tperhaps not with Windows 7 and 8. Please download it from Microsoft if VCT doesn't start.**


### Visual Studio usage:
Source code files created by VS 2022 Community Edition, so just unpack and opeb the solution with VS. However you can create project in VS 2010 (tested) or VS 2012, just create a new folder and copy all files except *.sln and *.suo to that folder. Then, simply open VCT.csproj with your version of Visual Studio.
Whenever I add new version I provide the latest ffmpeg.exe and ffprobe static build compiled by zeranoe, but if you want a more recent one, just download and replace the existing one. License, download paths are mentioned in About box.



### LINUX MONO USAGE

Application is built using Winforms so it has MS Windows looks, not the native Linux looks you would expect in Gnome or KDE. I changed GUI elements to be flat in appeareance so that win and linux looks don't differ much.

UPDATE: **I added small scripts to automate installations.**

For **Debian, Ubuntu**, etc. with APT package manager download  **install_vct_apt.sh**, and run it(provide sudo credentials):
`./install_vct_apt.sh`  or just double click it - execute in terminal! It will update packages, download VCT_mono_binary and create desktop file **vct.desktop** which you can double click to run the program (edit it manually to reflect your program path if you intalled in location other that $HOME).  

For **Fedora, Centos**, etc. with YUM package manager download **install_vct_yum.sh**, and run it(provide sudo credentials):
`./install_vct_yum.sh`  or just double click it - execute in terminal! It will update packages, download VCT_mono_binary and create desktop file **vct.desktop** which you can double click to run the program (edit it manually to reflect your program path if you intalled in location other that $HOME).  

Program will be installed in $HOME/VCT_mono/.

For other distros that use other package managers, please read INSTALL_README.txt and install manually, like in the example below:

#### Prerequisities:
- You must have mono installed to run .NET application.
- You must have ffmpeg packages installed.
- Exact installation procedure is within those 2 scripts mentioned above so you can use them as template to modify installation process.

After you install ffmpeg and mono, unpack VCT_Linux_mono_binary.zip to directory of your choice. I will give example as if you put it in your home dir. Use sudo bash if permissions are inadequate.
The same procedure applies to MacOS.

- Open terminal and go to dir. where VCT_Linux_mono_binary.zip is saved, usually Downloads:

- `cd $HOME/Downloads`
- `unzip VCT_Linux_mono_binary.zip -d $HOME`
- `cd $HOME/VCT_mono`
- `chmod 777 *`

- Now, copy supplied binaries to the /usr/bin/ so they will overwrite installed old versions of ffmpeg:

- `sudo cp ff* /usr/bin/`


you can now run:

`mono $HOME/VCT_mono/VCT.exe`

or create launcher at desktop or menu.

- it should display MS Windows-like window

### Compiling from source code on Linux

Since beta v1.9.5, the source is the same for Linux, Mac and Windows. You can use Mono Develop to compile from source. The difference is only in ffmpeg, ffprobe and ffplay binaries. These are included with VCT binary download, but if you build from source, you must provide those 3 binaries and copy them to the same directory where the VCT.exe and Newtonsoft.Json.dll are located (or inlude path to ff* binaries: export PATH=$PATH:<ffmpeg_path>)


