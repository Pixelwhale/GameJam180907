//------------------------------------------------------
// 作成日：2018.9.7
// 作成者：林 佳叡
// 内容：Title Manager
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour 
{
	private Fader sceneFader;

	void Start () 
	{
		sceneFader = GameManager.Instance.SceneFader;
		sceneFader.FadeIn();
	}
}
