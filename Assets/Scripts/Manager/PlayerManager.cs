using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager> {

    //ステータス
    //絶対にSetter, Getterとかを使うこと
    private int life = 3;
    private int stock = 2;
    private int beetle_Power = 0;


    //Reduce
    public int Reduce_Life() {
        life--;
        if(life == 0) {
            GameManager.Instance.Miss();
        }
        return life;
    }

    public int Reduce_Stock() {
        stock--;
        if (stock == -1) {
            GameManager.Instance.Game_Over();
        }
        return stock;
    }

    //Add
    public void Add_Life() {
        life++;
    }
    
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

    public int Get_Beetle_Power() {
        return beetle_Power;
    }

    //Setter
    public void Set_Life(int life) {
        if (life >= 0) {
            this.life = life;
        }
        if (life == 0) {
            GameManager.Instance.Miss();
        }
    }

    public void Set_Stock(int stock) {        
        if (stock >= -1) {
            this.stock = stock;
        }
        if (stock == -1) {
            GameManager.Instance.Game_Over();
        }
    }

    public void Set_Beetle_Power(int beetle_Power) {
        if(beetle_Power < 0) {
            beetle_Power = 0;
        }
        else if(beetle_Power > 100) {
            beetle_Power = 100;
        }
        this.beetle_Power = beetle_Power;
    }

}
