using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int _countWave;
    
    private int _level;
    public TextMeshProUGUI levelNumber;
    
    public Hero hero;
    public GameObject heroPanel;

    public Enemy enemy;
    public GameObject enemyPanel;

    public CardController cardController;

    public void Start()
    {
        cardController.Init();
        hero = Instantiate(heroPanel, transform, false).GetComponent<Hero>();
        hero.cardController = cardController;
        hero.gameController = this;
        hero.Init();
        hero.OnDead += EndGame;
        NextLevel();
    }

    private void NextLevel()
    {
        levelNumber.text = ++_level + "st Floor";
        
        _countWave = 1 + _level / 5;
        
        NextWave();
    }
    
    public void NextWave()
    {
        if (_countWave > 0)
        {
            enemy = Instantiate(enemyPanel, transform, false).GetComponent<Enemy>();
            enemy.cardController = cardController;
            enemy.gameController = this;
            enemy.OnDead += NextWave;
            enemy.Init();
            _countWave--;
        }
        else NextLevel();
    }

    private void EndGame()
    {
        SceneManager.LoadScene(2);
    }
}
