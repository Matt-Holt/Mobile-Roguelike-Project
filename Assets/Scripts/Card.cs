using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    RectTransform rectTransform;
    private CardDeck deck;
    private GameObject blueprint;
    [SerializeField] private CardType cardType;
    [SerializeField] public int value;
    public int energyCost;

    public enum CardType
    {
        AttackSpecific,
        AttackAll,
        BuffSelf,
        BuffOther
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SlideToCentre()
    {
        transform.parent = deck.transform.parent;
        Vector2 startPos = rectTransform.anchoredPosition;
        float duration = 0.15f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, Vector3.zero, t);
            yield return null;
        }
        rectTransform.anchoredPosition = Vector2.zero;
        Destroy(gameObject, duration / 2);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        deck.HideDeck();
        deck.lastUsedCard = blueprint.GetComponent<Card>();
        print(deck.lastUsedCard);
        PartyMember.selectedPartyMember.RemoveCard(blueprint);
        StartCoroutine(SlideToCentre());
        if (cardType == CardType.AttackSpecific)
        {

        }
        else if (cardType == CardType.AttackAll)
        {

        }
        else if (cardType == CardType.BuffSelf)
        {

        }
        else if (cardType == CardType.BuffOther)
        {

        }
    }

    private void SelectAttacker()
    {

    }

    private void SelectPartyMember()
    {

    }

    public void SetBlueprint(GameObject blueprint)
    {
        this.blueprint = blueprint;
    }

    public void SetDeck(CardDeck deck)
    {
        this.deck = deck;
    }

    public CardType GetCardType()
    {
        return cardType;
    }
}
