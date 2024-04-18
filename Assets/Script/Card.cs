using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private int cardId;
    [SerializeField] private SpriteRenderer cardFront;

    [SerializeField] private Animator animator;


    public void Setcard(int id, Sprite sprite)
    {
        cardId = id;
        cardFront.sprite = sprite;
    }
    public void FlippedOpen(bool flipped)
    {

        animator.SetBool("FlippedOpen", flipped);

    }
    public int GetcardId()
    {
        return cardId;
    }




}
