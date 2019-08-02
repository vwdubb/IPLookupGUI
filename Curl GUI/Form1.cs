using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curl_GUI
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();

            richTextBox1.Text = "Oh hi there!\n\nWe only have the one button here so, go ahead";
        }

        private async void BtnCheck_Click(object sender, EventArgs e)
        {
            await doStuff();
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(500);
        }

        async Task doStuff()
        {
            richTextBox1.Text = "Please wait .";
            await PutTaskDelay();
            richTextBox1.Text = "Please wait . .";
            await PutTaskDelay();
            richTextBox1.Text = "Please wait . . .";
            await PutTaskDelay();

            var externalIpJson = new WebClient().DownloadString("http://ipinfo.io");

            IP iP = Newtonsoft.Json.JsonConvert.DeserializeObject<IP>(externalIpJson);

            if(iP.country == "CA")            
                iP.country = "Canada";            
            else if(iP.country == "US")            
                iP.country = "USA";            

            richTextBox1.Text = "IP Address: " + iP.ip + "\n";
            richTextBox1.Text += "City: " + iP.city + "\n";
            richTextBox1.Text += "Region: " + iP.region + "\n";
            richTextBox1.Text += "Country: " + iP.country + "\n";
            richTextBox1.Text += "Postal code: " + iP.postal + "\n";
            richTextBox1.Text += "GPS: " + iP.loc;
        }        
    }
}
