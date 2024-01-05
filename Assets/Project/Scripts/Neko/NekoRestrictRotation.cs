using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoRestrictRotation : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _initRotationZ;
    // Start is called before the first frame update
    void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        _initRotationZ=_rb.rotation;
        // Debug.Log(_rb.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Math.Abs(_rb.rotation-_initRotationZ)>0.1f)
        //     _rb.rotation=_initRotationZ;
        // Debug.Log(transform.parent.GetComponent<Rigidbody2D>().rotation);
    }
}
