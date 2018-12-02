using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SandC
{
    public partial class Form1 : Form
    {
        // Data Types
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public String text_to_send;

        public Form1()
        {
            InitializeComponent();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName()); // Aquires Host machines IP Address
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIPtextBox.Text = address.ToString();
                }
            }
        }

        private void StartServerbutton_Click(object sender, EventArgs e) // Start Server Functionality
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(ServerIPtextBox.Text)); //Turns Port Int number into String
            listener.Start();
            client = listener.AcceptTcpClient(); // Tells the client to accept the TCP connection
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;


        }
    }
}
