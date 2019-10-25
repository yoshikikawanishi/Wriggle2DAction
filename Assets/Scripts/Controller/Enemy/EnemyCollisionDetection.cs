using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の被弾判定を取るクラス
/// </summary>
[RequireComponent(typeof(Enemy))]
public class EnemyCollisionDetection : MonoBehaviour {

    private Dictionary<string, int> damaged_Tag_Dictionary = new Dictionary<string, int>() {
        {"PlayerAttackTag"  , 5 },
        {"PlayerKickTag"    , 10},
        {"PlayerBulletTag"  , 1 },
        {"PlayerChargeTag"  , 15},
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
                enemy.Damaged(damaged_Tag_Dictionary[key]);
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
            {"PlayerAttackTag"  , 5 },
            {"PlayerKickTag"    , 10},
            {"PlayerBulletTag"  , 1 },
            {"PlayerChargeTag"  , 15},
            {"PlayerTag"        , 10},
        };
    }

}
