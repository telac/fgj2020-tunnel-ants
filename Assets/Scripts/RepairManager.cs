using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairManager : MonoBehaviour
{
    public Queue<GameObject> repairQueue = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }
    public void EnqueueObject(GameObject repairableObject) {
        repairQueue.Enqueue(repairableObject);
        if (repairQueue.Count == 1) {
            RepairNextObject();
        }
        //Debug.Log("currently   " + repairQueue.Count + "   objects to repair");
    }

    public void RepairNextObject() {
        if (repairQueue.Count > 0) {
            GameObject _currentlyRepaired = repairQueue.Peek();
            if (_currentlyRepaired == null) {
                return;
            } else {
            _currentlyRepaired.GetComponent<RepairController>().StartRepair();
            }
        } else {
            Debug.Log("no objects to repair");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
