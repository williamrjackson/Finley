using UnityEngine;
using UnityEngine.Events;

public class FishControl : MonoBehaviour
{
    public static FishControl instance;
    public TouchAxisCtrl touchAxis;
    public float speed = 7.0F;

    private float initXScale = 1f;
    private float dir;
    private float cachedDir;

    public UnityAction OnGameOver;
    public UnityAction OnRestart;

    private static bool _gameOver = false;
    public static bool IsGameOver
    {
        get => _gameOver;
        set
        {
            if (_gameOver != value)
            {
                _gameOver = value;
                if (_gameOver == true)
                {
                    if (instance.OnGameOver != null)
                        instance.OnGameOver();
                }
                else
                {
                    if (instance.OnRestart != null)
                        instance.OnRestart();
                }
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnEnable()
    {
        initXScale = transform.localScale.x;
        OnGameOver += Hide;
        OnRestart += Restart;
    }

    void Hide()
    {
        transform.localScale = Vector3.zero;
    }

    void Restart()
    {
        Wrj.SceneReloader.ReloadScene();
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

        if (IsGameOver && Input.GetMouseButtonDown(0))
        {
            IsGameOver = false;
        }
    }
}
