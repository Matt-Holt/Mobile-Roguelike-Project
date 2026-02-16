using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PartyMember : MonoBehaviour
{
    private static GameObject selectedPartyMember;
    [SerializeField] private string memberName;
    [SerializeField] private Color colour;
    [SerializeField] private GameObject[] cards;
    // Start is called before the first frame update
    void Start()
    {
        cards = GetThreeRandomCards();
    }

    private GameObject[] GetThreeRandomCards()
    {
        List<GameObject> allCards = new List<GameObject>(Resources.LoadAll<GameObject>("Cards/" + memberName));
        List<GameObject> newCards = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            if (allCards.Count == 0)
                break;

            int n = Random.Range(0, allCards.Count);
            newCards.Add(allCards[n]);
            allCards.RemoveAt(n);
        }
        return newCards.ToArray();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectedPartyMember(GameObject partyMember)
    {
        selectedPartyMember = partyMember;
        CardDock deck = FindObjectOfType<CardDock>();
        deck.UpdateCards(cards);
        deck.DisplayDeck();
    }

    public static void DeselectPartyMember()
    {
        selectedPartyMember = null;
        FindObjectOfType<CardDock>().HideDeck();
    }
}