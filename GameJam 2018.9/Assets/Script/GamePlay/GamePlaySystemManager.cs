﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySystemManager : MonoBehaviour 
{
	private Fader sceneFader;			//Scene Fader
	private ResultManager resultManager;
	[SerializeField]
	private ScoreManager scoreManager;
	
	void Start () 
	{
		sceneFader = GameManager.Instance.SceneFader;
		resultManager = GameManager.Instance.Result;
		sceneFader.FadeIn();			//Fade In
	}

	public void Result()
	{
		sceneFader.FadeOut();			//Fade　Out
		resultManager.SetResult(scoreManager);
		StartCoroutine(LoadScene(SceneEnum.Result));
	}

	/// <summary>
	/// loadScene
	/// </summary>
	/// <param name="scene">Scene名</param>
	/// <returns></returns>
	private IEnumerator LoadScene(SceneEnum scene)
	{
		while(!sceneFader.IsEnd())		//Fade終了しなければ
		{
			yield return null;			//待つ
		}
		GameManager.Instance.SceneLoader.LoadScene(scene);
	}
}
