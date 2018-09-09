﻿//------------------------------------------------------
// 作成日：2018.9.9
// 作成者：林 佳叡
// 内容：Noteが押された時のEffect
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour 
{
	[SerializeField]
	private ParticleSystem[] oneShots;			//一回のエフェクト配列
	private int oneShotIndex = 0;				//使用する添え字
	[SerializeField]
	private ParticleSystem longHit;				//長押しエフェクト

	/// <summary>
	/// 一回のHitエフェクト
	/// </summary>
	public void PlayOneHit()
	{
		oneShots[oneShotIndex].Play(true);		//配列のエフェクトをプレイ
		++oneShotIndex;							//添え字更新
		oneShotIndex %= 2;
	}

	/// <summary>
	/// 長押しのエフェクトを出す
	/// </summary>
	public void PlayLongHit()
	{
		if(longHit.isPlaying)					//プレイ中は戻る
			return;
		longHit.Play(true);						//エフェクトをプレイ
	}

	/// <summary>
	/// 長押しのエフェクトを停止
	/// </summary>
	public void StopLongHit()
	{
		longHit.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}
}
