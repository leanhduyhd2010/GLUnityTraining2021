using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float RUN_SPEED = 2f;
    public float FLY_SPEED = 2f;

    private bool isFlying = true;
    private Vector3 direction;
    void Start()
    {
        if (transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            direction = Vector3.left;
        }
        else direction = Vector3.right;
    }

    void Update()
    {
        if (!isFlying)
        {
            animator.SetBool("Flying", isFlying);
            transform.Translate(direction * RUN_SPEED * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * FLY_SPEED * Time.deltaTime);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFlying = false;
        }
    }
}
