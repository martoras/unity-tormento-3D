using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject chestPrefab;
    [SerializeField] private int numberOfChests;
    
    private Vector3 spawnPosition = new Vector3(45.5f, 2.25f, 49.5f);
    private int columnSize = 48;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numberOfChests; i++)
        {
            Instantiate(chestPrefab, spawnPosition + new Vector3(-(i%columnSize)*2, 0, -Mathf.Floor(i/columnSize)*2), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
