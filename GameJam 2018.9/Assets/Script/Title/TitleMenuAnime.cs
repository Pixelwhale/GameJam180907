//------------------------------------------------------
// 作成日：2018.9.7
// 作成者：林 佳叡
// 内容：Title Menu animation
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenuAnime : MonoBehaviour 
{
	private Animator menuAnimator;
	[SerializeField]
	private Animator tapAnime;

	void Start () 
	{
		menuAnimator = GetComponent<Animator>();
	}

	/// <summary>
	/// Menu Slide In
	/// </summary>
	public void MenuIn()
	{
		menuAnimator.SetBool("menuIn", true);
		tapAnime.SetBool("isMenu", true);
	}

	/// <summary>
	/// Menu Slide Out
	/// </summary>
	public void MenuOut()
	{
		menuAnimator.SetBool("menuOut", true);
		tapAnime.SetBool("isMenu", false);
	}
}
