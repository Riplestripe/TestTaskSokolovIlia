using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputSystem : MonoBehaviour
{
    public Vector2 moveInput;

    public void OnMove(InputValue Input)
    {
        moveInput = Input.Get<Vector2>();
    }
}
