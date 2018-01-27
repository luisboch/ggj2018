using System.Collections.Generic;
using UnityEngine;

public class SoldierPatrol : MonoBehaviour {

    public GameObject[] patrolRoute;

    void Start() {
        FSMManager manager = GetComponent<FSMManager>();

        RandomState search = new RandomState();
        FollowState follow = new FollowState();
        IdleState idle = new IdleState();
        PatrolState patrol = new PatrolState();
        InvestigateState investigateState = new InvestigateState();


        patrol.patrolRoute = patrolRoute;
        manager.GetBasicState().config("Player", o => investigateState.setTargetPos(o.transform.position));
        manager.setCurrentState(patrol);
    }
}