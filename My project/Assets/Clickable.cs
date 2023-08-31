
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerDownHandler ,IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Renderer rend;
    private bool clicked = false;
    
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked = !clicked;
        if (clicked) { rend.material.SetColor("_Color", Color.red); } else { rend.material.SetColor("_Color", Color.green); }
    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }

}
