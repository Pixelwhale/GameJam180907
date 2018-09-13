//------------------------------------------------------
// 作成日：2018.9.7
// 作成者：林 佳叡
// 内容：Config Manager
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour 
{
	private Config config;
	private SceneLoader sceneManager;
	private Fader sceneFader;			//Scene Fader
	private float adjustPos;
	

	void Start () 
	{
		sceneManager = GameManager.Instance.SceneLoader;
		sceneFader = GameManager.Instance.SceneFader;
		config = GameManager.Instance.Config;
		sceneFader.FadeIn();			//Fade In
		adjustPos = config.AdjustPos;
	}

	public void PlusAjustPos()
	{
		adjustPos-=0.005f;
	}

	public void MinusAjustPos()
	{
		adjustPos-=0.005f;
	}

	public void BackToTitle()
	{
		config.SaveConfig(adjustPos);
		sceneFader.FadeOut();			//Fade　Out
		StartCoroutine(LoadScene(SceneEnum.Title));
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
