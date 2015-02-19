using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using Qlik.Sense.Client;

namespace QlikSenseLoopandReduce
{
    public partial class LaunchForm : Form
    {
        private QlikSenseLoopAndReduce loop;

        public LaunchForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtServer.Text = GetQRSURL();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QlikSenseJSONHelper helper = new QlikSenseJSONHelper(txtServer.Text);
            List<string> LoopValues = helper.GetFieldValues((app)cmbApps.SelectedItem, (IAppField)cmbLoopField.SelectedItem);


            loop = new QlikSenseLoopAndReduce(txtServer.Text);
            loop.LoopAndReduce(((app)cmbApps.SelectedItem), ((stream)cmbStreams.SelectedItem), txtScript.Text, LoopValues);

            txtMessageBox.Text = "Loop and reduce process completed.";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readApps();
            readStreams();
        }


        private void readApps()
        {
            //QRSWebClient qrsClient = new QRSWebClient(txtServer.Text + ":4242");
            QRSNTLMWebClient qrsClient = new QRSNTLMWebClient(txtServer.Text);
            string result = qrsClient.Get("/qrs/app");

            List<app> apps = new List<app>();
            apps = JsonConvert.DeserializeObject<List<app>>(result);

            cmbApps.DataSource = apps;

        }

        private void readStreams()
        {
            //QRSWebClient qrsClient = new QRSWebClient(txtServer.Text + ":4242");
            QRSNTLMWebClient qrsClient = new QRSNTLMWebClient(txtServer.Text);
            string result = qrsClient.Get("/qrs/stream");

            List<stream> streams = new List<stream>();
            streams = JsonConvert.DeserializeObject<List<stream>>(result);

            cmbStreams.DataSource = streams;

        }


        private static string GetQRSURL()
        {
            string domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            string hostName = Dns.GetHostName();
            string fqdn = "";
            //if (!hostName.Contains(domainName))
            //    fqdn = hostName + "." + domainName;
            //else
                fqdn = hostName;

            return @"https://" + fqdn;
        }



        private void cmbApps_SelectedIndexChanged(object sender, EventArgs e)
        {

            QlikSenseJSONHelper helper = new QlikSenseJSONHelper(txtServer.Text);

            List<IAppField> AppFields = helper.GetAppFields((app)cmbApps.SelectedItem);

            cmbLoopField.DataSource = AppFields;

            cmbLoopField.DisplayMember = "FallbackTitle";
            cmbLoopField.Format += (s, v) =>
            {
                v.Value = ((IAppField)v.ListItem).DimensionInfo.FallbackTitle;
            };
        }


    }
}
