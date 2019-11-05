using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    [SerializeField] private Text score_Text;
    [SerializeField] private Text power_Text;
    [SerializeField] private Text stock_Text;

    private PlayerManager player_Manager;

    private int score_Text_Value;
    private int power_Text_Value;
    private int stock_Text_Value;
    private int life_Image_Number;


	// Use this for initialization
	void Start () {
        //取得
        player_Manager = PlayerManager.Instance;

        //UI初期値
        Change_Player_UI(score_Text, 6, player_Manager.Get_Score(), score_Text_Value); //スコア
        Change_Player_UI(power_Text, 3, player_Manager.Get_Power(), power_Text_Value); //パワー
        Change_Player_UI(stock_Text, 1, player_Manager.Get_Stock(), stock_Text_Value); //ストック
        Change_Life_UI();   //ライフ
    }
	

	// Update is called once per frame
	void Update () {
        Change_Player_UI(score_Text, 6, player_Manager.Get_Score(), score_Text_Value); //スコア
        Change_Player_UI(power_Text, 3, player_Manager.Get_Power(), power_Text_Value); //パワー
        Change_Player_UI(stock_Text, 1, player_Manager.Get_Stock(), stock_Text_Value); //ストック
        Change_Life_UI();   //ライフ
	}


    //テキストUIの変更
    private void Change_Player_UI(Text text, int digit, int value, int text_Value) {
        if(value != text_Value) {
            text_Value = value;
            text.text = value.ToString("D" + digit.ToString());
        }
    }
    

    //ライフUI変更
    private void Change_Life_UI() {
        
    }

}
