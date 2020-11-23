using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileSpawner : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float safeZone=15.0f;
    private float tileLength = 12.0f;
    private int tilesOnScreen = 5;
    private int lastPrefabIndex = 0; 

    public List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone>(spawnZ-tilesOnScreen*tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
        
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[RandomIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);


    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
