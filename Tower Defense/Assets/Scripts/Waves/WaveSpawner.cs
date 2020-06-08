using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive;

    public Wave[] waves;

    [Header("References")]
    public Transform SpawnPoint;

    public Text WaveCountDownText;

    public GameManager gameManager;

    public float timeBetweenWaves;
    private float countDown;

    private int waveIndex = 0;

    void Start()
    {
        enemiesAlive = 0;
    }

    void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        WaveCountDownText.text = string.Format("{0:00.00}", countDown);
    }

    private IEnumerator SpawnWave()
    {
        if(waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        else
        {
            PlayerStats.Rounds++;

            Wave wave = waves[waveIndex];

            enemiesAlive = wave.count;

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }

            waveIndex++;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    }
}
