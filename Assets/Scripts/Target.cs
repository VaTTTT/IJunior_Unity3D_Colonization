using UnityEngine;

public abstract class Target : MonoBehaviour
{
    protected bool _isFree = true;

    public bool IsFree => _isFree;

    public void Occupy()
    {
        _isFree = false;
    }
}