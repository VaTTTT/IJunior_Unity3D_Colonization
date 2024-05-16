using UnityEngine;
using UnityEngine.Events;

public class CargoContainer : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private Survivor _owner;

    public event UnityAction Loaded;
    public event UnityAction Unloaded;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out SurvivorsBase survivorsBase) && _resource != null)
        {
            DropCargo(_resource);
            Unloaded?.Invoke();
            survivorsBase.AddResource();
        }
        else if (collision.gameObject.TryGetComponent(out Resource resource) && resource == _owner.Target && _resource == null)
        {
            TakeCargo(resource);
            resource.GetComponent<BoxCollider>().enabled = false;
            Loaded?.Invoke();
        }
    }

    public void TakeCargo(Resource resource)
    {
        resource.transform.SetParent(transform, false);
        resource.transform.position = transform.position;
        _resource = resource;
    }

    private void DropCargo(Resource resource)
    {
        Destroy(resource.gameObject);
        _resource = null;
    }
}
