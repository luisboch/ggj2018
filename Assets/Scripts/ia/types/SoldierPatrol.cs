using UnityEngine;
using UnityEngine.AI;

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
        patrol.setAgent(GetComponent<NavMeshAgent>());
        manager.GetBasicState().configure("Player",
                (o) => {
                    investigateState.setTargetPos(o.transform.position).SetDoWhenArrive(null);
                    return investigateState;
                },
                (o) => {
                    investigateState.setTargetPos(o.transform.position);
                    investigateState.SetDoWhenArrive((s) => {
                        // Alert view GOTCHA.
                        Debug.LogError("GOTCHA");
                        return null;
                    });

                    return investigateState;
                });
        manager.setCurrentState(patrol);
    }
}