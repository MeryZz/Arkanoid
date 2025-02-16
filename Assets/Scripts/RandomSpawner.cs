using UnityEngine;


public class RandomSpawner : MonoBehaviour
{
    public GameObject block_blue_0;
    public GameObject block_green_0;
    public GameObject block_pink_0;
    public GameObject block_red_0;
    public GameObject block_yellow_0;


    public int totalRandomBlocks = 10; // Número total de bloques aleatorios a generar
    public float startX = -90f; // Posición inicial en X
    public float[] startYPositions = { 88f, 78f, 68f, 58f, 48f }; // Alturas de las filas de bloques
    public float blockSpacing = 100f; // Espaciado entre bloques en la fila


    // Método público para generar bloques aleatorios
    public void SpawnRandomBlocks()
    {
        // Eliminar o desactivar los bloques iniciales
        GameObject[] existingBlocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in existingBlocks)
        {
            Destroy(block); // Destruimos los bloques anteriores
        }


        // Arreglo de bloques que pueden ser instanciados
        GameObject[] blocks = { block_blue_0, block_green_0, block_pink_0, block_red_0, block_yellow_0 };


        // Asegurémonos de que generemos 10 bloques aleatorios
        for (int i = 0; i < totalRandomBlocks; i++)
        {
            // Selección aleatoria de fila
            int randomRow = Random.Range(0, startYPositions.Length);  // Elegir una fila aleatoria


            // Selección aleatoria de columna (con un total de 10 columnas posibles)
            int randomCol = Random.Range(0, 10);  // 10 posibles columnas


            // Cálculo de la posición X y Y para instanciar el bloque
            float xPosition = startX + randomCol * blockSpacing;
            float yPosition = startYPositions[randomRow];


            // Selección aleatoria del color del bloque (puede repetirse)
            int randomColorIndex = Random.Range(0, blocks.Length); // Elegir un bloque aleatorio


            // Instanciar el bloque en la posición calculada
            GameObject block = Instantiate(blocks[randomColorIndex], new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            block.transform.localScale = new Vector3(100f, 100f, 1f);  // Escala del bloque
            block.tag = "Block"; // Asignamos el tag "Block" a los bloques instanciados
        }
    }
}
