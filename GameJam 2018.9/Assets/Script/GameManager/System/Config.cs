//------------------------------------------------------
// 作成日：2018.9.13
// 作成者：林 佳叡
// 内容：Config
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Config : MonoBehaviour {

	private float adjustPos;
	void Start () 
	{
		LoadConfig();
	}

	private void LoadConfig()
	{
		TextAsset textAsset = Resources.Load<TextAsset>("config");
		if(textAsset == null)							//ファイルなし
			return;

		StreamReader sr = new StreamReader(new MemoryStream(textAsset.bytes));
		adjustPos = float.Parse(sr.ReadLine());

		sr.Close();
	}

	public float AdjustPos { get { return adjustPos; } }

	public void SaveConfig(float adjustPos)
	{
		this.adjustPos = adjustPos;
		TextAsset textAsset = Resources.Load<TextAsset>("config");
		if(textAsset == null)							//ファイルなし
			return;
		
		StreamWriter sw = new StreamWriter(new MemoryStream(textAsset.bytes));
		sw.WriteLine(adjustPos);
		
	}
}
