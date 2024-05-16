using UnityEngine;

public class Survivor : Target
{
    [SerializeField] private CargoContainer _cargoContainer;
    [SerializeField] private int _cost;
    [SerializeField] private float _itemPickupDistance;
    [SerializeField] private float _enemyDetectDistance;
    [SerializeField] private float _itemDetectDistance;

    private Target _target;
    private SurvivorsBase _homeBase;

    public float StopDistance => _itemPickupDistance;
    public float ItemDetectDistance => _itemDetectDistance;
    public Target Target => _target;

    public int Cost => _cost;

    private void OnEnable()
    {
        _cargoContainer.Loaded += DeliverCargo;
        _cargoContainer.Unloaded += Release;
    }

    private void OnDisable()
    {
        _cargoContainer.Loaded -= DeliverCargo;
        _cargoContainer.Unloaded -= Release;
    }

    public void DeliverCargo()
    {
        SetTarget(_homeBase.CargoDropPoint);
    }

    public void SetHomeBase(SurvivorsBase survivorsBase)
    {
        _homeBase = survivorsBase;
    }

    public void Release()
    {
        _isFree = true;
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }
}