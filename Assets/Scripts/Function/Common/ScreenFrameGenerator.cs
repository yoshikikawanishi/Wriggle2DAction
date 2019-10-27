using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFrameGenerator : MonoBehaviour {

    [SerializeField] private Sprite texture;
    
    private GameObject main_Camera;

    private List<SpriteRenderer> frames = new List<SpriteRenderer>();


	// Use this for initialization
	void Start () {
        //取得
        main_Camera = GameObject.FindWithTag("MainCamera");
    }


    //上下の枠
    public void Generate_Top_Bottom_Frame() {
        Delete_Frames();
        StartCoroutine("Generate_Top_Bottom_Frame_Cor"); 
    }

    private IEnumerator Generate_Top_Bottom_Frame_Cor() {
        //生成
        if(texture == null) {
            yield break;
        }        
        for (int i = 0; i < 6; i++) {
            frames.Add(new GameObject("Sprite").AddComponent<SpriteRenderer>());
            frames[i].sprite = texture;
            frames[i].transform.position = main_Camera.transform.position
                                         + new Vector3(0, 150f - i * 300f, 10);
            frames[i].transform.SetParent(main_Camera.transform);
            frames[i].transform.localScale = new Vector3(16, 0, 1);
            frames[i].sortingOrder = 10;
            frames[i].color = new Color(0, 0, 0);
        }
        //大きくする
        while(frames[0].transform.localScale.y < 2) {
            frames[0].transform.localScale += new Vector3(0, 0.08f);
            frames[1].transform.localScale += new Vector3(0, 0.08f);
            yield return null;
        }
    }

    //上下の枠をなくす
    public void Delete_Top_Bottom_Frame() {
        Delete_Frames();
    }


    //枠の消去
    private void Delete_Frames() {
        foreach(SpriteRenderer f in frames) {
            Destroy(f);
        }
        frames.Clear();
    }
	
	
}
