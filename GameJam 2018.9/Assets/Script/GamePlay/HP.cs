using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    private int m_hp;

    // Use this for initialization
    void Start()
    {
        m_hp = 200;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Damaged(int damage)
    {
        m_hp -= damage;
		Death();
    }

    private void Death()
    {
        if (m_hp <= 0)
        {
            //gameover
        }
    }
}
