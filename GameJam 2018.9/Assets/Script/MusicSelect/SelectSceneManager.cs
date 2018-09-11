//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：MusicSelect　SceneManager
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneManager : MonoBehaviour 
{
	[SerializeField]
	private MusicSelectManager musicManager;
	private Fader sceneFader;			//Scene Fader

	void Start()
	{
		sceneFader = GameManager.Instance.SceneFader;
		sceneFader.FadeIn();			//Fade In
	}

	/// <summary>
	/// GamePlayへ
	/// </summary>
	public void GamePlay()
	{
		GameManager.Instance.SoundManager.SetGamePlayMusic(musicManager.SelectedMusic);		//音楽設定
		sceneFader.FadeOut();			//Fade　Out
		StartCoroutine(LoadScene(SceneEnum.GamePlay));
	}

	/// <summary>
	/// TitleSceneに戻る
	/// </summary>
	public void BackToTitle()
	{
		sceneFader.FadeOut();			//Fade　Out
		StartCoroutine(LoadScene(SceneEnum.Title));
	}

	private IEnumerator LoadScene(SceneEnum scene)
	{
		while(!sceneFader.IsEnd())		//Fade終了しなければ
		{
			yield return null;			//待つ
		}
		GameManager.Instance.SceneLoader.LoadScene(scene);
	}
}
