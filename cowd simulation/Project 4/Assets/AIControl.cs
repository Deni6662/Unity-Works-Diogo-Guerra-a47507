using UnityEngine;

public class AIControl:MonoBehaviour {

    GameObject[] goalLocations;
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;

    void Start() {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetFloat("wOffSet", Random.Range(0, 1));
        anim.SetTrigger("isWalking");
        float sm = Random.Range(0.5f, 2f);
        anim.SetFloat("SpeedMult", sm);
        agent.speed *= sm;
    }

    void Update() {

        if (agent.remainingDistance<1) {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}
