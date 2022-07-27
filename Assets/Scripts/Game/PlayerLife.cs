using System;
using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int LifeCount { get; private set; } = 3;
    public bool Dead { get; private set; }
    public Action<int> onLifeUpdate;
    public Action onDead;
    [SerializeField] private MeshRenderer _meshRenderer;
    private bool _protection;

    private void Start()
    {
        onLifeUpdate?.Invoke(LifeCount);
    }

    public void Damage()
    {
        if (_protection)
            return;
        LifeCount--;
        if (LifeCount == 0)
        {
            Dead = true;
            onDead?.Invoke();
        }
        onLifeUpdate?.Invoke(LifeCount);
        StartCoroutine(DamageEffect());
    }

    private IEnumerator DamageEffect()
    {
        _protection = true;
        var wait = new WaitForSeconds(0.1f);
        for (int i = 0; i < 5; i++)
        {
            _meshRenderer.enabled = false;
            yield return wait;
            _meshRenderer.enabled = true;
            yield return wait;
        }
        _protection = false;
    }
}
