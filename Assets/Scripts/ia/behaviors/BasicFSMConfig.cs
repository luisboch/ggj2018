using UnityEngine;

[RequireComponent(typeof(FSMManager))]
public class BasicFSMConfig : MonoBehaviour {

    void Start() {
        FSMManager manager = GetComponent<FSMManager>();

        RandomState search = new RandomState();
        FollowState follow = new FollowState();
        EatState eat = new EatState();

        /**
            Search for "food"
                when locate -> follow it
                    When arrive -> eat it;
         */
        manager.GetBasicState()
        .config("Food",
                o => follow.whenArrive((e) => eat.setToEat(e).setAfterEat((s) => search), o));

        /**
            Search for "player"
                when locate -> follow it
                    When arrive -> attack it;
         */
        //        search.config("Player", o => follow.config((e) => attack.setTarget(e), o));

        manager.setCurrentState(search);

    }
}