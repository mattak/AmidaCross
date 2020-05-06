using AmidaCross.Entities;
using AmidaCross.Reducers;
using UnityEngine;

namespace AmidaCross.UI
{
    public class DotObject : MonoBehaviour
    {
        public int lane = default;
        public int id = default;
        public DotEntity Entity => _entity;
        
        private DotEntity _entity = default;

        private void Awake()
        {
            this._entity = GlobalReducers.dots.Add(lane, this.transform.localPosition);
            this.id = this.Entity.id;
        }
        
        private void OnDestroy()
        {
            GlobalReducers.dots.Remove(this._entity.id);
            GlobalReducers.line.Remove(this._entity.id);
        }
    }
}