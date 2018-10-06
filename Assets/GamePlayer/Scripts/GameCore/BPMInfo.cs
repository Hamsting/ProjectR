using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR.GamePlayer
{
    [System.Serializable]
    public class BPMInfo
    {
        public float bpm = 60.0f;
        public int bar = 0;
        public float beat = 0.0f;
        public double position = 0.0f;
        public bool stopEffect = false;
    }
}
