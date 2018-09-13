//2018.09.13 金　淳元　
//パーセンテージのUIクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Percent : MonoBehaviour {
    [SerializeField]
    private ResultManager resultManager;

    [SerializeField]
    private Sprite[] numbers;
    [SerializeField]
    private Transform[] numbersBuffer;

    private float percent_end;
    private float percent = 0.0f;
    private float percent_plus = 0.0043f;

    private bool isEnd = false;

	// Use this for initialization
	void Start () {
        percent_end = resultManager.GetPercent();
	}
	
    void Update()
    {
        PercentPlus();
        PercentUpdate();
    }

    private void PercentPlus()
    {
        if (percent_end <= percent)
        {
            isEnd = true;
            return;
        }
        percent += percent_plus;
        percent = Mathf.Min(percent_end, percent);
    }

    private void PercentUpdate()
    {
        SetNum((int)(percent * 10000));
    }

    public void SetNum(int number)
    {
        for (int i = numbersBuffer.Length - 1; i >= 0; --i)
        {
            int count = number % 10;
            number /= 10;
            numbersBuffer[i].GetComponent<SpriteRenderer>().sprite = numbers[count];
            numbersBuffer[i].position = new Vector3(numbersBuffer[i].position.x, -2, 0);
        }
    }

    public bool IsEnd()
    {
        return isEnd;
    }
}
