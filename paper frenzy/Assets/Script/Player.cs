using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed;
    public float size = 1f;
    public GameManager manager;
    public Image multipleMater;
    public GameObject MultiMater;
    public int Phase = 1;

    public Animator anim;
    Rigidbody2D rb;
    Vector2 movement;
    float currentSpeed;

    Vector3 size1,size2,size3;

    bool multiple = false;

    void Start()
    {
        size1 = new Vector3(.4f, .4f, 1f);
        size2 = new Vector3(.7f, .7f, 1f);
        size3 = new Vector3(1f, 1f, 1f);
        transform.localScale = size1;
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = Speed;
    }

    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement = move.normalized * Speed;

        if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            transform.localScale = new Vector3(-size1.x, size1.y);
        }

        if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            transform.localScale = new Vector3(size1.x, size1.y);
        }

        if (Input.GetMouseButton(1))
        {
            Speed = currentSpeed * 1.5f;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Speed = currentSpeed;
        }

        if (multiple)
        {
            MultiMater.SetActive(true);
            multipleMater.fillAmount -= Time.deltaTime / 3;

            if(multipleMater.fillAmount <= 0)
            {
                multiple = false;
                manager.ScoreMultiple = 1;
                MultiMater.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {
            if (manager.CurrentProgress >= 0.33)
            {
                NextPhase(true);
            }

            if (manager.CurrentProgress >= 0.66)
            {
                NextPhase(false);
            }

            if (collision.gameObject.GetComponent<Fish>().size <= Phase)
            {
                manager.progresbarupdate(.01f);
                anim.SetTrigger("Eat");
                Destroy(collision.gameObject);
            }

            else
            {
                if (collision.gameObject.GetComponent<Fish>().anim != null)
                {
                    collision.gameObject.GetComponent<Fish>().anim.SetTrigger("Eat");
                }

                Destroy(gameObject);
            }


            if (multiple)
            {
                manager.ScoreMultiple++;
                int i = manager.poin += 100 * manager.ScoreMultiple;
                manager.poin = i;
                multipleMater.fillAmount = 1f;
            }

            else
            {
                manager.poin += 100;
                multiple = true;
                multipleMater.fillAmount = 1f;
            }
        }

        if (collision.tag == "killer")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Offset")
        {
            Destroy(gameObject);
        }
    }

    void NextPhase(bool Phase2)
    {
        if (Phase2)
        {
            transform.localScale = size2;
            size1 = size2;
        }

        if (!Phase2)
        {
            transform.localScale = size3;
            size1 = size3;
        }
    }
}
