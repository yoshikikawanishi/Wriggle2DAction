using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField] private GameObject bullet;
    private ObjectPool bullet_Pool;

    private GameObject main_Camera;

    private float interval_Time = 0;


	// Use this for initialization
	void Start () {
        //弾のオブジェクトプール
        ObjectPoolManager.Instance.Create_New_Pool(bullet, 10);
        bullet_Pool = ObjectPoolManager.Instance.Get_Pool(bullet);
        //取得
        main_Camera = GameObject.FindWithTag("MainCamera");
	}
	

    /// <summary>
    /// 通常ショットを撃つ
    /// </summary>
    public void Shoot() {
        for (int i = 0; i < 2; i++) {
            GameObject bullet = bullet_Pool.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.position += new Vector3(0, -8f) + new Vector3(0, 16f * i);
            bullet.transform.SetParent(main_Camera.transform);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(800f * transform.localScale.x, 0);            
        }
    }
	

}
