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

    public bool walkPointSet = false;

    public bool playerInsightCast = false;

    public LayerMask ob, plyr;

    public float objForward, objBack, objLeft, objRight;
    public float playerForward, playerBack, playerLeft, playerRight;
    public float distancePlayer;

    private Vector3 origin;
    private Vector3 direction;
    private Vector3 directionleft;
    private Vector3 directionrigth;
    private Vector3 directionback;
    private Vector3 thisPos;
    private float cd;

    public float radius, inSightRange;

    private RaycastHit hit;
    private float pyr;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        thisPos = transform.position;
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

        Gizmos.DrawWireSphere(origin + direction * 1000, radius);
        Gizmos.DrawWireSphere(origin + directionleft * 30, radius);
        Gizmos.DrawWireSphere(origin + directionrigth * 30, radius);
        Gizmos.DrawWireSphere(origin + directionback * 10, radius);
        Gizmos.DrawWireSphere(thisPos, inSightRange);

        Gizmos.DrawWireSphere(origin + direction * cd, radius);
    }

    private void OnDrawGizmosSelected()
    {
    }

    private void SearchPlayer()
    {
        if (Physics.CheckSphere(transform.position, inSightRange, plyr))
        {
            Debug.Log("player nearby");
        }
        else
        {
            playerInsightCast = false;
            Debug.Log("player get out");
        }
        Debug.Log("Search Player");

        if (Physics.SphereCast(cast.position, radius, cast.transform.forward, out hit, 10, ob))
        {
            if (hit.collider.CompareTag("Object"))
            {
                objForward = hit.distance;

                Debug.Log("find object in forward");
            }

            if (hit.collider.CompareTag("Player"))
            {
                playerForward = hit.distance;
                if (playerForward < objForward)
                {
                    if (!playerInsightCast) playerInsightCast = true;
                }
                Debug.Log("find player in forward");
            }
        }
        if (Physics.SphereCast(cast.position, radius, cast.transform.right, out hit, 10, ob))
        {
            if (hit.collider.CompareTag("Object"))
            {
                objRight = hit.distance;

                Debug.Log("find object in rigth");
            }

            if (hit.collider.CompareTag("Player"))
            {
                playerRight = hit.distance;
                Debug.Log("find player in right");
                if (playerRight < objRight)
                {
                    if (!playerInsightCast) playerInsightCast = true;
                }
            }
        }

        if (Physics.SphereCast(cast.position, radius, -cast.transform.right, out hit, 10, ob))
        {
            if (hit.collider.CompareTag("Object"))
            {
                objLeft = hit.distance;

                Debug.Log("find object in left");
            }

            if (hit.collider.CompareTag("Player"))
            {
                playerLeft = hit.distance;
                Debug.Log("find player in left");
                if (playerLeft < objLeft)
                {
                    if (!playerInsightCast) playerInsightCast = true;
                }
            }
        }

        if (Physics.SphereCast(cast.position, radius, -cast.transform.forward, out hit, 10, ob))
        {
            if (hit.collider.CompareTag("Object"))
            {
                objBack = hit.distance;

                Debug.Log("find object in back");
            }

            if (hit.collider.CompareTag("Player"))
            {
                playerBack = hit.distance;
                Debug.Log("find player in back");
                if (playerBack < objBack)
                {
                    if (!playerInsightCast) playerInsightCast = true;
                }
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