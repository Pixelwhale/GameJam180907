//------------------------------------------------------
// 作成日：2018.6.08
// 作成者：林 佳叡
// 内容：PlayしたいBGMを流してくれるクラス
//------------------------------------------------------
using UnityEngine;

public class SceneBGMPlayer : MonoBehaviour
{
    [SerializeField, Tooltip("Audio Source")]
    private AudioClip audioClip;
    [SerializeField, Tooltip("Start State")]
    private FadeState fadeState;
    [SerializeField]
    private float fadeSpeed = 0.3f;
    [SerializeField]
    private float startVolume = 0.0f;

    [SerializeField]
    private float maxVolume = 0.5f;
    
    [SerializeField]
    private bool loop = true;

	void Start ()
    {
        SoundManager soundManager = GameManager.Instance.SoundManager;

        soundManager.SetMaxVolume(maxVolume);
        soundManager.PlayBGM(audioClip, fadeState, fadeSpeed, loop, startVolume);
	}
}
