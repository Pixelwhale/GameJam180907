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
		effect.PlayLongHit();				//プレイパーティクル
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

	public int Score()
	{
		return 0;
	}

	public ILongNoteState NextState()
	{
		return new PushState(headTransform, bodyTransform, endTransform, pushPos);
	}
}
