using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //自機
    private GameObject player;
    private Rigidbody2D player_Rigid;
    
    //自機との距離、自機の向き
    private float camera_Center;
    private float distance_Center;
    private float auto_Scroll_Speed = 0.01f;    

    //強制スクロール化
    private bool is_Auto_Scroll = false;

    //端
    [SerializeField] private float left_Side = 0;
    [SerializeField] private float right_Side = 5000f;

    //ステージの方向
    public int stage_Direction = 1;


	// Use this for initialization
	void Start () {
        //取得
        player = GameObject.FindWithTag("PlayerTag");
        player_Rigid = player.GetComponent<Rigidbody2D>();
    }	


    private void FixedUpdate() {
        if (player == null) {
            return;
        }

        //オートスクロールか、自機追従
        if (is_Auto_Scroll) {
            Auto_Scroll();
        }
        else {
            Follow_Player();
        }

        //左端のときスクロールを止める
        if (transform.position.x < left_Side) {
            transform.position = new Vector3(left_Side, 0, -10);
        }
        //右端のときスクロールをとめる
        if (transform.position.x >= right_Side) {
            transform.position = new Vector3(right_Side, 0, -10);
        }
    }


    private void Follow_Player() {        
        //中心との距離が遠いとき、補完する
        camera_Center = player.transform.position.x + 80f * stage_Direction;
        distance_Center = camera_Center - transform.position.x;
        if (Mathf.Abs(distance_Center) < 5.0f) {
            transform.position = new Vector3(camera_Center, 0, -10f);            
        }        
        else {
            transform.position += new Vector3(distance_Center.CompareTo(0) * 5.0f, 0, 0);
        }
    }


    private void Auto_Scroll() {
        transform.position += new Vector3(auto_Scroll_Speed * stage_Direction, 0, 0);   
    }


    //強制スクロール化
    public void Start_Auto_Scroll(float speed) {
        is_Auto_Scroll = true;
        auto_Scroll_Speed = speed;
    }

    //強制スクロール解除
    public void Quit_Auto_Scroll() {
        is_Auto_Scroll = false;
    }


}
