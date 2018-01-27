using System.Collections.Generic;
using UnityEngine;

public class BasicState : State {

    private List<Config> searchConfig = new List<Config>();
    private List<string> searchTags = new List<string>();


    public BasicState config(string lookingType, EventAction doWhenLocate) {
        this.searchConfig.Add(new Config(lookingType, doWhenLocate));
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

    public class Config {

        public List<string> searchTypes = new List<string>();
        public EventAction doWhenLocate;

        public Config(string searchType, EventAction doWhenLocate) {
            this.searchTypes.Add(searchType);
            this.doWhenLocate = doWhenLocate;
        }

        public EventAction getDoWhenLocate() {
            return doWhenLocate;
        }

        public List<string> getSearchClass() {
            return searchTypes;
        }

    }

    public override int getCod() {
        return 6;
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

        Collider2D[] cs = Physics2D.OverlapCircleAll(obj.transform.position, fromAttr.viewLimit);


        foreach (Collider2D c in cs) {
            if ( this.searchTags.Contains(c.tag)
            && isVisible(c)) {
                State n = notify(c.gameObject);
                if (n != null) {
                    return n;
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


    private State notify(GameObject gameObject0) {
        foreach (Config c in this.searchConfig) {
            if (c.searchTypes.Contains(gameObject0.tag)) {
                return c.doWhenLocate.Invoke(gameObject0);
            }
        }

        // No config found for current obj.
        return null;
    }


    public override string ToString() {
        return "BASICSTATE";
    }
}