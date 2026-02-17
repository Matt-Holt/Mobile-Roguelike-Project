using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ClickObject(touch.position);
            }
        }
    }

    void ClickObject(Vector2 tapPos)
    {
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            return;

        Vector2 pos = Camera.main.ScreenToWorldPoint(tapPos);
        RaycastHit2D hit = Physics2D.Raycast(pos, transform.right * 0.5f, 0.5f);
        if (hit.collider != null)
        {
            string tag = hit.collider.tag;
            if (tag == "PartyMember")
            {
                Card lastUsedCard = FindObjectOfType<CardDeck>().lastUsedCard;
                if (lastUsedCard != null)
                {
                    //TO:DO Buff party member
                }
                else
                {
                    PartyMember member = hit.collider.GetComponent<PartyMember>();
                    member.SelectPartyMember(member);
                }
            }
            else if (tag == "Enemy")
            {
                Card lastUsedCard = FindObjectOfType<CardDeck>().lastUsedCard;
                print(lastUsedCard);
                if (lastUsedCard != null)
                {
                    //TO:DO Attack enemy with card
                    EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                    enemy.Damage(lastUsedCard.value);
                    FindObjectOfType<CardDeck>().lastUsedCard = null;
                }
                else
                {
                    //TO:DO Show enemy info
                }
            }
        }
        else
        {
            PartyMember.DeselectPartyMember();
        }
    }
}
