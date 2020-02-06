using UnityEngine;

public class EnemyFishSpawner : MonoBehaviour
{
    public OtherFish prototype;
    public FishEatController playerFish;
    public int initialEnemies = 6;
    void Start()
    {
        ProduceEnemies(initialEnemies);
    }

    public void ProduceEnemies(int count)
    {
        bool right = true;
        for (int i = 0; i < count; i++)
        {
            OtherFish fish = Instantiate(prototype).gameObject.GetComponent<OtherFish>();
            if (right)
            {
                fish.transform.position = new Vector3(-TorusLoop.Boundary.x, Random.Range(-TorusLoop.Boundary.y, TorusLoop.Boundary.y), 0f);
                fish.LeftToRight = true;
            }
            else
            {
                fish.transform.position = new Vector3(TorusLoop.Boundary.x, Random.Range(-TorusLoop.Boundary.y, TorusLoop.Boundary.y), 0f);
                fish.LeftToRight = false;
            }
            fish.speed = Random.Range(.5f, 1.5f);
            right = !right;
        }
    }
}
