using System.Collections;
using UnityEngine.EventSystems;

public interface Actionable : IEventSystemHandler{
    IEnumerable doAction(Player p);
}