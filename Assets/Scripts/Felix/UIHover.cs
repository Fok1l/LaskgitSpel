using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHover : MonoBehaviour
{
    [SerializeField] private Button currentButton;
    [SerializeField] private Image currentOutline;

    [SerializeField] TextMeshProUGUI playButtonText;
    [SerializeField] TextMeshProUGUI settingsButtonText;
    [SerializeField] TextMeshProUGUI quitButtonText;


    private AudioSource audioSource;
    public AudioClip hoverSound;
    private void Start()
    {
        currentButton = null;
        currentOutline = null;
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }


    //Fix this by saying stuff like for example, if the currentButton is startbutton. Then do the text size thing for startButtonText.
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
        MakeTextBig();
    }


    public void MouseLeave()
    {
        currentOutline.enabled = false;
        currentOutline = null;
        currentButton = null;
        MakeTextNormal();
    }

    void MakeTextBig()
    {
        if (playButtonText != null)
        {
            Vector3 scale = playButtonText.transform.localScale;
            scale *= 1.2f;
            playButtonText.transform.localScale = scale;
        }
    }

    void MakeTextNormal()
    {
        if (playButtonText != null)
        {
            Vector3 scale = playButtonText.transform.localScale;
            scale /= 1.2f;
            playButtonText.transform.localScale = scale;
        }
    }
}