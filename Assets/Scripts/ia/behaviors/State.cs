using System;
using UnityEngine;

public abstract class State {


    protected GameObject from;
    protected CharacterController fromCtrl;
    protected BasicObjectAttr fromAttr;


    protected GameObject target;
    protected CharacterController targetCtrl;
    protected BasicObjectAttr targetAttr;


    public abstract int getCod();
    /**
     * Executed when state starts
     * @param obj
     */
    public virtual void start(GameObject obj) {

        this.from = obj;
        this.fromCtrl = obj.GetComponent<CharacterController>();
        this.fromAttr = obj.GetComponent<BasicObjectAttr>();

        if (this.fromAttr == null || this.fromCtrl == null) {
            throw new ExecutionEngineException("All characters must have a character controller and character attributes");
        }
    }


    public State setTarget(GameObject target) {
        if (target != null) {
            this.target = target;

            this.targetCtrl = target.GetComponent<CharacterController>();
            this.targetAttr = target.GetComponent<BasicObjectAttr>();
        }
        return this;
    }


    /**
     * Update the logics and, when the state must be changed: return the new
     * state; when this state was finished returns null (and then, the object
     * will back to last state, using FILO); when nothing happens return this/
     * the same instance;
     *
     * @param obj
     * @return
     */
    public virtual State update(GameObject obj) {
        return null;
    }

    public delegate State EventAction(GameObject obj);
}