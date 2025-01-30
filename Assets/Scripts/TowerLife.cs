using TMPro;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.UI;

public class TowerLife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private UnitScript _darkTower_unit;
    private UnitScript _lightTower_unit;
    [SerializeField]
    private TMP_Text LightHpText;
    [SerializeField]
    private TMP_Text DarkHpText;
    private void Start()
    {
        GameObject _lightTower = GameObject.Find("Tower");
        GameObject _darkTower = GameObject.Find("Tower (1)");
        _darkTower_unit= _darkTower.GetComponent<UnitScript>();
        _lightTower_unit = _lightTower.GetComponent<UnitScript>();
    }

    // Update is called once per frame
    void Update()
    {
        LightHpText.text = math.round(_lightTower_unit.health).ToString();
        DarkHpText.text = math.round(_darkTower_unit.health).ToString();
    }
}
