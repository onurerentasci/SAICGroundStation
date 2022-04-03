using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UI
{
    public partial class Form1 : Form
    {
        private Stopwatch stopWatch;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void glControl1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.saat.Text = String.Format("{0:hh\\:mm\\:ss\\:fff}", stopWatch.Elapsed);
        }

        private void saat_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e) // Connect Button
        {
            stopWatch.Start(); // sayımı başlat
            textBox1.Text = "CONNECTED";
            textBox1.ForeColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e) // Disconnect Button
        {
            stopWatch.Reset();
            textBox1.Text = "DISCONNECTED";
            textBox1.ForeColor= Color.Red;
        }
    }
}
