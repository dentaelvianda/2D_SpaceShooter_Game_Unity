using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    Rigidbody2D rb;
    int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void ChangeColor(Color col)
    {
        GetComponent<SpriteRenderer>().color = col;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -10 * dir);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(dir == 1)
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerMovement>().Damage();
                Destroy(gameObject);
            }
        }
       
    }
}
        
