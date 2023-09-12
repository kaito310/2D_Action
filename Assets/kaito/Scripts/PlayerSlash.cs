using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---プレイヤーキャラの剣の判定のスクリプト---
public class PlayerSlash : MonoBehaviour
{
    PlayerController _playerControllerScript;
    [SerializeField] BoxCollider2D _bo2d; // コライダーの表示・非表示変更用
    [SerializeField] GameObject _player;
    float _offset; // プレイヤー位置からの相対距離（y座標）

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
        _offset = transform.position.y - _player.transform.position.y;
    }

    void Update()
    {
        Slash();
    }

    // 判定の表示・非表示を切り替える関数
    void Slash()
    {
        Vector2 _pos = transform.position; // オブジェクトの座標を変数に一旦格納
        // y座標に変数_offsetの値を加え、変数_posのy座標に代入
        _pos.y = _player.transform.position.y + _offset;
        transform.position = _pos; // 変数_posの値をオブジェクト座標に格納

        if (!_playerControllerScript.isDead)
        {
            // 銃を取得していないかつ、Wキーを押していれば
            if (_playerControllerScript.isGun == false && Input.GetKey(KeyCode.W))
            {
                _bo2d.enabled = true; // コライダーを取得
            }
            else
            {
                _bo2d.enabled = false;
            }
        }
    }
}
