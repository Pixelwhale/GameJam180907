//------------------------------------------------------
// 作成日：2018.9.7
// 作成者：林 佳叡
// 内容：NoteLoader
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteLoader
{
	/// <summary>
	/// 譜面を読み込む
	/// </summary>
	/// <param name="fileName">ファイル名</param>
	/// <param name="result">読み込んだ文字列</param>
	/// <param name="bpm">BPM</param>
	public static void LoadNotesFile(string fileName, ref List<NoteType> upperNotes, ref List<NoteType> lowerNotes, ref int bpm)
	{
		TextAsset textAsset = Resources.Load<TextAsset>("csv/" + fileName);
		if(textAsset == null)							//ファイルなし
			return;

		StreamReader sr = new StreamReader(new MemoryStream(textAsset.bytes));
		List<string> result = new List<string>();

		string bpmString = sr.ReadLine();				//First line
		bpm = int.Parse(bpmString.Split(',')[1]);		//BPM取得

		while(!sr.EndOfStream)
		{
			string line = sr.ReadLine();				//読み込む
			result.Add(line);							//List追加
		}
		sr.Close();

		TranslateNotes(result[0], ref upperNotes);		//notes translate
		TranslateNotes(result[1], ref lowerNotes);
	}

	private static void TranslateNotes(string noteString, ref List<NoteType> notes)
	{
		string[] noteStrings = noteString.Split(',');	//分解
		for(int i = 1; i < noteStrings.Length; ++i)
		{
			if(noteStrings[i] == "")					//Notesなし
			{
				notes.Add(NoteType.Null);
				continue;
			}

			int note = int.Parse(noteStrings[i]);
			notes.Add((NoteType)note);					//List追加
		}
	}
}
