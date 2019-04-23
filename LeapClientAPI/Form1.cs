using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace LeapClientAPI
{
    public partial class Form1 : Form
    {
        ISubscriber sub;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");

            sub = redis.GetSubscriber();

            //first subscribe, until we publish
            //subscribe to a test message
            sub.Subscribe("leapthuan", (channel, message) => {
                this.label1.Invoke((MethodInvoker)delegate
                {
                    this.label1.Text = message;
                });
                //Console.WriteLine("Got message: " + (string)message);
                MultiLeap leaps = (MultiLeap)JsonConvert.DeserializeObject<MultiLeap>(message);
                Console.WriteLine(leaps.sensors[0].dump);
            });  
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sub.Unsubscribe("leapthuan");
        }
    }
}
