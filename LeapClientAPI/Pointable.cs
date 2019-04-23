namespace LeapClientAPI
{
    public class Pointable
    {
        public double[] direction { get; set; }
        public double length { get; set; }
        public double[] stabilizedTipPosition { get; set; }
        public double[] tipPosition { get; set; }
        public double[] tipVelocity { get; set; }
        public double touchDistance { get; set; }
        public double width { get; set; }
        public string value { get; set; }
    }
}