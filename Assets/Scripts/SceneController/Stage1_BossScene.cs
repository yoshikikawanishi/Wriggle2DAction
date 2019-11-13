using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_BossScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //フェードイン
        FadeInOut.Instance.Start_Fade_In(new Color(0, 0, 0), 0.05f);
        //ムービー開始
        GetComponent<Stage1_BossMovie>().Start_Before_Boss_Movie();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
