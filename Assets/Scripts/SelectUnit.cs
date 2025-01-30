using UnityEngine;
using UnityEngine.UI;

public class SelectUnit : MonoBehaviour
{
    
    private Button _selectUnitButton;
    public GameObject unit;
    public new Camera camera;
    private PlayerController _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _selectUnitButton = gameObject.GetComponent<Button>();
        _player = camera.GetComponent<PlayerController>();
    }

    void Start()
    {
        _selectUnitButton.onClick.AddListener(() => SetUnit());
        Debug.Log(_selectUnitButton.name);
    }

    
    //public void SetUnit()
    //Définit la variable selectedUnit du playerController avec l'unité du bouton.
    void SetUnit()
    {
        if (_player && !_player.hasSelected)
        {
            _player.selectedUnit = unit;
            _player.hasSelected = true;
            Debug.Log(_player.selectedUnit);
        }
        else if (_player.hasSelected && _player.selectedUnit != unit)
        {
            _player.selectedUnit = unit;
            _player.hasSelected = true;
            Debug.Log(_player.selectedUnit);
        }
        else
        {
            _player.hasSelected = false;
            _player.selectedUnit = null;
        }
    }
    
}
