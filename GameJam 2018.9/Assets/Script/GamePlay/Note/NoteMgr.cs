using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMgr : MonoBehaviour
{
    public List<List<NoteType>> noteTable = new List<List<NoteType>>(2);
    public GameObject notePrefab;
    bool m_startFlag;

    // Use this for initialization
    void Start()
    {
        m_startFlag = false;
        for (int row = 0; row < 2; ++row)
        {
            for (int time = 0; time < noteTable[0].Count; ++time)
            {
                //add new note
                //AddNote(new Vector3(time, row, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_startFlag) transform.position -= new Vector3(-1.0f * Time.deltaTime, 0, 0);
    }

    public void AddNote(Vector2 position)
    {
        GameObject note = Instantiate(notePrefab, this.transform);
        note.transform.localPosition = position;
    }

    public void GameStart()
    {
        m_startFlag = true;
    }
}
