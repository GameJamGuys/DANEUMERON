using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class CatHead : MonoBehaviour
{
    public void PlaySound()
    {
        AudioBox.Instance.Play("Type");
    }
}
