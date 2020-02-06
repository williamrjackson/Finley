using UnityEngine;

public class FishControl : MonoBehaviour
{
    public TouchAxisCtrl touchAxis;
    public float speed = 7.0F;

    private float initXScale = 1f;
    private float dir;
    private float cachedDir;

    void Start()
    {
        initXScale = transform.localScale.x;
    }

    void Update()
    {
        Vector3 axis = touchAxis.GetAxis().ToVector3();
        if (axis.sqrMagnitude != 0)
        {
            transform.position += axis * speed * Time.deltaTime;
            dir = (axis.x > 0) ? initXScale : -initXScale;
            if (dir != cachedDir)
            {
                cachedDir = dir;
                transform.Scale(transform.localScale.With(x: dir), .25f);
            }
        }
    }
}
