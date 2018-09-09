//------------------------------------------------------
// 作成日：2018.9.8
// 作成者：林 佳叡
// 内容：Noteのインターフェース
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;

public interface INote
{
	int CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect);
	bool IsDead();
}
