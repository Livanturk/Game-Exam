using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Missile")]
    public GameObject missile;
    public Transform missileSpawnPosition;
    public float deactivationTime = 5f;

    private void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject gm = Instantiate(missile, missileSpawnPosition);
            gm.transform.SetParent(null);
            Destroy(gm, deactivationTime);
        }
    }    
}
