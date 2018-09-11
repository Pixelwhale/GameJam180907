//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：LongNoteの状態インターフェース
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILongNoteState
{
	void CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect);
	void MissProcess();
	bool IsEnd();
	bool IsDead();
	Enum_score Score();
	ILongNoteState NextState();
}
