using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBase : MonoBehaviour
{
    private NoteType m_noteType;
    private Vector2 m_position;
    private int m_bpm;
    private int m_dmg;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OverRange();
    }

    //death animation
    void Death()
    {

    }

    void OverRange()
    {
        if (m_position.x <= -10)
        {
            Destroy(gameObject);
        }
    }


}
