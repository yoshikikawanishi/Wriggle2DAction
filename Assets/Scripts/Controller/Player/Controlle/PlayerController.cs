using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //コンポーネント
    private Rigidbody2D _rigid;
    private PlayerJump _jump;
    private PlayerTransition _transition;
    private PlayerMissFunction _miss_Function;

    //スクリプト
    private PlayerManager player_Manager;

    //状態
    public bool is_Playable = true;
    public bool is_Landing = true;
    public bool is_Ride_Beetle = false;


    //Awake
    private void Awake() {
        //取得
        _rigid = GetComponent<Rigidbody2D>();
        _jump = GetComponent<PlayerJump>();
        _transition = GetComponent<PlayerTransition>();
        _miss_Function = GetComponent<PlayerMissFunction>();
    }


    //Start
    private void Start() {
        //取得
        player_Manager = PlayerManager.Instance;
    }



    // Update is called once per frame
    void Update () {

        if (!is_Playable) {
            return;
        }

        if (is_Ride_Beetle) {
            Beetle_Controlle();
            Get_Off_Beetle();       
        }
        else {
            Normal_Controlle();
            Ride_Beetle();            
        }

        if(player_Manager.Get_Life() == 0) {
            _miss_Function.Miss();
        }
        
	}


    //通常時の操作
    private void Normal_Controlle() {
        //移動
        if (Input.GetAxisRaw("Horizontal") > 0) {
            _transition.Transition(1);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) {
            _transition.Transition(-1);
        }
        else {
            _transition.Slow_Down();
        }
        //ジャンプ
        if (Input.GetKey(KeyCode.Z) && is_Landing) {
            _jump.Jump();
        }
        if (Input.GetKeyUp(KeyCode.Z)) {
            _jump.Slow_Down();
        }
        //パワーの回復

    }


    //カブトムシ時の操作
    private void Beetle_Controlle() {
        //移動

        //ショット

        //パワーの消費

    }


    //カブトムシに乗る
    public void Ride_Beetle() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            is_Ride_Beetle = true;
        }
    }


    //カブトムシから降りる
    public void Get_Off_Beetle() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            is_Ride_Beetle = false;
        }
    }


    //アニメーション変更
    public void Change_Animation(string next_Parameter) {

    }
}
