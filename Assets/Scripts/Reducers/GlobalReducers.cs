using AmidaCross.Entities;

namespace AmidaCross.Reducers
{
    public static class GlobalReducers
    {
        public static readonly DotsReducer dots = new DotsReducer(GlobalState._);
        public static readonly LineReducer line = new LineReducer(GlobalState._);
    }
}