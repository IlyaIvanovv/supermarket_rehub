using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telejka : MonoBehaviour
{
    Quaternion StartRot;
    Vector3 StartPos, NewPos;
    // Start is called before the first frame update
    void Start()
    {
        StartRot = transform.rotation;
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        NewPos = transform.position;
        NewPos.y = StartPos.y;
        NewPos.x = StartPos.x;
        transform.position = NewPos;

        transform.rotation = StartRot;
    }
}
