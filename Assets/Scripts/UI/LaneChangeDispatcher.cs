using AmidaCross.Reducers;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace AmidaCross.UI
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LaneChangeDispatcher : MonoBehaviour
    {
        private void Start()
        {
            this.GetComponent<Rigidbody2D>()
                .OnTriggerEnter2DAsObservable()
                .Subscribe(this.ChangeLane)
                .AddTo(this);
        }

        private void ChangeLane(Collider2D collider2D)
        {
            UnityEngine.Debug.Log($"ChangeLane: {collider2D.name}");
            var dot = collider2D.GetComponent<DotObject>();
            if (dot == default) return;
            if (dot.Entity == default) return;

            GlobalReducers.dots.Enter(dot.Entity);
        }
    }
}