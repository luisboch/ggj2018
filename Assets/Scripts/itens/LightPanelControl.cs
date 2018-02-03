using System.Collections;
using UnityEngine;


public class LightPanelControl : MonoBehaviour, Actionable {

    Config config;

    void Start() {
        config = Config.getInstance();
    }

    // Update is called once per frame
    public IEnumerable doAction(Player p) {
        config.lightIsOn = !config.lightIsOn;
        yield return null;
    }
}
