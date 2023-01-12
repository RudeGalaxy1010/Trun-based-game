using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public event UnityAction<int> HealthChanged;
    public event UnityAction<Character> Died;

    [SerializeField] private int _health;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int value)
    {
        _health -= value;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
