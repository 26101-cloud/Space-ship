using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public float speed = 8f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, 0f);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        if (transform.position.x < -3f)
        {
            transform.position = new Vector2(3f, transform.position.y);
        }
        else if (transform.position.x > 3f)
        {
            transform.position = new Vector2(-3f, transform.position.y);
        }
    }
}
