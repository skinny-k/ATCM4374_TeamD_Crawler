using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardHand))]
[RequireComponent(typeof(PlayerScore))]
public class Player : MonoBehaviour
{
    public CardHand Hand { get; private set; }
    public PlayerScore Score { get; private set; }
    
    void Start()
    {
        Hand = GetComponent<CardHand>();
        Score = GetComponent<PlayerScore>();
    }
}
