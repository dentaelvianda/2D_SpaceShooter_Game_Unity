using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int delay = 0;
    GameObject SpawnBlt;
    public GameObject bullet,explosion;
    Rigidbody2D rb;
    public float speed;
    Vector2 playerMovement;
    public float fireRate;
    public int health = 3;
    [SerializeField] private AudioClip laserSoundClip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpawnBlt = transform.Find("Bullet_Spawner").gameObject;
        PlayerPrefs.SetInt("Health", health);

    }

    // Update is called once per frame
    void Update()
    {
        playerMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized*speed ;
        if (Input.GetKey(KeyCode.Space) && delay > fireRate)
        {
            Shoot();

        }
        delay++;

    }
    private void FixedUpdate()
    {
        rb.AddForce(playerMovement);
       
    }
    public void Damage()
    {
        health--;
        PlayerPrefs.SetInt("Health", health);
        StartCoroutine(Blink());
        if(health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject,0.1f);
        }
    }
    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
    void Shoot()
    {
        delay = 0;
        Instantiate(bullet,SpawnBlt.transform.position, Quaternion.identity);
       
        SoundFXManager.instance.PlaySoundFXClip(laserSoundClip, transform, 1f);
    }
    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }
}
