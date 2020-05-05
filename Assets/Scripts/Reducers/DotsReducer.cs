using AmidaCross.Entities;

namespace AmidaCross.Reducers
{
    public class DotsReducer
    {
        private readonly GlobalState _state;

        public DotsReducer(GlobalState state)
        {
            this._state = state;
        }

        public DotEntity Add(int lane)
        {
            var id = this._state.dots.Count + 1;
            var entity = new DotEntity(id, lane);
            this._state.dots.Add(entity);
            return entity;
        }
        
        public void Remove(int id)
        {
            var index = this._state.dots.FindIndex(0, it => it.id == id);
            this._state.dots.RemoveAt(index);
        }

        public void Enter(DotEntity dot)
        {
            UnityEngine.Debug.Log($"DotsReducer.Enter: find {dot}");
            // find line
            foreach (var entity in this._state.lines)
            {
                UnityEngine.Debug.Log($"DotsReducer.Enter: ${entity}");
            }
            
            var player = this._state.player.Value;
            var line = this._state.lines.Find(it => it.HasDot(dot.id));
            if (line == null) return;
            if (!line.IsOnLane(player.lane)) return;
            
            UnityEngine.Debug.Log($"DotsReducer.Enter: update {dot}");
            
            // update player lane
            player.lane = line.GetOppositeLane(player.lane);
            this._state.player.Value = player;
        }
    }
}