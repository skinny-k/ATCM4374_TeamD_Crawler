using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardData : ScriptableObject
{
    [SerializeField] string _title = "Title";
    public string Title => _title;

    [MultilineAttribute][SerializeField] string _description = "Description";
    public string Description => _description;

    [SerializeField] Sprite _obstacle;
    public Sprite Obstacle => _obstacle;

    [SerializeField] Sprite _pickup;
    public Sprite Pickup => _pickup;
}
