//------------------------------------------------------
// 作成日：2018.6.08
// 作成者：林 佳叡
// 内容：音声を管理するクラス
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    private GameObject soundBuffer;                 //Prefab

    private List<GameObject> buffers = new List<GameObject>();               //Sound Buffer
    private GameObject gamePlayMusic;               //GamePlayの音楽Buffer
    private string currentBgm = "";                 //現在の音楽

    private float maxVolume = 1.0f;                 //最大音量

    private void Update()
    {
        for(int i = 0; i < buffers.Count;)
        {
            if(!buffers[i])                         //削除された場合
            {
                buffers.RemoveAt(i);
                continue;
            }                              

            SoundBuffer sound = buffers[i].GetComponent<SoundBuffer>();
            sound.UpdateFade();
            ++i;
        }
    }

    /// <summary>
    /// BGMを流す
    /// </summary>
    /// <param name="bgm">Audio Source</param>
    /// <param name="state">Start State</param>
    /// <param name="fadeSpeed">Fade Speed</param>
    /// <param name="loop">Is looping</param>
    /// <param name="startVolume">Start Volume</param>
    public void PlayBGM(AudioClip bgm, FadeState state, float fadeSpeed, bool loop, float startVolume = 0.0f)
    {
        if (currentBgm.Equals(bgm.name))
            return;

        FadeOutOtherBGM();                                              //他のBGMをFadeOut

        GameObject buffer = Instantiate(soundBuffer, transform);        //新しいBuffer作成
        buffer.GetComponent<SoundBuffer>().Initialize();
        buffer.GetComponent<SoundBuffer>().CurrentState = state;        //Fade状態設定
        buffer.GetComponent<SoundBuffer>().SetVolume(startVolume);      //StartVolume設定
        buffer.GetComponent<SoundBuffer>().SetMaxVolume(maxVolume);     //最大音量設定
        buffer.GetComponent<SoundBuffer>().SetFadeSpeed(fadeSpeed);     //FadeSpeedを設定
        buffer.GetComponent<SoundBuffer>().SetClip(bgm);                //音源設定
        buffers.Add(buffer);                                            //Listに追加
        currentBgm = bgm.name;

        buffer.GetComponent<SoundBuffer>().Play(loop);
    }

    private void FadeOutOtherBGM()
    {
        for(int i = 0; i < buffers.Count; ++i)
        {
            SoundBuffer sound = buffers[i].GetComponent<SoundBuffer>();
            sound.CurrentState = FadeState.FadeOut;
        }
    }

    /// <summary>
    /// 全体BGM音量を設定
    /// </summary>
    public void SetMaxVolume(float maxVolume)
    {
        this.maxVolume = maxVolume;
        for(int i = 0; i < buffers.Count; ++i)
        {
            SoundBuffer sound = buffers[i].GetComponent<SoundBuffer>();
            if (sound.CurrentState == FadeState.FadeOut)          //FadeOut処理はそのまま
                continue;

            sound.SetMaxVolume(maxVolume);                        //最大音量設定
            if (Mathf.Approximately(maxVolume, 1.0f))
            {
                sound.CurrentState = FadeState.FadeIn;            //最大の場合はFadeInを使う
                continue;
            }
            sound.CurrentState = FadeState.LerpToMax;
        }
    }

    /// <summary>
    /// GamePlayの音楽を設定
    /// </summary>
    /// <param name="clip"></param>
    public void SetGamePlayMusic(AudioClip clip)
    {
        if(gamePlayMusic) Destroy(gamePlayMusic);
        gamePlayMusic = Instantiate(soundBuffer, transform);                   //新しいBuffer作成
        gamePlayMusic.GetComponent<SoundBuffer>().Initialize();
        gamePlayMusic.GetComponent<SoundBuffer>().SetVolume(maxVolume);        //StartVolume設定
        gamePlayMusic.GetComponent<SoundBuffer>().SetMaxVolume(maxVolume);     //最大音量設定
        gamePlayMusic.GetComponent<SoundBuffer>().SetClip(clip);               //音源設定
    }

    /// <summary>
    /// GamePlayの音楽を流す
    /// </summary>
    public void PlayGameMusic()
    {
        gamePlayMusic.GetComponent<SoundBuffer>().Play(false);
    }

    public void StopBGM()
    {
        for(int i = 0; i < buffers.Count; ++i)
        {
            Destroy(buffers[i]);
        }
        buffers.Clear();
    }
}
