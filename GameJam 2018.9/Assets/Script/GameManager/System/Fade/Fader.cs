//------------------------------------------------------
// 作成日：2018.9.7
// 作成者：林 佳叡
// 内容：SceneFader
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour 
{
	private Animator fadeAnimator;

	void Awake () 
	{
		fadeAnimator = GetComponent<Animator>();
		fadeAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
	}

	/// <summary>
	/// Fade In
	/// </summary>
	public void FadeIn()
	{
		fadeAnimator.SetBool("fadeIn", true);
		fadeAnimator.Play("FadeIn", -1, 0);
	}

	/// <summary>
	/// Fade Out
	/// </summary>
	public void FadeOut()
	{
		fadeAnimator.SetBool("fadeOut", true);
		fadeAnimator.Play("FadeOut", -1, 0);
	}

	/// <summary>
	/// Fade終了しているか
	/// </summary>
	/// <returns></returns>
	public bool IsEnd()
	{
		return fadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f;
	}
}
