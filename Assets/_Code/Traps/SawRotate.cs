using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    [SerializeField]
    bool isRotate;

    [SerializeField]
    float rotateSpeed;

    void Update()
    {
        if (isRotate)
            transform.Rotate(Vector3.forward, rotateSpeed);
    }
}
