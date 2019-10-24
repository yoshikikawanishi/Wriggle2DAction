using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //コンポーネント
    private Rigidbody2D _rigid;
    private Animator _anim;
    private PlayerTransition _transition;
    private PlayerJump _jump;
    private PlayerAttack _attack;

    //状態
    public bool is_Playable = true;
    public bool is_Landing = true;
    public bool is_Ride_Beetle = false;
    //攻撃の入力識別用
    public bool start_Attack_Frame_Count = false;

    private int attack_Frame_Count = 0;

    private string now_Animator_Parameter = "IdleBool";

    private float attack_Time = 0.5f;
    private float attack_Interval = 0.5f;


    //Awake
    private void Awake() {
        //取得
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _transition = GetComponent<PlayerTransition>();
        _jump = GetComponent<PlayerJump>();
        _attack = GetComponent<PlayerAttack>();
    }


    // Update is called once per frame
    void Update () {

        if (!is_Playable) {
            return;
        }

        if (is_Ride_Beetle) {
            Beetle_Controlle();    
        }
        else {
            Normal_Controlle();                   
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
        //近接攻撃
        Attack();
        //カブトムシに乗る
        Ride_Beetle();
        //パワーの回復

    }


    //カブトムシ時の操作
    private void Beetle_Controlle() {
        //移動

        //ショット

        //カブトムシから降りる
        Get_Off_Beetle();
        //パワーの消費

    }


    //近接攻撃
    //注意：もし、攻撃発生までにis_Playableがfalseになっても、攻撃は続行する
    public void Attack() {
        //入力を受け取ったら、少しだけ待つ
        if (Input.GetKeyDown(KeyCode.X)) {
            start_Attack_Frame_Count = true;
        }
        //待ってる間に下が押されたらキック、1度も押されなかったら横攻撃
        if (start_Attack_Frame_Count) {
            attack_Frame_Count++;
            if (Input.GetKey(KeyCode.DownArrow)) {
                _attack.Kick();
            }
            else if (attack_Frame_Count > 7) {
                _attack.Attack();
            }
            else return;
            attack_Frame_Count = 0;
            start_Attack_Frame_Count = false;
        }
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
    //横攻撃とキックはAnyStateからのTriggerで管理
    public void Change_Animation(string next_Parameter) {
        if(now_Animator_Parameter == next_Parameter) {
            return;
        }

        _anim.SetBool("IdleBool", false);
        _anim.SetBool("DashBool", false);
        _anim.SetBool("JumpBool", false);

        _anim.SetBool(next_Parameter, true);
        now_Animator_Parameter = next_Parameter;
    }


    //Setter
    public void Set_Is_Playable(bool is_Playable) {
        this.is_Playable = is_Playable;
    }
}
