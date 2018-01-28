using System.Collections.Generic;
using UnityEngine;

public class BasicState : IAState {

    private List<SearchConfig> searchConfig = new List<SearchConfig>();
    private List<string> searchTags = new List<string>();
    private FSMManager manager;
    private Config _config;
    private LineOfSight _lineOfSight;


    public BasicState(FSMManager manager) {
        this.manager = manager;
        this.from = manager.gameObject;
        this.fromAttr = manager.GetComponent<BasicObjectAttr>();
        this._config = Config.getInstance();
    }

    public override void start(GameObject obj) {
        base.start(obj);
        _lineOfSight = from.GetComponentInChildren<LineOfSight>();
    }

    public override int getCod() {
        return 6;
    }

    public List<SearchConfig> GetSearchConfig() {
        return this.searchConfig;
    }

    public BasicState configure(string lookingType, EventAction doWhenLocate, EventAction doWhenAlert) {
        this.searchConfig.Add(new SearchConfig(lookingType, doWhenLocate, doWhenAlert));
        this.searchTags.Clear();


        foreach (var conf in this.searchConfig) {
            foreach (var c in conf.searchTypes) {
                if (!searchTags.Contains(c)) {
                    this.searchTags.Add(c);
                }
            }
        }

        return this;
    }


    public BasicState clear() {
        this.searchConfig.Clear();
        return this;
    }

    public override IAState update(GameObject obj) {

        // just validation
        if (obj == null || !fromAttr.isAlive().GetValueOrDefault(false)) {
            return null;
        }

        foreach (string tag in this.searchTags) {

            if (_lineOfSight.SeeByTag(tag)) {
                List<GameObject> inFView = _lineOfSight.getViewing();
                foreach (GameObject c in inFView) {
                    IAState n = notify(c.gameObject, _lineOfSight.GetStatus().Equals(LineOfSight.Status.Alerted));
                    if (n != null) {
                        manager.setCurrentState(n);
                    }
                }
            }
        }

        return this;
    }


    private IAState notify(GameObject gameObject0, bool dangerArea) {
        foreach (SearchConfig c in this.searchConfig) {
            if (c.searchTypes.Contains(gameObject0.tag)) {
                if (_config.alert || dangerArea) {
                    return c.doWhenAlert.Invoke(gameObject0);
                }

                return c.doWhenView.Invoke(gameObject0);
            }
        }

        // No config found for current obj.
        return null;
    }


    public override string ToString() {
        return "BASICSTATE";
    }

}