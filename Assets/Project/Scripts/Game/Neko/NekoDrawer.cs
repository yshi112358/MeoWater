using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.Neko
{
    [ExecuteInEditMode]
    public class NekoDrawer : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        private Mesh _mesh;
        private List<Vector3> _vertextList = new List<Vector3>();
        private List<Vector2> _uvList = new List<Vector2>();
        private List<int> _indexList = new List<int>();
        private Transform[] _child;

        void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _child = new Transform[transform.childCount];

            _mesh = CreatePlaneMesh();
            _meshFilter.mesh = _mesh;

            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    for (var i = 0; i < _vertextList.Count; i++)
                    {
                        _vertextList[i] = new Vector3(
                            (_child[i].position.x - transform.position.x) / transform.localScale.x,
                            (_child[i].position.y - transform.position.y) / transform.localScale.y,
                            (_child[i].position.z - transform.position.z) / transform.localScale.z);
                    }
                    _mesh.SetVertices(_vertextList);
                })
                .AddTo(this);
        }

        private Mesh CreatePlaneMesh()
        {
            var _mesh = new Mesh();
            _vertextList.Clear();
            _uvList.Clear();
            _indexList.Clear();

            for (int i = 0; i < transform.childCount; i++)
            {
                _child[i] = transform.GetChild(i);
                _vertextList.Add(new Vector3(
                            (_child[i].position.x - transform.position.x) / transform.localScale.x,
                            (_child[i].position.y - transform.position.y) / transform.localScale.y,
                            (_child[i].position.z - transform.position.z) / transform.localScale.z));
                _uvList.Add(_child[i].localPosition + new Vector3(0.5f, 0.5f, 0));
            }

            _indexList.AddRange(new[] { 0, 1, 7, 1, 2, 7, 6, 7, 2, 2, 3, 6, 5, 6, 3, 4, 5, 3 });//0-2-1の頂点で1三角形。 1-2-3の頂点で1三角形。

            _mesh.SetVertices(_vertextList);//meshに頂点群をセット
            _mesh.SetUVs(0, _uvList);//meshにテクスチャのuv座標をセット（今回は割愛)
            _mesh.SetIndices(_indexList.ToArray(), MeshTopology.Triangles, 0);//メッシュにどの頂点の順番で面を作るかセット
            return _mesh;
        }
    }
}