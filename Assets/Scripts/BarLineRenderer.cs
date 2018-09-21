using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR
{
    public class BarLineRenderer : MonoBehaviour
    {
        public int bar = 0;

        private float position = 0.0f;



        private void Start()
        {
            position = BeatManager.Instance.BarBeatToPosition(bar);
        }

        private void Update()
        {
            float yPos = (position - BeatManager.Instance.Position) * BeatManager.Instance.GameSpeed;
            this.transform.localPosition = new Vector3(0.0f, yPos, 0.0f);
        }
    }
}