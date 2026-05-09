using UnityEngine;


public class PoopShooter : MonoBehaviour
{
    public Transform player;
    
    public GameObject Poops;
    

    public float spawntimeMin;
    public float spawntimeMax;
    
    
    private GameObject obj;
    private float spawntime;
    private float spawntimeCount;

    void Start()
    {
        spawntimeCount = 0f;
        spawntime = Random.Range(spawntimeMin, spawntimeMax);
        
    }
    void Update()
    {
        
        transform.LookAt(player);
        spawntimeCount += Time.deltaTime;
        if (spawntimeCount >= spawntime)
        {
            Shoot();
            
            //Spawn time reset
            spawntimeCount = 0f;
            spawntime = Random.Range(spawntimeMin, spawntimeMax);
        }
    }

    void Shoot()
    {
        //direction
        Vector2 dir = (new Vector2(player.position.x, player.position.y) -
                      new Vector2(transform.position.x, transform.position.y)).normalized;
        
        
        obj = Instantiate(Poops, transform.position, Quaternion.identity);
        
        
        
        
        Poop poopScript = obj.GetComponent<Poop>();
        poopScript.Init(new Vector2(dir.x,dir.y));

    }
}
