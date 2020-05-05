using AmidaCross.Reducers;
using UnityEngine;

namespace AmidaCross.UI
{
    public class LineObject : MonoBehaviour
    {
        public DotObject Dot1;
        public DotObject Dot2;

        void Start()
        {
            GlobalReducers.line.Add(Dot1.Entity, Dot2.Entity);
        }

        private void OnDestroy()
        {
            GlobalReducers.line.Remove(Dot1.Entity.id);
            GlobalReducers.line.Remove(Dot2.Entity.id);
        }
    }
}