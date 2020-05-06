using AmidaCross.Entities;
using UnityEngine;

namespace AmidaCross.Reducers
{
    public class DotsReducer
    {
        private readonly GlobalState _state;

        public DotsReducer(GlobalState state)
        {
            this._state = state;
        }

        public DotEntity Add(int lane, Vector3 localPosition)
        {
            var id = this._state.dots.Value.Count + 1;
            var entity = new DotEntity(id, lane, localPosition);
            var list = this._state.dots.Value;
            list.Add(entity);
            this._state.dots.SetValueAndForceNotify(list);
            return entity;
        }

        public void Remove(int id)
        {
            var list = this._state.dots.Value;
            var index = list.FindIndex(0, it => it.id == id);
            if (index < 0) return;
            list.RemoveAt(index);
            this._state.dots.SetValueAndForceNotify(list);
        }

        public void Enter(DotEntity dot)
        {
            var list = this._state.lines.Value;

            // find line
            var player = this._state.player.Value;
            var line = list.Find(it => it.HasDot(dot.id));
            if (line == null) return;
            if (!line.IsOnLane(player.lane)) return;

            // update player lane
            player.lane = line.GetOppositeLane(player.lane);
            this._state.player.Value = player;
        }
    }
}
