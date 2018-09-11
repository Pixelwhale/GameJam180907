//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：LongNote
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour, INote 
{
	[SerializeField]
	private Transform headPos;						//頭の部分
	[SerializeField]
	private Transform endPos;						//終了部分
	[SerializeField]
	private Transform body;							//体
	private BoxCollider2D boxCollider;				//判定Box
	private ILongNoteState noteState;				//状態
	private LongNoteShape noteShape;				//形状

	void Start()
	{
		noteState = new UnpushState(headPos, body, endPos);
		boxCollider = GetComponent<BoxCollider2D>();
		noteShape = GetComponent<LongNoteShape>();
	}

	public Enum_score CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect)
	{
		if(noteState.IsEnd()) 						//終了の場合、状態遷移
			noteState = noteState.NextState();

		noteState.CheckInput(checkLineX, isTrigger, isDown, effect);	//入力確認
		UpdateCollider();							//判定Boxずらす
		noteShape.AdjustMaskLength();				//形状を調整

		return noteState.Score();					//スコアを戻す
	}

	public void MissProcess()
	{
		noteState.MissProcess();					//Miss処理
	}

	public bool IsDead()
	{
		if(noteState.IsDead())						//クリアの場合は削除
			Destroy(gameObject, 0.1f);
		return noteState.IsDead();
	}

	/// <summary>
	/// Collider位置調整
	/// </summary>
	private void UpdateCollider()
	{
		Vector2 offset = boxCollider.offset;
		offset.x = headPos.localPosition.x;
		boxCollider.offset = offset;
	}
}
