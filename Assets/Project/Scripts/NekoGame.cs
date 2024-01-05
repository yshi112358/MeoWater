using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoGame : MonoBehaviour
{
    private Transform _parentMe;
    private NekoCollisionData _collisionData;
    // Start is called before the first frame update
    void Awake()
    {
        _parentMe=transform.parent;
        _collisionData=_parentMe.GetComponent<NekoCollisionData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
        if(collision.gameObject.CompareTag("Neko"))
        {
            var _parentOther=collision.gameObject.transform.parent;
            if(_parentOther.CompareTag(_parentMe.tag))
            {
                _collisionData=_parentMe.GetComponent<NekoCollisionData>();
                _collisionData.AddCollisionData(_parentOther.gameObject);
                Debug.Log(_parentOther.gameObject.name);
                // _collisionData.AddCollisionData();
            }

        }
    }
}
