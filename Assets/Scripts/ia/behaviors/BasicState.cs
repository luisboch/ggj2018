using System.Collections.Generic;
using UnityEngine;

public class BasicState : State {

    private List<SearchConf> searchConfig = new List<SearchConf>();
    private List<string> searchTags = new List<string>();
    private FSMManager manager;
    private Config _config;

    public BasicState(FSMManager manager) {
        this.manager = manager;
        this.from = manager.gameObject;
        this.fromAttr = manager.GetComponent<BasicObjectAttr>();
        this._config = Config.getInstance();
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


        Collider2D[] cs = Physics2D.OverlapCircleAll(obj.transform.position, fromAttr.dangerViewAreaRadius);


        foreach (Collider2D c in cs) {
            if ( this.searchTags.Contains(c.tag)
            && isVisible(c)) {
                State n = notify(c.gameObject, true);
                if (n != null) {
                    manager.setCurrentState(n);
                }
            }
        }

        cs = Physics2D.OverlapCircleAll(obj.transform.position, fromAttr.viewLimit);

        foreach (Collider2D c in cs) {
            if ( this.searchTags.Contains(c.tag)
            && isVisible(c)) {
                State n = notify(c.gameObject, false);
                if (n != null) {
                    manager.setCurrentState(n);
                }
            }
        }



        return this;
    }


    private bool isVisible(Collider2D target) {

        var diff = (target.transform.position - from.transform.position).normalized;

        float diffAng = (from.transform.forward.normalized - diff).magnitude;
        bool visible = diffAng < (fromAttr.viewAngle / 180);

        if (visible) {
            var raycast = Physics2D.Raycast(from.transform.position, from.transform.position - target.transform.position);
            if (raycast && raycast.collider == target) {
                return true;
            }
        }

        return false;

    }


    private State notify(GameObject gameObject0, bool dangerArea) {
        foreach (SearchConf c in this.searchConfig) {
            if (c.searchTypes.Contains(gameObject0.tag)) {

                Player player = gameObject0.GetComponent<Player>();

                if(player.disguised && !dangerArea && !_config.alert){
                    return null;
                }

                if (_config.alert) {
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