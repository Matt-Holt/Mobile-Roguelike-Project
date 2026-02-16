using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    [SerializeField] private SpriteRenderer arrow;
    [SerializeField] private SpriteRenderer floorCircle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PartyMember.selectedPartyMember != null)
        {
            arrow.enabled = true;
            Vector2 pos = PartyMember.selectedPartyMember.transform.position;
            arrow.transform.position = new Vector2(pos.x, pos.y + 1);
            floorCircle.enabled = true;
            floorCircle.transform.position = new Vector2(pos.x, pos.y - 0.47f);
        }
        else
        {
            arrow.enabled = false;
            floorCircle.enabled = false;
        }
    }
}
