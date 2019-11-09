using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の被弾判定を取るクラス
/// </summary>
[RequireComponent(typeof(Enemy))]
public class EnemyCollisionDetection : MonoBehaviour {

    private Dictionary<string, int> damaged_Tag_Dictionary = new Dictionary<string, int>() {
        {"PlayerAttackTag"  , 10 },
        {"PlayerBulletTag"  , 1 },
        {"PlayerChargeBulletTag"  , 10},
        {"PlayerTag"        , 10},
    };

    private Enemy enemy;


    // Use this for initialization
    void Start() {
        enemy = GetComponent<Enemy>();
    }

    //OnTriggerEnter
    private void OnTriggerEnter2D(Collider2D collision) {
        //被弾の判定
        foreach (string key in damaged_Tag_Dictionary.Keys) {
            if (collision.tag == key) {
                int damage = (int)(damaged_Tag_Dictionary[key] * Damage_Rate());
                enemy.Damaged(damage);
            }
        }
    }

    //OnCollisionEnter
    private void OnCollisionEnter2D(Collision2D collision) {
        //被弾の判定
        foreach (string key in damaged_Tag_Dictionary.Keys) {
            if (collision.gameObject.tag == key) {
                enemy.Damaged(damaged_Tag_Dictionary[key]);
            }
        }
    }


    //被弾判定の変更
    protected virtual void Change_Damaged_Tag_Dictionary() {
        damaged_Tag_Dictionary.Clear();
        damaged_Tag_Dictionary = new Dictionary<string, int>() {
            {"PlayerAttackTag"  , 10 },
            {"PlayerBulletTag"  , 1 },
            {"PlayerChargeBulletTag"  , 10},
            {"PlayerTag"        , 10},
        };
    }


    //自機のパワーに応じてダメージ増加
    private float Damage_Rate() {
        int power = PlayerManager.Instance.Get_Power();
        if(power < 16) {
            return 1;
        }
        if(power < 32) {
            return 1.2f;
        }
        else if(power < 64) {
            return 1.5f;
        }
        else if(power < 128) {
            return 1.8f;
        }
        return 2;
    }

}
