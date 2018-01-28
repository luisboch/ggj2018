using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public float fadeTime = 2.0f;
    float timeRemaining;
    public string firstScene;

    public Text playText;
    public Text creditsText;

    public GameObject play;
    public GameObject credits;
    public GameObject imgJoy;
    public GameObject aim;
    public GameObject move;
    public GameObject action;

    public enum MainOption {
        PLAY,
        CREDITS
    }

    public MainOption MainMenuOption;


    // Use this for initialization
    void Start () 
    {
    }

    void GetMenuOptionFromControllerXBOX()
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

                // Entrar em alguma opcao do menu / cena
                if (Input.GetButtonDown("X360_A01"))
                {
                    if (MainMenuOption == MainOption.PLAY)
                    {
                        Initiate.Fade(firstScene, Color.black, fadeTime);
                    }
                    else if (MainMenuOption == MainOption.CREDITS)
                    {
                        Initiate.Fade("Credits", Color.black, fadeTime);
                    }
                }
            }
        }
    }
}
