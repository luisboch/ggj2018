using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Countdown countdown;

    float timeRemaining = 0f;
    public float force;

    private bool MoveRight, MoveLeft, MoveUp, MoveDown;

    public bool disguised = false;
    public float velocityMultiplier = 0.5f;
    public float runMultiplier = 0.5f;

    private SoldierAnimatorController animatorController;

    // Use this for initialization
    void Awake() {
        MoveRight = true;
        MoveLeft = false;
        MoveUp = false;
        MoveDown = false;
    }

    void Start() {
        animatorController = GetComponent<SoldierAnimatorController>();
    }

    // Update is called once per frame
    void Update() {
        // Funcao de Movimentacao
        Move();
    }

    void Move() {
        Vector3 movement = new Vector3(Input.GetAxisRaw("X360_LStickX01"), 0, Input.GetAxisRaw("X360_LStickY01"));
        float run = Input.GetAxisRaw("X360_RightTrigger01");
        if (Input.GetAxisRaw("X360_RightTrigger01") < 0) {
            Debug.Log("RUNNIGN");
        }

        Vector3 dir = transform.position + movement;
        transform.LookAt(dir);
        Debug.Log(run);
        run *= runMultiplier;
        float multiplierResult = velocityMultiplier + run;
        transform.position += (  multiplierResult * movement * Time.deltaTime);

        animatorController.setForward(movement.magnitude);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Disguise")
        {
            if (!disguised) {
                DisguiseBox disguise = other.gameObject.GetComponent<DisguiseBox>();
                //                spritePlayer.GetComponent<SpriteRenderer>().sprite = disguise.sprite;
                disguised = true;
            }
        }
        else if (other.gameObject.tag == "Info")
        {
            Config.getInstance().UpdateCollectedInfos();
            Destroy(other.gameObject);

        }
    }
}
