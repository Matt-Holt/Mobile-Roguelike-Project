using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDeck : MonoBehaviour
{
    private bool display;
    public Card lastUsedCard = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetBool("Display", display);
    }

    public void UpdateCards(GameObject[] cards)
    {
        //Delete all existing cards first
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        int cardNum = 0;
        foreach (GameObject card in cards)
        {
            if (card != null)
            {
                GameObject cardInstance = Instantiate(card, transform.position, Quaternion.identity);
                cardInstance.transform.SetParent(transform);
                cardInstance.GetComponent<RectTransform>().localPosition = new Vector3(-455 + (cardNum * 455), 164, 0);
                cardInstance.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1.4f);
                cardInstance.GetComponent<Card>().SetDeck(this);
                cardInstance.GetComponent<Card>().SetBlueprint(card);
            }
            cardNum++;
        }
    }

    public void DisplayDeck()
    {
        display = true;
    }

    public void HideDeck()
    {
        display = false;
    }
}
