using UnityEngine;
using UnityEngine.UI;

public class UIHover : MonoBehaviour
{
    private Button currentButton;
    private Image currentOutline; 

    private AudioSource audioSource;
    public AudioClip hoverSound;
    private void Start()
    {
        currentButton = null;
        currentOutline = null;
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void MouseEnter(Button button)
    {
        currentButton = button;
        currentOutline = button.GetComponentInChildren<Image>(); 
        currentOutline.enabled = true; 
        if (hoverSound != null)
        {
            audioSource.clip = hoverSound; 
            audioSource.Play(); 
        }
    }
    
 
    public void MouseLeave()
    {
        currentOutline.enabled = false;
        currentOutline = null; 
        currentButton = null; 
    }

}