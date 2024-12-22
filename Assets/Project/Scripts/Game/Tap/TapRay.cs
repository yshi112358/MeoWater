using UnityEngine;
using Game.Neko.Bone;
using System.Collections.Generic;
public class TapRay : MonoBehaviour
{
    [SerializeField] private GameObject _pointObj;
    [SerializeField] private GameObject _rayObj;
    private List<RaycastHit2D> hit2DList = new List<RaycastHit2D>();
    int layerMask;
    void Start()
    {
        layerMask = 1 << 8;
        layerMask = ~layerMask;
        hit2DList.Add(Physics2D.Raycast(gameObject.transform.position, Vector2.down, 30, layerMask));
        hit2DList.Add(Physics2D.Raycast(gameObject.transform.position + new Vector3(0.1f, 0, 0), Vector2.down, 30, layerMask));
        hit2DList.Add(Physics2D.Raycast(gameObject.transform.position + new Vector3(-0.1f, 0, 0), Vector2.down, 30, layerMask));
    }
    void Update()
    {
        hit2DList[0] = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 30, layerMask);
        hit2DList[1] = Physics2D.Raycast(gameObject.transform.position + new Vector3(0.1f, 0, 0), Vector2.down, 30, layerMask);
        hit2DList[2] = Physics2D.Raycast(gameObject.transform.position + new Vector3(-0.1f, 0, 0), Vector2.down, 30, layerMask);

        float min = -100;
        //以下１行追加しました
        foreach (var hit2D in hit2DList)
        {
            if (hit2D.collider != null)
            {
                if (hit2D.collider.gameObject.tag == "Neko" && !hit2D.collider.GetComponent<BoneCupCollision>().isCollision)
                    continue;
                else if (hit2D.collider.gameObject.name == "Left" || hit2D.collider.gameObject.name == "Right")
                    continue;
                else if (min < hit2D.point.y)
                    min = hit2D.point.y;
            }
        }
        float localmin = min - gameObject.transform.position.y + 0.2f;
        _pointObj.transform.localPosition = new Vector2(0, localmin);
        _rayObj.transform.localPosition = new Vector2(0, localmin / 2);
        _rayObj.transform.localScale = new Vector3(_rayObj.transform.localScale.x, localmin, 1);
    }
}
