using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContllor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�폜");
            Destroy(gameObject);
        }
    }
}
