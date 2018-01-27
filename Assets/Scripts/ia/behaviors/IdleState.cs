using UnityEngine;

public class IdleState : State {

    public override State update(GameObject obj) {
        return this;
    }

    public override int getCod() {
        return 5;
    }


}