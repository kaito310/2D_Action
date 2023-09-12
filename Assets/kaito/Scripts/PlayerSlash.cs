using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---プレイヤーキャラの剣の判定のスクリプト---
public class PlayerSlash : MonoBehaviour
{
    PlayerController _playerControllerScript;
    [SerializeField] BoxCollider2D _bo2d; // コライダーの表示・非表示変更用

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
    }

    void Update()
    {
        Slash();
    }

    // 判定の表示・非表示を切り替える関数
    void Slash()
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
