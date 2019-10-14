using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private GameObject _Target;
    [SerializeField] private Vector3 _Offset;

    private void Update()
    {
        transform.position = _Target.transform.position + _Offset;
    }
}
