using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public float SPEED = 5f;
    public GameObject soldier;
    public GameObject explosion;
    public GameObject fragments;


    Vector3 direction;
    private float soldierSpawnPosX;
    private bool isSoldierSpawned = false;

    void Start()
    {
        soldierSpawnPosX = Random.Range(GameManager.instance.helicopterSpawnXMin, GameManager.instance.helicopterSpawnXMax);
        if (transform.position.x > 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
            direction = Vector3.left;
        }
        else 
        {
            direction = Vector3.right;
        } 
    }

    void Update()
    {
        transform.Translate(direction * SPEED * Time.deltaTime);
        
        if (transform.position.x >= soldierSpawnPosX - 0.1f && transform.position.x <= soldierSpawnPosX + 0.1f && !isSoldierSpawned)
        {
            Instantiate(soldier, transform.position, transform.rotation);
            isSoldierSpawned = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ++GameManager.instance.score;
        Destroy(gameObject);
        Destroy(collision.gameObject);
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(fragments, transform.position, transform.rotation);
        Destroy(expl, 0.6f);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
