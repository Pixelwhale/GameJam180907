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
	private SoundManager soundManager;
	private GamePlayInfo playInfo;
	private DifficultyEnum difficulty;
	private Fader sceneFader;			//Scene Fader

	void Start()
	{
		sceneFader = GameManager.Instance.SceneFader;
		soundManager = GameManager.Instance.SoundManager;
		playInfo = GameManager.Instance.GamePlayInfo;
		sceneFader.FadeIn();			//Fade In
		difficulty = DifficultyEnum.Normal;
	}

	/// <summary>
	/// GamePlayへ
	/// </summary>
	public void GamePlay()
	{
		soundManager.SetGamePlayMusic(musicManager.SelectedMusic);		//音楽設定
		playInfo.GamePlayName = musicManager.SelectedMusic.name + "_" + difficulty.ToString();
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
