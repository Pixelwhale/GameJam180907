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
			MissProcess();				//ミスとしてカウント
			return;
		}

		//Todo: 押された長さを計算
		DelayHead();					//ヘッド固定
		CheckTimeUp(checkLineX);		//クリアかを確認
	}

	private void DelayHead()
	{
		headTransform.position = pushPos;
	}

	private void CheckTimeUp(float checkLineX)
	{
		if(endTransform.position.x < checkLineX)	//お尻が来た場合
		{
			isEnd = true;				//終了
			isClear = true;				//クリア
		}
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
		//Todo: 押された時間を渡す
		return new LongNoteEndState(isClear);
	}
}
