using UnityEngine;

public class RandomState : State {

    private System.Random rnd = new System.Random();


    public override int getCod() {
        return 4;
    }

    public override void start(GameObject obj) {
        base.start(obj);
        changeDirTo(newRandomDir());
    }

    public override State update(UnityEngine.GameObject obj) {

        // no item found, then we will continue our search.
        if (rnd.NextDouble() < fromAttr.chanceToChangeDir) {
            changeDirTo(newRandomDir());
        }

        if (rnd.NextDouble() < fromAttr.chanceToChangeVel) {
            changeVel();
        }

        return this;
    }

    private Vector3 newRandomDir() {
        return new Vector3((float) rnd.NextDouble() * (rnd.Next(0, 1) == 0 ? -1 : 1), 0f,
                (float) rnd.NextDouble() * (rnd.Next(0, 1) == 0 ? -1 : 1)).normalized;
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

    private void changeDirTo(Vector3 direction) {
        from.transform.forward = direction;

        //        from.transform.LookAt(from.transform.position + direction);
    }

}