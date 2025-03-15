using UnityEngine;

public class Hero : Character
{
    public override void Init()
    {
        base.Init();
        
        Instantiate(Resources.Load(HeroMap.Heroes[0].SpriteLink), transform, false);

        MaxHealth = Health = HeroMap.Heroes[0].MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        SetDamage(HeroMap.Heroes[0].Damage);
        SetDefense(HeroMap.Heroes[0].Defense);

        cardController.SetCardsInHandHero(6);
    }

    public override void CardMove(CardView cardView)
    {
        if (cardView.CardStat.Damage != 0)
        {
            gameController.enemy.GetDamage(Damage * cardView.CardStat.Damage);
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
            cardController.SetCardsInHandHero(cardView.CardStat.CountAddCards);
            // var waitForSecondsEnumerable = WaitUtils.Wait(_timeOnTextActionCard);
            cardMove.text = "";
        }
    }

    protected override void IsDie()
    {
    }
}
