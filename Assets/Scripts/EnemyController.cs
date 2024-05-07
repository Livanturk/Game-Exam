using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;

    void Update()
    {
        transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
    }

}
