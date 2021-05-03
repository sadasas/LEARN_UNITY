using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] target;

    [SerializeField]
    private Transform cast;

    private Transform player;

    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private int setDes;

    public bool walkPointSet;

    public bool playerInsightCast = false;

    public LayerMask ob;

    public float obj;
    public float distancePlayer;

    private Vector3 origin;
    private Vector3 direction;
    private Vector3 directionleft;
    private Vector3 directionrigth;
    private Vector3 directionback;
    private float cd;
    public float radius;

    private RaycastHit hit;
    private float pyr;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        origin = cast.transform.position;
        direction = cast.transform.forward;
        directionback = -cast.transform.forward;
        directionleft = -cast.transform.right;
        directionrigth = cast.transform.right;
        cd = hit.distance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SearchPlayer();

        if (playerInsightCast) ChasePlayer();
        if (!playerInsightCast)
        {
            Patroling();
        }
    }

    private void ChasePlayer()
    {
        Debug.Log("Chase Player");
        navMeshAgent.SetDestination(player.position);
        distancePlayer = navMeshAgent.remainingDistance;
        Debug.Log(distancePlayer);
        if (distancePlayer <= 0.5)
        {
            Debug.Log("Get Player");
            navMeshAgent.Stop();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * cd);

        Gizmos.DrawWireSphere(origin + direction * 10, radius);
        Gizmos.DrawWireSphere(origin + directionleft * 10, radius);
        Gizmos.DrawWireSphere(origin + directionrigth * 10, radius);
        Gizmos.DrawWireSphere(origin + directionback * 10, radius);
    }

    private void OnDrawGizmosSelected()
    {
    }

    private void SearchPlayer()
    {
        Debug.Log("Search Player");

        if (Physics.SphereCast(cast.position, radius, cast.transform.forward, out hit, 10, ob))
        {
            if (hit.collider.CompareTag("Object"))
            {
                obj = hit.distance;

                Debug.Log("find object in forward");
            }

            if (hit.collider.CompareTag("Player"))
            {
                obj = hit.distance;
                Debug.Log("find player in forward");
                playerInsightCast = true;
            }
        }
        if (Physics.SphereCast(cast.position, radius, cast.transform.right, out hit, 10, ob))
        {
            if (hit.collider.CompareTag("Object"))
            {
                obj = hit.distance;

                Debug.Log("find object in rigth");
            }

            if (hit.collider.CompareTag("Player"))
            {
                obj = hit.distance;
                Debug.Log("find player in right");
                playerInsightCast = true;
            }
        }

        if (Physics.SphereCast(cast.position, radius, -cast.transform.right, out hit, 10, ob))
        {
            if (hit.collider.CompareTag("Object"))
            {
                obj = hit.distance;

                Debug.Log("find object in left");
            }

            if (hit.collider.CompareTag("Player"))
            {
                obj = hit.distance;
                Debug.Log("find player in left");
                playerInsightCast = true;
            }
        }

        if (Physics.SphereCast(cast.position, radius, -cast.transform.forward, out hit, 10, ob))
        {
            if (hit.collider.CompareTag("Object"))
            {
                obj = hit.distance;

                Debug.Log("find object in back");
            }

            if (hit.collider.CompareTag("Player"))
            {
                obj = hit.distance;
                Debug.Log("find player in back");
                playerInsightCast = true;
            }
        }
    }

    private void Patroling()
    {
        Debug.Log("Patroling");
        if (!walkPointSet) SetWalkPoint();
        if (walkPointSet) navMeshAgent.SetDestination(target[setDes].position);

        float b = navMeshAgent.remainingDistance;
        if (b < 1f) walkPointSet = false;
        /* Debug.Log(b);*/
        /*Vector3 distanceWalkPoint = target[setDes].position - transform.position;
        if (distanceWalkPoint.magnitude < 1f) walkPointSet = false;*/
    }

    private void SetWalkPoint()
    {
        Debug.Log("Set Destination");
        int random = Random.Range(0, target.Length);
        setDes = random;
        walkPointSet = true;
    }
}