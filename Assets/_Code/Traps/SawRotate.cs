using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    [SerializeField] private CircleCollider2D coll2D;

    [SerializeField] bool isRotate;

    [SerializeField] float rotateSpeed;

    [SerializeField] private bool isOn;

    void Update()
    {
        if (isRotate)
        {
            isOn = true;
            transform.Rotate(Vector3.forward, rotateSpeed);
        }
    }

    public void OnSaw()
    {
        isRotate = true;
        coll2D.enabled = true;
    }

    public void OffSaw()
    {
        isRotate = false;
        coll2D.enabled = false;
    }

    public void ChangeSawState()
    {
        if (isOn)
        {
            isOn = false;
            OffSaw();
        }
        else
        {
            isOn = true;
            OnSaw();
        }
    }
}