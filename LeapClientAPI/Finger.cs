using System.Collections.Generic;

namespace LeapClientAPI
{
    //The information parsed from Finger JSON, the data is recovered from Javascript API
    //The attributes's description can be found here : https://developer-archive.leapmotion.com/documentation/javascript/api/Leap.Finger.html
    public class Finger : Pointable
    {
        public List<Bone> bones { get; set; }
        public bool extended { get; set; }
        public int type { get; set; }
        //this attribute is the value returned from method toString() of finger in Javascript
        public string toString { get; set; }
        public double[] carpPosition { get; set; }
        public double[] dipPosition { get; set; }
        public double[] mcpPosition { get; set; }
        public double[] pipPosition { get; set; }
        public double timeVisible { get; set; }

    }
}