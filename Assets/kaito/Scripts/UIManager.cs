using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//---UI���Ǘ����邽�߂̃X�N���v�g---
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _gameClearUI;
    [SerializeField] GameObject _gameOverUI;

    bool _isGameClear = false; // �Q�[���N���A���Ă邩���ʂ̂���
    bool _isGameOver = false;

    PlayerController _playerControllerScript; // �v���C���[�L�����̃X�N���v�g

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
        _gameClearUI.SetActive(false);
        _gameOverUI.SetActive(false);
    }

    void Update()
    {
        // �Q�[���N���A�̏���
        if (!_isGameClear)
        {
            if (_playerControllerScript.isClear)
            {
                _gameClearUI.SetActive(true);
                _isGameClear = true;
            }
        }

        // �Q�[���I�[�o�[�̏���
        if (!_isGameOver)
        {
            if (_playerControllerScript.isDead)
            {
                _gameOverUI.SetActive(true);
                _isGameOver = true;
            }
        }
    }

    public void RetryButton() // ���g���C�{�^���������ꂽ��
    {
        SceneManager.LoadScene("MainGame"); // �Q�[���̍ēǂݍ���
    }
}
