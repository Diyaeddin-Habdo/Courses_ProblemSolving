using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TextBox LastTxt = new TextBox();
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMain.Text))
                return;
            TextBox txt = new TextBox();
            txt.Multiline = true;
            txt.Size = new Size(110, 134);
            txt.BackColor = Color.FromArgb(255, 224, 192);
            txt.ReadOnly = true;
            txt.Margin = new System.Windows.Forms.Padding(8);
            txt.ContextMenuStrip = contextMenuStrip1;
            txt.Text = txtMain.Text;

            flowLayoutPanel1.Controls.Add(txt);
            txtMain.Clear();
        }
        private TextBox ReturnTxt(object obj)
        {
            var child = obj as ToolStripMenuItem;
            var parent = child.Owner as ContextMenuStrip;
            var txt = parent.SourceControl as TextBox;
            return txt;
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox txt = ReturnTxt(sender);
            for(byte i= 0; i<flowLayoutPanel1.Controls.Count;i++)
            {
                if (txt == flowLayoutPanel1.Controls[i])
                {
                    flowLayoutPanel1.Controls.Remove(txt);
                    return;
                }
            }
            flowLayoutPanel2.Controls.Remove(txt);
        }
        private void MoveNotes(object obj)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                moveToNotesToolStripMenuItem.Visible = false;
                markAsImportantToolStripMenuItem.Visible = true;
                flowLayoutPanel2.Controls.Add(ReturnTxt(obj));
            }
            else if(tabControl1.SelectedIndex == 2) 
            {
                moveToNotesToolStripMenuItem.Visible = true;
                markAsImportantToolStripMenuItem.Visible = false;
                flowLayoutPanel1.Controls.Add(ReturnTxt(obj));
            }
        }
        private void markAsImportantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveNotes(sender);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LastTxt = ReturnTxt(sender);
            txtMain.Text = LastTxt.Text;
            button1.Visible = false;
            button3.Visible = true;
            tabControl1.SelectedIndex = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMain.Clear();
            button1.Visible = true;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LastTxt.Text = txtMain.Text;
            txtMain.Clear();
            button1.Visible = true;
            button3.Visible = false;
        }

        private void moveToNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveNotes(sender);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                moveToNotesToolStripMenuItem.Visible = false;
                markAsImportantToolStripMenuItem.Visible = true;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                moveToNotesToolStripMenuItem.Visible = true;
                markAsImportantToolStripMenuItem.Visible = false;
            }
        }
    }
}
