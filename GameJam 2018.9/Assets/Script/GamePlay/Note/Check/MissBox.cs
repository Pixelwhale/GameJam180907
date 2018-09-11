//2018.09.11 金　淳元　
//MissBoxクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBox : MonoBehaviour {
    [Header("スコアマネージャー")]
    [SerializeField]
    private ScoreManager scoreManager;

	void OnTriggerEnter2D(Collider2D other)
    {
        scoreManager.AddScore(Enum_score.Miss);
    }
}
