using UnityEngine;

public class IdleState : State {

    private EventAction nextAction;
    public float time = -1;
    public bool isInfinite = true;

    public override void start(GameObject obj) {
        base.start(obj);
        this.isInfinite = time > 0;
    }

    public IdleState onComplete(EventAction nextAction) {
        this.nextAction = nextAction;
        return this;
    }

    public override State update(GameObject obj) {
        if (!isInfinite  ) {
            if (time < 0) {
                return nextAction == null ? null : nextAction.Invoke(from);
            }
        }
        return this;
    }

    public override int getCod() {
        return 5;
    }


}