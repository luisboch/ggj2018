using UnityEngine;

public class PatrolState : State {

    public GameObject[] patrolRoute;
    public float attractDistance;
    public float missPlayerDistance;

    private int currentPoint = -1;
    private bool goingNext = true;
    public FollowState followState;

    public PatrolState() {
        this.followState = new FollowState().whenArrive((o) => this, null);
    }

    public override int getCod() {
        return 7;
    }

    public override void start(GameObject obj) {
    }

    public override State update(GameObject from) {
        Debug.Log("Current pos " + currentPoint + ", going next");
        updateRouteIndex();
        followState.setTarget(patrolRoute[currentPoint]);

        return followState;
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