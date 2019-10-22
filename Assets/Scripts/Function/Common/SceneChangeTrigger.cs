using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangTrigger : MonoBehaviour {

    public string next_Scene;


    //OnTriggerEnter
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerBodyTag") {
            SceneManager.LoadScene(next_Scene);
        }
    }

}
