using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoMaker : MonoBehaviour
{
    [SerializeField] private GameObject _neko;
    private float _time=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time+=Time.deltaTime;
        if(_time>3f)
        {
            _time=0;
            MakeNeko();
        }
    }

    void MakeNeko()
    {
        Instantiate(_neko,transform.position,transform.rotation);
    }
}
