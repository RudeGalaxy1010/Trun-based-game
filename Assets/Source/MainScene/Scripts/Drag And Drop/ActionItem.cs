using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class ActionItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public event UnityAction<ActionItem> Used;

    private Canvas _canvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private ActionData _actionData;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Init(Canvas canvas, ActionData actionData)
    {
        _canvas = canvas;
        _actionData = actionData;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
    }

    public Action CreateActionFor(Character character)
    {
        return _actionData.CreateActionFor(character);
    }

    public void Use()
    {
        Used?.Invoke(this);
    }
}
