//2018.09.13 金　淳元　
//UIの移動関連
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMovement : MonoBehaviour {
    [SerializeField]
    private UiMovement next;
    [SerializeField]
    private UI_Num Num;
    [SerializeField]
    private ResultManager resultManager;

    private bool isStart = false;
    private bool isEnd = false;

    private Vector3 velocity = new Vector3(0.3f, 0, 0);
    private float stop_x = -8;

    void Start()
    {
        if (gameObject.name == "perfect") isStart = true;
    }

    // Update is called once per frame
    void Update() {
        if (!isStart) return;
        if (isEnd) return;
        MoveUpdate();
	}


    private void MoveUpdate()
    {
        if (transform.position.x >= stop_x)
        {
            CountUpdate();
            next.isStart = true;
            return;
        }
        transform.position += velocity;
    }

    private void CountUpdate()
    {
        Num.isStart = true;
        if (gameObject.name == "perfect")
        {
            Num.SetNum(resultManager.GetPerfect());
            return;
        }
        if (gameObject.name == "great")
        {
            Num.SetNum(resultManager.GetGreat());
            return;
        }
        if (gameObject.name == "Miss")
        {
            Num.SetNum(resultManager.GetMiss());
            return;
        }
        Num.SetNum(1114);
        Num.SetNum(resultManager.GetMaxCombo());
    }

}
