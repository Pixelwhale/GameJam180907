//2018.09.13 金　淳元　
//数字UI関連
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Num : MonoBehaviour {

    public bool isStart = false;

    private float alpha = 0.0f;
    private float alpha_plus = 0.02f;

    [SerializeField]
    private Sprite[] numbers;
    [SerializeField]
    private Transform[] numbersBuffer;

        // Update is called once per frame
    void Update () {
        if (!isStart) return;
        Renderer();
	}

    private void NumUpdate()
    {
        if (alpha >= 1.0f)
        {
            alpha = 1.0f;
            return;
        }
        alpha += alpha_plus;
    }
   
    public void SetNum(int number)
    {
        for (int i = numbersBuffer.Length - 1; i >= 0; --i)
        {
            int count = number % 10;
            number /= 10;
            numbersBuffer[i].GetComponent<SpriteRenderer>().sprite = numbers[count];
            numbersBuffer[i].position = new Vector3(numbersBuffer[i].position.x, transform.parent.position.y, 0);
        }
    }

    private void Renderer()
    {
        for (int i = numbersBuffer.Length - 1; i >= 0; --i) 
        {
            numbersBuffer[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }
        NumUpdate();
    }
}
