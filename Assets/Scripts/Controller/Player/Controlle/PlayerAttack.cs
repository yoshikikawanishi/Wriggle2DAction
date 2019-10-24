using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    //コンポーネント
    private PlayerController _controller;
    private Animator _anim;
    private Rigidbody2D _rigid;

    private bool can_Attack = true;


	// Use this for initialization
	void Start () {
        //取得
        _controller = GetComponent<PlayerController>();
        _anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }


    //攻撃
    public void Attack() {
        if (can_Attack) {
            StartCoroutine("Attack_Cor");
        }
    }


    public IEnumerator Attack_Cor() {
        can_Attack = false;       
        _anim.SetTrigger("AttackTrigger");
        yield return new WaitForSeconds(0.18f);        
        can_Attack = true;
    }


    //キック
    public void Kick() {
        if (can_Attack) {
            StartCoroutine("Kick_Cor");
        }        
    }


    private IEnumerator Kick_Cor() {
        can_Attack = false;
        _controller.Set_Is_Playable(false);
        _anim.SetTrigger("KickTrigger");
        _rigid.velocity = new Vector2(transform.localScale.x * 170f, -200f);
        yield return new WaitForSeconds(0.33f);
        _controller.Set_Is_Playable(true);
        can_Attack = true;
    }
}
