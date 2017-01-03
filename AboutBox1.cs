using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace VTC
{
    partial class AboutBoxZ : Form
    {
        public AboutBoxZ()
        {
            // uncomment next line to build for specifig language UI - useful if you have Windows installed in english but you want specific app UI
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr-Cyrl"); 
            InitializeComponent();
            //this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.richTextBoxDescription.Text = "Copyright 2014-2017 Zlatko Babić"+

				"\nLicensed under the Apache License, Version 2.0 (the 'License');"+
				"\nyou may not use this file except in compliance with the License."+
				"\nYou may obtain a copy of the License at"+

				"\n    http://www.apache.org/licenses/LICENSE-2.0  "+

				"\nUnless required by applicable law or agreed to in writing, software"+
				"\ndistributed under the License is distributed on an 'AS IS' BASIS,"+
				"\nWITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied."+
				"\nSee the License for the specific language governing permissions and"+
				"\nlimitations under the License."+
				"\nFull license text is located in the same folder where you have installed VCT in file Copying.txt."+
                "\n\nThis software uses FFmpeg binary as a wrapper to convert video and audio files."+
                "\nFFmpeg 32-bit binary is provided with VCT. It is unaltered static build compiled by Zeranoe and downloaded from:"+
                "\n    http://ffmpeg.zeranoe.com/builds/win32/static/ "+
                "\nIf you want to use newer version of FFmpeg, or the 64-bit one, or one that you compiled yourself, "+
                "you must store that new   ffmpeg.exe    in the same folder as VCT.exe"+
                "\n\nThis app uses icon from http://hadezign.com ."+
                "\n\nHelp is available in PDF document in the installation folder, or by clicking 'Help' button when on Transcode Tab.";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return "Video Converter & Transcoder";
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
