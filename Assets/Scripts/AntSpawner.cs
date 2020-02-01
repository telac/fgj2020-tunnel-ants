using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<Transform> itemPositions;
    public GameObject antPrefab;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Spawn ant");
            SpawnAnt();
        }
    }

    public void SpawnAnt() {
        GameObject ant = Instantiate(antPrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
        PathfindingMovement pathing = ant.GetComponent<PathfindingMovement>();
        GameObject item;

        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            item = Instantiate(item1, itemPositions[Random.Range(0, itemPositions.Count)].position, Quaternion.identity);
            if (pathing != null)
                pathing.goGetItem = PathfindingMovement.Item.Baby;
        }
        else if (rand == 1)
        {
            item = Instantiate(item2, itemPositions[Random.Range(0, itemPositions.Count)].position, Quaternion.identity);
            if (pathing != null)
                pathing.goGetItem = PathfindingMovement.Item.Blueb;
        }
        else if (rand == 2)
        {
            item = Instantiate(item3, itemPositions[Random.Range(0, itemPositions.Count)].position, Quaternion.identity);
            if (pathing != null)
                pathing.goGetItem = PathfindingMovement.Item.Leaf;
        }
        else
        {
            item = Instantiate(item4, itemPositions[Random.Range(0, itemPositions.Count)].position, Quaternion.identity);
            if (pathing != null)
                pathing.goGetItem = PathfindingMovement.Item.Strawb;
        }
        
        if (pathing != null)
            pathing.target = item.transform;
    }
}