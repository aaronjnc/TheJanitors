using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointNavigation : MonoBehaviour
{

    AINavigator controller;
    public Waypoint currentWaypoint;

    public NavMeshAgent agent;
    public Transform target;

    int direction;
  
    private void Awake()
    {
        controller = GetComponent<AINavigator>();
    }

    void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));

        controller.SetDestination(currentWaypoint.GetPosition());

        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if (controller.reachedDestination)
        {

            bool shouldBranch = false;

            if(currentWaypoint.branches != null && currentWaypoint.branches.Count < 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
            }
            
            if (currentWaypoint.branches.Count > 0)
            {
                int rand = Random.Range(0, currentWaypoint.branches.Count - 1);
                Waypoint newWayPoint = currentWaypoint.branches[rand];
                if (newWayPoint.transform.position == currentWaypoint.transform.position)
                {
                    rand++;
                    if (rand == currentWaypoint.branches.Count)
                        rand = 0;
                    newWayPoint = currentWaypoint.branches[rand];
                }
                currentWaypoint = newWayPoint;
            }
            else
            {
                if (direction == 0)
                {
                    if (currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                    }
                   else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        direction = 1;
                    }
                }
                else if (direction == 1)
                {
                    if (currentWaypoint.previousWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                        direction = 0;
                    }
                }
            }

            agent.SetDestination(currentWaypoint.transform.position);

            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
