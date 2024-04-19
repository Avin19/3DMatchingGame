using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private int pairAmount;
    public Sprite[] sprites;

    private List<GameObject> cardDeck = new List<GameObject>();

    private float offSet = 1.25f;

    [SerializeField] private GameObject pfCard;

    [SerializeField] private int width;
    [SerializeField] private int height;

    void Start()
    {
        GameManager.Instance.SetPair(pairAmount);

    }
    public void SetHeightWidth(int width = 2, int height = 2)
    {
        this.width = width;
        this.height = height;
        pairAmount = width * height / 2;
    }
    public void StartGame()
    {
        CreatePlayField();
    }
    private void CreatePlayField()
    {
        for (int i = 0; i < pairAmount; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 pos = Vector3.zero;
                GameObject cardGO = Instantiate(pfCard, pos, Quaternion.identity);
                cardGO.GetComponent<Card>().Setcard(i, sprites[i]);
                cardDeck.Add(cardGO);
            }

        }
        for (int i = 0; i < cardDeck.Count; i++)
        {
            int index = Random.Range(0, cardDeck.Count);
            var temp = cardDeck[i];
            cardDeck[i] = cardDeck[index];
            cardDeck[index] = temp;
        }
        int num = 0;
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x * offSet, 0f, z * offSet);
                cardDeck[num].transform.position = pos;
                num++;
            }
        }

    }
    private void OnDrawGizmos()
    {
        if (pairAmount * 2 != width * height)
        {
            Debug.Log("Error : width *height shouldbe pairAmount * 2");
        }
        if (pairAmount > sprites.Length)
        {
            Debug.Log("To much pairs");

        }
    }

}
