using UnityEngine;
using UnityEngine.EventSystems;

public class AuraHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator auraAnimator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        auraAnimator.ResetTrigger("Disappear");
        auraAnimator.SetTrigger("Appear");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        auraAnimator.ResetTrigger("Appear");
        auraAnimator.SetTrigger("Disappear");
    }
}
