//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：LongNote まだ押されていない状態
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpushState : ILongNoteState
{
	private bool isEnd = false;
	private Vector3 pushPos;
	private Transform headTransform;
	private Transform bodyTransform;
	private Transform endTransform;

    //追加部分　===============
    //2018.09.11 金　淳元　Perfect,Great　判定
    private Enum_score score = Enum_score.Null;
    //追加部分　===============

    public UnpushState(Transform headTransform, Transform bodyTransform, Transform endTransform)
	{
		this.headTransform = headTransform;
		this.bodyTransform = bodyTransform;
		this.endTransform = endTransform;
		pushPos = Vector3.zero;
		isEnd = false;
	}

	public void CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect)
	{
		if(!isTrigger)						//Trigger以外はカウントしない
			return;

		isEnd = true;						//終了
		pushPos = headTransform.position;	//押された点を記録

        //追加部分　===============
        //2018.09.11 金　淳元　Perfect,Great　判定
        float distance = Mathf.Abs(pushPos.x - checkLineX);
        DistanceCheck(distance);
        //追加部分　===============
		PlayEffect(effect);
    }

	private void PlayEffect(HitEffect effect)
	{
		effect.PlayLongHit();				//プレイパーティクル
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
		//Todo: 全体半透明にする
	}

	public bool IsEnd()
	{
		return isEnd;
	}

	public bool IsDead()
	{
		return false;
	}

	public Enum_score Score()
	{
		return score;
	}

	public ILongNoteState NextState()
	{
		return new PushState(headTransform, bodyTransform, endTransform, pushPos);
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
