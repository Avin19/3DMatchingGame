using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.HasPicked())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Card currentCard = hit.transform.GetComponent<Card>();
                GameManager.Instance.AddCardTopickList(currentCard);
                currentCard.FlippedOpen(true);

            }
        }
    }
}
