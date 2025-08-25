using UnityEngine;

public abstract class UIPage : MonoBehaviour
{
    public void SetActive(bool value)
    {
        transform.SetAsLastSibling();
        gameObject.SetActive(value);
    }
}