using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VTC
{
    public partial class Form3 : Form
    {
        public Form3(string pass_log)
        {
            InitializeComponent();
            richTextBoxLog.Text = pass_log;
        }
    }
}
