using UnityEngine;

public class Idle : State {

    public override State update(GameObject obj) {
        return this;
    }

    public override int getCod() {
        return 5;
    }


}