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
	private Fader sceneFader;			//Scene Fader
	[SerializeField]
	private TitleMenuAnime menuPanel;	//Menu Anime
	private bool isMenuIn;				//Menu In?

	void Start () 
	{
		sceneFader = GameManager.Instance.SceneFader;
		sceneFader.FadeIn();			//Fade In
		isMenuIn = false;
	}

	void Update()
	{
		if(!isMenuIn)					//State Menu Out
		{
			CheckTap();					//Tapされたか
		}
	}

	/// <summary>
	/// Tapされたかをチェック
	/// </summary>
	private void CheckTap()
	{
#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0))
		{
			isMenuIn = true;
			menuPanel.MenuIn();			//Menu　Animate
		}
#endif

		if(Input.touchCount <= 0)		//例外処理
			return;
		if(Input.GetTouch(0).phase == TouchPhase.Began)		//Tapされた
		{
			isMenuIn = true;
			menuPanel.MenuIn();			//Menu　Animate
		}
	}

	/// <summary>
	/// Title画面に戻る
	/// </summary>
	public void BackToTitle()
	{
		isMenuIn = false;
		menuPanel.MenuOut();			//Menu　Animate
	}

	/// <summary>
	/// MusicSelect画面へ
	/// </summary>
	public void MusicSelect()
	{
		sceneFader.FadeOut();			//Fade　Out
		StartCoroutine(LoadScene(SceneEnum.Music_Select));
	}

	public void GamePay()
	{
		sceneFader.FadeOut();			//Fade　Out
		GameManager.Instance.SoundManager.StopBGM();
		StartCoroutine(LoadScene(SceneEnum.GamePlay));
	}

	public void Option()
	{
		sceneFader.FadeOut();			//Fade　Out
		StartCoroutine(LoadScene(SceneEnum.Option));
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
