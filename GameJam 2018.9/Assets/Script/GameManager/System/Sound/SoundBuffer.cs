//------------------------------------------------------
// 作成日：2018.6.08
// 作成者：林 佳叡
// 内容：音声を流すクラス
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBuffer : MonoBehaviour
{
    private AudioSource audioSource;
    private FadeState state;                //Fade状態
    private float fadeSpeed = 0.5f;         //Fade速度
    private float maxVolume = 1.0f;         //最大音量

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        state = FadeState.None;
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 音量を更新
    /// </summary>
    public void UpdateFade()
    {
        switch(state)
        {
            case FadeState.None:
                break;
            case FadeState.FadeIn:
                FadeIn();
                break;
            case FadeState.FadeOut:
                FadeOut();
                break;
            case FadeState.LerpToMax:
                LerpToMax();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 音の大きさを設定
    /// </summary>
    /// <param name="volume">大きさ</param>
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private void FadeIn()
    {
        float volume = audioSource.volume;

        volume += fadeSpeed * Time.deltaTime;       //Fade処理
        volume = Mathf.Min(volume, 1.0f);
        audioSource.volume = volume;                //適用
        if (volume >= maxVolume)                    //完全にFadein
            state = FadeState.None;
    }

    private void FadeOut()
    {
        float volume = audioSource.volume;

        volume -= fadeSpeed * Time.deltaTime;       //Fade処理
        volume = Mathf.Max(volume, 0.0f);
        if (volume <= 0.0f)                         //完全にFadeout
            Destroy(gameObject);
        audioSource.volume = volume;                //適用
    }

    /// <summary>
    /// 現在最大音量にLerpする
    /// </summary>
    /// <param name="fadeSpeed">Fadeスピード</param>
    public void LerpToMax()
    {
        float volume = audioSource.volume;

        volume = Mathf.Lerp(volume, maxVolume, Time.deltaTime);
        if(Approximately(volume, maxVolume, 0.001f))        //近似
        {
            volume = maxVolume;                     //数字指定
            state = FadeState.None;                 //Fade状態切り替え
        }
        audioSource.volume = volume;                //適用
    }

    private bool Approximately(float a, float b, float interval)
    {
        if(Mathf.Abs(a-b) < interval) return true;
        return false;
    }

    /// <summary>
    /// 音源を設定
    /// </summary>
    /// <param name="clip">音源</param>
    public void SetClip(AudioClip clip)
    {
        audioSource.clip = clip;
    }

    /// <summary>
    /// Fade状態
    /// </summary>
    /// <value></value>
    public FadeState CurrentState
    {
        get{ return state; }
        set{ this.state = value; }
    }

    /// <summary>
    /// Fadeのスピードを設定
    /// </summary>
    public void SetFadeSpeed(float speed)
    {
        fadeSpeed = speed;
    }

    /// <summary>
    /// 最大音量設定
    /// </summary>
    /// <param name="maxVolume">最大音量</param>
    public void SetMaxVolume(float maxVolume)
    {
        this.maxVolume = maxVolume;
    }

    /// <summary>
    /// 流す
    /// </summary>
    /// <param name="loop">ループするか</param>
    public void Play(bool loop = true)
    {
        audioSource.loop = loop;
        audioSource.Play();
    }

    /// <summary>
    /// 終わっているか
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return !audioSource.isPlaying;
    }
}
