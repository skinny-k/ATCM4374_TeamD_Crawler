using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] GameObject _visuals;
    [SerializeField] TMP_Text _title;
    [SerializeField] TMP_Text _description;
    [SerializeField] Image _image;
    [SerializeField] Button _playButton;
    
    CardObject card;
    
    public void SetCard(CardObject newCard)
    {
        card = newCard;

        RenderData(card != null);
    }

    public void EnablePlay(bool state)
    {
        _playButton.gameObject.SetActive(state);
    }

    public void PlayCard()
    {
        card.Play();
    }

    void RenderData(bool state)
    {
        if (state)
        {
            _visuals.SetActive(true);
            _title.text = card.CurrentCardData.Title;
            _description.text = card.CurrentCardData.Description;
            _image.sprite = card.CurrentCardData.Image;
        }
        else
        {
            _visuals.SetActive(false);
        }
    }
}
