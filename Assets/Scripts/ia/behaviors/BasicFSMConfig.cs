using UnityEngine;

[RequireComponent(typeof(FSMManager))]
public class BasicFSMConfig : MonoBehaviour {

    void Start() {
        FSMManager manager = GetComponent<FSMManager>();

        Search search = new Search();
        Follow follow = new Follow();
        Eat eat = new Eat();
//        Attack attack = new Attack();

        /**
            Search for "food"
                when locate -> follow it
                    When arrive -> eat it;
         */
        search.config("Food", o => follow.config((e) => eat.setToEat(e).setAfterEat((s) => search), o));

        /**
            Search for "player"
                when locate -> follow it
                    When arrive -> attack it;
         */
//        search.config("Player", o => follow.config((e) => attack.setTarget(e), o));

        manager.setCurrentState(search);

    }
}