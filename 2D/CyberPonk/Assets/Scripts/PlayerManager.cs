using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float RELOAD_TIME = 1f;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public GameObject deathCat;
    public GameObject explosion;
    public SpriteRenderer sr;
    public Sprite boxOnly;

    private float cooldown = 0;
    bool isFired = true;
    bool isDead = false;

    void Update()
    {
        if (!GameManager.instance.isGameOver && GameManager.instance.isGameStarted)
        {
            float dt = Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                isFired = true;
            }

            if (isFired)
            {
                cooldown -= dt;
                if (cooldown <= 0)
                {
                    Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                    cooldown = RELOAD_TIME;
                    isFired = false;
                }
            }
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            StartCoroutine(PlayerDeath());
            isDead = true;
        }
            
    }

    public IEnumerator PlayerDeath()
    {
        DestroyAllBullets();
        GameManager.instance.isGameOver = true;
        sr.sprite = boxOnly;
        Instantiate(deathCat, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        for (int i = 0; i < 7; i++)
        {
            Vector2 p = bulletSpawnPoint.transform.position;
            float randomRange = 2f;
            Vector2 randomPoint = new Vector2(Random.Range(p.x - randomRange, p.x + randomRange), Random.Range(p.y - randomRange, p.y + randomRange));
            GameObject expl = Instantiate(explosion, randomPoint, bulletSpawnPoint.transform.rotation);
            Destroy(expl, 0.6f);
            yield return new WaitForSeconds(0.4f);
        }
        GameManager.instance.ShowUserDeathScreen();
    }

    private void DestroyAllBullets()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject b in bullets)
        {
            Destroy(b);
        }

    }
}
