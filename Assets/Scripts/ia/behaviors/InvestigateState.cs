using UnityEngine;
using UnityEngine.AI;

public class InvestigateState : IAState {

    public Vector3 targetPos;
    private LineOfSight lineOfSight;
    private EventAction doWhenArrive;
    private NavMeshAgent navAgent;

    public InvestigateState() {
    }

    public InvestigateState SetDoWhenArrive(EventAction action) {
        this.doWhenArrive = action;
        return this;
    }

    public InvestigateState setTargetPos(Vector3 pos) {
        this.targetPos = pos;
        return this;
    }

    public override void start(GameObject obj) {
        base.start(obj);
        lineOfSight = from.GetComponentInChildren<LineOfSight>();
        this.navAgent = from.GetComponent<NavMeshAgent>();
    }

    public override int getCod() {
        return 3;
    }

    public override IAState update(GameObject obj) {

        float dist = Vector3.Distance(targetPos, obj.transform.position);

        float calc = (fromAttr.arriveDist + fromCtrl.radius + (targetCtrl == null ? 0 : targetCtrl.radius) );

        if (dist < (fromAttr.arriveDist + (fromCtrl.radius) + (targetCtrl == null ? 0 : targetCtrl.radius) )) {

            if (this.doWhenArrive != null) {
                return this.doWhenArrive.Invoke(null);
            }

            // We arrive to destination
            IdleState state = new IdleState();
            state.time = fromAttr.investigateWaitTime;
            state.isInfinite = false;

            state.onComplete((s) => {
                return previousState;
            });

            return state;
        }

        //        obj.transform.LookAt(target.transform.position);/
        if (navAgent) {
            navAgent.destination = targetPos;
            navAgent.speed = lineOfSight.GetStatus().Equals(LineOfSight.Status.Alerted) ? fromAttr.alertVelocity : fromAttr.velocity;
            if (animatorController) {
                animatorController.setForward(navAgent.speed);
            }

        } else {
            Vector3 def = targetPos - obj.transform.position;
            obj.transform.position += (def.normalized * fromAttr.velocity * Time.deltaTime);

            if (animatorController) {
                animatorController.setForward(fromAttr.velocity);
            }
        }
        return this;
    }

    public override string ToString() {
        return "INVESTIGATE";
    }
}