using UnityEngine;
using UnityEngine.UI;
public class PlanetButton :  MonoBehaviour, IClickable
{
    [SerializeField]
    private PlanetItem planet = null;

    private Button btn;
    
    private void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(() => Click()); 
    }


    public void Click()
    {
        GameManager.Instance.ClickableClick(this);
    }

    public void DoSomething()
    {
        PlanetController.Instance.SetPlanet(planet);
    }
    

    public ClickableType GetClickableType()
    {
        return ClickableType.Button;
    }
}
