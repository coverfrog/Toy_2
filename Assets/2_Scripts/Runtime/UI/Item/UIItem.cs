using UnityEngine;

public abstract class UIItem : MonoBehaviour
{
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}