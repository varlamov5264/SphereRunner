using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private PlayerLife _playerLife;
    [SerializeField] private Text _label;

    private void OnEnable()
    {
        _playerLife.onLifeUpdate += OnLifeUpdate;
    }

    private void OnLifeUpdate(int life)
    {
        _label.text = "♡ " + life;
    }

    private void OnDisable()
    {
        _playerLife.onLifeUpdate += OnLifeUpdate;
    }
}
