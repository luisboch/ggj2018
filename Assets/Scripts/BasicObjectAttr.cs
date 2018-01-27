using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicObjectAttr : MonoBehaviour, IEventSystemHandler {

    public int health = 1;

    public float viewLimit;

    public float dangerViewAreaRadius = 7f;
    public float viewAngle = 60;
    public float chanceToChangeDir = 0.01f;
    public float chanceToChangeVel = 0.01f;
    public float followLimit = 30f;
    public float arriveDist = 5f;
    public float velocity = 1f;

    void Start() {
    }

    void OnDrawGizmos() {

        if (dangerViewAreaRadius != null) {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, dangerViewAreaRadius);
        }
    }

    public bool? isAlive() {
        return health > 0;
    }

    public int? getHealth() {
        return health;
    }

    public float? getViewLimit() {
        return viewLimit;
    }


}