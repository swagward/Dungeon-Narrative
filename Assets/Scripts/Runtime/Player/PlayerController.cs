using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject targetMarkerPrefab;
    private GameObject _targetMarkerInstance;
    public AudioSource stepSFX;
    private Vector3 _targetPos;
    private bool _isMoving;
    public NavMeshAgent nMA;
    [Header("Player Interactions")]
    [SerializeField] private LayerMask interactableLayer;

    private void Start()
    {
        _targetMarkerInstance = Instantiate(targetMarkerPrefab);
        _targetMarkerInstance.SetActive(false);
    }
    
    private void Update()
    {
        if (DialogueManager.Instance.DialogueActive) return;

        UpdateTargetMarker();
        
        if (Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var groundHit, 20, groundLayer))
            {
                _targetPos = new Vector3(groundHit.point.x, 1, groundHit.point.z);
                _isMoving = true;
            }

            if (Physics.Raycast(ray, out var interactHit, 5, interactableLayer))
            {
                var interactableObj = interactHit.collider.gameObject;
                interactableObj.GetComponent<Interactable>().Interact();
            }
        }
        
        if (_isMoving)
            stepSFX.Play();
            MoveToTarget();
    }

    private void UpdateTargetMarker()
    {
        //same as ground raycast stuff but needs to be outside the Input.GetMouseButton()
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 20, groundLayer))
        {
            _targetMarkerInstance.SetActive(true);
            _targetMarkerInstance.transform.position = hit.point;
        }
        else _targetMarkerInstance.SetActive(false);
    }

    private void MoveToTarget()
    {
        var moveDir = (_targetPos - transform.position).normalized;
        var dst = Vector3.Distance(transform.position, _targetPos);

        //move to target until close enough
        if (dst > .1f)
            nMA.SetDestination(_targetPos);
        else
            _isMoving = false;
    }
}
