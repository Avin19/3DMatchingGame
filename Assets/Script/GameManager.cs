using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool picked;
    private int pair;
    private int pairCounter;
    private int score = 0;
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
            if (pickCard[0].transform.position == pickCard[1].transform.position)
            {

            }
            else
            {
                picked = true;
                StartCoroutine(CheckMatch());
            }

        }


    }
    private IEnumerator CheckMatch()
    {

        yield return new WaitForSeconds(0.2f);
        if (pickCard[0].GetcardId() == pickCard[1].GetcardId())
        {
            score++;
            UIHandler.Instance.UpdateScore(score);
            AudioManager.Instance.Match();


            pickCard[0].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.05f);
            pickCard[1].gameObject.SetActive(false);

            pairCounter++;

            CheckForWin();

        }
        else
        {

            pickCard[0].FlippedOpen(false);

            pickCard[1].FlippedOpen(false);
            AudioManager.Instance.MisMatch();


        }
        yield return new WaitForSeconds(0.1f);
        picked = false;
        pickCard.Clear();

        // clearn up 

    }
    private void CheckForWin()
    {
        if (pair == pairCounter)
        {
            UIHandler.Instance.Win();
            AudioManager.Instance.Win();

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
