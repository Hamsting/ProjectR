using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR
{
    public class NoteRenderer : MonoBehaviour
    {
        public int bar = 0;
        public float beat = 0.0f;
        public int lineNumber = 0;
        public float targetBPM = 60.0f;

        private double position = 0.0f;
        private Vector3 notePos = Vector3.zero;
        private Vector3 noteScale = Vector3.one;
        private Vector3 noteDefaultScale = Vector3.one;



        private void Start()
        {
            position = BeatManager.Instance.BarBeatToPosition(bar, beat);
            noteDefaultScale = this.transform.localScale;
            noteScale = noteDefaultScale;
        }

        private void Update()
        {
            notePos.x = ((float)((lineNumber % 4) * 2 + 1) / 8.0f - 0.5f) * GlobalDefines.RailWidth;
            notePos.y = (float)(position - BeatManager.Instance.Position) * BeatManager.Instance.GameSpeed;
            this.transform.localPosition = notePos;
            
            float correction = noteDefaultScale.y * (targetBPM / 60.0f - 1.0f) * (BeatManager.Instance.GameSpeed - 1.0f) * 0.15f;
            noteScale.y = Mathf.Clamp(noteDefaultScale.y + correction * 0.33f, 0.2f, 10.0f);
            this.transform.localScale = noteScale;

            if (BeatManager.GetBarDifference(bar, beat, BeatManager.Instance.Bar, BeatManager.Instance.Beat) <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}