using System;
using UnityEngine;

namespace AmidaCross.Entities
{
    [Serializable]
    public class DotEntity
    {
        public int id = 0;
        public int lane = 0;
        public Vector3 localPosition = default;

        public DotEntity(int id, int lane, Vector3 localPosition)
        {
            this.id = id;
            this.lane = lane;
            this.localPosition = localPosition;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}