//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：一発Note
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNote : MonoBehaviour, INote
{
	private bool isDead = false;

    //追加部分　===============
    //2018.09.11 金　淳元　Perfect,Great　判定
    private float distance_perfect = 0.2f; //後に調整
    //追加部分　===============


    public int CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect)
	{
		if(!isTrigger || isDead)
			return 0;

        //Todo: Perfect, great, good?

        //追加部分　===============
        //2018.09.11 金　淳元　Perfect,Great　判定
        float distance = Mathf.Abs(transform.position.x - checkLineX);
        DistanceCheck(distance);
        //追加部分　===============

        isDead = true;
		effect.PlayOneHit();
		Destroy(gameObject, 0.1f);
		return 0;
	}

	public void MissProcess()
	{
		return;
	}

	public bool IsDead()
	{
		return isDead;
	}

    //追加部分　===============
    //perfect great 判定
    private void DistanceCheck(float distance)
    {
        if (distance < distance_perfect)
        {
            //Todo：Perfectのエフェクト
            Debug.Log("Perfect");
            return;
        }
        //Todo：Greatのエフェクト
        Debug.Log("Great");
    }//追加部分　===============


    }
