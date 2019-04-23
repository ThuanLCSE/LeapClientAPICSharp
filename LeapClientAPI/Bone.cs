namespace LeapClientAPI
{
    public class Bone
    {
        private double[][] basis { get; set; }
        private double[] center { get; set; }
        private double[] matrix { get; set; }
        private double[] nextJoint { get; set; }
        private double[] prevJoint { get; set; }
        private double[] direction { get; set; }
        private string type { get; set; }
        private double width { get; set; }
        private double length { get; set; }
    }
}