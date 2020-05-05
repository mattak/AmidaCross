using System.Collections.Generic;
using UniRx;

namespace AmidaCross.Entities
{
    public class GlobalState
    {
        private static GlobalState _instance = null;
        public static GlobalState _ => _instance = _instance ?? new GlobalState();
        
        public ReactiveProperty<PlayerEntity> player = new ReactiveProperty<PlayerEntity>();
        public List<DotEntity> dots = new List<DotEntity>();
        public List<LineEntity> lines = new List<LineEntity>();

        public void SetUpDots()
        {
            
        }
    }
}