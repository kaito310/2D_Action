using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPContllore : MonoBehaviour
{
    [SerializeField] GameObject lifeObj;
    [SerializeField] GameObject Player;
    private GameObject playerIcon;
    private PlayerController player;
    private int beforeHP;

    // Start is called before the first frame updat
    void Start()
    {
        //�yFindObjectOfType�z<>�Ŏw�肵���R���|�[�l���g�����Ă���I�u�W�F�N�g��
        //inspector��ʂ���T���ăR���|�[�l���g���擾����B
        player = FindObjectOfType<PlayerController>();
        beforeHP = player.GetHP();
        CreateHPIcon();

    }

    private void CreateHPIcon()
    {
        for (int i = 0; i < player.GetHP(); i++)
        {
            GameObject playerHPObj = Instantiate(playerIcon);
            playerHPObj.transform.parent = transform;

        }

    }

    // Update is called once per frame
    void Update()
    {
        ShowHPIcon();

    }

    private void ShowHPIcon()
    {
        if (beforeHP == player.GetHP()) return;

        Image[] icons = transform.GetComponentsInChildren<Image>();
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].gameObject.SetActive(i < player.GetHP());

        }
        beforeHP = player.GetHP();
    }
}
