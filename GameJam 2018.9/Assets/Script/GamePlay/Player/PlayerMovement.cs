//2018.09.11 金　淳元　
//プレイヤーの移動管理クラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private ValidZone upperZone;                        //上の判定区
    [SerializeField]
    private ValidZone lowerZone;						//下の判定区

    private Vector3 basePos;                            //基本位置
    private Vector3 movePos;                            //移動する位置

    private float count;                                
    private float maxCount = 0.3f;                      

    // Use this for initialization
    void Start () {
        basePos = transform.position;
        movePos = basePos;
        count = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (upperZone.IsTrigger() || upperZone.IsDown()) UpperMovement();   //上に移動設定
        if (lowerZone.IsTrigger() || lowerZone.IsDown()) LowerMovement();   //下に移動設定
        ReturnLowerUpdate();                                                //下に戻る
        transform.position = movePos;                                       //移動
    }

    private void UpperMovement()
    {
        movePos = new Vector3(basePos.x, -basePos.y, 0);
    }

    private void LowerMovement()
    {
        movePos = basePos;
    }

    private void ReturnLowerUpdate()
    {
        if (transform.position != basePos &&
            !upperZone.IsDown())
        {
            count += Time.deltaTime;
        }
        if (count >= maxCount)
        {
            count = 0.0f;
            movePos = basePos;
        }
    }

}
