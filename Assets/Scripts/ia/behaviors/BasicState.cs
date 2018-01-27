using System.Collections.Generic;
using UnityEngine;

public class BasicState : State {

    private List<SearchConf> searchConfig = new List<SearchConf>();
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

    public BasicState configure(string lookingType, EventAction doWhenLocate, EventAction doWhenAlert) {
        this.searchConfig.Add(new SearchConf(lookingType, doWhenLocate, doWhenAlert));
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

    public override State update(GameObject obj) {

        // just validation
        if (obj == null || !fromAttr.isAlive().GetValueOrDefault(false)) {
            return null;
        }

        foreach (string tag in this.searchTags) {

            if (_lineOfSight.SeeByTag(tag)) {
                List<GameObject> inFView = _lineOfSight.getViewing();
                foreach (GameObject c in inFView) {
                    State n = notify(c.gameObject, _lineOfSight.GetStatus().Equals(LineOfSight.Status.Alerted));
                    if (n != null) {
                        manager.setCurrentState(n);
                    }
                }
            }
        }

        return this;
    }


    private State notify(GameObject gameObject0, bool dangerArea) {
        foreach (SearchConf c in this.searchConfig) {
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


    public class SearchConf {

        public List<string> searchTypes = new List<string>();
        public EventAction doWhenView;
        public EventAction doWhenAlert;

        public SearchConf(string searchType, EventAction doWhenLocate, EventAction doWhenAlert) {
            this.searchTypes.Add(searchType);
            this.doWhenView = doWhenLocate;
            this.doWhenAlert = doWhenAlert;
        }

        public EventAction getDoWhenLocate() {
            return doWhenView;
        }

        public EventAction getDoWhenAlert() {
            return this.doWhenAlert;
        }

        public List<string> getSearchClass() {
            return searchTypes;
        }

    }
}