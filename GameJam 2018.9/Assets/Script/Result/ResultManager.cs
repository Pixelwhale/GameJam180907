//2018.09.13 金　淳元　
//結果関連数値管理クラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour {

    [SerializeField]
    private ScoreManager scoreManager;

    private int num_perfect = 0;
    private int num_great = 0;
    private int num_miss = 0;
    private int num_maxcombo = 0;
    private float percent = 0.0f;


    // Use this for initialization
    public void SetResult() {
        if (scoreManager == null) return;
        num_perfect = scoreManager.GetScore(Enum_score.Perfect);
        num_great = scoreManager.GetScore(Enum_score.Great);
        num_miss = scoreManager.GetScore(Enum_score.Miss);
        num_maxcombo = scoreManager.GetMaxCombo();
        percent = scoreManager.GetPercent();
    }
	
	public int GetPerfect()
    {
        return num_perfect;
    }

    public int GetGreat()
    {
        return num_great;
    }

    public int GetMiss()
    {
        return num_miss;
    }

    public int GetMaxCombo()
    {
        return num_maxcombo;
    }

    public float GetPercent()
    {
        return percent;
    }
}
