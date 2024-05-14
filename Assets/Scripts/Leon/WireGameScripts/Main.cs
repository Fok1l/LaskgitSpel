using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main Instance;
    public GameObject winText;

    public int SwitchCount;
    private int onCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchChange(int points) { 
    onCount = onCount + points;
        if (onCount == SwitchCount)
        {
            winText.SetActive(true);
        }
    }
}
