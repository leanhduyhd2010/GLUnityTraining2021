using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float HELICOPTER_SPAWN_TIME = 2f;
    public GameObject Helicopter;
    public BoxCollider2D ground;
    public GameObject scoreBoard;
    public TextMeshProUGUI scoreText;

    public static GameManager instance;

    
    public float helicopterSpawnXMin;
    public float helicopterSpawnXMax;
    public float helicopterSpawnYMin;
    public float helicopterSpawnYMax;

    public float score = 0;
    Camera cam;
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

        ground.size = new Vector2(cam.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x * 3f, 1f);
        ground.offset = new Vector2(0, -cam.ScreenToWorldPoint(new Vector3(0, Screen.height)).y - 0.5f);
        scoreBoard.transform.position = new Vector3(-cam.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x + scoreBoard.GetComponent<Renderer>().bounds.size.x / 2, -cam.ScreenToWorldPoint(new Vector3(0, Screen.height)).y + scoreBoard.GetComponent<Renderer>().bounds.size.y / 2);
    }

    void Update()
    {
        scoreText.text = score.ToString();

        if (helicopterSpawnTime < 0)
        {

            Instantiate(Helicopter, new Vector3(Random.Range(0f, 1f) > 0.5 ? helicopterSpawnXMax : helicopterSpawnXMin, Random.Range(helicopterSpawnYMin, helicopterSpawnYMax)), Helicopter.transform.rotation);
            helicopterSpawnTime = HELICOPTER_SPAWN_TIME;
        }

        helicopterSpawnTime -= Time.deltaTime;
    }
}
