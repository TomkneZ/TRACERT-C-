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

namespace TRACEROUT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Tracert(String remoteHost)
        {
            byte[] data = new byte[1024];
            int recv = 0;
            Socket host = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
            IPHostEntry iphe = Dns.Resolve(remoteHost);
            IPEndPoint iep = new IPEndPoint(iphe.AddressList[0], 0);
            EndPoint ep = (EndPoint)iep;

            // создаю пакет и заполняю его
            ICMP packet = new ICMP();

            packet.Type = 8;
            packet.Code = 0;
            packet.Checksum = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, packet.Message, 0, 2);   //identifier
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, packet.Message, 2, 2);   //sequence number
            data = Encoding.ASCII.GetBytes("This is a test packet, which i'm gonna sent to  test  connection");
            Buffer.BlockCopy(data, 0, packet.Message, 4, data.Length);
            packet.MessageSize = data.Length + 4;
            int packetsize = packet.MessageSize + 4;



            UInt16 chcksum = packet.getChecksum();
            packet.Checksum = chcksum;

            host.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
            richTextBox_route.Text += "Трассировка маршрута к " + textBox_dest.Text + " [" + iphe.AddressList[0] + "] \n";
            bool IsEpRiched = false;
            int i = 1;
            while (i < 31 && !(IsEpRiched))
            {
                int badcount = 0;
                host.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IpTimeToLive, i);  //задает срок жизни в заголовке             

                for (int j = 0; j < 3; j++)
                {
                    DateTime timestart = DateTime.Now;
                    host.SendTo(packet.getBytes(), packetsize, SocketFlags.None, iep); // 1-ый пакет  
                    try
                    {
                        data = new byte[1024];
                        recv = host.ReceiveFrom(data, ref ep);
                        TimeSpan timestop = DateTime.Now - timestart;
                        ICMP response = new ICMP(data, recv);

                        if (j == 0)
                        {
                            if (response.Type == 11)
                            {
                                richTextBox_route.Text += i + " " + (timestop.Milliseconds.ToString()) + "ms" + " ";
                            }
                            if (response.Type == 0)
                            {
                                richTextBox_route.Text += i + " " + (timestop.Milliseconds.ToString()) + "ms" + " ";
                            }
                        }
                        if (j == 1)
                        {
                            if (response.Type == 11)
                            {
                                richTextBox_route.Text += (timestop.Milliseconds.ToString()) + "ms" + " ";
                            }
                            if (response.Type == 0)
                            {
                                richTextBox_route.Text += (timestop.Milliseconds.ToString()) + "ms" + " ";
                            }

                        }
                        if (j == 2)
                        {
                            if (response.Type == 11)
                            {
                                richTextBox_route.Text += (timestop.Milliseconds.ToString()) + ep.ToString() + "\n";
                            }

                            if (response.Type == 0)
                            {
                                IsEpRiched = true;
                                richTextBox_route.Text += ep.ToString() + " достигнут за " + i + " прыжков, " + (timestop.Milliseconds.ToString()) + "мс\n";
                                break;
                            }
                        }

                        badcount = 0;
                    }
                    catch (SocketException)
                    {
                        badcount++;
                        if (j == 0)
                        {
                            richTextBox_route.Text += i + " " + "*" + "     ";

                        }
                        if (j == 1)
                        {
                            richTextBox_route.Text += "*" + "     ";
                        }
                        if (j == 2)
                        {
                            richTextBox_route.Text += "*" + "     ";
                        }

                        if (badcount == 3)
                        {

                            richTextBox_route.Text += "Превышен интервал ожидания для запроса.\n";
                            badcount = 0;
                        }
                    }
                }
                i++;
            }
            host.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_tracert_Click(object sender, EventArgs e)
        {
            Tracert(textBox_dest.Text);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            richTextBox_route.Clear();
        }
    }
}
