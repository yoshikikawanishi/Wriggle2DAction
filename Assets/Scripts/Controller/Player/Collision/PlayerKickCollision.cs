﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKickCollision : MonoBehaviour {
    
    private bool is_Hit_Kick = false;    


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "EnemyTag" && !is_Hit_Kick) {
            is_Hit_Kick = true;
        }    
    }


    public bool Hit_Trigger() {
        if (is_Hit_Kick) {
            is_Hit_Kick = false;
            return true;
        }
        return false;
    }


    public void Make_Collider_Appear() {
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public void Make_Collider_Disappear() {
        GetComponent<CircleCollider2D>().enabled = false;
    }

}