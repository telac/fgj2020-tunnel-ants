using UnityEngine;
using UnityEngine.AI;

public class SimpleMovement : MonoBehaviour {
    public Transform goal;
    private Vector3 oldPos;
    private NavMeshAgent agent;
    
    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        oldPos = goal.position;
    }

    private void Update() {
        if (goal.position != oldPos) {
            agent.destination = goal.position;
            oldPos = goal.position;
        }
    }
}