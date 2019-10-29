using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Game_Over();
            return;
        }
        //復活
        StartCoroutine("Revive");
    }


    //復活の処理
    public IEnumerator Revive() {
        yield return new WaitForSeconds(1.0f);

        if (!PlayerPrefs.HasKey("SCENE")) 
            DataManager.Instance.Initialize_Player_Data();
        
        string scene = PlayerPrefs.GetString("SCENE");
        float pos_X = PlayerPrefs.GetFloat("POS_X");
        float pos_Y = PlayerPrefs.GetFloat("POS_Y");

        SceneManager.LoadScene(scene);
        yield return null;

        GameObject player = GameObject.FindWithTag("PlayerTag");
        if (player == null) yield break;
        player.transform.position = new Vector3(pos_X, pos_Y);
        //TODO: その他のステータス変更
        //TODO: エフェクト
        //TODO: 点滅、無敵化        
    }


    //その場復活の処理
    public IEnumerator Revive_Same_Point(GameObject player) {
        yield return new WaitForSeconds(1.0f);        
        //復活
        PlayerManager.Instance.Set_Life(3);
        player.SetActive(true);
        revive_Point = RevivePointCorrection.Correct_Revive_Point(revive_Point);
        player.transform.position = revive_Point;
        //TODO: エフェクト
        //TODO: 点滅、無敵化        
    }


    //ゲームオーバー時の処理
    public void Game_Over() {
        Debug.Log("Game_Over");
    }


    //Setter
    public void Set_Revive_Point(Vector2 revive_Point) {
        this.revive_Point = revive_Point;
    }

}
