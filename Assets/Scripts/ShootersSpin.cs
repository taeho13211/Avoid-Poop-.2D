using UnityEngine;

public class ShootersSpin : MonoBehaviour
{
    private float _z;
    void Update()
    {
        _z += 3 * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, _z);
    }
}
