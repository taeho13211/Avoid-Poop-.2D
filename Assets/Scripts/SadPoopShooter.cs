using Unity.VisualScripting;
using UnityEngine;

public class SadPoopShooter : MonoBehaviour
{
    public Transform player;
    public GameObject sadPoop;

    public float starttime;
    private float starttimeCount;

    public float spawntimeMin;
    public float spawntimeMax;

    private float spawntime;
    private float spawntimeCount;
    void Start()
    {
        spawntime = Random.Range(spawntimeMin, spawntimeMax);
        spawntimeCount = 0f;
        starttimeCount = 0f;
    }
    
    void Update()
    {
        starttimeCount += Time.deltaTime;
        if (starttimeCount >= starttime)
        {
            spawntimeCount += Time.deltaTime;
            if (spawntimeCount >= spawntime)
            {
                Shoot();
                spawntimeCount = 0f;
                spawntime = Random.Range(spawntimeMin, spawntimeMax);
            }
        }
    }

    void Shoot()
    {
        Vector2 dir = (new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x,transform.position.y)).normalized;
        GameObject obj = Instantiate(sadPoop, transform.position, Quaternion.identity);
        SadPoop sadPoopScript = obj.GetComponent<SadPoop>();
        sadPoopScript.Init(new Vector2(dir.x,dir.y));
    }
}
