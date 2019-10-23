using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePointCorrection  {

    /// <summary>
    /// 復活座標の修正、ちょっと重い
    /// </summary>
    /// <param name="revive_Point">元の座標</param>
    /// <returns>修正後の座標</returns>
	public static Vector2 Correct_Revive_Point(Vector2 revive_Point) {
        Vector2 point = revive_Point;
        //Rayを飛ばして、左側で最も近い地面を探す。
        while (revive_Point.x - point.x < 5000f) {
            RaycastHit2D hit = Physics2D.Raycast(point, new Vector2(0, -1), 64f);
            if(hit.collider) {
                if(hit.collider.tag == "GroundTag")
                    break;
            }
            point += new Vector2(-8f, 0);
        }
        return point;
    }
}
