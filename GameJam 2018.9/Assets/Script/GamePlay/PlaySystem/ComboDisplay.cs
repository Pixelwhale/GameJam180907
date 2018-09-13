//------------------------------------------------------
// 作成日：2018.9.11
// 作成者：林 佳叡
// 内容：Comboを表示するUI
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboDisplay : MonoBehaviour 
{
	[SerializeField]
	private Animator comboAnime;
	[SerializeField]
	private Sprite[] numbers;
	[SerializeField]
	private Transform[] numbersBuffer;

	public void AddCombo(int combo)
	{
		comboAnime.SetBool("isCombo", true);
		comboAnime.Play("Combo", -1, 0);
		for(int i = numbersBuffer.Length - 1; combo > 0; --i)
		{
			int count = combo % 10;
			combo /= 10;
			numbersBuffer[i].GetComponent<Image>().sprite = numbers[count];
			numbersBuffer[i].gameObject.SetActive(true);
		}
	}

	public void ResetCombo()
	{
		comboAnime.SetBool("isCombo", false);
		for(int i = 0; i < numbersBuffer.Length; ++i)
		{
			numbersBuffer[i].gameObject.SetActive(false);
		}
	}
}
