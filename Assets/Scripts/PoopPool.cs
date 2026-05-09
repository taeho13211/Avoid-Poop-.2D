using System.Collections.Generic;
using UnityEngine;

public class PoopPool : MonoBehaviour
{
    #region
    [Header ("Pool")]
    public Queue<GameObject> Pool = new Queue<GameObject>();
    public int poolSize = 20;

    [Header ("Poop Setting")]
    public GameObject poop;
    public float spawnTimeMax;
    public float spawnTimeMin;
    private float _spawnInterval;
    private float _spawnTimeCount;

    [Header("Transform Info")]
    public Transform _player;
    private Vector2 dir;
    
    private static PoopPool Instance;
    #endregion
    void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(poop);
            obj.SetActive(false);
            Pool.Enqueue(obj);
        }
    }
    void Start()
    {
        _spawnTimeCount = 0f;
        _spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
    }
    void Update()
    {
        dir = (new Vector2(_player.position.x, _player.position.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
        _spawnTimeCount += Time.deltaTime;
        if (_spawnTimeCount >= _spawnInterval)
        {
            _spawnTimeCount = 0f;
            _spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
            GameObject poopObj = Get();
            poopObj.transform.position = transform.position;
            
        }
    }

    private GameObject Get()
    {
        if (Pool.Count > 0)
        {
            GameObject obj = Pool.Dequeue();
            obj.SetActive(true);
            Poop poopobj = obj.GetComponent<Poop>();
            poopobj.Init(new Vector2(dir.x,dir.y));
            return obj;
        }
        GameObject newobj = Instantiate(poop);
        Poop newPoopobj = newobj.GetComponent<Poop>();
        newPoopobj.Init(new Vector2(dir.x,dir.y));
        return newobj;
    }
}
