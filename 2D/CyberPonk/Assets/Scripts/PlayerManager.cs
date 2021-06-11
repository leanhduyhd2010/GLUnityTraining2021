using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float RELOAD_TIME = 1f;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    private float cooldown;
    bool isFired = false;
    void Start()
    {
        Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        cooldown = RELOAD_TIME;
    }

    // Update is called once per frame
    void Update()
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