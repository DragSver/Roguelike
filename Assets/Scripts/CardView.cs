using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public CardStats CardStat;

    public TextMeshProUGUI title;
    public Image CardImage;
    public TextMeshProUGUI description;
    
    public Image damage;
    public Image heal;
    public Image defense;

    public void ShowCard(CardStats cardStat)
    {
        CardStat = cardStat;
        
        if (CardStat.Damage == 0)
            damage.gameObject.SetActive(false);
        else
        {
            damage.gameObject.SetActive(true);
            damage.GetComponentInChildren<TextMeshProUGUI>().text = CardStat.Damage.ToString();
        }
        if (CardStat.Defense == 0)
            defense.gameObject.SetActive(false);
        else
        {
            defense.gameObject.SetActive(true);
            defense.GetComponentInChildren<TextMeshProUGUI>().text = CardStat.Defense.ToString();
        }
        if (CardStat.Heal == 0)
            heal.gameObject.SetActive(false);
        else
        {
            heal.gameObject.SetActive(true);
            heal.GetComponentInChildren<TextMeshProUGUI>().text = CardStat.Heal.ToString();
        }

        title.text = CardStat.Name;
        CardImage.sprite = CardStat.Image;
        description.text = CardStat.CountAddCards switch
        {
            0 => CardStat.Description,
            1 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карту",
            2 or 3 or 4 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карты",
            5 or 6 or 7 or 8 or 9 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карт",
            _ => description.text
        };
    }
}
