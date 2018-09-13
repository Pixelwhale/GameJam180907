//2018.09.13 金　淳元　
//PercentUIをTrueに
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextToPercenUI : MonoBehaviour {

    [SerializeField]
    private GameObject ui_percent;
    [SerializeField]
    private UiMovement ui_move;
    private bool alldo = false;

    void Update()
    {
        if (alldo) return;
        if (!ui_move.IsEnd()) return;
        SetPercentUITrue();
    }

	private void SetPercentUITrue()
    {
        ui_percent.SetActive(true);
        alldo = true;
    }
    
}
