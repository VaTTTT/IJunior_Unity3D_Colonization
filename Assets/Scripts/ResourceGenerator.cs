using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] Resource _resourcePrefab;
    [SerializeField] int _quantity;
    [SerializeField] float _radius;
    [SerializeField] float _delay;
    [SerializeField] GameObject _container;

    void Start()
    {
        StartCoroutine(nameof(GenerateResources));
    }

    private IEnumerator GenerateResources()
    {
        WaitForSeconds pauseTime = new(_delay);

        float positionX;
        float positionY = 0;
        float positionZ;

        for (int i = 0; i < _quantity; i++)
        {
            positionX = Random.Range(-_radius, _radius);
            positionZ = Random.Range(-_radius, _radius);
            
            Instantiate(_resourcePrefab, new Vector3(positionX, positionY, positionZ), Quaternion.identity, _container.transform);

            yield return pauseTime;
        }
    }
}
