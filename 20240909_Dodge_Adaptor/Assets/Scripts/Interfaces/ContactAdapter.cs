using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContactAdapter : MonoBehaviour, IContactable
{
    public UnityEvent<PlayerController> OnEvent;

    public void Contact(PlayerController player)
    {
        OnEvent?.Invoke(player);
    }
}
