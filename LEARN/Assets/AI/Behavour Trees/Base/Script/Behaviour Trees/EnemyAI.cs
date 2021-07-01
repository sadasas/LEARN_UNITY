using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float lowHealthTreshold;
    [SerializeField] private float healthRestoredRates;

    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Cover[] availableCovers;

    private Transform BestCoverSpot;

    private Material material;
    private NavMeshAgent agent;

    private Node topNode;
    private float _currentHealth;

    public float currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, startingHealth); }
    }

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _currentHealth = startingHealth;
        ConstructBehaviourTree();
    }

    private void OnMouseDown()
    {
        currentHealth -= 10f;
    }

    private void ConstructBehaviourTree()
    {
        IsCoverAvailableNode coverAvailableNode = new IsCoverAvailableNode(availableCovers, playerTransform, this);
        GoToCoverNode goToCoverNode = new GoToCoverNode(agent, this);
        IsCoveredNode isCoveredNode = new IsCoveredNode(playerTransform, transform);
        HealthNode healthNode = new HealthNode(this, lowHealthTreshold);
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);
        RangeNode chasingRangeNode = new RangeNode(chasingRange, playerTransform, transform);
        RangeNode shootingRangeNode = new RangeNode(shootingRange, playerTransform, transform);
        ShootNode shootNode = new ShootNode(agent, this);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, shootNode });
        Sequence goToCoverSequence = new Sequence(new List<Node> { coverAvailableNode, goToCoverNode });

        Selector findCoverSelector = new Selector(new List<Node> { goToCoverSequence, chaseSequence });
        Selector tryToTakeCoverSelector = new Selector(new List<Node> { isCoveredNode, findCoverSelector });
        Sequence coverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector });

        topNode = new Selector(new List<Node> { coverSequence, shootSequence, chaseSequence });
    }

    private void Update()
    {
        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.red);
        }
        currentHealth += Time.deltaTime * healthRestoredRates;
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    public void SetBestCoverSpot(Transform bestSpot)
    {
        this.BestCoverSpot = bestSpot;
    }

    public Transform GetBestCover()
    {
        return BestCoverSpot;
    }
}