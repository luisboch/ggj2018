using UnityEngine;

public class SoldierLvl2 : MonoBehaviour {
    void Start() {
        FSMManager manager = GetComponent<FSMManager>();

        RandomState search = new RandomState();
        FollowState follow = new FollowState();
        IdleState idle = new IdleState();

        manager.setCurrentState(idle);
        manager.GetBasicState().config("Player",
                o => follow.whenArrive((s) => {
                   // What we do when arrive?
                    return null;
                }, o));
    }
}