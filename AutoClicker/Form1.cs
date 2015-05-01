using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace AutoClicker
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            webControl1.Source = new Uri("http://mossaband.com/AutoClicker/login.html");
        GetTemp:

            int retry = 0;
            try
            {
                WebClient Weather = new WebClient();
                string htmlWeather = Weather.DownloadString("http://api.openweathermap.org/data/2.5/weather?zip=90212,us&units=imperial");
                MatchCollection temperature = Regex.Matches(htmlWeather, "\"temp\":(.{5})", RegexOptions.Singleline);

                foreach (Match currentTemp in temperature)
                {
                    textBox1.Text = currentTemp.Value;
                }
                string temp = textBox1.Text;
                textBox1.Text = temp.Remove(0, 7);
            }
            catch (Exception ex)
            {
                if (retry <= 3)
                {
                    goto GetTemp;
                }
                DialogResult res = MessageBox.Show("Can't get Account Information:\n" + ex.Message, "Error",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (res == DialogResult.Retry)
                {
                    goto GetTemp;
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("Please send an email to Daniel@Mossaband regarding the issue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            
            int xPosition = Cursor.Position.X;
            int yPosition = Cursor.Position.Y;
            Console.Write(xPosition + " " + yPosition);

        }

        double clicks = 0;

        private void buttonClickFast_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(labelSeed.Text) > 0 )
            {
                clicks = clicks + 1;
            }
            if (!timerSeed.Enabled)
            {
                timerSeed.Start();
            }
        }

        private void timerSeed_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(labelSeed.Text) > 0)
            {
                labelSeed.Text = Convert.ToString(Convert.ToInt32(labelSeed.Text) - 1);
            }
            else if (Convert.ToInt32(labelSeed.Text) <= 0)
            {
                buttonSeed.Visible = false;
                labelSeed.Visible = false;
                timerSeed.Stop();
                clicksPerSecond.Text = Convert.ToString(clicks / 30);
            }
        }

        private void refine_Click(object sender, EventArgs e)
        {
            labelSeed.Text = "30";
            buttonSeed.Visible = true;
            labelSeed.Visible = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (buttonSeed.Visible == false)
            {
                if (e.KeyCode == Keys.Oemtilde)
                {
                    if (timerAutoClick.Enabled == false)
                    {

                        timerAutoClick.Start();
                    }
                    else if (timerAutoClick.Enabled == true)
                    {
                        timerAutoClick.Stop();
                    }
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    int xPosition = Cursor.Position.X;
                    int yPosition = Cursor.Position.Y;
                   
                    Console.Write(xPosition + " " + yPosition);
                }
            } 

        }

        private void timerAutoClick_Tick(object sender, EventArgs e)
        {

        }

    }
}
