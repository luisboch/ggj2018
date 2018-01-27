using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Countdown countdown;

    float timeRemaining = 0f;
    public float velocity;
    public float force;

    private bool MoveRight, MoveLeft, MoveUp, MoveDown;


    public GameObject bulletPosition;
    public GameObject bullet;
    public GameObject spritePlayer;
    public GameObject arma;

    public bool disguised = false;

    private float life = 4;
    private int ammo = 10;

    //Text lifeText;
    //Text ammoText;

    //refer�ncias aos demais players para saber se o jogo
    //acabou ou n�o quando esse player morrer
    //GameObject player2;
    //GameObject player3;
    //GameObject player4;

    // Use this for initialization
    void Awake()
    {
        MoveRight = true;
        MoveLeft = false;
        MoveUp = false;
        MoveDown = false;

        
    }

    void Start()
    {
        countdown = FindObjectOfType(typeof(Countdown)) as Countdown;

        //lifeText = GameObject.Find("LifePlayer1").GetComponentInChildren<Text>();
        //ammoText = GameObject.Find("AmmoPlayer1").GetComponentInChildren<Text>();

        //lifeText.text = "x " + life;
        //ammoText.text = "x " + ammo;

        //player2 = GameObject.Find("Player2");
        //player3 = GameObject.Find("Player3");
        //player4 = GameObject.Find("Player4");

        AimingUp();
    }

    // Update is called once per frame
    void Update()
    {

        timeRemaining += Time.deltaTime;
        float seconds = (timeRemaining % 60);

        // Funcao de Movimentacao
        Move();
        CallAim();

        if (seconds > 0.3f)
        {
            if ((Input.GetAxisRaw("X360_RightTrigger01")) < 0)
            {
                Shoot();
                timeRemaining = 0;
            }
        }        
    }

    // Seleciona o tiro que sera utilizado e atira
    public void Shoot()
    {
        if (ammo > 0)
        {
            GameObject tmpBullet = (GameObject)(Instantiate(bullet, bulletPosition.transform.position, Quaternion.identity));

            if (MoveRight)
            tmpBullet.GetComponent<Bullet>().StartDirection(Vector3.right);
            else if (MoveLeft)
            tmpBullet.GetComponent<Bullet>().StartDirection(Vector3.left);
            else if (MoveUp)
            tmpBullet.GetComponent<Bullet>().StartDirection(new Vector3(0,0,1));
            else if (MoveDown)
            tmpBullet.GetComponent<Bullet>().StartDirection(new Vector3(0, 0, -1));

            //ammo -= 1;
            //ammoText.text = "x " + ammo;
        }
    }

    void AimingLeft()
    {
        MoveRight = false; MoveLeft = true; MoveUp = false; MoveDown = false;
        bulletPosition.transform.position = new Vector3(spritePlayer.transform.position.x - 0.5f, 1, spritePlayer.transform.position.z);
        arma.transform.position = new Vector3(spritePlayer.transform.position.x - 0.25f, 1, spritePlayer.transform.position.z);
    }

    void AimingRight()
    {
        MoveRight = true; MoveLeft = false; MoveUp = false; MoveDown = false;
        bulletPosition.transform.position = new Vector3(spritePlayer.transform.position.x + 0.5f, 1, spritePlayer.transform.position.z);
        arma.transform.position = new Vector3(spritePlayer.transform.position.x + 0.25f, 1, spritePlayer.transform.position.z);
    }

    void AimingUp()
    {
        MoveRight = false; MoveLeft = false; MoveUp = true; MoveDown = false;
        bulletPosition.transform.position = new Vector3(spritePlayer.transform.position.x, 1, spritePlayer.transform.position.z + 0.5f);
        arma.transform.position = new Vector3(spritePlayer.transform.position.x, 1, spritePlayer.transform.position.z + 0.25f);
    }

    void AimingDown()
    {
        MoveRight = false; MoveLeft = false; MoveUp = false; MoveDown = true;
        bulletPosition.transform.position = new Vector3(spritePlayer.transform.position.x, 1, spritePlayer.transform.position.z - 0.5f);
        arma.transform.position = new Vector3(spritePlayer.transform.position.x, 1, spritePlayer.transform.position.z - 0.25f);
    }

    void CallAim()
    {
        if (Input.GetAxisRaw("X360_RStickX01") < 0)
        {
            AimingLeft();
        }
        if (Input.GetAxisRaw("X360_RStickX01") > 0)
        {
            AimingRight();
        }
        if (Input.GetAxisRaw("X360_RStickY01") < 0)
        {
            AimingUp();
        }
        if (Input.GetAxisRaw("X360_RStickY01") > 0)
        {
            AimingDown();
        }
    }

    void Move()
    {
        var movimento = new Vector3(Input.GetAxisRaw("X360_LStickX01"), Input.GetAxisRaw("X360_LStickY01"), 0);
        transform.Translate(velocity * movimento.normalized * Time.deltaTime);
        movimento = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            //ammo += 5;
            //ammoText.text = "x " + ammo;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Life")
        {
            //life += 1;
            //lifeText.text = "x " + life;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Disguise")
        {
            DisguiseBox disguise = other.gameObject.GetComponent<DisguiseBox>();
            spritePlayer.GetComponent<SpriteRenderer>().sprite = disguise.sprite;
            Destroy(other.gameObject);
            disguised = true;
        }
        else if (other.gameObject.tag == "Info")
        {
            Config.getInstance().UpdateCollectedInfos();
            Destroy(other.gameObject);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(collision.gameObject);
        }
    }

    public void TakeDamage(GameObject enemy)
    {
        life -= 1;
        //lifeText.text = "x " + life;

        Destroy(enemy);

        if (life <= 0)
        {
            countdown.playersDied += 1;
            //Remove o player morto da cena
            Destroy(gameObject);

            //Verifica se os outros jogadores estão vivos ainda
            //if (player2.activeInHierarchy || player3.activeInHierarchy || player4.activeInHierarchy)
            //{
            //    return;
            //}
            //else
            //{
            //    //Executar game over
            //    SceneManager.LoadScene("SceneDied");
            //}
        }
    }

}
