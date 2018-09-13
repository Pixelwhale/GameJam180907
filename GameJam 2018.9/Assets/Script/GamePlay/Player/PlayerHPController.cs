//2018.09.11 金　淳元　
//プレイヤーのHP管理クラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPController : MonoBehaviour {
    [Header("プレイヤーのHP")]
    private int hp;
    [Header("死亡フラグ")]
    private bool isDead;

	// Use this for initialization
	void Start () {
        hp = 999;
        isDead = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //hp -= other.GetComponent<NoteBase>().dmg;
        --hp;
        Debug.Log("hp : " + hp);
        DeadUpdate();
    }

    private void DeadUpdate()
    {
        if (hp <= 0 ) isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }

}
