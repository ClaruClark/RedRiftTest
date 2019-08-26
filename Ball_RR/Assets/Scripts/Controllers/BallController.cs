using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.AddHit();
        PlanetController.Instance.gotPosition = false;
        if (collision.collider.CompareTag("Platform"))
            collision.collider.GetComponent<PlatformController>().NextColor();
    }

}
