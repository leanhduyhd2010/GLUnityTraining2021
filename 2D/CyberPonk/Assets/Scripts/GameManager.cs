using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float HELICOPTER_SPAWN_TIME = 2f;
    public GameObject Helicopter;

    public static GameManager instance;

    Camera cam;
    private float helicopterSpawnXMin;
    private float helicopterSpawnXMax;
    private float helicopterSpawnYMin;
    private float helicopterSpawnYMax;
    private float helicopterSpawnTime = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(instance);

        cam = Camera.main;
    }
    void Start()
    {
        helicopterSpawnXMin = - cam.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x - 0.5f;
        helicopterSpawnXMax = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x + 0.5f;
        helicopterSpawnYMax = cam.ScreenToWorldPoint(new Vector3(0, Screen.height)).y;
        helicopterSpawnYMin = cam.ScreenToWorldPoint(new Vector3(0, Screen.height)).y - 2;
    }

    void Update()
    {
        if (helicopterSpawnTime < 0)
        {

            Instantiate(Helicopter, new Vector3(Random.Range(0f, 1f) > 0.5 ? helicopterSpawnXMax : helicopterSpawnXMin, Random.Range(helicopterSpawnYMin, helicopterSpawnYMax)), Helicopter.transform.rotation);
            helicopterSpawnTime = HELICOPTER_SPAWN_TIME;
        }

        helicopterSpawnTime -= Time.deltaTime;
    }
}
