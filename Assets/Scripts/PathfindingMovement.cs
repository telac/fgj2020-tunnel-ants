using UnityEngine;
using UnityEngine.AI;

public class PathfindingMovement : MonoBehaviour {
    public Transform target;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    private NavMeshAgent agent;
    
    private void Awake() {
        path = new NavMeshPath();
        elapsed = 0.0f;
        agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }

    private void Update() {
        // Update the way to the goal every second.
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
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
        
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
    }
}