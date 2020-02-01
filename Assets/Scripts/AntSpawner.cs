using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject antPrefab;
    public GameObject itemPrefab;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spawn ant");
            SpawnAnt();
        }
    }

    public void SpawnAnt() {
        int start, end;
        start = end = Random.Range(0, spawnPoints.Count);
        while (start == end)
            end = Random.Range(0, spawnPoints.Count);

        GameObject ant = Instantiate(antPrefab, spawnPoints[start].position, Quaternion.identity);
        GameObject item = Instantiate(itemPrefab, spawnPoints[end].position, Quaternion.identity);

        PathfindingMovement pathing = ant.GetComponent<PathfindingMovement>();
        if (pathing != null)
        {
            pathing.target = item.transform;
        }
    }
}