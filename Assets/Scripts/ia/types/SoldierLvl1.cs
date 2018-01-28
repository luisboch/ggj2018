using UnityEngine;
using UnityEngine.AI;

public class SoldierLvl1 : MonoBehaviour {

    private BasicObjectAttr fromAttr;
    public GameObject originalPos;

    void Start() {
        fromAttr = GetComponent<BasicObjectAttr>();
        this.originalPos.transform.parent = null;
        FSMManager manager = GetComponent<FSMManager>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        RandomState search = new RandomState();
        FollowState follow = new FollowState();
        IdleState idle = new IdleState();
        idle.isInfinite = true;
        InvestigateState investigateState = new InvestigateState();

        manager.GetBasicState().configure("Player",
                (o) => {
                    return null;
                },
                (o) => {
                    investigateState.setTargetPos(o.transform.position);
                    investigateState.SetDoWhenArrive((s) => {

                        Collider[] coll = Physics.OverlapSphere(gameObject.transform.position, fromAttr.dangerViewAreaRadius);
                        Debug.Log("Clll" + coll.Length);
                        foreach (Collider c in coll) {
                            if (c.tag.Equals("Player")) {
                                var go = Camera.main.GetComponent<GameOverCameraControl>();
                                go.showDeadEffect = true;
                                return null;
                            }
                        }

                        idle.time = fromAttr.investigateWaitTime;
                        idle.isInfinite = false;
                        idle.onComplete((s1) => {
                            investigateState.setTargetPos(this.originalPos.transform.position);
                            investigateState.SetDoWhenArrive((s2) => {
                                idle.isInfinite = true;
                                transform.rotation = this.originalPos.transform.rotation;
                                agent.destination = this.transform.position;
                                return idle;
                            });
                            return investigateState;
                        });
                        return idle;
                    });

                    return investigateState;
                });
        manager.setCurrentState(idle);
    }
}