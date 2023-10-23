using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CatPaw : MonoBehaviour
{
    //[SerializeField]
    //float minAngle = -50, maxAngle = -20;

    float newAngle;
    bool isUp;

    void Start()
    {
        newAngle = 0;
        isUp = true;
        ToAngle();
    }

     
    void PawWave()
    {
        
    }

    async void ToAngle()
    {
        bool check;
        if (isUp)
            check = transform.rotation.eulerAngles.z < newAngle;
        else
            check = transform.rotation.eulerAngles.z > newAngle;

        while (check)
        {
            transform.Rotate(Vector3.forward, 1);
            await UniTask.Delay(100);
        }

        isUp = !isUp;
          
    }
}
