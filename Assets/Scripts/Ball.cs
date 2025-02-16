using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float speed = 150.0f;
    private GameManager gameManager;
    public float speedIncrement = 20.0f; // Incremento de velocidad
    public float incrementInterval = 10.0f; // Intervalo de tiempo en segundos

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        float randomDirectionX = Random.Range(-1f, 1f);
        Vector2 initialDirection = new Vector2(randomDirectionX, 1).normalized;
        GetComponent<Rigidbody2D>().linearVelocity = initialDirection * speed;

        StartCoroutine(IncreaseSpeedOverTime()); // Inicia la corutina
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().linearVelocity = dir * speed;
        }
    }

    void Update()
    {
        gameManager.CheckBallOutOfBounds(gameObject);
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(incrementInterval);
            speed += speedIncrement;
            GetComponent<Rigidbody2D>().linearVelocity = GetComponent<Rigidbody2D>().linearVelocity.normalized * speed;
        }
    }
}
