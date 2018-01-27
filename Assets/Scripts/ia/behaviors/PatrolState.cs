using UnityEngine;

public class PatrolState : State {

    public Transform[] positions;
    public bool rotate;
    private int currIndex;

    public override int getCod() {
        return 7;
    }

    public override State update(GameObject obj) {
//        bool hasArrived = hasArrived();

        //        int  next = nextIndex();

        return this;
    }

    private bool hasArrived() {
        return false;
    }
}