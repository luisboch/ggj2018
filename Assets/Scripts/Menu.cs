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
    void Start() {
    }

    void UpdateMenuPos() {
        float vertical = Input.GetAxis("Vertical");
        vertical += SimpleMobileController.GetInstance().getVertical();

        if (vertical > 0) {
            MainMenuOption = MainOption.PLAY;
        } else if (vertical < 0) {
            MainMenuOption = MainOption.CREDITS;
        }

        switch (MainMenuOption) {
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
    void Update() {

        // Verifica comando do controle do Xbox
        UpdateMenuPos();

        // Entrar em alguma opcao do menu / cena
        if (Input.GetButtonDown("Fire1") || SimpleMobileController.GetInstance().getAction1())
        {
            if (MainMenuOption == MainOption.PLAY)
            {
                PlayGame();
            }
            else if (MainMenuOption == MainOption.CREDITS)
            {
                goToScene("Credits");
            }
        }
    }

    public void goToScene(string scene) {
        Initiate.Fade(scene, Color.black, fadeTime);
    }

    public void PlayGame() {
        Initiate.Fade(firstScene, Color.black, fadeTime);
    }
}
