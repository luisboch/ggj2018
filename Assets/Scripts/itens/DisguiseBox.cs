using System;
using UnityEngine;
using System.Collections;

public class DisguiseBox : MonoBehaviour, Actionable {

    public IEnumerable doAction(Player p) {

        if (!p.disguised)
        {
            FeedbackMessage.getInstance().AddMessage("Voce pegou um disfarce", 5);

            p.disguised = true;
        }

        yield return null;
    }
}
