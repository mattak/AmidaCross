using System.Linq;
using AmidaCross.Entities;

namespace AmidaCross.Reducers
{
    public class LineReducer
    {
        private readonly GlobalState _state;

        public LineReducer(GlobalState state)
        {
            this._state = state;
        }

        public LineEntity Add(DotEntity d1, DotEntity d2)
        {
            var entity = new LineEntity(d1, d2);
            var list = this._state.lines.Value;
            list.Add(entity);
            this._state.lines.SetValueAndForceNotify(list);
            return entity;
        }

        public void Remove(int dotId)
        {
            var previousCount = this._state.lines.Value.Count;
            var lines = this._state.lines.Value.Where(it => it.dot1.id != dotId && it.dot2.id != dotId).ToList();
            if (lines.Count == previousCount) return;
            this._state.lines.SetValueAndForceNotify(lines);
        }
    }
}