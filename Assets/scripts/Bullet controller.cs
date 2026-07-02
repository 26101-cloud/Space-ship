using UnityEngine;

public class Bulletcontroller : MonoBehaviour
{
    [SerializeField] float speed = 14f;
    void Update()
    {
        transform.Translate(Vector2.up * speed *  Time.deltaTime);
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
