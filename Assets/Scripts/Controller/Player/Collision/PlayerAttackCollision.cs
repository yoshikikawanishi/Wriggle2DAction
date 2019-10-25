using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour {

    private bool is_Hit_Attack = false;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "EnemyTag" && !is_Hit_Attack) {
            is_Hit_Attack = true;
        }
    }


    public bool Hit_Trigger() {
        if (is_Hit_Attack) {
            is_Hit_Attack = false;
            return true;
        }
        return false;
    }


    public void Make_Collider_Appear() {
        GetComponent<BoxCollider2D>().enabled = true;
        is_Hit_Attack = false;
        Play_Animation();
    }

    public void Make_Collider_Disappear() {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Play_Animation() {
        GetComponent<Animator>().SetTrigger("AttackTrigger");
    }
}
