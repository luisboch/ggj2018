using UnityEngine;

public class FollowState : IAState {

    private EventAction nextAction;

    public FollowState() {
    }

    public override void start(GameObject obj) {
        base.start(obj);
    }

    public override int getCod() {
        return 3;
    }

    public FollowState whenArrive(EventAction whenArrive, GameObject target) {
        this.nextAction = whenArrive;
        setTarget(target);
        return this;
    }

    public override IAState update(GameObject obj) {

        float dist = Vector3.Distance(target.transform.position, obj.transform.position);


        if (target == null
        || (targetAttr != null && !targetAttr.isAlive().GetValueOrDefault(false))
        || dist > fromAttr.followLimit) {
            // Target is dead or lost
            return null;
        } else if (dist < (fromAttr.arriveDist + (fromCtrl.radius) + (targetCtrl == null ? 0 : targetCtrl.radius) )) {
            return nextAction == null ? null : (IAState) nextAction.Invoke(target);
        }

//        obj.transform.LookAt(target.transform.position);/

        Vector3 def = target.transform.position - obj.transform.position ;

        obj.transform.position += (def.normalized * fromAttr.velocity * Time.deltaTime);

        return this;
    }

    public override string ToString() {
        return "FOLLOW";
    }
}