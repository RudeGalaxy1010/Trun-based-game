using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> ProtectionChanged;
    public event UnityAction<Character> Died;

    [SerializeField] private int _health;
    [SerializeField] private int _protection;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        ProtectionChanged?.Invoke(_protection);
    }

    public void TakeDamage(int value)
    {
        if (value <= 0)
        {
            return;
        }

        if (_protection > 0)
        {
            if (value <= _protection)
            {
                RemoveProtection(value);
                return;
            }

            value = value - _protection;
            RemoveProtection(_protection);
        }

        _health -= value;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Heal(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _health += value;
        HealthChanged?.Invoke(_health);
    }

    public void AddProtection(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _protection += value;
        ProtectionChanged?.Invoke(_protection);
    }

    public void RemoveProtection(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _protection = Mathf.Max(0, _protection - value);
        ProtectionChanged?.Invoke(_protection);
    }

    public void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
