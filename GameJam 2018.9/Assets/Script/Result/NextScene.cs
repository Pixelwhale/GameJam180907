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

	// Update is called once per frame
	void Update () {
        if (Input.touchCount <= 0) return;
        if(Input.GetTouch(0).phase < TouchPhase.Ended && ui_percent.IsEnd())
        {
            //Titleに移動
            sceneLoader.LoadScene(SceneEnum.Title);
        }
        
	}
}
