namespace LeapClientAPI
{
    public class Pointable
    {
        public Pointable(double[] direction, double length, double[] stabilizedTipPosition, double[] tipPosition, double[] tipVelocity, double touchDistance, double width, string value)
        {
            this.direction = direction;
            this.length = length;
            this.stabilizedTipPosition = stabilizedTipPosition;
            this.tipPosition = tipPosition;
            this.tipVelocity = tipVelocity;
            this.touchDistance = touchDistance;
            this.width = width;
            this.value = value;
        }
        public Pointable() { }

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