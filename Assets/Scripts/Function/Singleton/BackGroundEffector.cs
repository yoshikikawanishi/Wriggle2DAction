﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundEffector : SingletonMonoBehaviour<BackGroundEffector> {

    [SerializeField] private GameObject back_Ground;
    private SpriteRenderer back_Ground_Sprite;

    private new void Awake() {
        if(back_Ground == null) {
            Debug.Log("Set_BackGround_BackGroundEffecter");
            return;
        }
        back_Ground_Sprite = back_Ground.GetComponent<SpriteRenderer>();
    }
    

    /// <summary>
    /// 背景の色を変える
    /// </summary>
    /// <param name="next_Color">変更後の背景の色</param>
    /// <param name="change_Speed_Rate">変更の速さ(1で直接変化)</param>
    public void Start_Change_Color(Color next_Color, float change_Speed_Rate) {
        if(change_Speed_Rate <= 0) {
            Debug.Log("Change_Speed_Rate Must Positive_Number");
            return;
        }
        StopCoroutine(Change_Color_Cor(new Color(), 0));
        StartCoroutine(Change_Color_Cor(next_Color, change_Speed_Rate));
    }


    //背景の色遷移
    private IEnumerator Change_Color_Cor(Color next_Color, float change_Speed_Rate) {
        float rate = 0;
        Color difference = next_Color - back_Ground_Sprite.color;
        Color delta_Color = difference * change_Speed_Rate;
        while (rate < 1) {
            rate += change_Speed_Rate;
            back_Ground_Sprite.color += delta_Color;
            yield return null;
        }
    }



	
	
}
