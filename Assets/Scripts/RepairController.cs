using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{
    public float repairSpeed;

    private float _repairState;
    private bool _underRepair;
    // Start is called before the first frame update
    private void Start()
    {
        _repairState = 1.0f;
        _underRepair = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_underRepair) {
            _repairState += repairSpeed;
            if (_repairState >= 1.0f) {
                _underRepair = false;
                // send message to event manager that repair is complete
            }
        }
    }

    public void StartRepair() {
        _underRepair = true;
    }

    public void StopRepair() {
        _underRepair = false;
    }
}
