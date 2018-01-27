using UnityEngine;

public class SoliderLvl1 : MonoBehaviour {
    void Start() {
        FSMManager manager = GetComponent<FSMManager>();

        RandomState search = new RandomState();
        FollowState follow = new FollowState();
        IdleState idle = new IdleState();

        manager.setCurrentState(idle);
    }
}