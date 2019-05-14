using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeapClientAPI
{
    //The information parsed from Frame JSON, the data is recovered from Javascript API
    //The detail of Frame object can be found here : https://developer-archive.leapmotion.com/documentation/javascript/api/Leap.Frame.html
    class Frame
    {
        //IP of the VM to which the sensor is connected 
        public String ip { get; set; }
        //The position and rotation of the sensor on the table
        public double positionX { get; set; }
        public double positionY { get; set; }
        public double rotation { get; set; }
        //Detected informmation in long format
        //it is the value returned from method dump() of Frame in Javascript
        public String dump { get; set; }
        //Detected informmation in short format, 
        //it is the value returned from method toString() of Frame in Javascript
        public String toString { get; set; }
        public List<Hand> hands { get; set; }
        public List<Pointable> pointableList { get; set; }
        public List<Finger> fingerList { get; set; }

        //duplicate Pointable List from each hand into this Frame
        public void reconstructPointable()
        {
            pointableList = new List<Pointable>();
            if (hands == null) return;
            foreach (Hand hand in hands)
            {
                if (hand.pointables == null) break;
                foreach (Pointable point in hand.pointables)
                {
                    pointableList.Add(point);
                }
            }
        }
        //duplicate Finger List from each hand into this Frame
        public void reconstructFingers()
        {
            fingerList = new List<Finger>();
            if (hands == null) return;
            foreach (Hand hand in hands)
            {
                //create Pointables in Hand from Fingers                
                hand.reconstructPoints();
                if (hand.fingers == null) break;
                foreach (Finger finger in hand.fingers)
                {
                    fingerList.Add(finger);
                }
            }
        }
        public void reconstructAll()
        {
            reconstructPointable();
            reconstructFingers();
        }
    }
}
