using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransition : MonoBehaviour {

    //コンポーネント
    private Rigidbody2D _rigid;
    private PlayerController _controller;

    //速度、加速度
    private float MAX_SPEED = 180f;
    private float acc = 20f;

    
    private void Start() {
        _rigid      = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
    }


    //移動
    public void Transition(int direction) {
        //空中で慣性つける
        acc = _controller.is_Landing ? 20f : 6f;
        //移動、加速
        if(direction == 1 && _rigid.velocity.x < MAX_SPEED) {            
            _rigid.velocity += new Vector2(acc, 0);            
        }
        if(direction == -1 && _rigid.velocity.x > -MAX_SPEED){
            _rigid.velocity += new Vector2(-acc, 0);            
        }
        
    }

    //減速
    public void Slow_Down() {
        if (_controller.is_Landing) {
            _rigid.velocity *= new Vector2(0.4f, 1);
        }
    }
}
