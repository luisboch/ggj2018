using UnityEngine;
using UnityEngine.AI;

public class SoldierLvl2 : MonoBehaviour {
    private BasicObjectAttr fromAttr;
    public GameObject originalPos;

    void Start() {
        //        originalPos.transform.
        this.originalPos.transform.parent = null;

        fromAttr = GetComponent<BasicObjectAttr>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        FSMManager manager = GetComponent<FSMManager>();

        IdleState idle = new IdleState();
        idle.isInfinite = true;
        InvestigateState investigateState = new InvestigateState();
        manager.setCurrentState(idle);

        manager.GetBasicState().configure("Player",
                (o) => {
                    investigateState.setTargetPos(o.transform.position).SetDoWhenArrive((s) => {

                        Collider[] coll = Physics.OverlapSphere(gameObject.transform.position, fromAttr.dangerViewAreaRadius);
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
                },
                (o) => {
                    investigateState.setTargetPos(o.transform.position);
                    investigateState.SetDoWhenArrive((s) => {

                        Collider[] coll = Physics.OverlapSphere(gameObject.transform.position, fromAttr.dangerViewAreaRadius);
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
    }
}