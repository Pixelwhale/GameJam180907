//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：一発Note
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointAnime : MonoBehaviour 
{
	private Animator checkpointAnime;
	void Awake () 
	{
		checkpointAnime = GetComponent<Animator>();
		checkpointAnime.SetBool("isPlay", false);
	}

	public void PlayAnimation(int bpm)
	{
		checkpointAnime.speed = bpm / 120.0f;
		checkpointAnime.SetBool("isPlay", true);
	}
}
