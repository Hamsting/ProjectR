using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR
{
    public class BeatManager : Singleton<BeatManager>
    {
        [SerializeField, InspectorReadOnly]
        private int bar = 0;
        [SerializeField, InspectorReadOnly]
        private float beat = 0.0f;
        [SerializeField, InspectorReadOnly]
        private double position = 0.0f;
        [SerializeField, InspectorReadOnly]
        private double positionWithSpeed = 0.0f;
        [SerializeField, InspectorReadOnly]
        private float bpm = 60.0f;
        [SerializeField, InspectorReadOnly]
        private float originalBPM = 60.0f;
        [SerializeField, InspectorReadOnly]
        private float beatPerSecond = 60.0f / 60.0f * GlobalDefines.BeatPerBar;
        [SerializeField, Range(0.5f, 10.0f)]
        private float gameSpeed = 2.0f;
        [SerializeField, InspectorReadOnly]
        private List<BPMInfo> bpmInfos;
        [SerializeField, InspectorReadOnly]
        private int bpmInfoLastIndex = -1;
        [SerializeField, InspectorReadOnly]
        private float barToRailLength = GlobalDefines.RailLength / GlobalDefines.DefaultBarCount * (60.0f / 60.0f) * 2.0f;
        private bool isStopEffect = false;

        public int Bar
        {
            get
            {
                return bar;
            }
        }
        public float Beat
        {
            get
            {
                return beat;
            }
        }
        public double Position
        {
            get
            {
                return position;
            }
        }
        public float CurrentBPM
        {
            get
            {
                return bpm;
            }
            set
            {
                bpm = value;
                OnBPMChanged();
            }
        }
        public float OriginalBPM
        {
            get
            {
                return originalBPM;
            }
        }
        public float GameSpeed
        {
            get
            {
                return gameSpeed;
            }
            set
            {
                gameSpeed = value;
            }
        }



        private void Awake()
        {
            bpmInfos = new List<BPMInfo>();
        }

        private void Start()
        {
            originalBPM = bpm;
        }

        private void Update()
        {
            UpdateBarAndBeat();
            UpdateBPM();
        }

        private void UpdateBarAndBeat()
        {
            float increasedBeat = beatPerSecond * Time.deltaTime;
            beat += increasedBeat;
            position += (increasedBeat / GlobalDefines.BeatPerBar) * barToRailLength;
            positionWithSpeed = position * gameSpeed;

            if (beat >= GlobalDefines.BeatPerBar)
            {
                bar += (int)beat / GlobalDefines.BeatPerBar;
                beat = beat % (float)GlobalDefines.BeatPerBar;
            }
        }

        private void UpdateBPM()
        {
            if (bpmInfos.Count - 1 > bpmInfoLastIndex)
            {
                BPMInfo nextInfo = bpmInfos[bpmInfoLastIndex + 1];
                float barDiff = GetBarDifference(bar, beat, nextInfo.bar, nextInfo.beat);
                if (barDiff >= 0.0f)
                {
                    float bpmDiffRatio = nextInfo.bpm / bpm;
                    float fixedBarDiff = barDiff * bpmDiffRatio;

                    bar = nextInfo.bar;
                    beat = 0.0f;
                    if (nextInfo.beat > 0.0f)
                        ++bar;

                    beat += fixedBarDiff * GlobalDefines.BeatPerBar;
                    if (beat >= GlobalDefines.BeatPerBar)
                    {
                        bar += (int)beat / GlobalDefines.BeatPerBar;
                        beat = beat % (float)GlobalDefines.BeatPerBar;
                    }

                    isStopEffect = nextInfo.stopEffect;
                    CurrentBPM = nextInfo.bpm;
                    position = nextInfo.position + fixedBarDiff * barToRailLength;
                    ++bpmInfoLastIndex;
                    Debug.Log("" + barDiff + ", " + fixedBarDiff);
                }
            }
        }

        private void OnBPMChanged()
        {
            beatPerSecond = bpm / 60.0f * GlobalDefines.BeatPerBar;

            if (isStopEffect)
                barToRailLength = 0.0f;
            else
                barToRailLength = GlobalDefines.RailLength / GlobalDefines.DefaultBarCount * (bpm / 60.0f);

            Debug.LogError("BPM Changed : " + bpm + 
                         ", Position : " + position + 
                         ", Bar/Beat : " + bar + "/" + beat + 
                         ", Stop : " + isStopEffect);
        }

        public void AddNewBPMInfo(int _bar, float _beat, float _bpm, bool _stopEffect = false)
        {
            BPMInfo info = new BPMInfo()
            {
                bar = _bar,
                beat = _beat,
                bpm = _bpm,
                stopEffect = _stopEffect
            };

            BPMInfo lastInfo = null;
            for (int i = 0; i <= bpmInfos.Count; ++i)
            {
                if (i == bpmInfos.Count)
                {
                    bpmInfos.Add(info);
                    break;
                }
                else
                {
                    lastInfo = bpmInfos[i];
                    if (GetBarDifference(_bar, _beat, lastInfo.bar, lastInfo.beat) < 0.0f)
                    {
                        bpmInfos.Insert(i, info);
                        break;
                    }
                }
            }

            if (bpmInfos.Count > 1 && lastInfo != null)
            {
                double pivotPos = lastInfo.position;
                if (lastInfo.stopEffect)
                    info.position = pivotPos;
                else
                {
                    int lastInfoStartBar = (lastInfo.beat == 0.0f) ? lastInfo.bar : lastInfo.bar + 1;
                    float barDiff = GetBarDifference(_bar, _beat, lastInfoStartBar, 0.0f);
                    info.position = pivotPos + (barDiff *
                                (GlobalDefines.RailLength / GlobalDefines.DefaultBarCount * (lastInfo.bpm / 60.0f)));
                }
            }
            else
                info.position = 0.0f;           
        }

        public double BarBeatToPosition(int _bar, float _beat = 0.0f)
        {
            for (int i = bpmInfos.Count - 1; i >= 0; --i)
            {
                BPMInfo info = bpmInfos[i];
                int infoStartBar = (info.beat == 0.0f) ? info.bar : info.bar + 1;
                if (infoStartBar <= _bar)
                {
                    if (info.stopEffect)
                        return info.position;
                    else
                        return info.position + GetBarDifference(_bar, _beat, infoStartBar, 0.0f) * 
                            (GlobalDefines.RailLength / GlobalDefines.DefaultBarCount * (info.bpm / 60.0f));
                }
            }

            return 0.0f;
        }

        public static float GetBarDifference(int _bar1, float _beat1, int _bar2, float _beat2)
        {
            return ((float)_bar1 + _beat1 / GlobalDefines.BeatPerBar) -
                   ((float)_bar2 + _beat2 / GlobalDefines.BeatPerBar);
        }

        public float GetBPMWithBarBeat(int _bar, float _beat = 0.0f)
        {
            for (int i = bpmInfos.Count - 1; i >= 0; --i)
            {
                BPMInfo info = bpmInfos[i];
                int infoStartBar = (info.beat == 0.0f) ? info.bar : info.bar + 1;
                if (infoStartBar <= _bar)
                {
                    return info.bpm; 
                }
            }
            return 60.0f;
        }

        //TEST
        public bool IsPossibleBarBeat(int _bar, float _beat)
        {
            foreach (BPMInfo info in bpmInfos)
            {
                if (info.bar > _bar)
                    return true;
                else if (info.bar != _bar)
                    continue;

                if (info.beat != 0.0f && info.beat <= _beat)
                    return false;
            }
            return true;
        }
    }
}