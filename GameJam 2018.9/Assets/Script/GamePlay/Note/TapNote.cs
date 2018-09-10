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

	public int CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect)
	{
		if(!isTrigger || isDead)
			return 0;

		//Todo: Perfect, great, good?
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
}
