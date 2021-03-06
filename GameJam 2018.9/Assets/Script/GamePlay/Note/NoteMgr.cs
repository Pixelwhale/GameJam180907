﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMgr : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject tapNotePrefab;
    public GameObject longNotePrefab;
    [SerializeField]
    private NotePool tapPool;

    private List<NoteType> m_upperNotes, m_lowerNotes;
    private int m_bpm;

    private bool m_startFlag;
    [SerializeField]
    private GameObject gamePlayInput;

    private int noteCount;

    private float m_adjustPos;

    [SerializeField]
    private GameObject playSystemMgr;

    private bool m_endFlag;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        m_upperNotes = new List<NoteType>();
        m_lowerNotes = new List<NoteType>();
        NoteLoader.LoadNotesFile("BlackestLuxuryCar", ref m_upperNotes, ref m_lowerNotes, ref m_bpm);
        tapPool.GenerateNotes(transform);

        noteCount = 0;
        AddNote(m_upperNotes, 2.0f);
        AddNote(m_lowerNotes, -2.0f);
    }


    // Use this for initialization
    void Start()
    {
        m_startFlag = false;
        m_endFlag = false;
        m_adjustPos = GameManager.Instance.Config.AdjustPos * 0.05f;
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_startFlag || m_endFlag) return;
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if (GetComponent<AudioSource>().time > 136)
        {
            m_endFlag = true;
            GameOver();
        }
    }

    private void AddNote(List<NoteType> noteList, float y)
    {
        int longNoteHead = 0;
        for (int time = 0; time < noteList.Count; ++time)
        {
            switch (noteList[time])
            {
                case NoteType.Tap:
                    AddTapNote(new Vector2(15 * speed / m_bpm * time, y));
                    ++noteCount;
                    break;
                case NoteType.Long_Down:
                    longNoteHead = time;
                    ++noteCount;
                    break;
                case NoteType.Long_Up:
                    AddLongNote(new Vector2(15 * speed / m_bpm * longNoteHead, y), new Vector2(15 * speed / m_bpm * time, y));
                    ++noteCount;
                    break;
            }
        }
    }

    private void AddTapNote(Vector2 position)
    {
        /*
        GameObject note = Instantiate(tapNotePrefab, this.transform);
        note.transform.localPosition = position;
        */
        //2018.9.13　Pool に変更
        tapPool.InitNotePos(position);
    }

    private void AddLongNote(Vector2 head, Vector2 end)
    {
        GameObject note = Instantiate(longNotePrefab, this.transform);
        note.transform.localPosition = head;
        note.GetComponent<LongNoteShape>().InitLength(end);
    }

    private void GameStart()
    {
        m_startFlag = true;
        transform.position += new Vector3(m_adjustPos, 0, 0);
        GetComponent<AudioSource>().Play();
        gamePlayInput.GetComponent<CheckPointAnime>().PlayAnimation(m_bpm);
    }

    private void GameOver()
    {
        playSystemMgr.GetComponent<GamePlaySystemManager>().Result();
    }

    public int GetNoteCount()
    {
        return noteCount;
    }
}
