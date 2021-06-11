using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public float SPEED = 5f;
    public GameObject soldier;


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
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
