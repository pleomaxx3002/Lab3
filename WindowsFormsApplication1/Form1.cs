using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Encrypt_DecryptMode.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dialog.Text = "";
            SourcePath.Text = "";
            TargetPath.Text = "";
        }

        private void TransformButton_Click(object sender, EventArgs e)
        {
            try
            {
                ker.Status += Ker_Status;
                ker.exitEvent += Ker_OnExit;
                ker.ThrownExceptions += Ker_Errors;

                ker.Set(SourcePath.Text, TargetPath.Text, KeyTextBox.Text);
                Dialog.Text = "In Progress";
                Action a; 
                if (Encrypt_DecryptMode.SelectedIndex == 0)
                    a = new Action(ker.EnCode);
                else
                    a = new Action(ker.DeCode);
                BeginInvoke(a);

            }
            catch (Exception E)
            {
                Dialog.Text = E.ToString();
                ker.Status -= Ker_Status;
                ker.exitEvent -= Ker_OnExit;
                ker.ThrownExceptions -= Ker_Errors;
            }
        }

        private void Ker_OnExit()
        {
            Dialog.Text = "Finished";
            ker.Status -= Ker_Status;
            ker.exitEvent -= Ker_OnExit;
            ker.ThrownExceptions -= Ker_Errors;
        }

        private void Ker_Errors(object sender, Exception e)
        {
            Dialog.Text = e.ToString();
            ker.Status -= Ker_Status;
            ker.exitEvent -= Ker_OnExit;
            ker.ThrownExceptions -= Ker_Errors;
        }

        private void Ker_Status(object sender, double a)
        {
            Dialog.Text = String.Format("{0}%",(a*100).ToString("F2"));
        }

        private void SourcePath_TextChanged(object sender, EventArgs e)
        {
            Dialog.Text = "";
        }

        private void TargetPath_TextChanged(object sender, EventArgs e)
        {
            Dialog.Text = "";
        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            Dialog.Text = "";
        }

        private void ChoseSourceButton_Click(object sender, EventArgs e)
        {
            if (Encrypt_DecryptMode.SelectedIndex == 0)
            {
                if (SourceFolderDialog.ShowDialog() == DialogResult.OK)
                    SourcePath.Text = SourceFolderDialog.SelectedPath;
            }
            else
            {
                if (SourceFileDialog.ShowDialog() == DialogResult.OK) 
                    SourcePath.Text = SourceFileDialog.FileName;
            }

        }

        private void ChoseDestButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = TargetFolderDialog.ShowDialog();
            TargetPath.Text = TargetFolderDialog.SelectedPath;
        }
    }
}
