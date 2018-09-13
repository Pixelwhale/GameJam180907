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
	private List<GameObject> upperTapNotes = new List<GameObject>();
	private List<GameObject> lowerTapNotes = new List<GameObject>();
	private Vector2 hidePos = new Vector2(-100, 0);
	private int upperIndex = 0;
	private int lowerIndex = 0;

	public void GenerateNotes(Transform noteManager)
	{
		for(int i = 0; i < noteAmount; ++i)
		{
			GameObject tap = Instantiate(tapNote, hidePos, Quaternion.identity, noteManager);
			upperTapNotes.Add(tap);
		}
		for(int i = 0; i < noteAmount; ++i)
		{
			GameObject tap = Instantiate(tapNote, hidePos, Quaternion.identity, noteManager);
			lowerTapNotes.Add(tap);
		}
	}

	public void InitNotePos(Vector2 pos)
	{
		if(pos.y > 0)
		{
			InitUpperTapNotes(pos);
			return;
		}
		InitLowerTapNotes(pos);
	}

	private void InitUpperTapNotes(Vector2 pos)
	{
		upperTapNotes[upperIndex].GetComponent<TapNote>().Initialize(pos);
		++upperIndex;
		if(upperIndex >= upperTapNotes.Count)
			upperIndex = 0;
	}

	private void InitLowerTapNotes(Vector2 pos)
	{
		lowerTapNotes[lowerIndex].GetComponent<TapNote>().Initialize(pos);
		++lowerIndex;
		if(lowerIndex >= lowerTapNotes.Count)
			lowerIndex = 0;
	}
}
