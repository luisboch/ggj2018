using UnityEngine;

public class Follow : State {

    private EventAction nextAction;

    public Follow() {
    }

    public override void start(GameObject obj) {
        base.start(obj);
//        obj.Send<IAnimalAnimatorHelper>(_ => _.run(1));
    }

    public override int getCod() {
        return 3;
    }

    public Follow whenArrive(EventAction whenArrive, GameObject target) {
        this.nextAction = whenArrive;
        setTarget(target);
        return this;
    }

    public override State update(GameObject obj) {

        float dist = Vector3.Distance(target.transform.position, obj.transform.position);


        if (target == null
        || (targetAttr != null && !targetAttr.isAlive().GetValueOrDefault(false))
        || dist > fromAttr.followLimit) {
            // Target is dead or lost
            return null;
        } else if (dist < (fromAttr.arriveDist + (fromCtrl.radius) + (targetCtrl.radius) )) {
            return nextAction == null ? null : (State) nextAction.Invoke(target);
        }

        obj.transform.LookAt(target.transform.position);

//        obj.Send<IAnimalAnimatorHelper>(_ => _.run(1));

        return this;
    }

    public override string ToString() {
        return "FOLLOW";
    }
}