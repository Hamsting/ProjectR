using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR
{
    public class GameTest : MonoBehaviour
    {
        public GameObject barLinePrefab;
        public GameObject notePrefab;
        public Transform rail;


        private void Start()
        {
            /*
            BeatManager.Instance.AddNewBPMInfo( 0,  0.0f, 100.0f);
            BeatManager.Instance.AddNewBPMInfo( 1, 48.0f, 200.0f);
            BeatManager.Instance.AddNewBPMInfo( 3, 48.0f, 300.0f);
            BeatManager.Instance.AddNewBPMInfo( 5,  0.0f, 400.0f);
            BeatManager.Instance.AddNewBPMInfo( 7, 72.0f, 500.0f);
            BeatManager.Instance.AddNewBPMInfo(11,  0.0f, 600.0f);
            BeatManager.Instance.AddNewBPMInfo(14, 48.0f, 500.0f);
            BeatManager.Instance.AddNewBPMInfo(18,  0.0f, 400.0f);
            BeatManager.Instance.AddNewBPMInfo(20,  0.0f, 300.0f);
            BeatManager.Instance.AddNewBPMInfo(22,  0.0f, 200.0f);
            BeatManager.Instance.AddNewBPMInfo(23, 24.0f, 100.0f);
            */
            /*
            BeatManager.Instance.AddNewBPMInfo( 0, 0.0f,  30.0f);
            BeatManager.Instance.AddNewBPMInfo( 1, 0.0f, 120.0f);
            BeatManager.Instance.AddNewBPMInfo( 2, 0.0f,  30.0f);
            BeatManager.Instance.AddNewBPMInfo( 3, 0.0f, 120.0f);
            BeatManager.Instance.AddNewBPMInfo( 4, 0.0f,  30.0f);
            BeatManager.Instance.AddNewBPMInfo( 5, 0.0f, 120.0f);
            BeatManager.Instance.AddNewBPMInfo( 6, 0.0f,  30.0f);
            BeatManager.Instance.AddNewBPMInfo( 7, 0.0f, 240.0f);
            BeatManager.Instance.AddNewBPMInfo( 8, 0.0f,  30.0f);
            BeatManager.Instance.AddNewBPMInfo( 9, 0.0f, 240.0f);
            BeatManager.Instance.AddNewBPMInfo(10, 0.0f,  30.0f);
            BeatManager.Instance.AddNewBPMInfo(11, 0.0f, 240.0f);
            BeatManager.Instance.AddNewBPMInfo(12, 0.0f,  30.0f);
            BeatManager.Instance.AddNewBPMInfo(12, 0.0f, 240.0f);
            */
            /*
            BeatManager.Instance.AddNewBPMInfo( 0, 0.0f,  90.0f);
            BeatManager.Instance.AddNewBPMInfo( 4, .0f,  15.0f);
            BeatManager.Instance.AddNewBPMInfo( 6, 0.0f, 140.0f);
            BeatManager.Instance.AddNewBPMInfo( 7, 0.0f, 120.0f);
            BeatManager.Instance.AddNewBPMInfo(16, 0.0f,  90.0f);
            */
            
            BeatManager.Instance.AddNewBPMInfo( 0,  0.0f,  60.0f);
            BeatManager.Instance.AddNewBPMInfo( 1, 48.0f,  90.0f);
            BeatManager.Instance.AddNewBPMInfo( 3, 48.0f, 120.0f);
            BeatManager.Instance.AddNewBPMInfo( 5, 48.0f, 150.0f);
            BeatManager.Instance.AddNewBPMInfo( 7, 48.0f, 180.0f);
            BeatManager.Instance.AddNewBPMInfo( 9, 48.0f, 210.0f);
            BeatManager.Instance.AddNewBPMInfo(11, 48.0f, 240.0f);
            BeatManager.Instance.AddNewBPMInfo(13, 48.0f, 210.0f);
            BeatManager.Instance.AddNewBPMInfo(15, 48.0f, 120.0f);
            BeatManager.Instance.AddNewBPMInfo(17, 48.0f,  60.0f);
            BeatManager.Instance.AddNewBPMInfo(19, 48.0f, 150.0f);
            BeatManager.Instance.AddNewBPMInfo(21, 48.0f,  90.0f);
            BeatManager.Instance.AddNewBPMInfo(23, 48.0f,  60.0f);

            Time.timeScale = 0.5f;
            for (int i = 0; i < 36; ++i)
            {
                GameObject barLine = GameObject.Instantiate<GameObject>(barLinePrefab, rail);
                barLine.GetComponent<BarLineRenderer>().bar = i;
            }

            for (int i = 0; i < 36 * 4; ++i)
            {
                if (!BeatManager.Instance.IsPossibleBarBeat(i / 4, (float)(i % 4) / 4.0f * GlobalDefines.BeatPerBar))
                    continue;

                GameObject note = GameObject.Instantiate<GameObject>(notePrefab, rail);
                NoteRenderer ren = note.GetComponent<NoteRenderer>();
                ren.bar = i / 4;
                ren.beat = (float)(i % 4) / 4.0f * GlobalDefines.BeatPerBar;
                ren.lineNumber = i % 4;
                ren.targetBPM = BeatManager.Instance.GetBPMWithBarBeat(ren.bar, ren.beat);
            }
        }


    }
}