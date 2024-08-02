using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    public static UnityEvent<Obstacle> disabledObstacleEvent = new();
    public static UnityEvent poolObstacleEvent = new();
    [SerializeField] float minimumDistance;
    [SerializeField] bool spawnObstacleFlag;

    private void Start()
    {
        GameManager.increasedSpeedGameEvent.AddListener(increasedSpeedGame);
    }

    private void Update()
    {
        if (!spawnObstacleFlag && transform.position.x < minimumDistance)
        {
            spawnObstacleFlag = true;
            poolObstacleEvent.Invoke();
        }
        else if (transform.position.x < -10f)
        {
            spawnObstacleFlag = false;
            disabledObstacleEvent.Invoke(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dino") && !GameManager.instance.isGodMode)
        {
            GameManager.instance.GameOver();
        } 
        else if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = other.transform;
        }
    }

    private void increasedSpeedGame(float speed)
    {
        minimumDistance -= 1f;
        if (minimumDistance < 0f)
        {
            GameManager.increasedSpeedGameEvent.RemoveListener(increasedSpeedGame);
            minimumDistance = -5f;
        }
    }
}
