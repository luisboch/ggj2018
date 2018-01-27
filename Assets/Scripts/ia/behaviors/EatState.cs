using UnityEngine;

public class EatState : State {

    private float lastTime = 0;
    private float timeToEat = 3f;
    private EventAction nextAction;

    public EatState() {
    }

    public override void start(GameObject obj) {
        base.start(obj);
//        obj.Send<IAnimalAnimatorHelper>(_=>_.eat());
    }

    public override int getCod() {
        return 2;
    }

    public EatState setToEat(GameObject toEat) {
        setTarget(toEat);
        this.lastTime = Time.time;
        return this;
    }

    public EatState setAfterEat(EventAction afterEat) {
        this.nextAction = afterEat;
        return this;
    }


    public override State update(GameObject obj) {


        if ((Time.time - lastTime) > timeToEat) {
            var objManager = target.GetComponent<BasicObjectManager>();
            if(objManager){
                objManager.destroy();
            }
            return nextAction == null ? null : nextAction.Invoke(null);
        }

        fromCtrl.velocity.Set(0f, 0f, 0f);

        return this;

    }

    public override string ToString() {
        return "EAT";
    }
}