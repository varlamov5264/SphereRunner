using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private PlayerMovement _player;

    public void StartClick()
    {
        _window.SetActive(false);
        _player.gameObject.SetActive(true);
    }
}