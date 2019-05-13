using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeapClientAPI
{
    class Frame
    {
        public String ip { get; set; }
        public double positionX { get; set; }
        public double positionY { get; set; }
        public double rotation { get; set; }
        public String dump { get; set; }
        public String toString { get; set; }
        public List<Hand> hands { get; set; }
        public List<Pointable> pointableList { get; set; }
        public List<Finger> fingerList { get; set; }
        public void reconstructPointable()
        {
            pointableList = new List<Pointable>();
            //duplicate Pointable List
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
        public void reconstructFingers()
        {
            fingerList = new List<Finger>();
            if (hands == null) return;
            foreach (Hand hand in hands)
            { 
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
