using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isHidden = false;
    private GameManager gameManager;

    // Añadimos una variable pública para el sistema de partículas
    public ParticleSystem explosionEffect;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isHidden)
        {
            TriggerExplosion(); // Activar efecto de partículas
            HideBlock();
            gameManager.BlockHidden();

            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddPoints(10);
            }
        }
    }

    private void HideBlock()
    {
        isHidden = true;
        gameObject.SetActive(false);
    }

    // Método para instanciar el efecto de partículas
    private void TriggerExplosion()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
    }
}
