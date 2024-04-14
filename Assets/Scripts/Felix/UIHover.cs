using UnityEngine;
using UnityEngine.UI;
public class UIHover : MonoBehaviour
{
    public GameObject UIOutline;
    private bool isTouchingUI;
   [SerializeField] private Button currentButton;

    private void Start()
    {
        isTouchingUI = false;
    }

    public void MouseEnter(Button button)
    {
        currentButton = button; // Set the current button to the hovered button
    }

    public void MouseLeave()
    {
        currentButton = null; // Clear the reference to the current button
    }
}