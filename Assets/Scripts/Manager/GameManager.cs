using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {


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
        if (player == null) { Debug.Log("Can't Find Player"); yield break; }        
        player.transform.position = new Vector3(pos_X, pos_Y);        

        //エフェクト
        Play_Revive_Effect(player);
    }   


    //ゲームオーバー時の処理
    public void Game_Over() {
        Debug.Log("Game_Over");
    }    


    //復活時のエフェクト
    private void Play_Revive_Effect(GameObject player) {
        //点滅
        player.GetComponent<PlayerController>().StartCoroutine("Blink", 3.0f);
        //無敵化
        player.GetComponentInChildren<PlayerBodyCollision>().StartCoroutine("Become_Invincible_Cor", 3.1f);
    }

}
