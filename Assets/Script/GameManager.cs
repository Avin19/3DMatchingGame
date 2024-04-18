using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool picked;

    List<Card> pickCard = new List<Card>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void AddCardTopickList(Card card)
    {
        pickCard.Add(card);
        if (pickCard.Count == 2)
        {
            picked = true;


        }
    }
    public bool HasPicked()
    {
        return picked;
    }
}
