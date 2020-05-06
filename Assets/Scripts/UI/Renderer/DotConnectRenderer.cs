using System.Collections.Generic;
using AmidaCross.Entities;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace AmidaCross.UI
{
    public class DotConnectRenderer : MonoBehaviour
    {
        public LineRenderer baseRenderer = default;
        private List<LineRenderer> _renderers = new List<LineRenderer>();

        private void Awake()
        {
            Assert.IsNotNull(baseRenderer, $"BaseRenderer should not be null on {typeof(DotConnectRenderer).Name}");
        }

        void Start()
        {
            GlobalState._.lines
                .Subscribe(this.Render)
                .AddTo(this);
        }

        private void OnDestroy()
        {
            RemoveAll();
        }

        void Render(List<LineEntity> lines)
        {
            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if (_renderers.Count <= i) _renderers.Add(Create(line));

                this.Draw(
                    _renderers[i],
                    line.dot1.localPosition,
                    line.dot2.localPosition
                );
                
                if (!_renderers[i].gameObject.activeSelf) _renderers[i].gameObject.SetActive(true);
            }

            for (var i = lines.Count; i < _renderers.Count; i++)
            {
                _renderers[i].gameObject.SetActive(false);
            }
        }

        LineRenderer Create(LineEntity entity)
        {
            var _renderer = Instantiate(this.baseRenderer, this.transform, false);
            _renderer.widthMultiplier = 0.05f;
            var d1 = entity.dot1;
            var d2 = entity.dot2;
            _renderer.gameObject.name = $"Line,D{d1.id}:{d2.id},L{d1.lane}:{d2.lane}";
            return _renderer;
        }

        void RemoveAll()
        {
            var t = this.gameObject.transform;
            var children = new Transform[t.childCount];
            for (var i = 0; i < t.childCount; i++) children[i] = t.GetChild(i);
            foreach (var child in children) Destroy(child);
        }

        void Draw(LineRenderer renderer, Vector3 p1, Vector3 p2)
        {
            renderer.widthMultiplier = 0.05f;
            renderer.positionCount = 2;
            renderer.SetPositions(new[] {p1, p2});
        }
    }
}