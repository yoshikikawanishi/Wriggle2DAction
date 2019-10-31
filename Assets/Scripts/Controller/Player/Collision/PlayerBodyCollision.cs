using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyCollision : MonoBehaviour {

    private GameObject player;
    
    //被弾タグリスト
    private List<string> damaged_Tag_List = new List<string>() {
        "EnemyTag",
        "EnemyBulletTag",
    };

    //1フレーム内に２回以上被弾しないようにする
    private bool is_Damaged = false;
    //無敵時間
    private float INVINCIBLE_TIME_LENGTH = 3.0f;


	// Use this for initialization
	void Start () {
        //取得
        player = transform.parent.gameObject;
	}


    //OnTriggerEnter
    private void OnTriggerEnter2D(Collider2D collision) {
        foreach(string tag in damaged_Tag_List) {
            if(collision.tag == tag) {
                StartCoroutine("Damaged");
            }
        }
        //Miss時
        if(collision.tag == "MissZoneTag") {
            Miss();
        }
    }


    //OnCollisionEnter
    private void OnCollisionEnter2D(Collision2D collision) {
        foreach (string tag in damaged_Tag_List) {
            if (collision.gameObject.tag == tag) {
                StartCoroutine("Damaged");
            }
        }
    }


    //被弾時の処理
    private IEnumerator Damaged() {
        if (is_Damaged) {
            yield break;
        }        
        if(PlayerManager.Instance.Reduce_Life() == 0) {
            yield break;
        }

        is_Damaged = true;

        StartCoroutine("Blink");    //点滅
        gameObject.layer = LayerMask.NameToLayer("InvincibleLayer");    //無敵化
        Vector2 reaction_Velocity = new Vector2(-player.transform.localScale.x * 120f, 180f);   //反動
        player.GetComponent<Rigidbody2D>().velocity = reaction_Velocity;    
        yield return new WaitForSeconds(INVINCIBLE_TIME_LENGTH);    //無敵時間
        gameObject.layer = LayerMask.NameToLayer("PlayerLayer");    //戻す

        is_Damaged = false;
    }


    //MissZoneに当たったときの処理
    private void Miss() {
        PlayerManager.Instance.Set_Life(0);
    }


    //点滅
    private IEnumerator Blink() {
        Renderer player_Renderer = player.GetComponent<Renderer>();
        float span = INVINCIBLE_TIME_LENGTH / 30;
        for(int i = 0; i < 15; i++) {
            player_Renderer.enabled = false;
            yield return new WaitForSeconds(span);
            player_Renderer.enabled = true;
            yield return new WaitForSeconds(span);
        }
    }


    

}
