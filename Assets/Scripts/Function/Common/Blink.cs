using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Blink : MonoBehaviour {

	/// <summary>
    /// 点滅開始
    /// </summary>
    public void Start_Blink(Color default_Color) {
        StartCoroutine("Blink_Routine", default_Color);
    }


    //点滅
    private IEnumerator Blink_Routine(Color default_Color) {
        SpriteRenderer _sprite = GetComponent<SpriteRenderer>();
        for(int i = 0; i < 10; i++) {
            _sprite.color = default_Color - new Color(0, 0, 0, default_Color.a / 2.0f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
