//2018.09.13 金　淳元
//SE管理クラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour {

    private AudioSource audio;
    private AudioClip se;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        se = audio.clip;
    }

    public void PlaySE()
    {
        audio.PlayOneShot(se);
    }
}
