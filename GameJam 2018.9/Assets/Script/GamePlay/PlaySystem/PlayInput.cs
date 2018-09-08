//------------------------------------------------------
// 作成日：2018.9.8
// 作成者：林 佳叡
// 内容：Input処理
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInput : MonoBehaviour 
{
	private static readonly int maxTouchCount = 5;		//最大タッチ数
	[SerializeField]
	private ValidZone upperZone;						//上の判定区
	[SerializeField]
	private ValidZone lowerZone;						//下の判定区
	[SerializeField, Tooltip("上下を分けるWorld座標のY座標")]
	private float yLine = 0;							//BoarderLine

	void Start () 
	{
	}
	
	void Update () 
	{
		UpdatePreviousTouch();				//前のフレームのInput更新
#if UNITY_EDITOR
		CheckTouch();
		return;
#endif
		
		if(Input.touchCount <= 0)			//現在タッチされてない場合Return
			return;

		CheckTouch();						//このフレームのInput更新
	}
	
	/// <summary>
	/// 前のフレームのInput更新
	/// </summary>
	private void UpdatePreviousTouch()
	{
		upperZone.UpdatePreviousTouch();
		lowerZone.UpdatePreviousTouch();
	}

	/// <summary>
	/// このフレームのInput更新
	/// </summary>
	private void CheckTouch()
	{
#if UNITY_EDITOR
		if(Input.GetMouseButton(0))
		{
			Touched(Input.mousePosition, true);
			return;
		}
		Touched(Input.mousePosition, false);
		return;
#endif

		int touchCount = Mathf.Min(maxTouchCount, Input.touchCount);		//最大タッチ数制限
		for(int i = touchCount - 1; i >= 0; --i)							//Old -> Newの順番
		{
			UpdateCurrentTouch(Input.GetTouch(i));							//更新
		}
	}

	/// <summary>
	/// 判定して更新
	/// </summary>
	/// <param name="touch">このフレームのタッチ</param>
	private void UpdateCurrentTouch(Touch touch)
	{
		if(touch.phase < TouchPhase.Ended)									//Downの場合
		{
			Touched(touch.position, true);
			return;
		}
		Touched(touch.position, false);										//Up
	}

	/// <summary>
	/// 座標変換
	/// </summary>
	/// <param name="pos">スクリーム座標</param>
	/// <param name="isTouch">DownかUpか</param>
	private void Touched(Vector2 pos, bool isTouch)
	{
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);				//座標変換
		if(worldPos.y > yLine)												//上半分か
		{
			upperZone.UpdateCurrentTouch(isTouch);							//上半分更新
			return;
		}

		lowerZone.UpdateCurrentTouch(isTouch);								//下半分更新
	}
}
