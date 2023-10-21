using System;
using UnityEngine;

namespace _Code.Gameloop.Triggers
{
    public class Teleportable : ButtonPresser
    {
        protected bool _enable = true;
        public bool Enable => _enable;
    }
}