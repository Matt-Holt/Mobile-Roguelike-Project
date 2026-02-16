using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    private CardDeck deck;
    private GameObject blueprint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBlueprint(GameObject blueprint)
    {
        this.blueprint = blueprint;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PartyMember.selectedPartyMember.RemoveCard(blueprint);
        if (PartyMember.selectedPartyMember.IsDeckEmpty())
        {
            deck.HideDeck();
        }
        Destroy(gameObject);
    }

    public void SetDeck(CardDeck deck)
    {
        this.deck = deck;
    }
}
