//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：LongNote Score計算状態
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteEndState : ILongNoteState
{
	private bool isClear = false;			//全部の長さが押されている場合
	private bool giveScore = false;			//スコアを渡したか

	public LongNoteEndState(bool isClear)
	{
		this.isClear = isClear;
		giveScore = false;
	}

	public void CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect)
	{
		effect.StopLongHit();
	}

	public void MissProcess()
	{
		return;
	}

	public bool IsEnd()
	{
		return false;
	}

	public bool IsDead()
	{
		return isClear;
	}

	public Enum_score Score()
	{
		if(!giveScore && isClear)
		{
			giveScore = true;
			//Todo:Scoreを計算
			return Enum_score.Perfect;
		}
		
		return Enum_score.Null;
	}

	public ILongNoteState NextState()
	{
		return new LongNoteEndState(isClear);
	}
}
