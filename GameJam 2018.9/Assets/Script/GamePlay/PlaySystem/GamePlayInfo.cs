//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：初期情報
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayInfo : MonoBehaviour 
{
	private string fileName;

	/// <summary>
	/// GamePlayの名前（譜面ファイル名）
	/// </summary>
	/// <value></value>
	public string GamePlayName
	{
		get { return fileName; }
		set { fileName = value; }
	}
}
