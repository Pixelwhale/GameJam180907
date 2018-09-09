//------------------------------------------------------
// 作成日：2018.9.8
// 作成者：林 佳叡
// 内容：Note有効範囲判定クラス
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidZone : MonoBehaviour 
{
	private bool currentTouch = false;				//このフレームタッチされたか
	private bool prevousTouch = false;				//前のフレームタッチされたか
	private List<INote> notes;						//範囲内Notes
	private float posX;								//判定中心
	[SerializeField]
	private HitEffect hitEffect;					//Noteが押されたときのEffect

	private void Start()
	{
		notes = new List<INote>();
		posX = transform.position.x;
	}

	/// <summary>
	/// 前のフレームのInput更新
	/// </summary>
	public void UpdatePreviousTouch()
	{
		prevousTouch = currentTouch;
		currentTouch = false;
	}

	/// <summary>
	/// このフレームのInput更新
	/// </summary>
	/// <param name="isDown">タッチされたか</param>
	public void UpdateCurrentTouch(bool isDown)
	{
		currentTouch = isDown;
	}
	
	private bool IsTrigger()
	{
		return currentTouch && !prevousTouch;
	}

	private bool IsDown()
	{
		return currentTouch;
	}

	private void Update()
	{
		if(notes.Count <= 0)											//入ってなければ更新しない
			return;

		int score = notes[0].CheckInput(posX, IsTrigger(), IsDown(), hitEffect);			//インターフェースを通して処理する
		//------------------------------
		// Score 追加の処理
		//------------------------------
		if(notes[0].IsDead())											//死んだ場合
			notes.RemoveAt(0);
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		notes.Add(other.GetComponent<INote>());							//管理リスト追加
		Debug.Log(notes[0]);
    }

	void OnTriggerExit2D(Collider2D other)
    {
        notes.RemoveAt(0);												//管理リストから削除
    }
}
