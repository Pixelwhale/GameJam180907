//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：選択された音楽
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectManager : MonoBehaviour 
{
	private int selectIndex = 0;

	public AudioClip SelectedMusic
	{
		get { return transform.GetChild(selectIndex).GetComponent<MusicSelectObject>().Clip; }
	}
}
