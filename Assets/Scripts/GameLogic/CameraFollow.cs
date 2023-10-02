using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _ObjectToFollow;

    void Update()
    {
        if (_ObjectToFollow != null)
            transform.position = _ObjectToFollow.position + new Vector3(0, 0, -10);
    }
}
