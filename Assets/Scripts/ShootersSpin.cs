using UnityEngine;

public class ShootersSpin : MonoBehaviour
{
    private float _z;
    public float spinSpeed;
    void Update()
    {
        _z += spinSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, _z);
    }
}
