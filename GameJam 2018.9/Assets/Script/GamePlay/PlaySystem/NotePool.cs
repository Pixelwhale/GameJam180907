//------------------------------------------------------
// 作成日：2018.9.13
// 作成者：林 佳叡
// 内容：NotePool
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePool : MonoBehaviour 
{
	[SerializeField]
	private int noteAmount;
	[SerializeField]
	private GameObject tapNote;
	private List<GameObject> tapNotes = new List<GameObject>();
	private Vector2 hidePos = new Vector2(-100, 0);
	private int tapNoteIndex = 0;

	public void GenerateNotes(Transform noteManager)
	{
		for(int i = 0; i < noteAmount; ++i)
		{
			GameObject tap = Instantiate(tapNote, hidePos, Quaternion.identity, noteManager);
			tapNotes.Add(tap);
		}
	}

	public void InitializeTapNotes(Vector2 pos)
	{
		tapNotes[tapNoteIndex].GetComponent<TapNote>().Initialize(pos);
		++tapNoteIndex;
		if(tapNoteIndex >= tapNotes.Count)
			tapNoteIndex = 0;
	}
}
