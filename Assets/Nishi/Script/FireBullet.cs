using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] GameObject firingPoint;
    [SerializeField] GameObject Bullet;
    [SerializeField] float speed = 30f;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            LauncherShot(); //‹Ê‚ð”­ŽË‚·‚é
        }
    }

    private void LauncherShot()
    {
        Vector2 BulletPosition = firingPoint.transform.position;
        GameObject newBall = Instantiate(Bullet, BulletPosition, transform.rotation);
        Vector2 direction = newBall.transform.right;
        newBall.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        newBall.name = Bullet.name;
        Destroy(newBall, 0.8f);
    }
}
