using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----enemyを左右に動かすスクリプト----
public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] float speed;
    float elapsedTime; // 経過時間

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime == 0)
        {
            elapsedTime += 1;
        }
        if (elapsedTime < 10)
        {
            transform.Translate(new Vector2(speed, 0) * Time.deltaTime);    
        }
        if (elapsedTime == 10)
        {
            elapsedTime -= 1;
        }
        if (elapsedTime > 10)
        {
            transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);
        }
    }
}
