using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private KeyCode backKey = KeyCode.Escape;

    private void Update()
    {
        if (Input.GetKeyDown(backKey))
            GameManager.Instance.BackButton();

        if (!GameManager.Instance.isGameOn)
            return;
        
        #if !UNITY_EDITOR

                 if(Input.touchCount > 0)
                 {
                     Touch tap = Input.GetTouch(0);

                     if (tap.phase == TouchPhase.Ended)
                     {            
                        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(tap.position.x, tap.position.y, 10));            
                       PlanetController.Instance.SetBallPosition(position);
                     }
                 }

        #else
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                    PlanetController.Instance.SetBallPosition(position);
                }
        #endif
        


      

    }
}
