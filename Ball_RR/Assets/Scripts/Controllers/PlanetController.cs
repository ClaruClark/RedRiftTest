using UnityEngine;
using UnityEngine.UI;

public class PlanetController : Singleton<PlanetController>
{

    [SerializeField]
    GameObject ballPrefab = null;

    private PlanetItem currentPlanet;
    private Image backgroundImage;

    private Rigidbody2D ballRB;

    public bool gotPosition { get; set; }
    public void SetPlanet(PlanetItem item)
    {
       
        currentPlanet = item;
        backgroundImage = GetComponent<Image>();
        backgroundImage.color = currentPlanet.planetColor;

        ballRB = Instantiate(ballPrefab, transform).GetComponent<Rigidbody2D>();
        ballRB.gravityScale = currentPlanet.gravity;
    }

    public void StopPlanet()
    {
        Destroy(ballRB.gameObject);
    }

    public void SetBallPosition(Vector3 pos)
    {
        ballRB.AddForce(pos);
    }

}
