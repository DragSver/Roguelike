using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private CardsConfig _cardsConfig;
    [SerializeField] private Transform _cardHandArea;
    public CardView CardViewPrefab => _cardViewPrefab;
    [SerializeField] private CardView _cardViewPrefab;
    private List<CardStats> _cardsInActualDesk = new ();

    public void Init()
    {
        foreach (var cardStats in _cardsConfig.CardStatsList)
            for (int i = 0; i < cardStats.CountCardsInDeck; i++)
                _cardsInActualDesk.Add(cardStats);
    }
        
    public void SetCardsInHandHero(int countAddCards)
    {
        for (var i = 0; i < countAddCards; i++)
            Instantiate(_cardViewPrefab, _cardHandArea, false).ShowCard(RandomSelection());
    }

    public void SetCardsInHandEnemy(int countAddCards, List<CardStats> cards)
    {
        for (var i = 0; i < countAddCards; i++)
        {
            var card = RandomSelection();
            cards.Add(card);
        }
    }

    private CardStats RandomSelection() => _cardsInActualDesk[Random.Range(0, _cardsInActualDesk.Count)];
}
