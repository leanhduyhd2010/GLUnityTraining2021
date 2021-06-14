using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BULLET_SPEED = 5f;
    public Rigidbody2D rb;
    public GameObject smoke;

    Camera cam;
    bool isFired = false;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!isFired)
        {
            Vector2 startPoint = gameObject.transform.position;
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(mousePos.x - startPoint.x, mousePos.y - startPoint.y) * Mathf.Rad2Deg;
            if (angle < -90) angle = -90;
            if (angle > 90) angle = 90;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            if (Input.GetMouseButtonDown(0))
            {
                isFired = true;
                smoke.SetActive(true);
                Vector2 endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 force = new Vector2(endPoint.x - startPoint.x, endPoint.y - startPoint.y).normalized;
                if (force.y < 0) force.y = 0;
                rb.AddForce(force * BULLET_SPEED, ForceMode2D.Impulse);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
