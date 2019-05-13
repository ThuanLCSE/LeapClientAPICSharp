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
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;

namespace LeapClientAPI
{
    public partial class Form1 : Form
    {
        ISubscriber sub;
        protected const String REDIS_SERVER_IP = "172.22.217.59";
        protected const String REDIS_PORT = "6379";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(REDIS_SERVER_IP +":" + REDIS_PORT);

            sub = redis.GetSubscriber();
      
            //first subscribe, until we publish
            //subscribe to a test message
            sub.Subscribe("leapthuan", (channel, message) =>
            {

                //Console.WriteLine((string)message);
                try
                {
                    MultiLeap leaps = (MultiLeap)JsonConvert.DeserializeObject<MultiLeap>(message);
                    leaps.reconstructData();
                    Console.WriteLine(leaps.sensors[0].ip);
                    Console.WriteLine(leaps.sensors[0].positionX);
                    Console.WriteLine(leaps.sensors[0].rotation);
                    Console.WriteLine(leaps.sensors[0].toString);
                    String status = "Sensor detected :";
                    foreach(Frame f in leaps.sensors) {
                        status += "leap " + f.ip + " hands: " + f.hands.Count + "  "+ f.toString + "\n ";
                    }
                    this.label1.Invoke((MethodInvoker)delegate
                    {
                        
                        this.label1.Text = status;
                    }); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sub.Unsubscribe("leapthuan");
        }
        private static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }
    }
}
