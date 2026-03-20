using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    public static int score = 0;

    void Update()
    {
        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                score++;
                Debug.Log("Target Hit!  Score: " + score);
                Destroy(gameObject);
            }
        }

        // For testing with mouse clicks
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    score++;
                    Debug.Log("Target Hit!  Score: " + score);
                    Destroy(gameObject);
                }
            }

        }
    }
    
}
