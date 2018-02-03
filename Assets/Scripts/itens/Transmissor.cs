using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Transmissor : MonoBehaviour, Actionable {


    public float radius = 1f;
    public string nextScene;

    public IEnumerable doAction(Player p) {
        if (Config.getInstance().IsAllInfosCollected())
        {
            Debug.Log("All infos collected!!!");
            FeedbackMessage.getInstance().AddMessage("Todas as informações coletadas", 5);
            Config.getInstance().SetNextScene(nextScene);
            Initiate.Fade("Victory", Color.black, 2f);
        }
        else
        {
            Debug.Log("Go get the infos MF!!!");
            FeedbackMessage.getInstance().AddMessage("Volte e pege todas as informações", 5);
        }
        yield return null;
    }

}
