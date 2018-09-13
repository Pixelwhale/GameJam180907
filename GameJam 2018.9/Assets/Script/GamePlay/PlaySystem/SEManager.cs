//2018.09.13 金　淳元
//SE管理クラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour {
    //[SerializeField]
    //private ValidZone upper;
    //[SerializeField]
    //private ValidZone lower;

    [SerializeField]
    private ScoreManager scoreManager;

    private AudioSource audio;
    private AudioClip se;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        se = audio.clip;
    }

    void Update()
    {
        //if (upper.IsTrigger() || lower.IsTrigger())
        //{
        //    Debug.Log("se");
        //    audio.PlayOneShot(se);
        //}
        if (scoreManager.ishit)
        {
            audio.PlayOneShot(se);
            scoreManager.ishit = false;
        }
    }

}
