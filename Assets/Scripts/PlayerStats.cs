using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class PlayerStats : MonoBehaviour
    {
        [Range(0.1f, 100f)]
        public float ForwardSpeed = 1f;
        [Min(0.1f)]
        public float ForceJump = 100f;
        [Min(0.1f)]
        public float SideSpeed = 1f;

    }
}