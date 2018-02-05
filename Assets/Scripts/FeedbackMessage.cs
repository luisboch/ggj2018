using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
class MessageItem {
    public string Message;
    public float DurationTime;
}

class FeedbackMessage : MonoBehaviour {
    private static FeedbackMessage _instance = null;

    public List<MessageItem> Messages = new List<MessageItem>();

    public GUIStyle style = new GUIStyle();

    void Awake() {
        if (_instance == null) {
            _instance = this;
            style.fontSize = 20;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;
        }
    }

    public static FeedbackMessage getInstance() {
        if (_instance == null) {
            _instance = new FeedbackMessage();
        } else {
        }
        return _instance;
    }

    void Update() {
        /*
        currentTime = Time.time;
        if(someRandomCondition)
            showText = true;
        else
            showText = false;

        if(executedTime != 0.0f)
        {
            if(currentTime - executedTime > timeToWait)
            {
                executedTime = 0.0f;
                someRandomCondition = false;
            }
        }
        */

        foreach (var message in Messages.ToList()) {
            message.DurationTime -= Time.deltaTime;

            if (message.DurationTime < 0)
            {
                Messages.Remove(message);
            }
        }
    }

    public void AddMessage(string message, float durationTime) {
        var item = new MessageItem
        {
            Message = message,
            DurationTime = durationTime
        };

        var existingMessage = Messages.Find(m => m.Message == message);

        if (existingMessage == null)
        {
            Messages.Add(item);
        }
        else
        {
            existingMessage.DurationTime = durationTime;
        }
    }

    void OnGUI() {

        var yOffset = 0;

        foreach (var message in Messages) {
            GUI.Label(new Rect(10, yOffset, 300, 100), message.Message, style);
            yOffset += 20;
        }
    }
}