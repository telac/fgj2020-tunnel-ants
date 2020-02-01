using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PathfindingMovement : MonoBehaviour {
    public Transform target;
    private Vector3 startPos;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    private NavMeshAgent agent;
    public GameObject resizer;

    public enum Item {Empty, Baby, Blueb, Leaf, Strawb};
    private Item currentItem = Item.Empty;
    public Item goGetItem = Item.Empty;

    public GameObject wantBaby;
    public GameObject wantBlueB;
    public GameObject wantLeaf;
    public GameObject wantStrawb;
    public GameObject carryBaby;
    public GameObject carryBlueB;
    public GameObject carryLeaf;
    public GameObject carryStrawb;

    private void Awake() {
        startPos = transform.position;
        path = new NavMeshPath();
        elapsed = 0.0f;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdateIcon());
    }

    private IEnumerator UpdateIcon()
    {
        yield return null;
        wantBaby.SetActive(false);
        wantBlueB.SetActive(false);
        wantLeaf.SetActive(false);
        wantStrawb.SetActive(false);
        carryBaby.SetActive(false);
        carryBlueB.SetActive(false);
        carryLeaf.SetActive(false);
        carryStrawb.SetActive(false);
        if (currentItem == Item.Baby)
        {
            carryBaby.SetActive(true);
        } else if (currentItem == Item.Blueb)
        {
            carryBlueB.SetActive(true);
        }
        else if (currentItem == Item.Leaf)
        {
            carryLeaf.SetActive(true);
        }
        else if (currentItem == Item.Strawb)
        {
            carryStrawb.SetActive(true);
        } else
        {
            if (goGetItem == Item.Baby)
            {
                wantBaby.SetActive(true);
            } else if (goGetItem == Item.Blueb)
            {
                wantBlueB.SetActive(true);
            }
            else if (goGetItem == Item.Leaf)
            {
                wantLeaf.SetActive(true);
            }
            else if (goGetItem == Item.Strawb)
            {
                wantStrawb.SetActive(true);
            }
        }
    }

    private void ChangeDirection()
    {
        if (currentItem == Item.Empty)
        {
            currentItem = goGetItem;
            target.position = startPos;
            target.gameObject.SetActive(false);
            StartCoroutine(UpdateIcon());
        } else
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update() {
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        }
        if (path.status == UnityEngine.AI.NavMeshPathStatus.PathComplete) {
            agent.path = path;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < 1.0f)
        {
            ChangeDirection();
        }
        
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

        if (currentItem == Item.Empty)
        {
            float sin = (Mathf.Sin(Time.time) + 2.0f) * 0.25f;
            resizer.transform.localScale = new Vector3(0.75f + sin, 1.0f, 0.75f + sin);
        }
    }
}