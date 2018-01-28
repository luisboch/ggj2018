using UnityEngine;
using UnityEngine.AI;

public class PatrolState : IAState {

    public GameObject[] patrolRoute;
    public float attractDistance;
    public float missPlayerDistance;

    private int currentPoint = -1;
    private bool goingNext = true;
    public NavMeshAgent agent;

    public PatrolState() {
    }

    public override int getCod() {
        return 7;
    }

    public PatrolState setAgent(NavMeshAgent agent) {
        this.agent = agent;
        return this;
    }

    public override void start(GameObject obj) {
        base.start(obj);
        updateRouteIndex();
    }

    public override IAState update(GameObject from) {


        float dist = Vector3.Distance(patrolRoute[currentPoint].transform.position, from.transform.position);

        if (dist < (fromAttr.arriveDist + (fromCtrl.radius) + (targetCtrl == null ? 0 : targetCtrl.radius) )) {
            updateRouteIndex();

        }

        if (agent) {
            agent.destination = patrolRoute[currentPoint].transform.position;
        }

        return this;
    }

    private void updateRouteIndex() {
        if (goingNext)
        {
            if (currentPoint < patrolRoute.Length - 1)
            {
                currentPoint++;
            }
            else
            {
                goingNext = false;
                currentPoint--;
            }
        }
        else
        {
            if (currentPoint > 0)
            {
                currentPoint--;
            }
            else
            {
                goingNext = true;
                currentPoint++;
            }
        }
    }
}