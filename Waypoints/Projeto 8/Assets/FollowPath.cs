using UnityEngine;

public class FollowPath:MonoBehaviour {

    Transform goal;
    float speed = 5;
    float accuracy = 1;
    float rotSpeed = 2;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph G;

    void Start() {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        G = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[7];
    }

    public void GoToHeli() 
    {
        G.AStar(currentNode, wps[4]);
        currentWP = 0;
    }

    public void GoToRuin() 
    {
        G.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoBehindHeli() 
    {
        G.AStar(currentNode, wps[11]);
        currentWP = 0;
    }

    void LateUpdate() 
    {
        if (G.getPathLength() == 0 || currentWP == G.getPathLength())
            return;

        currentNode = G.getPathPoint(currentWP);
        if (Vector3.Distance(
            G.getPathPoint(currentWP).transform.position,
            transform.position) < accuracy) 
        {
            currentWP++;
        }

        if (currentWP < G.getPathLength()) 
        {
            goal = G.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,
                                            this.transform.position.y,
                                            goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        Time.deltaTime * rotSpeed);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }
}