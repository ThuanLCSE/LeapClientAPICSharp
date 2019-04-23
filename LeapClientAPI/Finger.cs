using System.Collections.Generic;

namespace LeapClientAPI
{
    public class Finger : Pointable
    {
        public List<Bone> bones { get; set; }
        public bool extended { get; set; }
        public int type { get; set; }
        public string toString { get; set; }
        public double[] carpPosition { get; set; }
        public double[] dipPosition { get; set; }
        public double[] mcpPosition { get; set; }
        public double[] pipPosition { get; set; }
        public double timeVisible { get; set; }

    }
}