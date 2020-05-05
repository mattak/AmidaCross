using AmidaCross.Entities;
using AmidaCross.Physics;
using UniRx;
using UnityEngine;

namespace AmidaCross.UI
{
    public class PlayerRenderer : MonoBehaviour
    {
        public Transform[] BaseLanePoints = default;

        void Start()
        {
            GlobalState._.player
                .DistinctUntilChanged(it => it.lane)
                .Subscribe(this.Render)
                .AddTo(this);
        }

        void Render(PlayerEntity player)
        {
            UnityEngine.Debug.Log($"Render: {player.lane}");
            if (this.BaseLanePoints.Length < 3) return;
            var target = this.BaseLanePoints[player.lane];
            this.GetComponent<MoveByLine>().StartMove(target);
        }
    }
}