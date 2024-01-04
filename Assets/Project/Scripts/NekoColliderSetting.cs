using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoColliderSetting : MonoBehaviour
{
    private PolygonCollider2D _collider;
    private Transform[] _child;
    // Start is called before the first frame update
    void Awake()
    {
        _collider=GetComponent<PolygonCollider2D>();
        _child=new Transform[transform.childCount];
        var _path=new List<Vector2>();
        for(int i=0;i<transform.childCount;i++)
        {
            _child[i]=transform.GetChild(i);
            _path.Add(_child[i].localPosition);
        }
        _collider.SetPath(0,_path.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        var _path=new List<Vector2>();
        for(int i=0;i<transform.childCount;i++)
        {
            _path.Add(_child[i].localPosition);
        }
        _collider.SetPath(0,_path.ToArray());
    }
}
