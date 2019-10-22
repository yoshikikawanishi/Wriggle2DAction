using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissFunction : MonoBehaviour {


    //ミス前に最後に地面にいた時の座標
    //PlayerFootCollisionで保存
    private Vector2 revive_Point;



    //ミス時の処理
    public void Miss() {

        if(PlayerManager.Instance.Get_Stock() == 0) {
            Game_Over();
        }
    }


    //ゲームオーバー時の処理
    public void Game_Over() {

    }


    //Setter
    public void Set_Revive_Point(Vector2 revive_Point) {
        this.revive_Point = revive_Point;
    }

}
