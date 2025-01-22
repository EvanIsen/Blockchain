using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectMaokai : MonoBehaviour
{
    
    private Button _selectMaokaiButton;
    public GameObject unit;
    public new Camera camera;
    private PlayerController _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _selectMaokaiButton = gameObject.GetComponent<Button>();
        _player = camera.GetComponent<PlayerController>();
    }

    void Start()
    {
        _selectMaokaiButton.onClick.AddListener(() => SetUnit());
    }

    
    //public void SetUnit()
    //Définit la variable selectedUnit du playerController avec l'unité du bouton.
    void SetUnit()
    {
        if (_player && !_player.hasSelected)
        {
            _player.selectedUnit = unit;
            _player.hasSelected = true;
        }
        else if (_player.hasSelected)
        {
            _player.hasSelected = false;
            _player.selectedUnit = null;
        }
    }
    
}
