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
        StartCoroutine(StartSpawningRocks());
    }

    IEnumerator StartSpawningRocks() {
        while(true) {
            float _waitTime = Random.Range(0.0f, 5.0f);
            yield return new WaitForSeconds(_waitTime);
            SpawnRock();
        }
    }
    void SpawnRock() {
        int i = Random.Range(0, rockSpawnPoints.Count);
        Instantiate(rockPrefab, rockSpawnPoints[i].position, rockPrefab.transform.rotation);
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
