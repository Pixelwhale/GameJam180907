//------------------------------------------------------
// 作成日：2018.8.18
// 作成者：林 佳叡
// 内容：SceneLoader
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
    private SceneEnum currentScene = SceneEnum.Null;            //現在のシーン
    private SceneEnum lastScene = SceneEnum.Null;               //前のシーン

    /// <summary>
    /// シーンをロードする
    /// </summary>
    /// <param name="nextScene">目標のシーン</param>
    public void LoadScene(SceneEnum nextScene)
    {
        if(nextScene == SceneEnum.Null) return;                 //無効シーン
        lastScene = currentScene;                               //記録
        currentScene = nextScene;                               //切り替え
        StartCoroutine(LoadSceneAsync());                       //Start Loading
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(currentScene.ToString());    //指定のシーンをロード

        while(!operation.isDone)                                //Load中
        {
            yield return null;
        }
    }
}
