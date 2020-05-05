using AmidaCross.Entities;
using AmidaCross.Reducers;
using UnityEngine;

namespace AmidaCross.UI
{
    public class DotObject : MonoBehaviour
    {
        public int lane = default;
        public int id = default; // TODO: remove debug
        public DotEntity Entity => _entity;
        
        private DotEntity _entity = default;

        private void Awake()
        {
            this._entity = GlobalReducers.dots.Add(lane);
            this.id = this.Entity.id;
            UnityEngine.Debug.Log($"Awake: {lane} -> {this.Entity}");
        }
        
        private void OnDestroy()
        {
            GlobalReducers.dots.Remove(this._entity.id);
            GlobalReducers.line.Remove(this._entity.id);
        }
    }
}