using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;



public class Dog : MonoBehaviour
{
    NavMeshAgent agent;
    public NavMeshSurface surfaces;

    public Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        surfaces.BuildNavMesh();
    }

    private void Update()
    {
        NavMeshPath path = new NavMeshPath();

        if(agent.CalculatePath(target.position,path))
            agent.SetDestination(target.position);
    }
}
