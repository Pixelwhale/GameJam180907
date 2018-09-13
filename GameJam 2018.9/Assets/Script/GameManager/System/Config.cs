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

	private int adjustPos;
	void Awake () 
	{
		LoadConfig();
	}

	private void LoadConfig()
	{
		/*string path = "Application.persistentDataPath/config.txt";

		StreamReader sr = new StreamReader(path);
		adjustPos = int.Parse(sr.ReadLine());

		sr.Close();*/
		TextAsset textAsset = Resources.Load<TextAsset>("config");
		if(textAsset == null)							//ファイルなし
			return;

		StreamReader sr = new StreamReader(new MemoryStream(textAsset.bytes));

		adjustPos = int.Parse(sr.ReadLine());				//First line
		sr.Close();
	}

	public int AdjustPos { get { return adjustPos; } }

	public void SaveConfig(int adjustPos)
	{
		this.adjustPos = adjustPos;
		/*string path = "Application.persistentDataPath/config.txt";

        StreamWriter sw = new StreamWriter(path, false);
		sw.WriteLine(adjustPos);
		sw.Close();*/
		File.WriteAllText(Application.persistentDataPath + "/config.csv", adjustPos.ToString());
		/*
		TextAsset textAsset = Resources.Load<TextAsset>("config");
		if(textAsset == null)							//ファイルなし
			return;

		StreamWriter sw = new StreamWriter(new MemoryStream(textAsset.bytes));
		sw.WriteLine(adjustPos);
		sw.Close();
		*/
	}
}
