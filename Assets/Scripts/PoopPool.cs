using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoopPool : MonoBehaviour
{
    #region
    [Header ("Pool")] private Queue<GameObject> _pool = new Queue<GameObject>();
    public int poolSize = 20;

    [Header ("Poop Setting")]
    public GameObject poop;
    public float spawnTimeMax;
    public float spawnTimeMin;
    private float _spawnInterval;
    private float _spawnTimeCount;

    [Header("Transform Info")]
    public Transform player;
    private Vector2 _dir;

    [Header("StartTime")]
    public float startTime;
    private float _startTimeCount;
    
    public static PoopPool Instance;
    #endregion
    void Awake()
    {
        Instance = this;
        for (int i = 0; i <= poolSize; i++)
        {
            GameObject obj = Instantiate(poop);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
    void Start()
    {
        _spawnTimeCount = 0f;
        _spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
    }
    void Update()
    {
        _startTimeCount += Time.deltaTime;
        if (_startTimeCount >= startTime)
        {
            _dir = (new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
            _spawnTimeCount += Time.deltaTime;
            if (_spawnTimeCount >= _spawnInterval && _pool.Count > 0)
            {
                _spawnTimeCount = 0f;
                _spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
                Get();
            }
        }
    }

    private GameObject Get()
    {
            GameObject obj = _pool.Dequeue();
            obj.SetActive(true);
            Poop poopobj = obj.GetComponent<Poop>();
            poopobj.myPool = this;
            poopobj.Init(new Vector2(_dir.x,_dir.y));
            obj.transform.position = transform.position;
            return obj;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }
}
