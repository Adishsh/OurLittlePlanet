using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    public UnityEvent DrawCards; 
    public UnityEvent EndTurn; 
    public UnityEvent WinGame; 
    public UnityEvent<Slot> BuyCard;
    public UnityEvent<Slot> SelectCard;
    public UnityEvent<Slot> SelectDiscardCard;
    public UnityEvent<int> BuildCard;

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
        WinGame = new UnityEvent(); 
        BuyCard = new UnityEvent<Slot>();
        SelectCard = new UnityEvent<Slot>();
        BuildCard = new UnityEvent<int>();
        SelectDiscardCard = new UnityEvent<Slot>();
    }

    public void EndTurnPressed()
    {
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Gameplay));
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Cards_Shuffle));
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