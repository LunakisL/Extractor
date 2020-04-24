using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArchivingProgramUsingCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Archiving ar = new Archiving();

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Fbd = new FolderBrowserDialog();
            string path = string.Empty;
            if (Fbd.ShowDialog() == DialogResult.OK)
            {
                path = Fbd.SelectedPath;
            }
            DirectoryInfo Dinfo = new DirectoryInfo(path);
            foreach (FileInfo finfo in Dinfo.GetFiles())
            {
               if (YesDo)
                {
                    ar.Compress(finfo,this.listBox1);
                    File.Delete(finfo.FullName);
                }
               else
                {
                    ar.Compress(finfo,this.listBox1);
                }
            }
        }

        bool YesDo = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                YesDo = true;
                return;
            }
            YesDo = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Fbd = new FolderBrowserDialog();
            string path = string.Empty;
            if (Fbd.ShowDialog() == DialogResult.OK)
            {
                path = Fbd.SelectedPath;
            }
            DirectoryInfo Dinfo = new DirectoryInfo(path);
            foreach (FileInfo finfo in Dinfo.GetFiles())
                {
                    ar.Extract(finfo);
                    File.Delete(finfo.FullName);
            }
        }
    }
}
