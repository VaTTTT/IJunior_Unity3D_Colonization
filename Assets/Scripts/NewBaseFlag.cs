using UnityEngine;

public class NewBaseFlag : Target
{
    [SerializeField] private SurvivorsBase _basePrefab;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Survivor survivor) && survivor.Target == this)
        {
            SurvivorsBase newBase = Instantiate(_basePrefab, transform.position, transform.rotation);
            survivor.SetHomeBase(newBase);
            survivor.SetTarget(null);
            survivor.Release();
            newBase.AddSurvivor(survivor);
            Destroy(gameObject);
        }
    }
}