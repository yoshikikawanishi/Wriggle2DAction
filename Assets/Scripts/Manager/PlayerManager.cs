using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager> {

    //ステータス
    private int life = 3;
    private int stock = 2;
    private int beetle_Power = 0;

    
    //ライフ減らす
    public void Reduce_Life() {
        if (life > 0) {
            life--;
        }
    }

    //ライフ増やす
    public void Add_Life() {
        life++;
    }


    //ストック減らす
    public void Reduce_Stock() {
        stock--;
    }

    //ストック増やす
    public void Add_Stock() {
        stock++;
    }

    
    //Getter
    public int Get_Life() {
        return life;
    }

    public int Get_Stock() {
        return stock;
    }


    //Setter
    public void Set_Life(int life) {
        this.life = life;
    }

    public void Set_Stock(int stock) {
        this.stock = stock;
    }


}
