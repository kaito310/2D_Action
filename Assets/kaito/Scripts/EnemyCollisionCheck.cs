using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---敵が壁や敵に当たったか判定するスクリプト---
public class EnemyCollisionCheck : MonoBehaviour
{
    [HideInInspector] public bool _isOn = false; // 何かに接触したかどうか

    string _wallTag = "Wall";
    string _enemyTag = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision) // 接触したとき
    {
        // WallタグかEnemyタグを持つオブジェクトなら
        if (collision.tag == _wallTag || collision.tag == _enemyTag)
        {
            _isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // 接触が終わったら
    {
        if (collision.tag == _wallTag || collision.tag == _enemyTag)
        {
            _isOn = false;
        }
    }
}
