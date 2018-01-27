using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController), typeof(BasicObjectAttr))]
public class FSMManager : MonoBehaviour, IEventSystemHandler {


    protected List<State> states = new List<State>();
    protected State currentState;

    private static int MAX_MEM_STATES = 5;
    private BasicObjectAttr attributes;

    void Start() {
        attributes = GetComponent<BasicObjectAttr>();
    }

    public FSMManager() {
    }

    public void setCurrentState(State next) {

        if (next == null) {
            this.currentState = null;
            return;
        }

        // same state, ignore
        if (this.currentState != null && next.getCod() == this.currentState.getCod()) {
            return;
        }

        if (states.Count >= MAX_MEM_STATES) {
            states.Remove(states[0]);
        }

        if (this.currentState != null) {
            states.Add(this.currentState);
        }

        this.currentState = next;
        // Initialize the state.
        this.currentState.start(gameObject);
    }

    public void finishCurrentState() {

        // No behavior?
        if (states.Count == 0) {
            this.currentState = null;
            return;
        }

        states.Remove(currentState);

        if(states.Count > 0){
            this.currentState = states[states.Count - 1];
        }

        if (this.currentState != null) {
            this.currentState.start(gameObject);
        }

    }

    public void receiveHit(GameObject from, int force) {
//        Attack attack = new Attack();
//
//        if (this.currentState == null || this.currentState.getCod() != attack.getCod() ) {
//            setCurrentState(attack.setTarget(from));
//        }
    }


    void Update() {

        // No behavior?
        if (currentState != null) {
            State next = this.currentState.update(gameObject);

            // This state was finished?
            if (next == null) {
                Debug.Log("Finished state " + currentState);
                finishCurrentState();
            } else if (next != this.currentState) {
                // The state was updated?
                // Then use the new state, and add to List
                Debug.Log("Changing state to: " + next);
                setCurrentState(next);
            }
        }


//        Debug.Log("Alive?" + attributes.isAlive().GetValueOrDefault(true));

        if (!attributes.isAlive().GetValueOrDefault(true)) {
            currentState = null;
            // Object was killed.
//            gameObject.Send<IAnimalAnimatorHelper>((_ => _.die()));
        }
    }

}