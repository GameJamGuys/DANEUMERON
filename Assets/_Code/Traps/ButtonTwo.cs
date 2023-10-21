using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Code.Traps
{
    public class ButtonTwo : MonoBehaviour
    {
        [SerializeField] private Button firstButton;
        [SerializeField] private Button secondButton;

        private void Start()
        {
            firstButton.IsSecondInteraction = true;
            firstButton.IsTwo = true;
            firstButton.IsLoop = false;

            secondButton.IsSecondInteraction = false;
            secondButton.IsTwo = true;
            secondButton.IsLoop = false;
        }

    }
}