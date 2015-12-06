using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace VTC
{
    public partial class Form2 : Form
    {
        public Form2(string pass_video_info, string pass_audio_info, string  pass_subtitle_info, string pass_labelFileName2, string pass_labelFormat2, string pass_labelDuration2, string pass_labelSize2, string pass_labelvideobitrate, string temp_path)
        {
            try
            {
                InitializeComponent();

                richTextBoxVideoStr.SelectionTabs = new int[] { 10, 20, 30, 40, 45 };
                //richTextBoxVideoStr.Text = "Stream: 0\nCodec:\th264\tProfile:\tHigh\nPicture size:\t1920x1080\t29.97 fps";
                richTextBoxVideoStr.Text = pass_video_info;
                richTextBoxAudioStr.SelectionTabs = new int[] { 10, 20, 30, 40, 45 };
                //richTextBoxAudioStr.Text = "Stream: 1\nCodec:\tmp3\tBit rate:\t128kb/s\nDuration:\t02:01:15\nLanguage:\teng\tChannels:\t2";
                richTextBoxAudioStr.Text = pass_audio_info;
                richTextBoxSubsStr.SelectionTabs = new int[] { 10, 20, 30, 40, 45 };
                //richTextBoxSubsStr.Text = "Stream: 2\nLanguage:\tund\tCodec:\tmov_text";
                richTextBoxSubsStr.Text = pass_subtitle_info;
                labelvideobitrate.Text = pass_labelvideobitrate;
                labelDuration2.Text = pass_labelDuration2;
                labelFileName2.Text = pass_labelFileName2;
                labelSize2.Text = pass_labelSize2;
                labelFormat2.Text = pass_labelFormat2;
                System.Threading.Thread.Sleep(500);
                pictureBox1.Image = Image.FromFile(temp_path);
            }
            catch (Exception x)
            {
                string m = x.Message;
            }
        }
    }
}
