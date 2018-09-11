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
    private Enum_score score;
    //追加部分　===============

    public Enum_score CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect)
	{
		if(!isTrigger || isDead)
			return Enum_score.Null;

        //Todo: Perfect, great, good?

        //追加部分　===============
        //2018.09.11 金　淳元　Perfect,Great　判定
        float distance = Mathf.Abs(transform.position.x - checkLineX);
        DistanceCheck(distance);
        //追加部分　===============

        isDead = true;
		PlayEffect(effect);
		Destroy(gameObject);
		return score;
	}

    private void PlayEffect(HitEffect effect)
    {
        effect.PlayOneHit();
        if(score == Enum_score.Perfect)
        {
            effect.PlayPerfect();
            return;
        }
        if(score == Enum_score.Great)
            effect.PlayGreat();
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
    //2018.09.11 金　淳元
    //perfect great 判定
    private void DistanceCheck(float distance)
    {
        if (distance < Distance_Perfect.distance_perfect)
        {
            //Todo：Perfectのエフェクト
            score = Enum_score.Perfect;
            return;
        }
        //Todo：Greatのエフェクト
        score = Enum_score.Great;
    }//追加部分　===============


}
