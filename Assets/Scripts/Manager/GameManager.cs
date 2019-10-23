using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    //ミス前に最後に地面にいた時の座標
    //PlayerFootCollisionで保存
    private Vector2 revive_Point;


    //ミス時の処理
    public void Miss() {
        //TODO:エフェクト
        GameObject player = GameObject.FindWithTag("PlayerTag");
        player.SetActive(false);
        //ゲームオーバー
        PlayerManager.Instance.Reduce_Stock();
        if (PlayerManager.Instance.Get_Stock() == -1) {
            return;
        }
        //復活
        StartCoroutine("Revive", player);
    }


    //復活の処理
    public IEnumerator Revive(GameObject player) {
        yield return new WaitForSeconds(1.0f);
        //TODO: エフェクト
        //復活
        PlayerManager.Instance.Set_Life(3);
        player.SetActive(true);
        revive_Point = RevivePointCorrection.Correct_Revive_Point(revive_Point);
        player.transform.position = revive_Point;
        //TODO: 点滅、無敵化        
    }


    //ゲームオーバー時の処理
    public void Game_Over() {

    }


    //Setter
    public void Set_Revive_Point(Vector2 revive_Point) {
        this.revive_Point = revive_Point;
    }

}
