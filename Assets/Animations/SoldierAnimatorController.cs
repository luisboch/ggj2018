using UnityEngine;

public class SoldierAnimatorController : MonoBehaviour {
    private Animator animator;
    private AudioSource walkSource;

    void Start() {
        this.animator = GetComponent<Animator>();
        this.walkSource = GetComponent<AudioSource>();
    }

    public void setForward(float forward) {
        this.animator.SetFloat("Forward", forward);
        if(walkSource){
            if(forward > 0.2f){
                walkSource.enabled = true;
            } else {
                walkSource.enabled = false;
            }
        }
    }
}