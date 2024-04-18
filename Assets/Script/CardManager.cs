using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private int pairAmount = 2;
    public Sprite[] sprites;

    private float offSet;

    [SerializeField] private GameObject pfCard;

    void Start()
    {

    }

    private void CreatePlayField()
    {
        for (int i = 0; i < pairAmount; i++)
        {

        }
    }

}
