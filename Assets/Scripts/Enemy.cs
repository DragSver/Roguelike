using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private readonly System.Random _random = new();

    private GameObject _destroyEnemy;

    public List<CardStats> CardsInHand;
    public static bool EnemyIsDie;

    public override void Init()
    {
        base.Init();
        
        var characterStats = RandomSelection();
        
        Instantiate(Resources.Load(characterStats.SpriteLink), transform, false);
        
        MaxHealth = Health = characterStats.MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        
        Damage = characterStats.Damage;
        SetDefense(characterStats.Defense);

        CardsInHand = new List<CardStats>();
        cardController.SetCardsInHandEnemy(6, CardsInHand);
    }

    public override void CardMove(CardView cardView)
    {
        if (cardView.CardStat.Damage != 0)
        {
            gameController.hero.GetDamage(Damage * cardView.CardStat.Damage);
        }
        if (cardView.CardStat.Heal != 0)
        {
            cardMove.text = "+" + cardView.CardStat.Heal + " здоровья";
            SetHealth(Health + cardView.CardStat.Heal);
            // var waitForSecondsEnumerable = WaitUtils.Wait(_timeOnTextActionCard);
            cardMove.text = "";
        }
        if (cardView.CardStat.Defense != 0)
        {
            cardMove.text = "+" + cardView.CardStat.Heal + " защиты";
            SetDefense(Defense + cardView.CardStat.Defense);
            // var waitForSecondsEnumerable = WaitUtils.Wait(_timeOnTextActionCard);
            cardMove.text = "";
        }
        if (cardView.CardStat.CountAddCards != 0)
        {
            cardMove.text = "+" + cardView.CardStat.Heal + " карты";
            cardController.SetCardsInHandEnemy(cardView.CardStat.CountAddCards, CardsInHand);
            // var waitForSecondsEnumerable = WaitUtils.Wait(_timeOnTextActionCard);
            cardMove.text = "";
        }
    }

    protected override void IsDie()
    {
        EnemyIsDie = true;
        _destroyEnemy = gameObject;
        gameController.enemy = null;
        Destroy(_destroyEnemy);
        OnDead?.Invoke();
    }
    
    private CharacterStats RandomSelection()
    {
        return EnemyMap.Enemies[_random.Next(EnemyMap.Enemies.Count)];
    }
}
