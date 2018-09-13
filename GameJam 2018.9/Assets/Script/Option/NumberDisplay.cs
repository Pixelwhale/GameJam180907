//------------------------------------------------------
// 作成日：2018.9.7
// 作成者：林 佳叡
// 内容：Config Number
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay : MonoBehaviour 
{
	[SerializeField]
	private Image[] displayNumbers;
	[SerializeField]
	private Sprite[] numbers;

	public void SetNumber(int adjustPos)
	{
		displayNumbers[0].sprite = numbers[11];
		if(adjustPos < 0)
		{
			displayNumbers[0].sprite = numbers[12];
			adjustPos*=-1;
		}
		
		int one = (int)(adjustPos / 1000);
		displayNumbers[1].sprite = numbers[one];

		for(int i = displayNumbers.Length - 1; i >= 3; --i)
		{
			int number = adjustPos % 10;
			displayNumbers[i].sprite = numbers[number];
			adjustPos /= 10;
		}
	}
}
