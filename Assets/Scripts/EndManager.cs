using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndManager : MonoBehaviour
{
    [SerializeField] GameObject _endUI;
    [SerializeField] Image _colorField;
    [SerializeField] TMP_Text _winText;

    void OnEnable()
    {
        QuestManager.OnAllQuestsComplete += OnGameEnd;
    }

    void OnDisable()
    {
        QuestManager.OnAllQuestsComplete -= OnGameEnd;
    }

    void OnGameEnd()
    {
        List<Player> winners = new List<Player>();
        
        foreach(Player player in TurnManager.Instance.Players)
        {
            if (winners.Count == 0 || player.ScoreKeeper.Score == winners[0].ScoreKeeper.Score)
            {
                winners.Add(player);
                
            }
            else if (player.ScoreKeeper.Score > winners[0].ScoreKeeper.Score)
            {
                winners.Clear();
                winners.Add(player);
            }
        }

        string winnerNames = "";
        Color winnerColor = Color.white;
        for (int i = 0; i < winners.Count; i++)
        {
            winnerNames += winners[i].gameObject.name;
            if (i < winners.Count - 1)
            {
                winnerNames += " and ";
            }
        }

        if (winners.Count == 1)
        {
            winnerNames += " won!\n";
            winnerColor = winners[0].PlayerColor;
        }
        else
        {
            winnerNames += " tied!\n";
        }

        string pointTotal = "with " + winners[0].ScoreKeeper.Score + " points\n\n";

        string otherPlayers = "";
        foreach (Player player in TurnManager.Instance.Players)
        {
            if (!winners.Contains(player))
            {
                otherPlayers += player.gameObject.name + ": " + player.ScoreKeeper.Score + "\n";
            }
        }

        string fullString = winnerNames + pointTotal + otherPlayers;

        _colorField.color = winnerColor;
        _winText.text = fullString;
        _endUI.SetActive(true);
    }
}
