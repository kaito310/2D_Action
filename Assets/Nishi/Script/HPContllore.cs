using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPContllore : MonoBehaviour
{
    [SerializeField] GameObject lifeObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLifeGauge(int life)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        //�@���݂̗̑͐����̃��C�t�Q�[�W���쐬
        for (int i = 0; i < life; i++)
        {
            Instantiate<GameObject>(lifeObj, transform);
        }
    }

    void SetLifeGauge2(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            //�@�Ō�̃��C�t�Q�[�W���폜
            Destroy(transform.GetChild(i).gameObject);
            //Destroy(transform.GetChild(transform.childCount - 1 - i).gameObject);
        }
    }
}
