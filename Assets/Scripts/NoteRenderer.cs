using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR
{
    public class NoteRenderer : MonoBehaviour
    {
        public int bar = 0;
        public float beat = 0.0f;

        private float position = 0.0f;



        private void Start()
        {
            position = BeatManager.Instance.BarBeatToPosition(bar, beat);
        }

        private void Update()
        {
            float yPos = (position - BeatManager.Instance.Position) * BeatManager.Instance.GameSpeed;
            this.transform.localPosition = new Vector3(0.0f, yPos, 0.0f);
        }
    }
}