using System.Collections.Generic;
using UniRx;

namespace AmidaCross.Entities
{
    public class GlobalState
    {
        private static GlobalState _instance = null;
        public static GlobalState _ => _instance = _instance ?? new GlobalState();

        public ReactiveProperty<PlayerEntity> player
            = new ReactiveProperty<PlayerEntity>();

        public ReactiveProperty<List<DotEntity>> dots
            = new ReactiveProperty<List<DotEntity>>(new List<DotEntity>());

        public ReactiveProperty<List<LineEntity>> lines
            = new ReactiveProperty<List<LineEntity>>(new List<LineEntity>());
    }
}