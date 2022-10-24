using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [Zenject.Inject] private IMovable _player;

    public void StartClick()
    {
        _window.SetActive(false);
        _player.StartMove();
    }
}