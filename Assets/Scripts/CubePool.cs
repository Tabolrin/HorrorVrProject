using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] private float returnAfterTime = 4f;
    [SerializeField] private Transform spawnPos;

    void Awake()
    {
        // Create a pool with the four core callbacks.
        pool = new ObjectPool<GameObject>
        (
            createFunc: CreateItem,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyItem,
            collectionCheck: true,   
            defaultCapacity: 10,
            maxSize: 50
        );
    }

    void Update()
    {

    }

    // Creates a new pooled GameObject the first time (and whenever the pool needs more).
    private GameObject CreateItem()
    {
        GameObject gameObject = Instantiate(cubePrefab, spawnPos.position, spawnPos.rotation);
        gameObject.SetActive(false);
        return gameObject;
    }

    // Called when an item is taken from the pool.
    private void OnGet(GameObject gameObject)
    {
        gameObject.SetActive(true);
        StartCoroutine(ReturnAfter(gameObject, returnAfterTime));
    }

    // Called when an item is returned to the pool.
    private void OnRelease(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    // Called when the pool decides to destroy an item (e.g., above max size).
    private void OnDestroyItem(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private System.Collections.IEnumerator ReturnAfter(GameObject gameObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // Give it back to the pool.
        pool.Release(gameObject);
    }
}

