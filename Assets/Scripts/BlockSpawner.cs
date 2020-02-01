using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockSpawner : MonoBehaviour

{

    public List<Transform> rockSpawnPoints;
    public GameObject rockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {

    }

    void SpawnRock() {
        int i = Random.Range(0, rockSpawnPoints.Count);
        Debug.Log(i);
        Instantiate(rockPrefab, rockSpawnPoints[1].position, rockPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("Spawn ant");
            SpawnRock();
        }
    }
}
