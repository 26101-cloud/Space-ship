using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -7f)
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        } 
    }
}
