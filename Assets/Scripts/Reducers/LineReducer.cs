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
            this._state.lines.Add(entity);
            return entity;
        }

        public void Remove(int dotId)
        {
            var lines = this._state.lines.Where(it => it.dot1.id != dotId && it.dot2.id != dotId).ToList();
            this._state.lines = lines;
        }
    }
}