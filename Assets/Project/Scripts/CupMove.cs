using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupMove : MonoBehaviour
{
    private float _pitch=0,_yaw=0,_roll=0;
    private float _pitchRate,_yawRate,_rollRate;
    // Start is called before the first frame update
    void Awake()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var _tilt=transform.position.x;
        _tilt+=Input.gyro.rotationRateUnbiased.y/100;
        if(_tilt<-1f)
            _tilt=-1f;
        else if(_tilt>1f)
            _tilt=1f;
        transform.position=new Vector3(_tilt,transform.position.y,0);
    }
}
