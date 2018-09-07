//------------------------------------------------------
// 作成日：2018.9.7
// 作成者：林 佳叡
// 内容：Logo時間制御
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoController : MonoBehaviour 
{
	private SceneLoader sceneLoader;		//シーンマネージャー
	private Animator logoAnimator;			//Logo　Animator
	
	void Start () 
	{
		sceneLoader = GameManager.Instance.SceneLoader;
		logoAnimator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(logoAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)		//アニメーションが終わったら終了
			sceneLoader.LoadScene(SceneEnum.Title);									//タイトルシーン
	}
}
