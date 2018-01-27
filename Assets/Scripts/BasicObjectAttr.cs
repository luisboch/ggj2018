using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicObjectAttr : MonoBehaviour, IEventSystemHandler {

    public int health;

    public float viewLimit;

    public float dangerViewAreaRadius = 7f;
    public float viewAngle = 60;
    public float chanceToChangeDir = 0.01f;
    public float chanceToChangeVel = 0.01f;
    public float followLimit = 30f;
    public float arriveDist = 5f;

    public int animAttackForce = 1;

    public int coinQuantity = 0;

    void Start() {
    }

    public bool? isAlive() {
        return health > 0;
    }

    public bool? addCoin(int qty) {
        Debug.Log("Adding coin");
        this.coinQuantity += qty;
        return  true;
    }

    public int? getHealth() {
        return health;
    }

    public float? getViewLimit() {
        return viewLimit;
    }

    public IEnumerable takeHit(int force) {
        this.health -= force;
        yield return  null;
    }


    public int? getAnimAttackForce() {
        return this.animAttackForce;
    }

}