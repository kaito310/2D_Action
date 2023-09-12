using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---プレイヤーキャラの剣の判定のスクリプト---
public class PlayerSlash : MonoBehaviour
{
    PlayerController _playerControllerScript;
    SpriteRenderer p_Sr;
    bool _srCheck; // プレイヤーの向き

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
        p_Sr = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        _srCheck = p_Sr.flipX;
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
            Debug.Log("表示");
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
