using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionsPool : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _actionsContainer;
    [SerializeField] private ActionData[] _actionsData;
    [SerializeField] private ActionItem _actionItemPrefab;
    [SerializeField] private Vector2 SpawnOffset;
    [SerializeField] private int _actionsCount;

    private List<ActionItem> _items;

    private void Start()
    {
        _items = new List<ActionItem>();

        for (int i = 0; i < _actionsCount; i++)
        {
            CreateItem();
        }
    }

    private ActionItem CreateItem()
    {
        ActionItem item = Instantiate(_actionItemPrefab, _actionsContainer);
        item.gameObject.SetActive(false);
        _items.Add(item);
        return item;
    }

    private ActionItem GetFreeItem()
    {
        if (_items.Count == 0)
        {
            CreateItem();
        }

        ActionItem item = _items.First();
        _items.Remove(item);
        item.gameObject.SetActive(true);
        return item;
    }

    public ActionItem GetRandomActionItemFor(Character character)
    {
        ActionItem item = GetFreeItem();
        item.Init(_canvas, _actionsData[Random.Range(0, _actionsData.Length)]);
        item.GetComponent<RectTransform>().anchoredPosition = 
            character.GetComponent<RectTransform>().anchoredPosition + SpawnOffset;
        return item;
    }

    public void ReturnItem(ActionItem item)
    {
        item.gameObject.SetActive(false);
        _items.Add(item);
    }
}
