using System.Collections.Generic;
using RPGCardRoguelike.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    public UnityAction OnDead; 
    
    [SerializeField] protected float _timeOnTextActionCard = 2f;
    [SerializeField] private CardsConfig _cardsInStartDesk;
    public List<CardStats> CardsInDesk => _cardsInActualDesk;
    private List<CardStats> _cardsInActualDesk;
    
    protected int MaxHealth;
    protected int Health;
    protected int Defense;
    protected int Damage;

    public HealthBar healthBar;
    public GameObject spritePrefab;
    public TextMeshProUGUI cardMove;
    
    public GameController gameController;
    public CardController cardController;

    public virtual void Init()
    {
        // foreach (var cardStats in _cardsInStartDesk.CardStatsList)
            // for (int i = 0; i < cardStats.CountCardsInDeck; i++)
                // _cardsInActualDesk.Add(cardStats);
    }
    
    public void GetDamage(int damage) 
    {
        if (Defense == 0)
        {
            cardMove.text = "-" + damage + " здоровья";
            SetHealth(Health-damage);
        }
        else if (Defense >= damage)
            SetDefense(Defense-damage);
        else if (Defense < damage) 
        {
            cardMove.text = "-" + (damage-Defense) + " здоровья";
            SetHealth(Health-damage+Defense);
            SetDefense(0);
        }
        // var waitForSecondsEnumerable = WaitUtils.Wait(_timeOnTextActionCard);
        cardMove.text = "";
    }

    protected void SetHealth(int health)
    {
        Health = (health>MaxHealth?MaxHealth:health);
        
        healthBar.SetHealth(Health);

        if (Health <= 0)
        {
            OnDead?.Invoke();
            IsDie();
        }
    }
    protected void SetDefense(int defense)
    {
        Defense = defense;
        healthBar.SetDefense(Defense);
    }

    public void SetDamage(int damage)
    {
        Damage = damage;
    }

    public abstract void CardMove(CardView cardView);
    protected abstract void IsDie();
}
