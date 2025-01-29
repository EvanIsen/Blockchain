using UnityEngine;

public class SpawnRandomUnit : MonoBehaviour
{
    
    [SerializeField] private GameObject[] spawnPos;
    [SerializeField] private GameObject[] Units;


    public void SpawnUnit()
    {
        int location = Random.Range(0, spawnPos.Length-1);
        int SelectedUnit = Random.Range(0, Units.Length-1);
        GameObject unit = Units[SelectedUnit];
        Instantiate(unit, spawnPos[location].transform.position, Quaternion.identity);

        IA ia = unit.GetComponent<IA>();
        ia.side = Side.DarkSide;
        ia.tag = "DarkMonster";
    }
}
