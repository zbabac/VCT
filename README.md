# v1.9.4 
- **option to select time span `from time --> to time` to copy to output file**
- **bear in mind that window is crowded now, so THIS OPTION IS VALID FOR BOTH Convert and Transcode**
- **If you set it in Transcode tab, it will affect the Convert as well**
- **Also, IT WILL BE USED IF MULTIPLE FILES ARE SELECTED, so use check box to control it**


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
Source code for Linux is the same, but check file **Form1.cs** and commented lines marked with __"Linux"__.

**If you want to use precompiled binaries with Linux, you have 2 choices: use Linux mono binary, or use Windows Setup with Wine. 
My experience in the 2019 is that Windows Setup installed with Wine works better. However, Mono may give you better performance, since native Linux FFmpeg binary is used.**

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

**Latest version 1.9.3**



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
- Pause/Resume encoding tasks

Help/walkthrough is available in both Binary installation and Source. When installed, Start menu folder is created with links to VCT.exe, help (pdf), license and uninstall option. 


### GIT:
To get latest source, please use GIT either on GITHUB or SF!
https://sourceforge.net/projects/videoconvertertranscoder/

Added git repository. It is now preferred method to get source code. To clone use:

`git clone https://github.com/zbabac/VCT.git`

Please contact me via discussion board if you want to collaborate or send me an email: zlatko.babic@mail.com.

### Change log 

# v1.9.4 
- **option to select time span (from time --> to time) to copy to output file**
- **bear in mind that window is crowded now, so THIS OPTION IS VALID FOR BOTH Convert and Transcode**
- **If you set it in Transcode tab, it will affect the Convert as well**
- **Also, IT WILL BE USED IF MULTIPLE FILES ARE SELECTED, so use check box to control it**

# v1.9.3.4
- **fixed issue with rotate video; used new ffmpeg video filter -vf "rotate="   
- **Transcode all streams option "-map 0:v -map 0:a" to try to copy all streams (including multiple audio streams, thanks to user McCoy for suggestion). If it fails, then simply delete the batch task and remove check box for that option on Transcode tab
- **If this option is unchecked, then you have option to choose which video and audio stream will be copied to output; by default, first video and audio stream is copied
- **Keep file extension - useful with option above unchecked: only first video and first audio is copied and file extension (e.g. MP4) is preserved
- **Remove subtitle usage extended with 2 above options: in most of the cases, subtitle is not compatible in MKV and MP4 containers; it is by default set to remove subtitle stream, but you've left with option to keep it
- **Windows XP users can download VCT_setup.exe and separately download older version of FFmpeg (ffmpeg version N-76123-g002b049, e.g. http://hp.vector.co.jp/authors/VA020429/ffmpeg/list.html) in order to be able to get new VCT features
- **Linux finaly fixed file info bug if you use mono version; if you have Wine, you can download Windows VCT_setup.exe (or 64-bit binary)
- **Fixed issue when video rotated 180 degrees is also mirrored - used new filter option, e.g. `-vf "rotate=PI"`

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

Antivirus software can cause problems after installation. Windows can give message: "windows cannot access the specified device path or file you may not have appropriate permissions". Avast antivirus is blocking execution. If you are worried about security, please scan this app first or compile it yourself from the source. However, there is simple remendy to overcome this problem, please check the following link:
http://www.getavast.net/support/stop-blocking-a-program/
You basically need to add scanning exclusion to the installation path, default is: "C:\Program Files (x86)\VCT" or "C:\Program Files\VCT".

**Update**: new Avast version uses Deep scan at first run, so everything is ok.

**Update 2**: Windows 8 and 10 will try to prevent installation. After you scan setup file, click Advanced, then click `install anyway`.


### Prerequisities:
If you download setup, all neccessary dependencies are installed (ffpmeg, pdf help), except **.NET 4.0 client profile. Please download it from Microsoft if VCT doesn't start.**
Some antivirus programs (mine is Avast) will complain that "File reputation/prevalence is low". It will be sandboxed. This is due to the fact that application does not have commercial signature. If you are worried about it, please scan it first. There is no virus, full source code is available. After checking, you can instruct your antivirus to execute anyway, or in case of Avast on Windows XP, you need to disable shield (after scanning first, of course) in order to install program.


### Visual Studio usage:
Source code files created by VS 2017 Community Edition for Desktop, so just unpack and opeb the solution with VS. However you can create project in VS 2010 (tested) or VS 2012, just create a new folder and copy all files except *.sln and *.suo to that folder. Then, simply open VCT.csproj with your version of Visual Studio.
Whenever I add new version I provide the latest ffmpeg.exe and ffprobe static build compiled by zeranoe, but if you want a more recent one, just download and replace the existing one. License, download paths are mentioned in About box.



### Linux mono usage

Application is built using Winforms so it has MS Windows looks, not the native Linux looks.

#### Prerequisities:
- You must have mono installed to run .NET application.
- **For Debian systems (Ubuntu, Mint, etc.) run**:

- `sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF`
- `echo "deb http://download.mono-project.com/repo/debian stretch main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list`
- `sudo apt-get update`
- `sudo apt-get install mono-complete`

- **For another distributions, just search: mono <distro_name> installation.**
- Example for Fedora or CentOS (Red Hat derivative):

- `yum install yum-utils`
- `rpm --import "http://keyserver.ubuntu.com/pks/lookup?op=get&search=0x3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF"`
- `yum-config-manager --add-repo http://download.mono-project.com/repo/centos/`
- `yum install mono-complete`

After that, unpack VCT_Linux_mono_binary.zip to directory of your choice. I will give example as if you put it in your home dir. Use sudo bash if permissions are inadequate.

- Open terminal and go to dir. where VCT_Linux_mono_binary.zip is saved, usually Downloads:

- `cd $HOME/Downloads`
- `unzip VCT_Linux_mono_binary.zip -d $HOME`
- `cd $HOME/VCT_mono`
- `chmod 777 *`

add ffmpeg to path if you don't have it installed:

`PATH=$PATH:$HOME/VCT_mono`

or add that line permanently to your profile at `$HOME/.profile` or `$HOME/.bash_profile` - just put the above line at the end of the .profile file, usually `$HOME/.bash_profile`

you can now run:

`mono $HOME/VCT_mono/VCT.exe`

or create launcher at desktop or menu.

- it should display MS Windows-like window

### Compiling from source code on Linux

Due to different path naming in Windows and Linux, if you are compiling on Linux with Monodevelop, you need first to go through `Form1.cs` and comment all lines marked in comment as `Windows` and uncomment lines marked as `Linux`. Use common sense to do that, it's not hard.

**If you use Wine on Linux, then just download Windows installer: VCT_setup.exe and install it via Wine. The prerequisite is that you have .NET Framework 4 Client installed in Wine.**

