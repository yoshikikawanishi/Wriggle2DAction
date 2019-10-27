using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransitionRidingBeetle : MonoBehaviour {

    //コンポーネント
    private Rigidbody2D _rigid;


	// Use this for initialization
	void Start () {
        _rigid = GetComponent<Rigidbody2D>();
	}

    //移動
    public void Transition(Vector2 direction) {
        if (Time.timeScale == 0) return;

        //移動
        _rigid.velocity = direction * 170f;                               
    }

}
