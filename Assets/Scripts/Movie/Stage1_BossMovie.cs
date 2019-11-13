using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_BossMovie : MonoBehaviour {

    //自機
    private GameObject player;

    private void Awake() {
        player = GameObject.FindWithTag("PlayerTag");
    }
	

    //ボス前ムービー開始
    public void Start_Before_Boss_Movie() { 
        StartCoroutine("Play_Before_Boss_Movie_Cor");
    }

    //ボス前ムービー
    private IEnumerator Play_Before_Boss_Movie_Cor() {
        //初期設定
        player.GetComponent<PlayerController>().Set_Is_Playable(false);
        PauseManager.Instance.Set_Is_Pausable(false);

        yield return null;

        //終了設定
        player.GetComponent<PlayerController>().Set_Is_Playable(true);
        PauseManager.Instance.Set_Is_Pausable(true);
    }

}
