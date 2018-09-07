/*
2018.09.07 金　淳元
TapのHit判定を管理するクラス
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHitManager : MonoBehaviour {
    [Header("TapとTouchしたところが同じか？")]
    private bool isSameDirection = false;
    [Header("Tapは上にいるか")]
    private bool isUp = false;
    [Header("エネミーリスト")]
    private List<GameObject> enemyList;

	// Use this for initialization
	void Start () {
        if (transform.position.y > 0) isUp = true;
        enemyList = new List<GameObject>();
	}
	

    void OnTriggerEnter2D(Collider2D other)
    {
        enemyList.Add(other.gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!isSameDirection) return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //enemyList[0].GetComponent<NoteBase>().Dead();
            enemyList.RemoveAt(0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        enemyList.RemoveAt(0);
    }

    //TapとTouchが同じDirectionか判断
    private void TouchUpdate()
    {
        if ((Input.GetTouch(0).position.y > 0 && isUp) || 
            (Input.GetTouch(0).position.y < 0 && !isUp))
        {
            isSameDirection = true;
        }
    }

}
