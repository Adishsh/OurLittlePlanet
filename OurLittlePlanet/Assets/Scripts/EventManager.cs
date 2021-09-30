using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    public UnityEvent DrawCards; 
    public UnityEvent EndTurn; 
    public UnityEvent<Card> BuyCard;
    public UnityEvent<Card> SelectCard;
    public UnityEvent<int> BuildCard;


    private UnityAction<Card> SelectCardListener;
    private UnityAction<Card> BuyCardListener;
    private UnityAction DrawCardsListener;
    private UnityAction EndTurnListener;
    private UnityAction<int> BuildListener;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init (); 
                }
            }

            return eventManager;
        }
    }

    void Init ()
    {
        DrawCards = new UnityEvent();
        EndTurn = new UnityEvent(); 
        BuyCard = new UnityEvent<Card>();
        SelectCard = new UnityEvent<Card>();
        BuildCard = new UnityEvent<int>();
    }

    public void EndTurnPressed()
    {
        EndTurn.Invoke();
    }
/*
    public static void StartListening<T> (string eventName, UnityAction<T> listener)
    {
        UnityEvent<T> thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.AddListener (listener);
        } 
        else
        {
            thisEvent = new UnityEvent ();
            thisEvent.AddListener (listener);
            instance.eventDictionary.Add (eventName, thisEvent);
        }
    }

    public static void StopListening (string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.RemoveListener (listener);
        }
    }

    public static void TriggerEvent (string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.Invoke ();
        }
    }*/
}