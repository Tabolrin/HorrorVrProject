using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float cubeSpawnInterval = 1f;
    [SerializeField] private float cubeSpeed = 3f;
    [SerializeField] private CubePool pool;
    private float timer = 0;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        
        if(timer >= cubeSpawnInterval)
        {
            timer = 0;
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        GameObject cube = pool.pool.Get();
        cube.GetComponent<Rigidbody>().linearVelocity = Vector3.forward * cubeSpeed;
    }
}
