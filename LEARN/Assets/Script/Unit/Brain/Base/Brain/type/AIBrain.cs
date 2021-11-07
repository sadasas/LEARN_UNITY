using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/*
 
 TODO : - Create variant item 
        - Make AI to manage Item 
        - Create  mechanic type shoot  ScriptableObject
 
 
 */

[RequireComponent(typeof(UnitEvent), typeof(UnitHealth), typeof(UnitInventory))]
[RequireComponent(typeof(UnitInventory), typeof(UnitShoot))]

public class AIBrain : Brain
{

    NavMeshAgent agent;


    public TypeBrain brain;

    //patrol
    [Header("Patrol")]
    [SerializeField] List<Transform> poinPatrol;
  /*  [Range(10, 50)]
    [Tooltip("Sniper betwen 20 and 50 \n Normal max 20")]
    [SerializeField] float rangeSearchPatrol;
    [SerializeField] string targetSearch;*/

    //chase
    [Header("Chase")]
    [Range(0, 5)]
    [SerializeField] float agentStoppingDistance;

    //shoot
  /*  [Header("Shoot")]
    [Range(0, 5)]
    [SerializeField] float timeReloadReset;
    [Range(10, 15)]
    [SerializeField] float distanceShoot;
    [Range(1, 5)]
    [SerializeField] float distanceBetweenShoot;*/

    //Health
    [Header("Health")]
    [Range(10, 40)]
    [SerializeField] float minHealth;
    [SerializeField] int healthPlus;
    [SerializeField] float delay;

    //cover
    [Header("Cover")]
    [SerializeField] List<UnitCover> unitCovers;
    [SerializeField] Transform bestCoverSpot;

    //item
    [Header("Item")]
    [SerializeField] float rangeSearchItem;


    #region NODE
    ChaseNode chaseState;
    PatrolNode patrolSate;
    RangeNode rangeChaseState;
    ShootNode shootState;
    HealthNode healthState;
    GoToCoverNode goToCoverState;
    AvailableCoverNode availableCoverState;
    IsCoverSpotNode isCoverSpotState, isCoverSpotHealState;
    HealingNode healingState;
    SearchItemNode searchItemState;


    Selector patrolSelector, topNode, isCoverSelector;
    Sequence healthSequence, coverSequence, healingSequence;
    Inventor ceckHealtInventer;
    #endregion


    public override void Starting()
    {
        agent = this.GetComponent<NavMeshAgent>();

        GetComponent<UnitShoot>().typeShoot = brain.shoot;

        SearchPointPatrol();
        SearchPointCover();


       
        //state
        healthState = new HealthNode(this.gameObject.GetComponent<UnitEvent>(), this.gameObject.GetComponent<UnitHealth>(), minHealth);

        availableCoverState = new AvailableCoverNode(unitCovers, this);

        isCoverSpotState = new IsCoverSpotNode(unitCovers, agent);

        isCoverSpotHealState = new IsCoverSpotNode(unitCovers, agent);

        goToCoverState = new GoToCoverNode(agent, this);

        rangeChaseState = new RangeNode(agent,brain.target.rangeSearchPatrol, agentStoppingDistance,  brain.target.targetSearch);

        patrolSate = new PatrolNode(poinPatrol, agent);

        chaseState = new ChaseNode(agent, agentStoppingDistance);

        shootState = new ShootNode(agent, this.gameObject.GetComponent<UnitEvent>(), brain.shoot.setting.distanceShoot, brain.shoot.setting.timeReloadReset, brain.shoot.setting.distanceBetweenShoot, brain.target.rangeSearchPatrol);

        healingState = new HealingNode(this.gameObject.GetComponent<UnitEvent>(), this.gameObject.GetComponent<UnitHealth>(), healthPlus, delay);

        searchItemState = new SearchItemNode(rangeSearchItem, agent);


        //group state
        //Health

        healingSequence = new Sequence(new List<Node> { isCoverSpotHealState, healingState });

        isCoverSelector = new Selector(new List<Node> { healingSequence, goToCoverState });

        coverSequence = new Sequence(new List<Node> { availableCoverState, isCoverSelector });

        // ceckHealtInventer = new Inventor(new List<Node>() { healthState });
        healthSequence = new Sequence(new List<Node> { healthState, coverSequence });

        //patrol
        patrolSelector = new Selector(new List<Node> { chaseState, patrolSate });

        topNode = new Selector(new List<Node> { rangeChaseState, healthSequence, shootState, searchItemState, patrolSelector });

    }
   
    public override void Think()
    {

        chaseState.target = rangeChaseState.target;
        shootState.target = rangeChaseState.target;
        if (rangeChaseState.target != null) availableCoverState.target = rangeChaseState.target;
        target = rangeChaseState.target;
        topNode.Evaluate();
    }






    #region SEARCH POINT

    public Transform SetBestCoverSpot(Transform spot)
    {
        return bestCoverSpot = spot;
    }
    public Transform GetBestCoverSpot()
    {
        return bestCoverSpot;
    }

    //Searh point every scene started
    List<Transform> SearchPointPatrol()
    {

        poinPatrol = new List<Transform>();
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();

        foreach (var objects in gameObjects)
        {
            if (objects.CompareTag("PointPatrol"))
            {

                poinPatrol.Add(objects.transform);
            }
        }



        return poinPatrol;
    }

    List<UnitCover> SearchPointCover()
    {

        unitCovers = new List<UnitCover>();
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        foreach (var objects in gameObjects)
        {
            if (objects.CompareTag("PointCover"))
            {

                unitCovers.Add(objects.GetComponent<UnitCover>());
            }
        }
        return unitCovers;
    }

    #endregion
}
