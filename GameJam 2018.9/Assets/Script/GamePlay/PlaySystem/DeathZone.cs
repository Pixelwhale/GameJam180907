//------------------------------------------------------
// 作成日：2018.9.13
// 作成者：林 佳叡
// 内容：DeathZone
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
    {
		TapNote tap = other.GetComponent<TapNote>();
		if(tap)
		{
			tap.Next();
			return;
		}
		Destroy(other.gameObject);
    }
}
