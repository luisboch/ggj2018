using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    float timeRemaining = 0f;

    public GameObject buttonPlayGame;
    public GameObject buttonCredits;
    public GameObject buttonNameCredits;
    public GameObject buttonNameCredits2;
    public GameObject logo;
    public GameObject buttonNamePlayers;
    public GameObject buttonNameZombies;
    public GameObject buttonNameShoot;
    public GameObject buttonNameAim;
    public GameObject buttonNameMove;
    public GameObject buttonBack;
    public GameObject howToPlay;

    public Text play;
    public Text credits;

    private bool sceneCredits;

    public enum PositionMenu {
        PLAY,
        CREDITS,
        BACK      
    }

    public PositionMenu positionMenu;

    // Use this for initialization
    void Start () {

        sceneCredits = false;

        buttonPlayGame.SetActive(true);
        buttonCredits.SetActive(true);
        buttonNameCredits.SetActive(false);
        buttonNameCredits2.SetActive(false);
        logo.SetActive(false);
        buttonNamePlayers.SetActive(true);
        buttonNameZombies.SetActive(true);
        buttonNameShoot.SetActive(true);
        buttonNameAim.SetActive(true);
        buttonNameMove.SetActive(true);
        buttonBack.SetActive(false);
        howToPlay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position == new Vector3(0, 0, -10))
        {

            timeRemaining += Time.deltaTime;
            float seconds = (timeRemaining % 60);

            if (seconds > 1)
            {


                // Verifica comando do controle do Xbox
                controllerXBOX();

                // Selecionar componente do menu de acordo com comando do controle
                positionsMenu();


                // Entrar em alguma opcao do menu / cena
                if (((Input.GetButtonDown("X360_A01"))) || ((Input.GetButtonDown("X360_A02"))) || ((Input.GetButtonDown("X360_A03"))) || ((Input.GetButtonDown("X360_A04"))))
                {
                    if (!sceneCredits)
                    {
                        if (positionMenu == PositionMenu.PLAY)
                        {
                            SceneManager.LoadScene("MapSceneNavMesh");
                        }
                        else if (positionMenu == PositionMenu.CREDITS)
                        {
                            callCredits();
                            positionMenu = PositionMenu.BACK;
                            sceneCredits = true;
                        }
                    }
                    else
                    {
                        if (positionMenu == PositionMenu.BACK)
                        {
                            positionMenu = PositionMenu.PLAY;
                            callBack();
                            sceneCredits = false;
                        }
                    }
                }
            }
        }     
    }    

    void controllerXBOX() {
        if (((Input.GetAxisRaw("X360_LStickY01") < 0)) || ((Input.GetAxisRaw("X360_LStickY02") < 0)) || ((Input.GetAxisRaw("X360_LStickY03") < 0)) || ((Input.GetAxisRaw("X360_LStickY04") < 0)))
        {
            positionMenu = PositionMenu.CREDITS;

        }
        if (((Input.GetAxisRaw("X360_LStickY01") > 0)) || ((Input.GetAxisRaw("X360_LStickY02") > 0)) || ((Input.GetAxisRaw("X360_LStickY03") > 0)) || ((Input.GetAxisRaw("X360_LStickY04") > 0)))
        {
            positionMenu = PositionMenu.PLAY;
        }
    }

    void positionsMenu() {
        switch (positionMenu)
        {
            case PositionMenu.PLAY:
                play.color = Color.white;
                credits.color = Color.gray;
                break;
            case PositionMenu.CREDITS:
                play.color = Color.gray;
                credits.color = Color.white;
                break;
        }
    }


    void callCredits() {
        buttonPlayGame.SetActive(false);
        buttonCredits.SetActive(false);
        buttonNameCredits.SetActive(true);
        buttonNameCredits2.SetActive(true);
        logo.SetActive(true);
        buttonNamePlayers.SetActive(false);
        buttonNameZombies.SetActive(false);
        buttonNameShoot.SetActive(false);
        buttonNameAim.SetActive(false);
        buttonNameMove.SetActive(false);
        buttonBack.SetActive(true);
        howToPlay.SetActive(false);
    }


    void callBack()
    {
        buttonPlayGame.SetActive(true);
        buttonCredits.SetActive(true);
        buttonNameCredits.SetActive(false);
        buttonNameCredits2.SetActive(false);
        logo.SetActive(false);
        buttonNamePlayers.SetActive(true);
        buttonNameZombies.SetActive(true);
        buttonNameShoot.SetActive(true);
        buttonNameAim.SetActive(true);
        buttonNameMove.SetActive(true);
        buttonBack.SetActive(false);
        howToPlay.SetActive(true);
    }

}
