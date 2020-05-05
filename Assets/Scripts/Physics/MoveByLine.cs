using UnityEngine;

namespace AmidaCross.Physics
{
    public class MoveByLine : MonoBehaviour
    {
        public float speed = 1.0f;
        private Transform targetTo = default;

        private bool _isMoving = false;

        public void StartMove(Transform to)
        {
            this.targetTo = to;
            this._isMoving = true;
        }

        private void FixedUpdate()
        {
            if (!_isMoving) return;

            this.Move();
            this.CheckMoveCompleted();
        }

        private void Move()
        {
            var distance = Mathf.Min(1f, speed * Time.deltaTime);
            this.transform.position = Vector3.Lerp(this.transform.position, this.targetTo.position, distance);
        }

        private void CheckMoveCompleted()
        {
            var diff = (this.transform.position - this.targetTo.position).sqrMagnitude;
            if (diff < 0.01f) this._isMoving = false;
        }
    }
}