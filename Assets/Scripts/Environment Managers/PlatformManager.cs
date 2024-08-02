using UnityEngine;

namespace GHSPG
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] GameObject platformPrefab;
        GameObject[] platformSpawnedArray;
        [SerializeField] int numberOfSpawns;
        [SerializeField] int leaderIndex;
        [SerializeField] int lastPlatformIndex;
        //[SerializeField] Vector3 spawnPosition = Vec

        public float platformSpeed = 8f;

        private void OnEnable()
        {
            GameManager.increasedSpeedGameEvent.AddListener(increasedSpeedGame);
        }

        private void Start()
        {
            platformSpawnedArray = new GameObject[numberOfSpawns];
            for (int i = 0; i < numberOfSpawns; ++i)
            {
                platformSpawnedArray[i] = Instantiate(platformPrefab, Vector3.right * (30f * i), Quaternion.identity);
            }
        }

        private void Update()
        {
            if (platformSpawnedArray[leaderIndex].transform.position.x > -25f)
            {
                for (int i = 0; i < numberOfSpawns; ++i)
                {
                    platformSpawnedArray[i].transform.Translate(Vector3.left * platformSpeed * Time.deltaTime);
                }
            }
            else
            {
                platformSpawnedArray[leaderIndex].transform.position = platformSpawnedArray[lastPlatformIndex].transform.position + new Vector3(30f, 0f, 0f);
                if (leaderIndex < numberOfSpawns - 1)
                {
                    lastPlatformIndex = leaderIndex;
                    ++leaderIndex;
                }
                else
                {
                    leaderIndex = 0;
                    lastPlatformIndex = numberOfSpawns - 1;
                }
            }
        }

        private void increasedSpeedGame(float newSpeed)
        {
            platformSpeed = newSpeed;
        }
    }
}