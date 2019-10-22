﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootCollision : MonoBehaviour {

    //本体
    private GameObject player;
    //コンポーネント
    private PlayerController player_Controller;
    private PlayerMissFunction player_miss_Func;
    private AudioSource landing_Sound;

    
    private void Start() {
        player = transform.parent.gameObject;        
        player_Controller   = player.GetComponent<PlayerController>();
        player_miss_Func    = player.GetComponent<PlayerMissFunction>();
    }

    
    protected void OnTriggerStay2D(Collider2D collision) {
        //着地判定
        foreach(string tag_Name in TagManager.LAND_TAG_LIST) {
            if (player_Controller.is_Landing) {
                break;
            }
            if (collision.tag == tag_Name) {
                player_Controller.is_Landing = true;
                //landing_Sound.Play();
            }
        }        
    }

    
    private void OnTriggerExit2D(Collider2D collision) {
        //地面から離れる
        foreach(string tag_Name in TagManager.LAND_TAG_LIST) {
            if(collision.tag == tag_Name) {
                player_Controller.is_Landing = false;
                player_miss_Func.Set_Revive_Point(player.transform.position);
            }
        }        
    }

}
