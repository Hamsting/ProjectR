using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR
{
    public class BarLineRenderer : MonoBehaviour
    {
        public int bar = 0;

        private double position = 0.0f;



        private void Start()
        {
            position = BeatManager.Instance.BarBeatToPosition(bar);
        }

        private void Update()
        {
            float yPos = (float)(position - BeatManager.Instance.Position) * BeatManager.Instance.GameSpeed;
            this.transform.localPosition = new Vector3(0.0f, yPos, 0.0f);


            if (BeatManager.GetBarDifference(bar, 0.0f, BeatManager.Instance.Bar, BeatManager.Instance.Beat) <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}