using TMPro;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _protectionText;

    private void OnEnable()
    {
        _character.HealthChanged += OnHealthChanged;
        _character.ProtectionChanged += OnProtectionChanged;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= OnHealthChanged;
        _character.ProtectionChanged -= OnProtectionChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthText.text = health.ToString();
    }

    private void OnProtectionChanged(int protection)
    {
        if (protection == 0)
        {
            _protectionText.text = "";
            return;
        }

        _protectionText.text = string.Format("+{0}", protection);
    }
}
