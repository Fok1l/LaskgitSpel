using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHover : MonoBehaviour
{
    [SerializeField] private Button currentButton;
    [SerializeField] private Image currentOutline;
    [SerializeField] private TextMeshPro currentText;

    private AudioSource audioSource;
    public AudioClip hoverSound;
    private void Start()
    {
        currentButton = null;
        currentOutline = null;
        currentText = null;
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void MouseEnter(Button button)
    {
        currentButton = button;
        currentOutline = button.GetComponentInChildren<Image>();
        currentOutline.enabled = true;
        currentText = button.GetComponentInChildren<TextMeshPro>();
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
        currentText = null;
        currentButton = null;
        MakeTextNormal();
    }

    void MakeTextBig()
    {
        if (currentText != null)
        {
            Vector3 scale = currentText.transform.localScale;
            scale *= 1.2f;
            currentText.transform.localScale = scale;
        }
    }

    void MakeTextNormal()
    {
        if (currentText != null)
        {
            Vector3 scale = currentText.transform.localScale;
            scale /= 1.2f;
            currentText.transform.localScale = scale;
        }
    }
}