using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int delay = 0;
    Rigidbody2D rb;
    public GameObject enemyBullet,explosion,healthItem;
    public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    public float fireRateMin;
    public float fireRateMax;
    public float health;
    GameObject spawnBlt;
    public Color bulletColor;
    public int score;
   
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnBlt = transform.Find("EnemyBullet_Spawner").gameObject;
       
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed,ySpeed*-1);
        if (canShoot && delay >Random.Range(fireRateMin,fireRateMax))
        {
            Shoot();
        }
        delay++;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerMovement>().Damage();
            Die();
        }
    }
    
    void Die()
    {
        if((int)Random.Range(0, 3) == 0)
        {
            Instantiate(healthItem, transform.position, Quaternion.identity);
        }
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }
    void Shoot()
    {
        delay = 0;
        Instantiate(enemyBullet, spawnBlt.transform.position, Quaternion.identity);
        enemyBullet.GetComponent<EnemyBulletController>().ChangeColor(bulletColor);
    }
}
