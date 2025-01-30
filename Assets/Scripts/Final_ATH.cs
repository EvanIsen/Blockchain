using System;
using UnityEngine;
using UnityEngine.UI;

public class Final_ATH : MonoBehaviour
{
    [SerializeField]
    private GameObject _skeletonButton;
    [SerializeField]
    private GameObject _maokaiButton;
    [SerializeField]
    private Button _quitButton;
    private UnitScript _darkTower_unit;
    private UnitScript _lightTower_unit;

    private void Start()
    {
        _quitButton.onClick.AddListener(Application.Quit);
       GameObject _lightTower = GameObject.Find("Tower");
       GameObject _darkTower = GameObject.Find("Tower (1)");
        _darkTower_unit= _darkTower.GetComponent<UnitScript>();
        _lightTower_unit = _lightTower.GetComponent<UnitScript>();
    }

    private void Update()
    {
        if (_darkTower_unit.health <= 0)
        {
           SetFinalATH();
            Time.timeScale = 0;
        }
        else if (_lightTower_unit.health <= 0)
        {
            SetFinalATH();
            Time.timeScale = 0;
        }
    }

    public void SetFinalATH()
    {
        _skeletonButton.SetActive(false);
        _maokaiButton.SetActive(false);
        _quitButton.gameObject.SetActive(true);
    }
}
