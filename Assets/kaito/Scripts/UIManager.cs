using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//---UIを管理するためのスクリプト---
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _gameClearUI;
    [SerializeField] GameObject _gameOverUI;

    bool _isGameClear = false; // ゲームクリアしてるか判別のため
    bool _isGameOver = false;

    PlayerController _playerControllerScript; // プレイヤーキャラのスクリプト

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
        _gameClearUI.SetActive(false);
        _gameOverUI.SetActive(false);
    }

    void Update()
    {
        // ゲームクリアの処理
        if (!_isGameClear)
        {
            if (_playerControllerScript.isClear)
            {
                _gameClearUI.SetActive(true);
                _isGameClear = true;
            }
        }

        // ゲームオーバーの処理
        if (!_isGameOver)
        {
            if (_playerControllerScript.isDead)
            {
                _gameOverUI.SetActive(true);
                _isGameOver = true;
            }
        }
    }

    public void RetryButton() // リトライボタンが押されたら
    {
        SceneManager.LoadScene("MainGame"); // ゲームの再読み込み
    }
}
