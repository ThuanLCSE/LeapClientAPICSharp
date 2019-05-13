using System;
using System.Collections.Generic;

namespace LeapClientAPI
{
    public class Hand
    { 
        public double[] palmPosition { get; set; }
        public double confidence { get; set; }
        public double grabStrength { get; set; }
        public double[] direction { get; set; }
        public double[] palmNormal { get; set; }
        public double[] palmVelocity { get; set; }
        public double palmWidth { get; set; }
        public float pinchStrength { get; set; }
        public double[] sphereCenter { get; set; }
        public double sphereRadius { get; set; }
        public double timeVisible { get; set; }
        public double[] stabilizedPalmPosition { get; set; }
        public string type { get; set; }
        public Bone arm { get; set; }
        public List<Finger> fingers { get; set; }
        public List<Pointable> pointables { get; set; }
        public long id { get; set; }
        public double roll { get; set; }
        public double pitch { get; set; }
        public double yaw { get; set; }

        public void reconstructPoints()
        { 
            this.pointables = new List<Pointable>();
            foreach (Finger finger in fingers)
            {
                Pointable point = new Pointable(finger.direction,
                        finger.length,
                        finger.stabilizedTipPosition,
                        finger.tipPosition,
                        finger.tipVelocity,
                        finger.touchDistance,
                        finger.width,
                        finger.value);
                this.pointables.Add(point);
            }
        }
    }

    
}