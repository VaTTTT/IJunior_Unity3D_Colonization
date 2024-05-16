using UnityEngine;
using UnityEngine.InputSystem;

public class BaseSelector : MonoBehaviour
{
    private Camera _sceneCamera;
    [SerializeField] private LayerMask _interactableLayerMask;

    private SurvivorsBase _selectedBase;
    private Vector3 _mousePosition;
    private Ray _ray;
    private float _rayHitDistance = 200;
    private Mouse _mouse;

    public SurvivorsBase SelectedBase => _selectedBase;

    private void Awake()
    {
        _sceneCamera = Camera.main;
        _mouse = Mouse.current;
    }

    private void Update()
    {
        if (_mouse.leftButton.wasPressedThisFrame)
        {
            TrySelectBase();
        }

        if (_mouse.rightButton.wasPressedThisFrame)
        {
            TryDeselectBase();
        }
    }

    private void TrySelectBase()
    {
        if (_selectedBase == null)
        {
            _mousePosition = _mouse.position.ReadValue();
            _ray = _sceneCamera.ScreenPointToRay(_mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit hit, _rayHitDistance, _interactableLayerMask))
            {
                if (hit.collider.TryGetComponent(out SurvivorsBase target))
                {
                    _selectedBase = target;
                    target.Select();
                }
            }
        }
    }

    private void TryDeselectBase()
    {
        if (_selectedBase != null)
        {
            if (_selectedBase.TryGetComponent(out SurvivorsBase survivorsBase))
            {
                survivorsBase.Deselect();
            }

            _selectedBase = null;
        }
    }
}