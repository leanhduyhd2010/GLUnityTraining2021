using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{

    public float EXPLOSION_FORCE = 100f;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.Log("Null");
    }
    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * EXPLOSION_FORCE);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.layer = 7;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
