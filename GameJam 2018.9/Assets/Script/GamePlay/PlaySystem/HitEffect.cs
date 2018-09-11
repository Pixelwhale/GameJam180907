//------------------------------------------------------
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
	private ParticleSystem oneShots;			//一回のエフェクト配列
	[SerializeField]
	private ParticleSystem longHit;				//長押しエフェクト
	[SerializeField]
	private ParticleSystem perfect;				//Score Perfect
	[SerializeField]
	private ParticleSystem great;				//Score Great


	/// <summary>
	/// 一回のHitエフェクト
	/// </summary>
	public void PlayOneHit()
	{
		oneShots.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		oneShots.Play(true);
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

	public void PlayPerfect()
	{
		perfect.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		perfect.Play();
	}

	public void PlayGreat()
	{
		great.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		great.Play();
	}
}
