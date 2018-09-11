using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMgr : MonoBehaviour
{
    public float speed = 10.0f;
    private List<NoteType> m_upperNotes, m_lowerNotes;
    public GameObject tapNotePrefab;
    public GameObject longNotePrefab;
    private int m_bpm;
    public bool m_startFlag;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        m_upperNotes = new List<NoteType>();
        m_lowerNotes = new List<NoteType>();
        NoteLoader.LoadNotesFile("BlackestLuxuryCar", ref m_upperNotes, ref m_lowerNotes, ref m_bpm);

        AddNote(m_upperNotes, 3.0f);
        AddNote(m_lowerNotes, -3.0f);
    }


    // Use this for initialization
    void Start()
    {
        m_startFlag = false;
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_startFlag) transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
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
                    break;
                case NoteType.Long_Down:
                    longNoteHead = time;
                    break;
                case NoteType.Long_Up:
                    AddLongNote(new Vector2(15 * speed / m_bpm * longNoteHead, y), new Vector2(15 * speed / m_bpm * time, y));
                    break;
            }
        }
    }

    private void AddTapNote(Vector2 position)
    {
        GameObject note = Instantiate(tapNotePrefab, this.transform);
        note.transform.localPosition = position;
    }

    private void AddLongNote(Vector2 head, Vector2 end)
    {
        GameObject note = Instantiate(longNotePrefab, this.transform);
        note.transform.localPosition = head;
        note.GetComponent<LongNoteShape>().InitLength(end);
    }

    public void GameStart()
    {
        m_startFlag = true;
        GetComponent<AudioSource>().Play();
    }
}
