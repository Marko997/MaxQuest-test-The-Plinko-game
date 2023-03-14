using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject circlePrefab;//obstacle
    [SerializeField] private GameObject circleParent;

    [SerializeField] private Button playButton;

    public float spawnInterval = 1f;
    private float timeSinceLastSpawn = 0f;

    private Vector2 spawnPosition = new Vector2(-3,4);

    public int pyramidHeight = 10; // The number of rows in the pyramid
    public float circleSpacing = 0.5f; // The spacing between circles

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonPressed);

        SpawnCirclePyramid(new Vector2(-3.2f,5f));
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
    }

    private void OnPlayButtonPressed()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // Spawn a circle if enough time has passed
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPlayer();
            timeSinceLastSpawn = 0f;
        }
        
    }

    private void SpawnPlayer()
    {
        Instantiate(player, spawnPosition, Quaternion.identity);
    }

    void SpawnCirclePyramid(Vector2 centerPosition)
    {
        for (int row = 2; row < pyramidHeight; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                // Calculate the position of the circle based on its row and column
                float xPos = centerPosition.x + (col - row / 2f) * circleSpacing;
                float yPos = centerPosition.y - row * circleSpacing;
                Vector2 circlePosition = new Vector2(xPos, yPos);

                // Spawn the circle prefab at the calculated position
                GameObject circle = Instantiate(circlePrefab, circlePosition, Quaternion.identity);

                // Set the circle's parent to this object so it moves with it
                circle.transform.parent = circleParent.transform;
            }
        }
    }
}
