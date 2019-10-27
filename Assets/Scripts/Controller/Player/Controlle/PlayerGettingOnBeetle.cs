using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGettingOnBeetle : MonoBehaviour {

    [SerializeField] private GameObject beetle_Prefab;
    private GameObject beetle;

    private GameObject main_Camera;
    private GameObject player_Body;

    private PlayerController _controller;

    private bool can_Get_On_Beetle = true;

    private float default_Gravity;
    private Vector2 default_Collider_Size;


    //Start
    private void Start() {
        //取得
        main_Camera = GameObject.FindWithTag("MainCamera");
        player_Body = transform.Find("Body").gameObject;
        _controller = GetComponent<PlayerController>();

        //初期値代入
        default_Gravity = GetComponent<Rigidbody2D>().gravityScale;
        default_Collider_Size = GetComponentInChildren<CapsuleCollider2D>().size;
    }


    #region Get On Beetle

    //カブトムシに乗る
    public void Get_On_Beetle() {
        if (can_Get_On_Beetle) {
            StopAllCoroutines();
            _controller.is_Ride_Beetle = true;
            StartCoroutine("Get_On_Beetle_Cor");
        }
    }

    private IEnumerator Get_On_Beetle_Cor() {
        can_Get_On_Beetle = false;

        //時間停止
        Time.timeScale = 0;
        PauseManager.Instance.Set_Is_Pausable(false);
        //カブトムシ登場        
        StartCoroutine("Appear_Beetle_Cor");
        for (float t = 0; t < 0.8f; t += 0.016f) { yield return null; }        
        //ステータス変更
        Change_Beetle_Status();

        PauseManager.Instance.Set_Is_Pausable(true);
        Time.timeScale = 1;

        beetle.SetActive(false);
        can_Get_On_Beetle = true;
    }

    //カブトムシ登場
    public IEnumerator Appear_Beetle_Cor() {
        //生成
        if (beetle == null)
            beetle = Instantiate(beetle_Prefab);
        else
            beetle.SetActive(true);
        beetle.transform.position = main_Camera.transform.position + new Vector3(-280f, 140f);

        //移動 
        float speed = 0.025f;    //速度
        float now_Location = 0;  //現在の移動距離割合
        Vector3 start_Pos = beetle.transform.position;
        Vector3 next_Pos = gameObject.transform.position;
        Vector3 pos = start_Pos;
        while (now_Location <= 1) {
            now_Location += speed;
            pos = Vector3.Lerp(start_Pos, next_Pos, now_Location);  //直線の軌道
            pos += new Vector3(0, -48 * Mathf.Sin(now_Location * Mathf.PI), 0); //弧の軌道
            beetle.transform.position = pos;
            yield return null;
        }
    }

    //ステータス変更
    private void Change_Beetle_Status() {
        _controller.Change_Animation("RideBeetleBool"); //アニメーション
        GetComponent<Rigidbody2D>().gravityScale = 0;   //重力
        player_Body.GetComponent<CapsuleCollider2D>().size = new Vector2(6f, 6f);//当たり判定
        player_Body.GetComponent<SpriteRenderer>().enabled = true;
        main_Camera.GetComponent<CameraController>().Start_Auto_Scroll(1f);  //オートスクロール
    }

    #endregion


    #region Get Off Beetle

    //カブトムシから降りる
    public void Get_Off_Beetle() {
        if (can_Get_On_Beetle) {
            StopAllCoroutines();
            _controller.is_Ride_Beetle = false;
            StartCoroutine("Get_Off_Beetle_Cor");
        }
    }    

    private IEnumerator Get_Off_Beetle_Cor() {
        can_Get_On_Beetle = false;
        //カブトムシ退場
        StartCoroutine("Leaving_Beetle_Cor");
        //ステータス変更
        Change_Default_Status();
        yield return new WaitForSeconds(0.8f);
        can_Get_On_Beetle = true;
    }

    //カブトムシ退場
    public IEnumerator Leaving_Beetle_Cor() {
        //生成
        if (beetle == null)
            beetle = Instantiate(beetle_Prefab);
        else
            beetle.SetActive(true);
        beetle.transform.position = gameObject.transform.position;

        //移動 
        float speed = 0.025f;    //速度
        float now_Location = 0;  //現在の移動距離割合
        Vector3 start_Pos = gameObject.transform.position;
        Vector3 next_Pos = main_Camera.transform.position + new Vector3(280f, 160f);
        Vector3 pos = start_Pos;
        while (now_Location <= 1) {
            now_Location += speed;
            pos = Vector3.Lerp(start_Pos, next_Pos, now_Location);  //直線の軌道
            pos += new Vector3(0, -48 * Mathf.Sin(now_Location * Mathf.PI), 0); //弧の軌道
            beetle.transform.position = pos;
            yield return null;
        }
        beetle.SetActive(false);
    }

    //ステータス変更
    private void Change_Default_Status() {
        string anim_Parm = _controller.is_Landing ? "IdleBool" : "JumpBool";    //アニメーション
        _controller.Change_Animation(anim_Parm);           
        GetComponent<Rigidbody2D>().gravityScale = default_Gravity;             //重力
        player_Body.GetComponent<CapsuleCollider2D>().size = default_Collider_Size;   //当たり判定
        player_Body.GetComponent<SpriteRenderer>().enabled = false;
        main_Camera.GetComponent<CameraController>().Quit_Auto_Scroll();        //オートスクロール
    }

    #endregion

    //飛行無効化
    public void To_Disable() {
        if (_controller.is_Ride_Beetle) {
            Get_Off_Beetle();
        }
        can_Get_On_Beetle = false;
    }

    //無効化解除
    public void To_Enable() {
        can_Get_On_Beetle = true;
    }
}
