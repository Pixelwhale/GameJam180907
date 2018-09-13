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
		string path = "Application.persistentDataPath/config.txt";
#if UNITY_EDITOR
		path = "Assets/resources/config.txt";
#endif

		StreamReader sr = new StreamReader(path);
		adjustPos = int.Parse(sr.ReadLine());

		sr.Close();
	}

	public int AdjustPos { get { return adjustPos; } }

	public void SaveConfig(int adjustPos)
	{
		this.adjustPos = adjustPos;
		string path = "Application.persistentDataPath/config.txt";
#if UNITY_EDITOR
		path = "Assets/resources/config.txt";
#endif

        StreamWriter sw = new StreamWriter(path, false);
		sw.WriteLine(adjustPos);
		sw.Close();
	}
}
