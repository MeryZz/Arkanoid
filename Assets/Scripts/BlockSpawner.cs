using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block_blue_0;
    public GameObject block_green_0;
    public GameObject block_pink_0;
    public GameObject block_red_0;
    public GameObject block_yellow_0;

    public int blocksPerRow = 10;
    public float startX = -90f;
    public float[] startYPositions = { 88f, 78f, 68f, 58f, 48f };
    public float blockSpacing = 100f;

    void Start()
    {
        SpawnInitialBlocks();
    }

    void SpawnInitialBlocks()
    {
        GameObject[] blocks = { block_blue_0, block_green_0, block_pink_0, block_red_0, block_yellow_0 };

        for (int row = 0; row < blocks.Length; row++)
        {
            float yPosition = startYPositions[row];
            for (int i = 0; i < blocksPerRow; i++)
            {
                Vector3 position = new Vector3(startX + i * blockSpacing, yPosition, 0);
                GameObject block = Instantiate(blocks[row], position, Quaternion.identity);
                block.transform.localScale = new Vector3(100f, 100f, 1f);
                block.tag = "Block"; // Asignamos el tag "Block" a los bloques instanciados
            }
        }
    }
}
