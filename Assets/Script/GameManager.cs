using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool picked;
    private int pair;
    private int pairCounter;
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
            StartCoroutine(CheckMatch());


        }
    }
    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(0.5f);

        if (pickCard[0].GetcardId() == pickCard[1].GetcardId())
        {
            // Match Scoring increase
            pickCard[0].gameObject.SetActive(false);
            pickCard[1].gameObject.SetActive(false);
            pairCounter++;
            CheckForWin();

        }
        else
        {
            pickCard[0].FlippedOpen(false);
            pickCard[1].FlippedOpen(false);
            //yield return new WaitForSeconds(0.5f);
        }



        // clearn up 
        picked = false;
        pickCard.Clear();
    }
    private void CheckForWin()
    {
        if (pair == pairCounter)
        {
            //Won condition
        }
    }
    public void SetPair(int pairAmount)
    {
        pair = pairAmount;
    }

    public bool HasPicked()
    {
        return picked;
    }
}
