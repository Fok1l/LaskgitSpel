using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTutorial : MonoBehaviour
{
    [SerializeField] Canvas FakeTutorial_Canvas;


    private void Start()
    {
        FakeTutorial_Canvas.enabled = false;
    }

    public void ShowFake()
    {
        FakeTutorial_Canvas.enabled = true;
    }
    IEnumerator wait()
    {
        FakeTutorial_Canvas.enabled = true;
        yield return new WaitForSecondsRealtime(2);
        FakeTutorial_Canvas.enabled = false;
    }
}
