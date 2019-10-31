using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFairy : MonoBehaviour {

    //コンポーネント
    private Rigidbody2D _rigid;
    private Renderer _renderer;
    

	// Use this for initialization
	void Start () {
        //取得
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        //止まらないようにする
        if (Mathf.Abs(_rigid.velocity.x) < 5f) {
            int direction = -transform.localScale.x.CompareTo(0);
            _rigid.velocity = new Vector2(direction * 40, _rigid.velocity.y);
        }
        //落下時消す
        if(transform.position.y < -170f) {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //反転用
        if(collision.tag == "InvisibleWallTag") {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
            _rigid.velocity = new Vector2(_rigid.velocity.x * -1, _rigid.velocity.y);
        }
    }


    private void OnBecameVisible() {
        int direction = -transform.localScale.x.CompareTo(0);
        _rigid.velocity = new Vector2(direction * 40, _rigid.velocity.y);
    }

}
