using UnityEngine;

public class OtherFish : MonoBehaviour
{
    [SerializeField]
    private bool leftToRight = true;
    [SerializeField]
    private Transform spriteTransform = null;
    [SerializeField]
    private SpriteRenderer sprite = null;
    [SerializeField]
    private Sprite altSprite = null;
    public float speed = .5f;
    public float noiseSmooth = 1f;
    public float overallScale = 1f;

    private float randomNoiseSeed = 0f;

    private int _fishSize = 0;
    public int Size
    {
        private set
        {
            _fishSize = value;
            spriteTransform.localScale = Vector3.one * _fishSize.Remap(0f, 10f, .25f, 2f);
            if (_fishSize > 0)
            {
                sprite.sprite = altSprite;
            }
        }
        get
        {
            return _fishSize;
        }

    }
    public bool LeftToRight
    {
        set
        {
            leftToRight = value;
            sprite.flipX = !leftToRight;
        }
        get
        {
            return leftToRight;
        }
    }

    void Start()
    {
        randomNoiseSeed = Random.Range(0f, 100f);
        Size = 0;
        FishControl.instance.OnGameOver += () => { Destroy(this.gameObject); };
    }

    void Update()
    {
        Vector3 newOffset = new Vector3();
        newOffset = (leftToRight) ? transform.right : -transform.right;
        newOffset = newOffset.With(y: (-.5f + Mathf.PerlinNoise(0f, (Time.time + randomNoiseSeed) * noiseSmooth)) * overallScale);
        transform.localPosition += newOffset * speed * Time.deltaTime;
    }

    public void RespawnBigger()
    {
        if (LeftToRight)
        {
            transform.position = new Vector3(-TorusLoop.Boundary.x, Random.Range(-TorusLoop.Boundary.y, TorusLoop.Boundary.y), 0f);
        }
        else
        {
            transform.position = new Vector3(TorusLoop.Boundary.x, Random.Range(-TorusLoop.Boundary.y, TorusLoop.Boundary.y), 0f);
        }
        Size++;
        speed = Random.Range(.5f, 1.5f);

    }

}
