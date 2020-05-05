using UnityEngine;

namespace AmidaCross.Entities
{
    [SerializeField]
    public class LineEntity
    {
        public DotEntity dot1;
        public DotEntity dot2;

        public LineEntity(DotEntity dot1, DotEntity dot2)
        {
            this.dot1 = dot1;
            this.dot2 = dot2;
        }

        public bool HasDot(int id)
            => this.dot1.id == id || this.dot2.id == id;

        public bool IsOnLane(int lane)
            => this.dot1.lane == lane || this.dot2.lane == lane;

        public int GetOppositeLane(int lane)
        {
            if (this.dot1.lane != lane) return dot1.lane;
            if (this.dot2.lane != lane) return dot2.lane;
            return -1;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}