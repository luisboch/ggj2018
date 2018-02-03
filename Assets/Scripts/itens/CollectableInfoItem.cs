using UnityEngine;
using System.Collections;

public class CollectableInfoItem : MonoBehaviour, Actionable {

    public IEnumerable doAction(Player p) {
        Config.getInstance().UpdateCollectedInfos();
        FeedbackMessage.getInstance().AddMessage("Voce pegou uma informação", 5);
        Destroy(gameObject);
        yield return null;
    }
}