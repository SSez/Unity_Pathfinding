using UnityEngine;
using UnityEngine.AI;

public class PlayerDestination : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject target = null;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target != null && agent != null)
        {
            Vector3 targetVector = target.transform.position;
            agent.SetDestination(targetVector);
        }
    }
}
