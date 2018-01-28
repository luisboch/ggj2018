using UnityEngine;

public class SoldierAnimatorController : MonoBehaviour {
    private Animator animator;

    void Start() {
        this.animator = GetComponent<Animator>();
    }

    public void setForward(float forward) {
        this.animator.SetFloat("Forward", forward);
    }
}