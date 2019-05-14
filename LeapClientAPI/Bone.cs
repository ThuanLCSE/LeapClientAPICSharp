namespace LeapClientAPI
{
    //The information parsed from Bone JSON, the data is recovered from Javascript API
    //The attributes's description can be found here : https://developer-archive.leapmotion.com/documentation/javascript/api/Leap.Bone.html
    public class Bone
    {
        private double[][] basis { get; set; }
        //this attribute is the value returned from method center() of Bone in Javascript
        private double[] center { get; set; }
        //this attribute is the value returned from method matrix() of Bone in Javascript
        private double[] matrix { get; set; }
        private double[] nextJoint { get; set; }
        private double[] prevJoint { get; set; }
        //this attribute is the value returned from method direction() of Bone in Javascript
        private double[] direction { get; set; }
        private string type { get; set; }
        private double width { get; set; }
        private double length { get; set; }
    }
}