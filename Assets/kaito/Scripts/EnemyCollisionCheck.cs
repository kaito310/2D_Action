using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---敵がステージや他の敵に当たったか判定するスクリプト---
public class EnemyCollisionCheck : MonoBehaviour
{
    [HideInInspector] public bool _isOn = false; // 何かに接触したかどうか

    string _stageTag = "Stage";
    string _enemyTag = "Enemy";
    string _wallTag = "HiddenWall";
    string _playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision) // 接触したとき
    {
        // StageタグかEnemyタグかHiddenWallタグかPlayerタグを持つオブジェクトなら
        if (collision.tag == _stageTag || collision.tag == _enemyTag || collision.tag == _wallTag || collision.tag == _playerTag)
        {
            _isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // 接触が終わったら
    {
        if (collision.tag == _stageTag || collision.tag == _enemyTag || collision.tag == _wallTag)
        {
            _isOn = false;
        }
    }
}
