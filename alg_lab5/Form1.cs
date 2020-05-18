using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alg_lab5
{
    public partial class TextEditor : Form
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0) {
                DialogResult dialogResult = MessageBox.Show("Сохранить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) {

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                        File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                        textBox1.Clear();
                    } 
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                File.WriteAllText("Безымянный", textBox1.Text);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();
            textBox1.Text += (String)data.GetData(DataFormats.Text);
        }
    }
}
