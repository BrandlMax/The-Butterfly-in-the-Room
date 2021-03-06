﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_CameraController : MonoBehaviour
{
    [Range(0.01f, 1f)]
    public float speed;

    [Header("Camera Positions")]
    public Transform pos_roomClose;
    public Transform pos_roomFar;
    public Transform pos_table;
    public Transform pos_close;
    public Transform pos_left;
    public Transform pos_right;

    Transform currentTarget;
    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if(Vector3.Distance(transform.position, currentTarget.position) > 0.1f || Quaternion.Angle(transform.rotation, currentTarget.rotation) > 0.1f )
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, currentTarget.rotation, speed * 10);
            } else
            {
                moving = false;
            }
        }        
    }

    public void setPosition(int i)
    {
        switch (i)
        {
            case 1:
                currentTarget = pos_roomClose;
                break;
            case 2:
                currentTarget = pos_roomFar;
                break;
            case 3:
                currentTarget = pos_table;
                break;
            case 4:
                currentTarget = pos_close;
                break;
            case 5:
                currentTarget = pos_left;
                break;
            case 6:
                currentTarget = pos_right;
                break;
        }
        moving = true;
    }
}
