using System.Collections.Generic;
using UnityEngine;

public class Search : State {

    private List<Config> searchConfig = new List<Config>();
    private List<string> searchTags = new List<string>();

    private System.Random rnd = new System.Random();


    public override int getCod() {
        return 4;
    }

    public override void start(GameObject obj) {
        base.start(obj);

        changeDirTo(newRandomDir());
    }

    public Search config(string lookingType, EventAction doWhenLocate) {
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

    public Search clear() {
        this.searchConfig.Clear();
        return this;
    }

    public override State update(GameObject obj) {

        // just validation
        if (obj == null || !fromAttr.isAlive().GetValueOrDefault(false)) {
            return null;
        }

        Collider[] cs = Physics.OverlapSphere(obj.transform.position, fromAttr.viewLimit);


        foreach (Collider c in cs) {
            if ( this.searchTags.Contains(c.tag)
            && isVisible(c.transform.position)) {
                State n = notify(c.gameObject);
                if (n != null) {
                    return n;
                }
            }
        }

        // no item found, then we will continue our search.
        if (rnd.NextDouble() < fromAttr.chanceToChangeDir) {
            changeDirTo(newRandomDir());
        }

        if (rnd.NextDouble() < fromAttr.chanceToChangeVel) {
            changeVel();
        }

        return this;
    }


    private bool isVisible(Vector3 target) {

        var diff = (target - from.transform.position).normalized;

        float diffAng = (from.transform.forward.normalized - diff).magnitude;
        return diffAng < (fromAttr.viewAngle / 180);
    }


    private Vector3 newRandomDir() {
        return new Vector3((float) rnd.NextDouble() * (rnd.Next(0, 1) == 0 ? -1 : 1), 0f,
                (float) rnd.NextDouble() * (rnd.Next(0, 1) == 0 ? -1 : 1)).normalized;
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

    private void changeDirTo(Vector3 direction) {
        from.transform.forward = direction;

        //        from.transform.LookAt(from.transform.position + direction);
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

    private void changeVel() {
        float vl = (float) rnd.NextDouble();

        if (vl < 0.3f) {
            vl = 0;
        } else if (vl < 0.7f) {
            vl = 0.5f;
        } else {
            vl = 1f;
        }
//        from.Send<IAnimalAnimatorHelper>(_ => _.run(vl));
    }

    public override string ToString() {
        return "SEARCH";
    }

}