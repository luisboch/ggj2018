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
        patrol.patrolRoute = patrolRoute;
        manager.GetBasicState().config("Player",
                o => follow.whenArrive((s) => {
                    // What we do when arrive?
                    return null;
                }, o));
        manager.setCurrentState(patrol);
    }
}