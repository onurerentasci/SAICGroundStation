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
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO.Ports;

namespace UI
{
    public partial class Form1 : Form
    {
        float x = 0, y = 0, z = 0;
        bool cx = false, cy = false, cz = false; //3d nesne

        private Stopwatch stopWatch;
        public Form1()
        {
            InitializeComponent();
        }

        // 3d nesne
        private void silindir(float step, float topla, float radius, float dikey1, float dikey2)
        {
            float eski_step = 0.1f;
            GL.Begin(PrimitiveType.Quads);//Y EKSEN CIZIM DAİRENİN
            while (step <= 360)
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(255, 255, 255));


                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 2) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 2) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            step = eski_step;
            topla = step;
            while (step <= 180)// UST KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));


                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);

                GL.Vertex3(ciz1_x, dikey1, ciz1_y);
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);
                step += topla;
            }
            step = eski_step;
            topla = step;
            while (step <= 180)//ALT KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));

                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey2, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();
        }
        private void koni(float step, float topla, float radius1, float radius2, float dikey1, float dikey2)
        {
            float eski_step = 0.1f;
            GL.Begin(PrimitiveType.Lines);//Y EKSEN CIZIM DAİRENİN
            while (step <= 360)
            {
                if (step < 45)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 90)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 135)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 180)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 225)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 270)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 315)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 360)
                    GL.Color3(1.0, 0.0, 0.0);


                float ciz1_x = (float)(radius1 * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius1 * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius2 * Math.Cos(step * Math.PI / 180F));
                float ciz2_y = (float)(radius2 * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();

            GL.Begin(PrimitiveType.Lines);
            step = eski_step;
            topla = step;
            while (step <= 180)// UST KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));


                float ciz1_x = (float)(radius2 * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius2 * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey2, ciz1_y);

                float ciz2_x = (float)(radius2 * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius2 * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            step = eski_step;
            topla = step;
            GL.End();
        }

        // 3d nesne

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void glControl1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] paket; 
            string sonuc = serialPort1.ReadLine();
            paket = sonuc.Split('*');

            this.saat.Text = String.Format("{0:hh\\:mm\\:ss\\:fff}", stopWatch.Elapsed); // status altındaki uptime, saat/dakika/saniye/salise
                                                                                         // formatlama sayesinde salise 3 hanede sınırlı
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] portlar = SerialPort.GetPortNames(); // usbden bağlı portları görmek için
            foreach (string portName in portlar)
            {
                comboBox1.Items.Add(portName);
            }

            stopWatch = new Stopwatch();
            timerX.Interval = 100;
            GL.ClearColor(Color.LightBlue); // 3d nesnenin arkaplan rengi // açık mavi

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(textBox2.Text);
            try
            {
                serialPort1.PortName = comboBox1.Text;
                if (!serialPort1.IsOpen)
                {
                    stopWatch.Start(); // sayımı başlat
                    timer1.Start();
                    serialPort1.Open();
                    DisconnectButton.Enabled = true;
                    ConnectButton.Enabled = false;
                    textBox1.Text = "CONNECTED";
                    textBox1.ForeColor = Color.Green;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bağlantı kurulamadı");
                DisconnectButton.Enabled = true;
            }
        }


        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            timer1.Stop();
            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;
            stopWatch.Reset();
            textBox1.Text = "DISCONNECTED";
            textBox1.ForeColor = Color.Red;
        }



        private void timerX_Tick(object sender, EventArgs e)
        {
            if (cx == true)
            {
                if (x < 360) // 360 yani 1 tur sonunda 0 a döner
                    x += 2; // modeli 2 saniyede bir tekrar oluşturur, sayı arttıkça fps düşer
                else
                    x = 0;
                lblx.Text = x.ToString();
            }
            if (cy == true)
            {
                if (y < 360)  // 360 yani 1 tur sonunda 0 a döner
                    y += 2;  // modeli 2 saniyede bir tekrar oluşturur, sayı arttıkça fps düşer
                else
                    y = 0;
                lbly.Text = y.ToString();
            }
            if (cz == true)
            {
                if (z < 360) // 360 yani 1 tur sonunda 0 a döner
                    z += 2; // modeli 2 saniyede bir tekrar oluşturur, sayı arttıkça fps düşer.
                else
                    z = 0;
                lblz.Text = z.ToString();
            }
            glControl1.Invalidate();
        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            if (cx == false)
                cx = true;
            else
                cx = false;
            timerX.Start();
        }

        private void ButtonY_Click(object sender, EventArgs e)
        {
            if (cy == false)
                cy = true;
            else
                cy = false;
            timerX.Start();
        }

        private void ButtonZ_Click(object sender, EventArgs e)
        {
            if (cz == false)
                cz = true;
            else
                cz = false;
            timerX.Start();
        }

        private void BreakButton_Click(object sender, EventArgs e)
        {

        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {

        }

        

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }


        private void glControl1_Load_1(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Pink);//Color.FromArgb(143, 212, 150)
            timerX.Interval = 1;
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            float step = 1.0f;
            float topla = step;
            float radius = 5.0f;
            float dikey1 = radius, dikey2 = -radius;
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(1.04f, 4 / 3, 1, 10000);
            Matrix4 lookat = Matrix4.LookAt(25, 0, 0, 0, 0, 0, 0, 1, 0); // kamera mesafesi
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Rotate(x, 1.0, 0.0, 0.0);// x ekseninde döndür
            GL.Rotate(z, 0.0, 1.0, 0.0); // z ekseninde döndür
            GL.Rotate(y, 0.0, 0.0, 1.0); // y ekseninde döndür

            silindir(step, topla, radius, 3, -5);
            silindir(0.01f, topla, 0.5f, 9, 9.7f);
            silindir(0.01f, topla, 0.1f, 5, dikey1 + 5);
            koni(0.01f, 0.01f, radius, 3.0f, 3, 5);
            koni(0.01f, 0.01f, radius, 2.0f, -5.0f, -10.0f);

            GL.Begin(PrimitiveType.Lines);

            GL.Color3(Color.FromArgb(250, 0, 0));
            GL.Vertex3(-30.0, 0.0, 0.0);
            GL.Vertex3(30.0, 0.0, 0.0);


            GL.Color3(Color.FromArgb(0, 0, 0));
            GL.Vertex3(0.0, 30.0, 0.0);
            GL.Vertex3(0.0, -30.0, 0.0);

            GL.Color3(Color.FromArgb(0, 0, 250));
            GL.Vertex3(0.0, 0.0, 30.0);
            GL.Vertex3(0.0, 0.0, -30.0);

            GL.End();
            //GraphicsContext.CurrentContext.VSync = true;
            glControl1.SwapBuffers();
        }
    }
}
