using UnityEngine;
using UnityEngine.UI;

public class UIHover : MonoBehaviour
{
 [SerializeField] private Button currentButton;
  [SerializeField] private Image currentOutline; 

    private AudioSource audioSource;
    public AudioClip hoverSound;
    public Canvas PauseCanvas;
    PlayerCamera cam;
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

    public void ResumeGame()
    {
        PauseCanvas.enabled = false;
        Time.timeScale = 1.0f;
    }

}