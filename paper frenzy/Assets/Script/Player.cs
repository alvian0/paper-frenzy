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

    Rigidbody2D rb;
    Vector2 movement;
    float currentSpeed;

    bool multiple = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = Speed;
    }

    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement = move.normalized * Speed;

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
            multipleMater.fillAmount -= Time.deltaTime / 3;

            if(multipleMater.fillAmount <= 0)
            {
                multiple = false;
                manager.ScoreMultiple = 1;
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
            Destroy(collision.gameObject);
            //transform.localScale += new Vector3(size, size, 0);
            manager.progresbarupdate();

            if (multiple)
            {
                int i = manager.poin += 1 * manager.ScoreMultiple;
                manager.ScoreMultiple++;
                manager.poin = i;
                multipleMater.fillAmount = 1f;
            }

            else
            {
                manager.poin++;
                multiple = true;
                multipleMater.fillAmount = 1f;
            }
        }

        if (collision.tag == "killer")
        {
            Destroy(gameObject);
        }
    }
}
