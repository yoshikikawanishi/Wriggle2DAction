using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : SingletonMonoBehaviour<DataManager> {


    //プレイヤーデータのセーブ
    public void Save_Player_Data(Vector2 save_Point) {       
        //データの取得
        string scene    = SceneManager.GetActiveScene().name;
        Vector2 pos     = save_Point;
        int life        = PlayerManager.Instance.Get_Life();
        int stock       = PlayerManager.Instance.Get_Stock();
        int beetle_Power = PlayerManager.Instance.Get_Beetle_Power();

        //データの保存
        PlayerPrefs.SetString   ("SCENE", scene);
        PlayerPrefs.SetFloat    ("POS_X", pos.x);
        PlayerPrefs.SetFloat    ("POS_Y", pos.y);
        PlayerPrefs.SetInt      ("LIFE", life);
        PlayerPrefs.SetInt      ("STOCK", stock);
        PlayerPrefs.SetInt      ("BEETLE_POWER", beetle_Power);
    }


    //データのロード
    public void Load_Player_Data() {
        StartCoroutine("Load_Player_Data_Cor");
    }

    private IEnumerator Load__Player_Data_Cor() {
        //データの取得
        if (!PlayerPrefs.HasKey("SCENE")) {
            Initialize_Player_Data();
        }
        string scene    = PlayerPrefs.GetString("SCENE");        
        float pos_X     = PlayerPrefs.GetFloat("POS_X");
        float pos_Y     = PlayerPrefs.GetFloat("POS_Y");
        int life        = PlayerPrefs.GetInt("LIFE");
        int stock       = PlayerPrefs.GetInt("STOCK");
        int beetle_Power = PlayerPrefs.GetInt("BEETLE_POWER");

        //データのロード
        SceneManager.LoadScene(scene);
        PlayerManager.Instance.Set_Life(life);
        PlayerManager.Instance.Set_Stock(stock);
        PlayerManager.Instance.Set_Beetle_Power(beetle_Power);
        yield return null;
        GameObject player = GameObject.FindWithTag("PlayerTag");
        if(player == null) 
            yield break;        
        player.transform.position = new Vector3(pos_X, pos_Y);
    }


    //データの初期化
    public void Initialize_Player_Data() {        
        string scene = "Stage1_1Scene";
        Vector2 pos = new Vector2(0, 0);
        int life = 3;
        int stock = 3;
        int beetle_Power = 0;

        //データの保存
        PlayerPrefs.SetString("SCENE", scene);
        PlayerPrefs.SetFloat("POS_X", pos.x);
        PlayerPrefs.SetFloat("POS_Y", pos.y);
        PlayerPrefs.SetInt("LIFE", life);
        PlayerPrefs.SetInt("STOCK", stock);
        PlayerPrefs.SetInt("BEETLE_POWER", beetle_Power);
    }


    //データの消去
    public void Delete_Player_Data() {
        PlayerPrefs.DeleteAll();
    }

}
