//------------------------------------------------------
// 作成日：2018.9.7
// 作成者：林 佳叡
// 内容：NoteLoader
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteLoader : MonoBehaviour 
{
	public void LoadNotesFile(string fileName, ref List<string> result, ref int bpm)
	{
		FileStream fs = new FileStream("Resources/csv/" + fileName, FileMode.Open, FileAccess.Read);
		StreamReader sr = new StreamReader(fs);

		result = new List<string>();

		string bpmString = sr.ReadLine();				//First line
		bpm = int.Parse(bpmString.Split(',')[1]);		//BPM取得

		while(!sr.EndOfStream)
		{
			string line = sr.ReadLine();				//読み込む
			result.Add(line);							//List追加
		}

		sr.Close();
		fs.Close();
	}
}
