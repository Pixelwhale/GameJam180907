//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：LongNote 押された状態
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushState : ILongNoteState 
{
	private bool isEnd = false;
	private bool isClear = false;
	private Vector3 pushPos;
	private Transform headTransform;
	private Transform bodyTransform;
	private Transform endTransform;

	public PushState(Transform headTransform, Transform bodyTransform, Transform endTransform, Vector3 pushPos)
	{
		this.headTransform = headTransform;
		this.bodyTransform = bodyTransform;
		this.endTransform = endTransform;
		this.pushPos = pushPos;
		isEnd = false;
		isClear = false;
	}

	public void CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect)
	{
		if(!isDown)						//押されてない場合
		{
			isEnd = true;				//終了
			effect.StopLongHit();
			MissProcess();				//ミスとしてカウント
			return;
		}

		DelayHead();					//ヘッド固定
		CheckTimeUp(checkLineX, effect);		//クリアかを確認
	}

	private void DelayHead()
	{
		headTransform.position = pushPos;
	}

	private void CheckTimeUp(float checkLineX, HitEffect effect)
	{
		if(endTransform.position.x <= checkLineX + Distance_Perfect.distance_perfect)	//お尻が来た場合
		{
			isEnd = true;				//終了
			isClear = true;				//クリア
			effect.StopLongHit();
		}
	}

	public void MissProcess()
	{
		headTransform.parent.GetComponent<Animator>().SetBool("isDead", true);
		bodyTransform.GetComponent<Animator>().SetBool("isDead", true);
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
		return Enum_score.Null;
	}

	public ILongNoteState NextState()
	{
		return new LongNoteEndState(isClear);
	}
}
