using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [Zenject.Inject] private ILifeUpdatable _lifeUpdateble;
    [SerializeField] private Text _label;

    private void OnEnable()
    {
        _lifeUpdateble.onLifeUpdate += OnLifeUpdate;
    }

    private void OnLifeUpdate(int life)
    {
        _label.text = "♡ " + life;
    }

    private void OnDisable()
    {
        _lifeUpdateble.onLifeUpdate -= OnLifeUpdate;
    }
}
