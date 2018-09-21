using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR
{
    public class GameTest : MonoBehaviour
    {
        public GameObject barLinePrefab;
        public Transform rail;


        private void Start()
        {
            /*
            BeatManager.Instance.AddNewBPMInfo( 0,  0.0f,  100.0f);
            BeatManager.Instance.AddNewBPMInfo( 0, 24.0f,  200.0f);
            BeatManager.Instance.AddNewBPMInfo( 2, 48.0f,  400.0f);
            BeatManager.Instance.AddNewBPMInfo( 3, 72.0f,  800.0f);
            BeatManager.Instance.AddNewBPMInfo( 4, 24.0f, 1600.0f);
            BeatManager.Instance.AddNewBPMInfo( 5, 48.0f, 3200.0f);
            BeatManager.Instance.AddNewBPMInfo( 6, 72.0f, 1600.0f);
            BeatManager.Instance.AddNewBPMInfo( 7, 24.0f,  800.0f);
            BeatManager.Instance.AddNewBPMInfo( 8, 48.0f,  400.0f);
            BeatManager.Instance.AddNewBPMInfo( 9, 72.0f,  200.0f);
            BeatManager.Instance.AddNewBPMInfo(10, 24.0f,  100.0f);
            */

            BeatManager.Instance.AddNewBPMInfo(0, 0.0f, 100.0f);
            BeatManager.Instance.AddNewBPMInfo(0, 0.0f, 200.0f);
            BeatManager.Instance.AddNewBPMInfo(2, 0.0f, 400.0f);
            BeatManager.Instance.AddNewBPMInfo(3, 0.0f, 800.0f);
            BeatManager.Instance.AddNewBPMInfo(4, 0.0f, 1600.0f);
            BeatManager.Instance.AddNewBPMInfo(5, 0.0f, 3200.0f);
            BeatManager.Instance.AddNewBPMInfo(6, 0.0f, 1600.0f);
            BeatManager.Instance.AddNewBPMInfo(7, 0.0f, 800.0f);
            BeatManager.Instance.AddNewBPMInfo(8, 0.0f, 400.0f);
            BeatManager.Instance.AddNewBPMInfo(9, 0.0f, 200.0f);
            BeatManager.Instance.AddNewBPMInfo(10,0.0f, 100.0f);

            for (int i = 0; i < 36; ++i)
            {
                GameObject barLine = GameObject.Instantiate<GameObject>(barLinePrefab, rail);
                barLine.GetComponent<BarLineRenderer>().bar = i;
            }
        }


    }
}