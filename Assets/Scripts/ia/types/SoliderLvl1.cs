using UnityEngine;

public class SoliderLvl1 : MonoBehaviour {
    void Start() {
        FSMManager manager = GetComponent<FSMManager>();

        Random search = new Random();
        Follow follow = new Follow();
        Idle idle = new Idle();

        manager.setCurrentState(idle);
    }
}