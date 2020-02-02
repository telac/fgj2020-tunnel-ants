using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RepairController : MonoBehaviour
{
    public enum Dir {North, East, South, West};

    public float repairSpeed;
    //public Text repairTextStatus;
    public Sprite halfState;
    public Sprite quarterState;

    private float _repairState;
    private RepairManager _repairManager;

    public GameObject ant1;
    public GameObject ant2;
    public GameObject ant3;
    private Dir ant1Dir;
    private Dir ant2Dir;
    private Dir ant3Dir;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void Awake() {
        GameManager gameManager = GameManager.Instance;
        //Debug.Log(this.gameObject.name + " ", gameManager);
        _repairManager = gameManager.GetComponent<RepairManager>();
        _repairState = 1.0f;
        MoveMiniAnt(1, true);
        MoveMiniAnt(2, true);
        MoveMiniAnt(3, true);
        ant1.SetActive(false);
        ant2.SetActive(false);
        ant3.SetActive(false);
    }


    // Update is called once per frame
    private void Update()
    {
        UpdateMiniAnt(1);
        UpdateMiniAnt(2);
        UpdateMiniAnt(3);
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
        ant1.SetActive(true);
        ant2.SetActive(true);
        ant3.SetActive(true);
        while (_repairState <= 1.0f) {
            _repairState += repairSpeed;
            float _repairPercentage = _repairState * 100;
            //repairTextStatus.text = _repairPercentage.ToString();
            yield return new WaitForSeconds(0.15f);
            if (_repairState > 0.33 && _repairState < 0.66) {
                GetComponentInChildren<SpriteRenderer>().sprite = halfState;
            } else if (_repairState > 0.66) {
                GetComponentInChildren<SpriteRenderer>().sprite = quarterState;
            }
        }
        if (_repairManager.repairQueue.Count > 0)
            _repairManager.repairQueue.Dequeue();
        //repairTextStatus.text = "Not repairing";
        // send message to event manager that repair is complete
        _repairManager.RepairNextObject();
        Destroy(gameObject);
    }

    private void UpdateMiniAnt(int index)
    {
        if (index == 1)
        {
            if (ant1Dir == Dir.North)
            {
                ant1.transform.localPosition += new Vector3(1.0f, 0f, 0f) * Time.deltaTime;
                if (ant1.transform.localPosition.x > 1.0f)
                    MoveMiniAnt(1);
            }
            else if (ant1Dir == Dir.East)
            {
                ant1.transform.localPosition += new Vector3(0f, -1.0f, 0f) * Time.deltaTime;
                if (ant1.transform.localPosition.y < -1.0f)
                    MoveMiniAnt(1);
            }
            else if (ant1Dir == Dir.South)
            {
                ant1.transform.localPosition += new Vector3(-1.0f, 0f, 0f) * Time.deltaTime;
                if (ant1.transform.localPosition.x < -1.0f)
                    MoveMiniAnt(1);
            }
            else
            {
                ant1.transform.localPosition += new Vector3(0f, 1.0f, 0f) * Time.deltaTime;
                if (ant1.transform.localPosition.y > 1.0f)
                    MoveMiniAnt(1);
            }
        }
        else if (index == 2)
        {
            if (ant2Dir == Dir.North)
            {
                ant2.transform.localPosition += new Vector3(1.0f, 0f, 0f) * Time.deltaTime;
                if (ant2.transform.localPosition.x > 1.0f)
                    MoveMiniAnt(2);
            }
            else if (ant2Dir == Dir.East)
            {
                ant2.transform.localPosition += new Vector3(0f, -1.0f, 0f) * Time.deltaTime;
                if (ant2.transform.localPosition.y < -1.0f)
                    MoveMiniAnt(2);
            }
            else if (ant2Dir == Dir.South)
            {
                ant2.transform.localPosition += new Vector3(-1.0f, 0f, 0f) * Time.deltaTime;
                if (ant2.transform.localPosition.x < -1.0f)
                    MoveMiniAnt(2);
            }
            else
            {
                ant2.transform.localPosition += new Vector3(0f, 1.0f, 0f) * Time.deltaTime;
                if (ant2.transform.localPosition.y > 1.0f)
                    MoveMiniAnt(2);
            }
        }
        else
        {
            if (ant3Dir == Dir.North)
            {
                ant3.transform.localPosition += new Vector3(1.0f, 0f, 0f) * Time.deltaTime;
                if (ant3.transform.localPosition.x > 1.0f)
                    MoveMiniAnt(3);
            }
            else if (ant3Dir == Dir.East)
            {
                ant3.transform.localPosition += new Vector3(0f, -1.0f, 0f) * Time.deltaTime;
                if (ant3.transform.localPosition.y < -1.0f)
                    MoveMiniAnt(3);
            }
            else if (ant3Dir == Dir.South)
            {
                ant3.transform.localPosition += new Vector3(-1.0f, 0f, 0f) * Time.deltaTime;
                if (ant3.transform.localPosition.x < -1.0f)
                    MoveMiniAnt(3);
            }
            else
            {
                ant3.transform.localPosition += new Vector3(0f, 1.0f, 0f) * Time.deltaTime;
                if (ant3.transform.localPosition.y > 1.0f)
                    MoveMiniAnt(3);
            }
        }
    }

    private void MoveMiniAnt(int index, bool first = false) {
        if (index == 1)
        {
            ant1Dir = (Dir)Random.Range(0, 4);
            if (ant1Dir == Dir.North)
            {
                if (first)
                    ant1.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant1.transform.localPosition = new Vector3(-1.0f, Random.Range(-1f, 1f), -0.2f);
                ant1.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (ant1Dir == Dir.East)
            {
                if (first)
                    ant1.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant1.transform.localPosition = new Vector3(Random.Range(-1f, 1f), 1.0f, -0.2f);
                ant1.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (ant1Dir == Dir.South)
            {
                if (first)
                    ant1.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant1.transform.localPosition = new Vector3(1.0f, Random.Range(-1f, 1f), -0.2f);
                ant1.transform.localRotation = Quaternion.Euler(0, 0, 270);
            }
            else
            {
                if (first)
                    ant1.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant1.transform.localPosition = new Vector3(Random.Range(-1f, 1f), -1.0f, -0.2f);
                ant1.transform.localRotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else if (index == 2)
        {
            ant2Dir = (Dir)Random.Range(0, 4);
            if (ant2Dir == Dir.North)
            {
                if (first)
                    ant2.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant2.transform.localPosition = new Vector3(-1.0f, Random.Range(-1f, 1f), -0.2f);
                ant2.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (ant2Dir == Dir.East)
            {
                if (first)
                    ant2.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant2.transform.localPosition = new Vector3(Random.Range(-1f, 1f), 1.0f, -0.2f);
                ant2.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (ant2Dir == Dir.South)
            {
                if (first)
                    ant2.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant2.transform.localPosition = new Vector3(1.0f, Random.Range(-1f, 1f), -0.2f);
                ant2.transform.localRotation = Quaternion.Euler(0, 0, 270);
            }
            else
            {
                if (first)
                    ant2.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant2.transform.localPosition = new Vector3(Random.Range(-1f, 1f), -1.0f, -0.2f);
                ant2.transform.localRotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else
        {
            ant3Dir = (Dir)Random.Range(0, 4);
            if (ant3Dir == Dir.North)
            {
                if (first)
                    ant3.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant3.transform.localPosition = new Vector3(-1.0f, Random.Range(-1f, 1f), -0.2f);
                ant3.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (ant3Dir == Dir.East)
            {
                if (first)
                    ant3.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant3.transform.localPosition = new Vector3(Random.Range(-1f, 1f), 1.0f, -0.2f);
                ant3.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (ant3Dir == Dir.South)
            {
                if (first)
                    ant3.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant3.transform.localPosition = new Vector3(1.0f, Random.Range(-1f, 1f), -0.2f);
                ant3.transform.localRotation = Quaternion.Euler(0, 0, 270);
            }
            else
            {
                if (first)
                    ant3.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -0.2f);
                else
                    ant3.transform.localPosition = new Vector3(Random.Range(-1f, 1f), -1.0f, -0.2f);
                ant3.transform.localRotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}
