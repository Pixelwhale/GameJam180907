//------------------------------------------------------
// 作成日：2018.9.11
// 作成者：林 佳叡
// 内容：選択画面の音楽オブジェクト
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectObject : MonoBehaviour 
{
	[SerializeField]
	private AudioClip music;

	public AudioClip Clip { get {return music; } }
}
