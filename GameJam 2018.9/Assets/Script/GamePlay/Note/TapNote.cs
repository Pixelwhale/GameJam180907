//------------------------------------------------------
// 作成日：2018.9.10
// 作成者：林 佳叡
// 内容：一発Note
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNote : MonoBehaviour, INote
{
	private bool isDead = false;
#if UNITY_EDITOR
    private bool isDebug = GamePlayDebugMode.isDebug;
#endif
    private List<Vector2> positions = new List<Vector2>();
    private int index = 0;

    //追加部分　===============
    //2018.09.11 金　淳元　Perfect,Great　判定
    private Enum_score score;
    //追加部分　===============

    public void Initialize(Vector2 pos)
    {
        positions.Add(pos);
        transform.position = positions[0];
    }

    public void Next()
    {
        ++index;
        if(index >= positions.Count)
        {
            Destroy(gameObject);
            return;
        }
        transform.localPosition = positions[index];
        score = Enum_score.Null;
        isDead = false;
    }

    public Enum_score CheckInput(float checkLineX, bool isTrigger, bool isDown, HitEffect effect)
	{
#if UNITY_EDITOR
        if(isDebug && !isDead)
        {
            score = Enum_score.Null;
            DebugMode(checkLineX, effect);
            return score;
        }
#endif
		if(!isTrigger || isDead)
			return Enum_score.Null;

        //追加部分　===============
        //2018.09.11 金　淳元　Perfect,Great　判定
        float distance = Mathf.Abs(transform.position.x - checkLineX);
        DistanceCheck(distance);
        //追加部分　===============

        isDead = true;
		PlayEffect(effect);
		return score;
	}

    private void DebugMode(float checkLineX, HitEffect effect)
    {
        float distance = Mathf.Abs(transform.position.x - checkLineX);
        if (distance < Distance_Perfect.distance_perfect)
        {
            isDead = true;
            score = Enum_score.Perfect;
            PlayEffect(effect);
        }
    }

    private void PlayEffect(HitEffect effect)
    {
        effect.PlayOneHit();
        if(score == Enum_score.Perfect)
        {
            effect.PlayPerfect();
            return;
        }
        if(score == Enum_score.Great)
            effect.PlayGreat();
    }

	public void MissProcess()
	{
		return;
	}

	public bool IsDead()
	{
		return isDead;
	}

    //追加部分　===============
    //2018.09.11 金　淳元
    //perfect great 判定
    private void DistanceCheck(float distance)
    {
        if (distance < Distance_Perfect.distance_perfect)
        {
            score = Enum_score.Perfect;
            return;
        }
        score = Enum_score.Great;
    }//追加部分　===============


}
