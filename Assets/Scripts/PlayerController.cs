using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    private bool CanSpawn =true;
    public GameObject selectedUnit;
    public bool hasSelected = false;
    public UnityEvent<Vector3> selectedUnitEvent;
    private Camera _cam;
    private PlayableDirector _director;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if(selectedUnitEvent == null) selectedUnitEvent = new UnityEvent<Vector3>();
        _cam = Camera.main;        
        _director = GetComponent<PlayableDirector>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 500f;
        mousePos = _cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.magenta);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 500f))
                // if(hit.collider.tag ==)
            {
                selectedUnitEvent.Invoke(hit.point);
            }
        }
    }

    public void swapbool()
    {
        CanSpawn = !CanSpawn;
        Debug.Log(CanSpawn);
    }
    public void OnClickOnLevel(Vector3 pos)
    {
        if (selectedUnit && CanSpawn)
        {
            Instantiate(selectedUnit, pos, Quaternion.identity);
            CanSpawn = !CanSpawn;
            _director.Play();
        }
    }
}
