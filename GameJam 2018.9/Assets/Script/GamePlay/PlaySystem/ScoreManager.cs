//------------------------------------------------------
// 作成日：2018.9.11
// 作成者：林 佳叡
// 内容：perfect, greate, miss Manager
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private ComboDisplay display;
    private int[] count;				//ScoreCount

    //2018.09.11 金　淳元  combo
    private int combo = 0;
    //2018.09.11 金　淳元  パーセント
    private int full_note;
    private int score_current = 0;
    private float percent = 0.0f;

    private int max_combo = 0;

    //se関連
    [SerializeField]
    private SEManager seManager;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Initialize();
    }

    void Start()
    {
        //Todo
        full_note = 0;//後に設定
        //全部のNoteに2を掛ける
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Initialize()
    {
        count = new int[(int)Enum_score.Null];
        for (int i = 0; i < count.Length; ++i)
        {
            count[i] = 0;
        }
    }

    /// <summary>
    /// Scoreを追加
    /// </summary>
    /// <param name="score">Score　Type</param>
    public void AddScore(Enum_score score)
    {
        if (score == Enum_score.Null)
            return;
        full_note+=2;
        //comboの更新
        ComboUpdate(score);
        //percentの更新
        PercentUpdate(score);
        ++count[(int)score];
    }

    /// <summary>
    /// Scoreを取得
    /// </summary>
    /// <param name="score">Score　Type</param>
    /// <returns></returns>
    public int GetScore(Enum_score score)
    {
        if (score == Enum_score.Null)
            return 0;
        return count[(int)score];
    }

    //combの更新
    private void ComboUpdate(Enum_score score)
    {
        if (score == Enum_score.Miss)
        {
            combo = 0;
            display.ResetCombo();
            return;
        }
        seManager.PlaySE();
        ++combo;
        MaxComboUpdate();
        display.AddCombo(combo);
    }

    //percentの更新
    private void PercentUpdate(Enum_score score)
    {
        if (score == Enum_score.Miss) return;
        if (score == Enum_score.Perfect) ++score_current;
        ++score_current;
        percent = (float)score_current / (float)full_note;
        percent = Mathf.Min(1.0f, percent);
    }

    private void MaxComboUpdate()
    {
        max_combo = Mathf.Max(max_combo, combo);
    }

    public int GetMaxCombo()
    {
        return max_combo;
    }

    public float GetPercent()
    {
        return percent;
    }
}
