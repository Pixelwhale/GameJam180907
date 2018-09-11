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
	private int[] count;				//ScoreCount

    //2018.09.11 金　淳元  combo
    private int combo = 0;

	/// <summary>
	/// 初期化処理
	/// </summary>
	public void Initialize()
	{
		count = new int[(int)Enum_score.Null];
		for(int i = 0; i < count.Length; ++i)
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
		if(score == Enum_score.Null) 
			return;

        //comboの更新
        ComboUpdate(score);
		++count[(int)score];
	}
	
	/// <summary>
	/// Scoreを取得
	/// </summary>
	/// <param name="score">Score　Type</param>
	/// <returns></returns>
	public int GetScore(Enum_score score)
	{
		if(score == Enum_score.Null) 
			return 0;
		return count[(int)score];
	}

    //combの更新
    private void ComboUpdate(Enum_score score)
    {
        if (score == Enum_score.Miss)
        {
            combo = 0;
            return;
        }
        ++combo;
    }

}
