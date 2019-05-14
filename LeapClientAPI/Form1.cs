using System; 
using System.Windows.Forms;
using StackExchange.Redis;
using Newtonsoft.Json; 

namespace LeapClientAPI
{
    public partial class Form1 : Form
    {
        ISubscriber sub;
        //Connection parameters to Redis Pub/Sub in server
        protected const String REDIS_SERVER_IP = "10.29.226.71" ; //"172.22.217.59"
        protected const String REDIS_PORT = "6379";
        //Redis Pub/Sub channel name (defined in NodeJS source code)
        protected const String REDIS_CHANNEL = "leapthuan";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initiate an instance of connection
            //The document of StackExchange Redis : https://stackexchange.github.io/StackExchange.Redis/
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(REDIS_SERVER_IP +":" + REDIS_PORT);
            sub = redis.GetSubscriber();
      
            //subscribe to a channel from REDIS server
            sub.Subscribe(REDIS_CHANNEL, (channel, message) =>
            {
                try
                {
                    //Log the status of message received
                    String status = "Message received from channel " + channel + ":\n";
                    //Parse from message in Json format to MultiLeap.cs Object 
                    MultiLeap leaps = (MultiLeap)JsonConvert.DeserializeObject<MultiLeap>(message);
                    //re-duplicate the pointables and fingers in Frame.cs to ensure each frame has the same structure 
                    //as described here : https://developer-archive.leapmotion.com/documentation/python/devguide/Leap_Tracking.html
                    leaps.reconstructData();

                    foreach (Frame f in leaps.sensors)
                    {
                        //Log each sensor information 
                        status += "Leap IP:" + f.ip + " x:" + f.positionX + " y:" + f.positionY + " rotation:" + f.rotation +
                        " hands: " + f.hands.Count + "\n" + f.toString + "\n ";
                    }
                    //Show log to label1 in Form
                    this.label1.Invoke((MethodInvoker)delegate
                    {
                        this.label1.Text = status;
                    }); 
                }
                //Detail of Exception from StackExchange Redis can be found here : https://stackexchange.github.io/StackExchange.Redis/Events
                //Document of JSON parser can be found here : https://www.newtonsoft.com/json/help/html/ReadingWritingJSON.htm
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //unsubscribe the channel when closing Form to avoid thread blocks the memory
            try
            {
                sub.Unsubscribe(REDIS_CHANNEL);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        
    }
}
