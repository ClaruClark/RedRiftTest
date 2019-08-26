using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformController : MonoBehaviour, IClickable
{
    [SerializeField]
    Color[] colorsPool = null;
    private int colorIndex = 0;
    private Image platformImage;
    private Button btn;
    private void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(() => Click());
    }

    public void NextColor()
    {
        
        platformImage = GetComponent<Image>();
        platformImage.color = colorsPool[colorIndex];
        colorIndex++;

        if (colorIndex >= colorsPool.Length)
            colorIndex = 0;
    }

    public void Click()
    {
        GameManager.Instance.ClickableClick(this);
    }


    public ClickableType GetClickableType()
    {
        return ClickableType.Platform;
    }

    public void DoSomething()
    {
        NextColor();
    }
}
