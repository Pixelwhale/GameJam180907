//------------------------------------------------------
// 作成日：2018.6.11
// 作成者：林 佳叡
// 内容：System音を鳴らすスクリプト
//------------------------------------------------------
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SystemSE : MonoBehaviour {

    [SerializeField, Tooltip("Same to the SystemSE Enum")]
    private AudioClip[] seResource;
    [SerializeField, Tooltip("Prefab")]
    private GameObject soundBuffer;                 //Prefab
    [SerializeField]
    private float maxVolume = 0.8f;                 //最大音量
    private List<GameObject> buffers = new List<GameObject>();

    private IEnumerator ClearSeBuffer()
    {
        for (int i = 0; i < buffers.Count;)
        {
            SoundBuffer se = buffers[i].GetComponent<SoundBuffer>();
            if (se.IsEnd())
            {
                Destroy(buffers[i]);
                buffers.RemoveAt(i);
                continue;
            }
            ++i;
        }

        if(buffers.Count > 0)                       //Play中のSEがある場合
        {
            yield return new WaitForSecondsRealtime(1.0f);      //wait for 1 Second
            StartCoroutine(ClearSeBuffer());        //Update
        }
    }

    /// <summary>
    /// System音を流す
    /// </summary>
    /// <param name="seType">System音のタイプ</param>
    public void PlaySystemSE(SystemSoundEnum seType)
    {
        GameObject se = Instantiate(soundBuffer, transform);
        SoundBuffer buffer = se.GetComponent<SoundBuffer>();
        buffer.Initialize();                        //初期化
        buffer.SetVolume(maxVolume);                //音量を設定
        buffer.SetClip(seResource[(int)seType]);    //音源設定
        buffer.Play(false);                         //流す
        buffers.Add(se);                            //管理もとに追加
        
        StopCoroutine(ClearSeBuffer());             //Reset
        StartCoroutine(ClearSeBuffer());            //Coroutine(Update)
    }

    /// <summary>
    /// 最大音量を設定
    /// </summary>
    /// <param name="maxVolume">音量</param>
    public void SetSystemVolume(float maxVolume)
    {
        this.maxVolume = maxVolume;
    }
}
