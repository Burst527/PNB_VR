using UnityEngine;
using UnityEngine.InputSystem; // pastikan pakai Input System baru

public class LeftControllerMenuToggle : MonoBehaviour
{
    [SerializeField] private GameObject menu; // drag UI-Menu ke sini di inspector
    [SerializeField] private InputActionReference toggleAction; // tombol input dari controller kiri

    private void OnEnable()
    {
        toggleAction.action.performed += ToggleMenu;
    }

    private void OnDisable()
    {
        toggleAction.action.performed -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        if (menu != null)
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
