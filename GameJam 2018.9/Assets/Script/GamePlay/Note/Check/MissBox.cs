//2018.09.11 金　淳元　
//MissBoxクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBox : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            //Todo: scoreManagerにMissをreturn；
        }
    }
}
