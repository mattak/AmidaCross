using UnityEngine;

namespace AmidaCross.Physics
{
    public class ConstantMove : MonoBehaviour
    {
        public float speed = 1.0f;

        void FixedUpdate()
        {
            this.transform.localPosition += new Vector3(speed, 0, 0);
        }
    }
}