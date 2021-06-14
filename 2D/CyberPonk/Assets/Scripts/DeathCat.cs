using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCat : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 400f));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
