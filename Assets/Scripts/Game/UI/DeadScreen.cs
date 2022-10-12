using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] private PlayerLife _playerLife;
    [SerializeField] private GameObject _window;

    private void OnEnable()
    {
        _playerLife.onDead += OnDead;
    }

    private void OnDead()
    {
        _window.SetActive(true);
    }

    public void RestartClick()
    {
        //По-хорошему надо вместо перезапуска сцены сбрасывать состояния объектов, сделал для экономии времени
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        _playerLife.onDead -= OnDead;
    }
}
