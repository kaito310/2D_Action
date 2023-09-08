using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jump = 1;
    [SerializeField] float gunTime = 1.0f;
    [SerializeField] float heatTime = 1.0f;
    [SerializeField] float flashInterval;
    [SerializeField] int loopCount;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject Item;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Image GUN;
    [SerializeField] Image Heat;

    [HideInInspector] public bool isjump = false;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool isHit = false;
    [HideInInspector] public bool isGun = false;
    [HideInInspector] public int HitCheck;
    [HideInInspector] public float hItTime;

    private Rigidbody2D _rd2D;
    private BoxCollider2D _bo2D;
    private float currentGunTime = 0f;
    private STATE state;

    // Start is called before the first frame update
    void Start()
    {
        _rd2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        _bo2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        if (isDead == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                sr.flipX = true;
                position.x -= speed * Time.deltaTime;
                if (Input.GetKey(KeyCode.D))
                {
                    position.x += speed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                sr.flipX = false;
                position.x += speed * Time.deltaTime;
                if (Input.GetKey(KeyCode.A))
                {
                    position.x -= speed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.Space) && !isjump)
            {
                _rd2D.velocity = Vector2.up * jump;
                isjump = true;
            }

            transform.position = position;
            if (isHit)
            {
                hItTime += Time.deltaTime;
            }
            if (hItTime >= 0.5f)
            {
                isHit = false;
                hItTime = 0;
                Debug.Log("HitTime = 0");
            }
            if (isGun)
            {
                if (Input.GetKeyDown(KeyCode.W)) //�ʂ𔭎˂���
                {
                    GameObject _Bullet = Instantiate(bullet) as GameObject;
                    _Bullet.transform.position = this.transform.position;
                    Destroy(_Bullet, 0.8f);
                }
            }
            if (state == STATE.DAMAGED)
            {
                return;
            }

            Fill();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            isjump = false;
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("E_Bullet"))
        {
            Debug.Log("�G�ƐڐG�����I");
            isHit = true;
            HitCheck++;
            state = STATE.DAMAGED;
            StartCoroutine(_hit()); //�R���[�`�����J�n
        }
        if (isDead == false)
        {
            if (HitCheck > 2)
            {
                isDead = true;
            }
        }
        if (other.gameObject.CompareTag("Gun"))
        {
            currentGunTime = gunTime;
            isGun = true;
            Destroy(Item);
        }
        if (isHit)
        {
            return;
        }
    }

    enum STATE
    {
        NOMAL,
        DAMAGED,
        MUTEKI
    }

    private void Fill()
    {
        currentGunTime -= Time.deltaTime;
        if (currentGunTime < 0) 
        {
            isGun = false;
        }
        GUN.fillAmount = currentGunTime / gunTime;
    }

    IEnumerator _hit() //�_�ł����鏈��
    {
        if(isDead) yield break;
        for (int i = 0; i < loopCount; i++) //�_�Ń��[�v�J�n
        {
            yield return new WaitForSeconds(flashInterval); //flashInterval�҂��Ă���
            sr.enabled = false; //spriteRenderer���I�t

            yield return new WaitForSeconds(flashInterval); //flashInterval�҂��Ă���
            sr.enabled = true; //spriteRenderer���I��
            if (i > 20)
            {
                state = STATE.MUTEKI;
            }
        }
        state = STATE.NOMAL;
        isHit = false;
    }
}