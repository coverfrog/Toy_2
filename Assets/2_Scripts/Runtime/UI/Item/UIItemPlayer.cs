using TMPro;
using Unity.Netcode;
using UnityEngine;

public class UIItemPlayer : UIItem
{
    [Header("[ References ]")]
    [SerializeField] private TMP_Text nameText;

    [Header("[ Values ]")]
    [SerializeField] private ulong id;

    public ulong Id => id;
    
    public void Init(ulong inId)
    {
        id = inId;
        nameText.text = $"Client {id}";
    }
}
