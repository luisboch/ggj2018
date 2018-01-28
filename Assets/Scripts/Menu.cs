using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    float timeRemaining;
    public string firstScene;

    public Text playText;
    public Text creditsText;

    public GameObject play;
    public GameObject credits;
    public GameObject back;
    public GameObject imgGGJ;
    public GameObject imgJoy;
    public GameObject creditsInfo1;
    public GameObject creditsInfo2;
    public GameObject aim;
    public GameObject move;
    public GameObject action;

    public enum MainOption {
        PLAY,
        CREDITS
    }

    public MainOption MainMenuOption;

    public enum MenuScreen
    {
        MAIN,
        CREDITS
    }

    public MenuScreen currentScreen;

    // Use this for initialization
    void Start () 
    {
        CallMainMenu();
    }

    void GetMenuOptionFromControllerXBOX()
    {
        if (currentScreen == MenuScreen.MAIN)
        {
            if (((Input.GetAxisRaw("X360_LStickY01") < 0)) || ((Input.GetAxisRaw("X360_LStickY02") < 0)) || ((Input.GetAxisRaw("X360_LStickY03") < 0)) || ((Input.GetAxisRaw("X360_LStickY04") < 0)))
            {
                MainMenuOption = MainOption.CREDITS;
            }
            if (((Input.GetAxisRaw("X360_LStickY01") > 0)) || ((Input.GetAxisRaw("X360_LStickY02") > 0)) || ((Input.GetAxisRaw("X360_LStickY03") > 0)) || ((Input.GetAxisRaw("X360_LStickY04") > 0)))
            {
                MainMenuOption = MainOption.PLAY;
            }
            switch (MainMenuOption)
            {
                case MainOption.PLAY:
                    playText.color = Color.white;
                    creditsText.color = Color.gray;
                    break;
                case MainOption.CREDITS:
                    playText.color = Color.gray;
                    creditsText.color = Color.white;
                    break;
            }
        }
        else
        {
            if (Input.GetButtonDown("X360_B01"))
            {
                CallMainMenu();
            }
        }
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
                GetMenuOptionFromControllerXBOX();

                if(currentScreen == MenuScreen.MAIN)
                {
                    // Entrar em alguma opcao do menu / cena
                    if (Input.GetButtonDown("X360_A01"))
                    {
                        if (MainMenuOption == MainOption.PLAY)
                        {
                            if (string.IsNullOrEmpty(firstScene))
                            {
                                return;
                            }
                            SceneManager.LoadScene(firstScene);
                        }
                        else if (MainMenuOption == MainOption.CREDITS)
                        {
                            CallCredits();
                        }
                    }
                }                
            }
        }
    }

    void CallMainMenu()
    {
        currentScreen = MenuScreen.MAIN;
        play.SetActive(true);
        credits.SetActive(true);
        back.SetActive(false);
        imgGGJ.SetActive(false);
        imgJoy.SetActive(true);
        creditsInfo1.SetActive(false);
        creditsInfo2.SetActive(false);
        aim.SetActive(true);
        move.SetActive(true);
        action.SetActive(true);
    }


    void CallCredits() 
    {
        currentScreen = MenuScreen.CREDITS;
        play.SetActive(false);
        credits.SetActive(false);
        back.SetActive(true);
        imgGGJ.SetActive(true);
        imgJoy.SetActive(false);
        creditsInfo1.SetActive(true);
        creditsInfo2.SetActive(true);
        aim.SetActive(false);
        move.SetActive(false);
        action.SetActive(false);
    }


}
