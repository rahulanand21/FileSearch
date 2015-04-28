using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxFolderpath.Text = folderBrowserDialog1.SelectedPath;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int i;
            string temp="*" + textBoxFileName.Text + "*";
            string[] AllFiles = Directory.GetFiles(@folderBrowserDialog1.SelectedPath,temp,SearchOption.AllDirectories);
            for(i=0;i<AllFiles.Length-1;i++)
            {
                progressBar1.Maximum = AllFiles.Length - 1;
                string[] row = new string[] {Path.GetFileName(AllFiles[i]),AllFiles[i] };
                dataGridView1.Rows.Add(row);
                progressBar1.Increment(1);
            }

        }
    }
}
