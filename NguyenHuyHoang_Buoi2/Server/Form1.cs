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

namespace Server
{
    public partial class Form1 : Form
    {
        Socket server;
        Socket client;
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(textBox2.Text);
            client.Send(data);
            listBox1.Items.Add("Server: " + textBox2.Text);
            textBox2.Text = "";

            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Client: " + Encoding.ASCII.GetString(data));
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 12345);
            server.Bind(ip);
            server.Listen(5);
            client = server.Accept();
        }
    }
}

