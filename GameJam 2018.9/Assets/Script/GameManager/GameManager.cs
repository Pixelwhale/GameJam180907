//------------------------------------------------------
// 作成日：2018.8.14
// 作成者：林 佳叡
// 内容：ゲームマネージャー
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance = null;                  //GameManagerのインスタンス
    [SerializeField]
    private SceneLoader sceneLoader;                            //SceneManager
    [SerializeField]
    private SoundManager soundManager;                          //SoundManager
    [SerializeField]
    private SystemSE systemSEManager;                           //SystemSEManager
    [SerializeField]
    private Fader sceneFader;                                   //SceneFader
    [SerializeField]
    private GamePlayInfo gameInfo;                              //GameInfo
    [SerializeField]
    private Config config;

	private void Awake()
    {
        CheckInstance();                                    	//Instanceをチェックする
    }

    private void CheckInstance()
    {
        if (Instance != null)                               	//Nullじゃない場合
        {
            DestroyImmediate(this.gameObject);              	//削除
            return;
        }

        Instance = this;                                    	//Instance指定
        DontDestroyOnLoad(this.gameObject);                 	//削除されないように

        Initialize();											//初期化
    }

	private void Initialize()
	{
		
	}
	
	void Update () 
	{
		
	}

    /// <summary>
    /// 音声の管理者
    /// </summary>
    /// <value></value>
    public SoundManager SoundManager { get{ return soundManager; } }
    /// <summary>
    /// システム音管理者
    /// </summary>
    /// <value></value>
    public SystemSE SystemSE { get{ return systemSEManager; } }
    /// <summary>
    /// Scene管理者
    /// </summary>
    /// <value></value>
    public SceneLoader SceneLoader { get{ return sceneLoader; } }

    /// <summary>
    /// シーンフェーダー
    /// </summary>
    /// <value></value>
    public Fader SceneFader { get{ return sceneFader; } }

     /// <summary>
    /// ゲームプレイの情報
    /// </summary>
    /// <value></value>
    public GamePlayInfo GamePlayInfo { get{ return gameInfo; } }

    public Config Config{ get{ return config; } }
}
