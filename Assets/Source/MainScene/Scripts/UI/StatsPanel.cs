using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private ActionsPerformer _actionsPerformer;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _protectionText;
    [SerializeField] private Image _poisonIcon;

    private void OnEnable()
    {
        _character.HealthChanged += OnHealthChanged;
        _character.ProtectionChanged += OnProtectionChanged;
        _actionsPerformer.ActionAdded += OnActionAdded;
        _actionsPerformer.ActionRemoved += OnActionRemoved;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= OnHealthChanged;
        _character.ProtectionChanged -= OnProtectionChanged;
        _actionsPerformer.ActionAdded -= OnActionAdded;
        _actionsPerformer.ActionRemoved -= OnActionRemoved;
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

    private void OnActionAdded(Action action)
    {
        if (action is PoisonAction)
        {
            _poisonIcon.gameObject.SetActive(true);
        }
    }

    private void OnActionRemoved(Action action)
    {
        if (_actionsPerformer.HasAction(typeof(PoisonAction)) == false)
        {
            _poisonIcon.gameObject.SetActive(false);
        }
    }
}
