using UnityEngine;

[RequireComponent(typeof(SimpleMobileController))]
public class Player : MonoBehaviour {

    public bool disguised = false;
    public float velocityMultiplier = 0.5f;
    public float runMultiplier = 0.5f;
    public float radius = 0.5f;
    public float height = 1f;


    private SimpleMobileController mobileController;

    private SoldierAnimatorController animatorController;

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position + new Vector3(0f, height, 0f), radius);
    }
    // Use this for initialization
    void Awake() {
        mobileController = GetComponent<SimpleMobileController>();
    }

    void Start() {
        animatorController = GetComponent<SoldierAnimatorController>();
    }

    // Update is called once per frame
    void Update() {
        // Funcao de Movimentacao
        Move();

        // Verifica se há algum objeto com ação proximo
        CheckForActionItem();
    }

    void Move() {
        Vector3 movement;
        float run;

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //float run = Mathf.Abs(Input.GetAxisRaw("X360_RightTrigger01"));
        run = Input.GetButton("Jump") ? 1 : 0;

        // Maybe mobile movement?
        if (movement == Vector3.zero) {
            movement = new Vector3(mobileController.getHorizontal(), 0, mobileController.getVertical());
            run = mobileController.getAction2() ? 1 : 0;
        }

        Vector3 dir = transform.position + movement;
        transform.LookAt(dir);

        run *= runMultiplier;
        float multiplierResult = velocityMultiplier + run;
        transform.position += (  multiplierResult * movement * Time.deltaTime);

        animatorController.setForward(movement.magnitude);
    }

    // Update is called once per frame
    void CheckForActionItem() {
        bool action = false;
        action = Input.GetButtonDown("Fire1") || mobileController.getAction1();
        if (action)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position + new Vector3(0f, height, 0f), radius);
            foreach (Collider other in colliders) {

                other.gameObject.Send<Actionable>(_ => _.doAction(this));
            }
        }
    }
}
