using UnityEngine;

public class Bulletcontroller : MonoBehaviour
{
    [SerializeField] float speed = 14f;
    [SerializeField] ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed *  Time.deltaTime);
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _scoreManager.AddScore(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
