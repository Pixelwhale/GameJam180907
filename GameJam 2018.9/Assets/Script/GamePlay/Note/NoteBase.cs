using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBase : MonoBehaviour
{
    private NoteType m_noteType;
    private Vector2 m_position;
    private float m_speed;
    private int m_dmg;

    // Use this for initialization
    void Start()
    {
        m_speed = 100.0f;
    }

    public void Initialize(NoteType type, Vector2 position, int dmg)
    {
        m_noteType = type;
        m_position = position;
        m_dmg = dmg;
    }

    // Update is called once per frame
    void Update()
    {
        OverRange();
    }

    //death animation
    void Dead()
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
