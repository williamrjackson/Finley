using UnityEngine;

public class FishEatController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite = null;

    private int _fishSize = 1;
    public int Size
    {
        private set
        {
            _fishSize = value;
            sprite.transform.localScale = Vector3.one * _fishSize.Remap(0f, 10f, .25f, 2f);
        }
        get
        {
            return _fishSize;
        }
    }
    private int mealCount = 0;

    void Start()
    {
        Size = _fishSize;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OtherFish meal = collision.gameObject.GetComponent<OtherFish>();
        if (meal != null)
        {
            if (meal.Size < Size)
            {
                meal.RespawnBigger();
                mealCount++;
            }
            else
            {
                Debug.Log("GameOver");
                Time.timeScale = 0f;
            }

            if (mealCount > 4)
            {
                Size++;
                mealCount = 0;
            }
        }
    }
}
