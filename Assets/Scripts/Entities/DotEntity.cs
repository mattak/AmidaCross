using System;
using UnityEngine;

namespace AmidaCross.Entities
{
    [Serializable]
    public class DotEntity
    {
        public int id = 0;
        public int lane = 0;

        public DotEntity(int id, int lane)
        {
            this.id = id;
            this.lane = lane;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}