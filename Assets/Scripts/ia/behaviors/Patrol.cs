using UnityEngine;

public class Patrol : State {

    public Transform[] positions;
    public bool rotate;
    private int currIndex;

    public override int getCod() {
        return 7;
    }

    public override State update(GameObject obj) {


        return this;

    }
}