using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    public GameObject selectedUnit;
    public bool hasSelected = false;
    public UnityEvent<Vector3> selectedUnitEvent;
    private Camera _cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(selectedUnitEvent == null) selectedUnitEvent = new UnityEvent<Vector3>();
        _cam = Camera.main;
        
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
            {
                selectedUnitEvent.Invoke(hit.point);
            }
        }
    }

    public void OnClickOnLevel(Vector3 pos)
    {
        Instantiate(selectedUnit, pos, Quaternion.identity);
    }
}
