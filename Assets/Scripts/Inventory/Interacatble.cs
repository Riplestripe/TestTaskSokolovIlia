using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactble : MonoBehaviour
{

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // Пустой метод который будет перезаписан подклассами далее
    }
}
