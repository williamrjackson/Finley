using UnityEngine;

public class TorusLoop : MonoBehaviour
{
    public float buffer = .5f;
    public static Vector2 Boundary
    {
        get
        {
            return new Vector2(Camera.main.orthographicSize * Screen.width / Screen.height, Camera.main.orthographicSize);
        }
        private set { }
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        Vector2 bufferedBoundary = new Vector2(Boundary.x + buffer, Boundary.y + buffer);
        if (transform.position.x > bufferedBoundary.x || transform.position.x < -bufferedBoundary.x)
        {
            newPos.x = -newPos.x;
        }
        if (transform.position.y > bufferedBoundary.y || transform.position.y < -bufferedBoundary.y)
        {
            newPos.y = -newPos.y;
        }
        transform.position = newPos;
    }
}
