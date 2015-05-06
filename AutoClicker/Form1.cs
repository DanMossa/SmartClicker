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
using System.Runtime.InteropServices;
using System.IO;

namespace AutoClicker
{

    public partial class Form1 : Form
    {
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
        const int URLMON_OPTION_USERAGENT = 0x10000001;

        public void ChangeUserAgent(String Agent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        }

        public Form1()
        {
            InitializeComponent();
        }

        string ExtractString(string s, string tag)
        {
            // You should check for errors in real-world code, omitted for brevity
            var startTag = tag;
            int startIndex = s.IndexOf(startTag) + startTag.Length;
            int endIndex = s.IndexOf(tag, startIndex);
            return s.Substring(startIndex, endIndex - startIndex);
        }

        String myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(myDocuments + @"\DG\AutoClicker");

            webBrowser1.ScriptErrorsSuppressed = true;
            ChangeUserAgent("Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)");
            loadingText.BringToFront();
            this.Size = new Size(336, 396);
            webBrowser1.Navigate("http://mossaband.com/AutoClicker/login.html");

        
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
            if (Convert.ToInt32(labelSeed.Text) > 0)
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
                button1.Visible = true;
                downloadedTemp.Visible = true;
                instructionsLabel.Visible = true;
                timerSeed.Stop();
                clicksPerSecondText.Text = Convert.ToString(clicks / 30);
                File.WriteAllText(myDocuments + @"\DG\AutoClicker\Settings.txt", clicksPerSecondText.Text);
            }
        }

        private void refine_Click(object sender, EventArgs e)
        {
            labelSeed.Text = "30";
            buttonSeed.Visible = true;
            labelSeed.Visible = true;
            clicksPerSecondText.Visible = true;
            downloadedTemp.Visible = true;
            button1.Visible = true;
            instructionsLabel.Visible = true;
            labelSeed.Visible = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (buttonSeed.Visible == false)
            //{
                if (e.KeyCode == Keys.Oemtilde)
                {
                    if (!timerAutoClick.Enabled)
                    {
                        timerAutoClick.Start();
                    }
                    else if (timerAutoClick.Enabled)
                    {
                        timerAutoClick.Stop();
                    }
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    int xPosition = Cursor.Position.X;
                    int yPosition = Cursor.Position.Y;

                    Console.Write(xPosition + " " + yPosition);
                }
            //}

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            loadingText.Visible = false;
            if (webBrowser1.DocumentTitle.Contains("Login"))
            {

                this.Size = new Size(336, 462);
                // webBrowser1.Size = new Size(320, 357);


            }
            else if (webBrowser1.DocumentTitle.Contains("Create"))
            {
                this.Size = new Size(336, 655);
                // webBrowser1.Size = new Size(320, 479);

            }
            else if (webBrowser1.DocumentText.Contains("ZZ"))
            {
                webBrowser1.Visible = false;

                string html = webBrowser1.DocumentText;

                string zipcode = ExtractString(html, "ZZ");
                string countrycode = ExtractString(html, "CC");

            GetTemp:

                int retry = 0;
                try
                {
                    WebClient Weather = new WebClient();
                    string htmlWeather = Weather.DownloadString("http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode + "," + countrycode + "&units=imperial");
                    MatchCollection temperature = Regex.Matches(htmlWeather, "\"temp\":(.{5})", RegexOptions.Singleline);

                    foreach (Match currentTemp in temperature)
                    {
                        downloadedTemp.Text = currentTemp.Value;
                    }
                    string temp = downloadedTemp.Text;
                    downloadedTemp.Text = temp.Remove(0, 7);
                    this.Size = new Size(605, 403);

                    if (!File.Exists(myDocuments + @"\DG\AutoClicker\Settings.txt"))
                    {
                        FileStream createSettingsTXT = new FileStream(myDocuments + @"\DG\AutoClicker\Settings.txt", FileMode.CreateNew);
                        createSettingsTXT.Close();
                        buttonSeed.Visible = true;
                        labelSeed.Visible = true;
                    }
                    else
                    {
                        button1.Visible = true;
                        downloadedTemp.Visible = true;
                        instructionsLabel.Visible = true;
                        string readSettingsTXT = File.ReadAllText(myDocuments + @"\DG\AutoClicker\Settings.txt");
                        clicksPerSecondText.Text = readSettingsTXT;
                    }
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
                        MessageBox.Show("Please send an email to Daniel@Mossaband.com regarding the issue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                }



            }
        }
        InputSimulator lol = new InputSimulator();
        private void timerAutoClick_Tick(object sender, EventArgs e)
        {

            lol.Mouse.LeftButtonClick();
        }



    }
}
