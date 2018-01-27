using UnityEngine;

public class InvestigateState : State {

    public Vector3 targetPos;

    public InvestigateState() {
    }

    public State setTargetPos(Vector3 pos){
        this.targetPos = pos;
        return this;
    }

    public override void start(GameObject obj) {
        base.start(obj);
    }

    public override int getCod() {
        return 3;
    }

    public override State update(GameObject obj) {

        float dist = Vector3.Distance(targetPos, obj.transform.position);


       if (dist < (fromAttr.arriveDist + (fromCtrl.radius) + (targetCtrl == null ? 0 : targetCtrl.radius) )) {

            // We arrive to destination
            IdleState state = new IdleState();
            state.time = fromAttr.investigateWaitTime;

            state.onComplete((s) => {
                return previousState;
            });

            return state;
        }

        //        obj.transform.LookAt(target.transform.position);/

        Vector3 def = target.transform.position - obj.transform.position;

        obj.transform.position += (def.normalized * fromAttr.velocity * Time.deltaTime);

        return this;
    }

    public override string ToString() {
        return "FOLLOW";
    }
}