//2018.09.11 金　淳元　
//プレイヤーのHP管理クラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPController : MonoBehaviour {
    [Header("プレイヤーのMaxHP")]
    private int Maxhp;
    [Header("プレイヤーのCurrentHP")]
    private int Currenthp;
    [Header("死亡フラグ")]
    private bool isDead;
    [Header("HPバーのパーセンテージ")]
    private float percent_hp;

	// Use this for initialization
	void Start () {
        Maxhp = 999;
        Currenthp = Maxhp;
        percent_hp = 1.0f;
        isDead = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //hp -= other.GetComponent<NoteBase>().dmg;
        --Currenthp;
        HpPercentUpdate();
        DeadUpdate();
    }

    private void DeadUpdate()
    {
        if (Currenthp <= 0 ) isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }

    private void HpPercentUpdate()
    {
        percent_hp = (float)Currenthp / (int)Maxhp;
    }

}
