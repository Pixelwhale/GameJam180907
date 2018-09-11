//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：LongNote形状
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteShape : MonoBehaviour 
{
	private static readonly float basicLength = 4;		//基準の長さ
	[SerializeField]
	private Transform headPos;							//頭の位置
	[SerializeField]
	private Transform endPos;							//終わりの位置
	[SerializeField]
	private GameObject body;							//体
	[SerializeField]
	private SpriteRenderer bodyRenderer;
	[SerializeField]
	private GameObject mask;							//マスク

	/// <summary>
	/// 長さを初期化（頭と終わりの部分を設定した後に初期化）
	/// </summary>
	public void InitLength(Vector3 endPosition)
	{
		endPos.position = endPosition;
		float length = endPos.position.x - headPos.position.x;					//全体の長さ
		float scale = (length / basicLength);									//長さの倍率	
		Vector3 center = (headPos.position + endPos.position) / 2.0f;			//中心部
		Vector3 bodyScale = body.transform.localScale;							//Bodyのスケール
		bodyScale.x *= scale;
		body.transform.position = center;										//位置
		body.transform.localScale = bodyScale;									//長さ
		bodyRenderer.material.SetFloat("_TileX", scale);

		AdjustMaskLength();														//マスク調整
	}

	/// <summary>
	/// マスクの長さを調整
	/// </summary>
	public void AdjustMaskLength()
	{
		float length = endPos.position.x - headPos.position.x;					//全体の長さ
		Vector3 center = (headPos.position + endPos.position) / 2.0f;			//中心部
		Vector3 maskScale = mask.transform.localScale;							//マスクのスケール
		mask.transform.position = center;										//中心設定
		maskScale.x = length;													//長さ計算
		mask.transform.localScale = maskScale;									//マスクの長さを設定
	}
}
