
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitBrain : Brain
{
    NavMeshAgent agent;

    //patrol
    [Header("Patrol")]
    [SerializeField] Transform[] poinPatrol;
    [Range(10,20)]
    [SerializeField] float rangeSearch;
    [SerializeField] string targetSearch;

    //chase
    [Header("Chase")]
    [Range(0, 5)]
    [SerializeField] float agentStoppingDistance;

    //shoot
    [Header("Shoot")]
    [Range(0,5)]
    [SerializeField] float timeReloadReset;
    [Range(10, 15)]
    [SerializeField] float distanceShoot;
    [Range(1, 5)]
    [SerializeField] float distanceBetweenShoot;

    //Health
    [Header("Health")]
    [Range(10, 40)]
    [SerializeField] float minHealth;
    [SerializeField] int healthPlus;
    [SerializeField] float delay;

    //cover
    [Header("Cover")]
    [SerializeField] UnitCover[] unitCovers;
    [SerializeField] Transform bestCoverSpot;

    ChaseNode chaseState;
    PatrolNode patrolSate;
    RangeNode rangeChaseState;
    ShootNode shootState;
    HealthNode healthState;
    GoToCoverNode goToCoverState;
    AvailableCoverNode availableCoverState;
    IsCoverSpotNode isCoverSpotState, isCoverSpotHealState;
    HealingNode healingState;


    Selector patrolSelector,topNode,isCoverSelector;
    Sequence healthSequence,coverSequence,healingSequence;
    Inventor ceckHealtInventer;
   






    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        //state
        healthState = new HealthNode(this.GetComponent<UnitEvent>(), GetComponent<UnitHealth>(), minHealth);
        availableCoverState = new AvailableCoverNode(unitCovers, this);
        isCoverSpotState = new IsCoverSpotNode(unitCovers, agent);
        isCoverSpotHealState = new IsCoverSpotNode(unitCovers, agent);
        goToCoverState = new GoToCoverNode(agent, this);

        rangeChaseState = new RangeNode(agent,rangeSearch, agentStoppingDistance, targetSearch);

        patrolSate = new PatrolNode(poinPatrol, agent);
        chaseState = new ChaseNode(agent, agentStoppingDistance);

        shootState = new ShootNode(agent,this.GetComponent<UnitEvent>(),distanceShoot,timeReloadReset,distanceBetweenShoot,rangeSearch);
      
        healingState = new HealingNode(this.GetComponent<UnitEvent>(),GetComponent<UnitHealth>(), healthPlus,delay);


        //group state
        //Health
   
        healingSequence = new Sequence(new List<Node> { isCoverSpotHealState, healingState });
         isCoverSelector = new Selector(new List<Node> { healingSequence, goToCoverState });

        coverSequence = new Sequence(new List<Node> { availableCoverState, isCoverSelector });

       // ceckHealtInventer = new Inventor(new List<Node>() { healthState });
        healthSequence = new Sequence(new List<Node> { healthState, coverSequence });

        //patrol
        patrolSelector = new Selector(new List<Node> {chaseState,patrolSate});

        topNode = new Selector(new List<Node> { rangeChaseState,healthSequence,  shootState, patrolSelector });


    }     

    private void Update()
    {
        chaseState.target = rangeChaseState.target;
        shootState.target = rangeChaseState.target;
        availableCoverState.target = rangeChaseState.target;
        topNode.Evaluate();
    }

    public Transform SetBestCoverSpot(Transform spot)
    {
        return bestCoverSpot = spot;
    }

    public Transform GetBestCoverSpot()
    {
        return  bestCoverSpot;
    }


}
