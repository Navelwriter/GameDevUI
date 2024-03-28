using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEventBus : MonoBehaviour {
    public enum EventType { ReactionCorrect, ReactionWrong, ReactionDie };
    private static IDictionary<EventType, UnityEvent> events = new Dictionary<EventType, UnityEvent>();

    public static void Publish(EventType eventType) {
        Debug.LogFormat("EventBus: Publish {0}", eventType);
        UnityEvent publishedEvent;
        if (events.TryGetValue(eventType, out publishedEvent)) {
            publishedEvent.Invoke();
        }
    }

    public static void Subscribe(EventType eventType, UnityAction listener) {
        UnityEvent subscribedEvent;
        if(events.TryGetValue(eventType, out subscribedEvent)) {
            subscribedEvent.AddListener(listener);
            return;
        }

        subscribedEvent = new UnityEvent();
        subscribedEvent.AddListener(listener);
        events.Add(eventType, subscribedEvent);
    }

    public static void Unsubscribe(EventType eventType, UnityAction listener) {
        UnityEvent unsubscribedEventEvent;
        if (events.TryGetValue(eventType, out unsubscribedEventEvent)) {
            unsubscribedEventEvent.RemoveListener(listener);
        }
    }
}
