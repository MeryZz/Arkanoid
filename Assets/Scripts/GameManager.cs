using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private int totalBlocks; // Total de bloques al inicio


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>(); // Usamos FindFirstObjectByType
            }
            return instance;
        }
    }


    public BlockSpawner blockSpawner; // Referencia al BlockSpawner
    public RandomSpawner randomSpawner; // Referencia al RandomSpawner


    void Awake()
    {
        // Espera para que BlockSpawner instancie los bloques iniciales
        Invoke("CountBlocks", 0.1f);
    }


    void CountBlocks()
    {
        GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("Block"); // Solo busca con tag "Block"
        totalBlocks = allBlocks.Length;
        Debug.Log("Bloques iniciales: " + totalBlocks);
    }


    public void BlockHidden()
    {
        totalBlocks--;
        Debug.Log("Bloques restantes: " + totalBlocks);
        if (totalBlocks <= 0)
        {
            LoadNextScene();
        }
    }


    private void LoadNextScene()
    {
        Debug.Log("¡Todos los bloques han sido destruidos!");
        // Cargar la siguiente escena Level2
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);  // Asegúrate de que "Level2" esté añadida en Build Settings
    }


    public void StartRandomSpawn()
    {
        randomSpawner.SpawnRandomBlocks(); // Llama a la función para generar bloques aleatorios
    }


    public void StopRandomSpawn()
    {
        randomSpawner.gameObject.SetActive(false);  // Desactiva el RandomSpawner si lo deseas
    }


    public void CheckBallOutOfBounds(GameObject ball)
    {
        if (ball.transform.position.y < -110)
        {
            ShowGameOver();
        }
    }


    private void ShowGameOver()
    {
        Debug.Log("Game Over");
        // Cargar la escena GameOver
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);  // Asegúrate de que "GameOver" esté añadida en Build Settings
    }
}
