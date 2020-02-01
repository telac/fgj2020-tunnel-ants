using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairController : MonoBehaviour
{
    public float repairSpeed;
    //public Text repairTextStatus;
    public Sprite halfState;
    public Sprite quarterState;

    private float _repairState;
    private RepairManager _repairManager;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void Awake() {
        GameManager gameManager = GameManager.Instance;
        Debug.Log(this.gameObject.name + " ", gameManager);
        _repairManager = gameManager.GetComponent<RepairManager>();
        _repairState = 1.0f;
    }


    // Update is called once per frame
    private void Update()
    {

    }

    public void StartRepair() {
        StartCoroutine(Repair());
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            _repairState = 0.0f;
            _repairManager.EnqueueObject(this.gameObject);
        }
    }

    IEnumerator Repair() {
        while(_repairState <= 1.0f) {
            _repairState += repairSpeed;
            float _repairPercentage = _repairState * 100;
            //repairTextStatus.text = _repairPercentage.ToString();
            yield return new WaitForSeconds(0.5f);
            if (_repairState > 0.33 && _repairState < 0.66) {
                GetComponentInChildren<SpriteRenderer>().sprite = halfState;
            } else if (_repairState > 0.66) {
                GetComponentInChildren<SpriteRenderer>().sprite = quarterState;
            }
        }
        _repairManager.repairQueue.Dequeue();
        //repairTextStatus.text = "Not repairing";
        // send message to event manager that repair is complete
        _repairManager.RepairNextObject();
        Destroy(gameObject);
    }
}
