using UnityEngine;
using UnityEngine.Pool;

namespace GHSPG
{
    public class ObstaclesSpawner : MonoBehaviour
    {
        [SerializeField] Obstacle[] arrayObstacles;

        [SerializeField] Vector3 startPosition= new (50f, 0.33f, 0f);
        [SerializeField] Quaternion startRotation = Quaternion.Euler(270f, 0f, 60f);
        int minimumRandomIndex;
        int maximumRandomIndex;
        [SerializeField] int maximumDistance;

        [SerializeField] ObjectPool<Obstacle> obstaclesPool;

        private void OnEnable()
        {
            Obstacle.disabledObstacleEvent.AddListener(KillObstacle);
            Obstacle.poolObstacleEvent.AddListener(PoolObstacle);
        }

        private void Start()
        {
            maximumRandomIndex = arrayObstacles.Length;

            //Refactor: Create all functions
            obstaclesPool = new ObjectPool<Obstacle>(CreateObstacle,
            ObstacleOnGet, ObstacleOnRelease,
            obstacle =>
            {
            Destroy(obstacle.gameObject);
            }, false, 6, 10);

            obstaclesPool.Get();
        }

        #region ArrayPool
        //private void PoolFromArray()
        //{
        //    Obstacle obs;
        //    int randomIndex;
        //    randomIndex = Random.Range(0, obstaclesArrPool.Length);
        //    obs = obstaclesArrPool[randomIndex];
        //    while (obs.isActiveAndEnabled)
        //    {
        //        randomIndex = Random.Range(0, obstaclesArrPool.Length);
        //        obs = obstaclesArrPool[randomIndex];
        //    }
        //    print("Pool From Array " + randomIndex);
        //    obs.gameObject.SetActive(true);
        //}

        //private void KillArrObstacle(Obstacle obstacle)
        //{
        //    obstacle.transform.parent = null;
        //    obstacle.transform.position = startPosition;
        //    obstacle.gameObject.SetActive(false);
        //}

        //private void PoolArrObstacle()
        //{
        //    PoolFromArray();
        //}
        #endregion

        #region obstaclePool
        private Obstacle CreateObstacle()
        {
            int randomIndex = Random.Range(minimumRandomIndex, maximumRandomIndex);
            if (randomIndex < 3)
            {
                minimumRandomIndex = 3;
                return Instantiate(arrayObstacles[randomIndex], startPosition, startRotation);
            }
            //else if (randomIndex == maximumRandomIndex - 1)
            //    maximumRandomIndex -= 1;
            return Instantiate(arrayObstacles[randomIndex], startPosition, Quaternion.identity);
        }

        private void ObstacleOnGet(Obstacle obstacle)
        {
            obstacle.gameObject.SetActive(true);
            obstacle.transform.position += Vector3.right * (maximumDistance * Random.Range(0f,1f));

        }

        private void ObstacleOnRelease(Obstacle obstacle)
        {
            obstacle.transform.position = startPosition;
            obstacle.gameObject.SetActive(false);
        }

        private void KillObstacle(Obstacle obstacle)
        {
            obstacle.transform.parent = null;
            obstaclesPool.Release(obstacle);
        }

        private void PoolObstacle()
        {
            obstaclesPool.Get();
        }
        #endregion
    }
}