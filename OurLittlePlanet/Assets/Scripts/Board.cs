using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Board : MonoBehaviour
{

    [SerializeField] EventDeck m_EventDeck;
    [SerializeField] Deck m_Deck;
    [SerializeField] Hand m_Hand;
    [SerializeField] Discard m_Discard;
    [SerializeField] Market m_Market;
    [SerializeField] WorldMap m_Map;

    public Action<StatsManager> EndTurnImpactCalculations => m_Map.CalcEndTurnImpact;
    public Action<StatsManager> SetNextEvent => SetAndActivateNextEvent;
    public void InitBoard()
    {
    }

    public void SetDrwaingSelectable(bool isSelectable)
    {
        m_Deck.SetSelectable(isSelectable);
    }

    public void SetPlayingSelectable(bool isSelectable)
    {
        m_Hand.SetSelectable(isSelectable);
        m_Market.SetSelectable(isSelectable);
        m_Hand.SetSelectable(isSelectable);
    }

    public void SetBuildSelectable(bool isSelectable)
    {
        m_Map.SetSelectable(isSelectable);
    }

    public void DrawCardToHand(int cardsToDraw)
    {
        RefilDeckIfNeeded();

        for (int i = 0; i < cardsToDraw; i++)
        {
            Card cardToHand = m_Deck.DrawCard();
            m_Hand.AddCard(cardToHand);

            RefilDeckIfNeeded();
        }
    }

    public void BuildCard(Slot slot, int mapIndex = 0)
    {
        Card card = m_Hand.DrawCard(slot);
        if (card != null)
        {
            m_Map.BuildCard(mapIndex, card);
            m_Discard.AddCard(card);
        }
    }


    public void DiscardHand()
    {
        Debug.Log("DiscardHand");
        var cards = m_Hand.RemoveAllCards();

        foreach (Card card in cards)
        {
            m_Discard.AddCard(card);
        }
    }

    public void RefilDeckIfNeeded()
    {
        if (m_Deck.CardsAmount > 0)
        {
            return;
        }
        Debug.Log($"ShuffleAndGetCards m_Discard: {m_Discard.CardsAmount}");
        var cards = m_Discard.ShuffleAndGetCards();

        foreach (Card card in cards)
        {
            m_Deck.AddCard(card);
        }
        Debug.Log($"RefilDeck to m_Deck {m_Deck.CardsAmount}");
    }

    public void BuyCard(Slot slot)
    {
        Card card = m_Market.DrawCard(slot);
        m_Discard.AddCard(card);
        Debug.Log($"Discard {card}");
    }

    public void AddEventCardToEventDeck()
    {
        m_EventDeck.AddEventCardToEventDeck();
    }

    private void SetAndActivateNextEvent(StatsManager statsManager)
    {
        EventCard newEvent = m_EventDeck.SelectEventCard();
        newEvent.ActivateEvent(m_Map, statsManager);
    }
}
