//2018.09.13 金　淳元　
//次のシーン（Title）に移動
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {
    [SerializeField]
    private UI_Percent ui_percent;
    [SerializeField]
    private SceneLoader sceneLoader;

    private Fader sceneFader;           //Scene Fader

    void Start()
    {
        sceneFader = GameManager.Instance.SceneFader;
        sceneFader.FadeIn();            //Fade In
    }

    // Update is called once per frame
    void Update () {
        if (Input.touchCount <= 0) return;
        if (Input.GetTouch(0).phase < TouchPhase.Ended && ui_percent.IsEnd())
        {
            Result();
        }
    }


    public void Result()
    {
        sceneFader.FadeOut();           //Fade　Out
        StartCoroutine(LoadScene(SceneEnum.Title));
    }

    /// <summary>
    /// loadScene
    /// </summary>
    /// <param name="scene">Scene名</param>
    /// <returns></returns>
    private IEnumerator LoadScene(SceneEnum scene)
    {
        while (!sceneFader.IsEnd())     //Fade終了しなければ
        {
            yield return null;          //待つ
        }
        GameManager.Instance.SceneLoader.LoadScene(scene);
    }

}
