using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    List<GameObject> heirs = new List<GameObject>();
    GameObject currRuler;

    [SerializeField]
    GameObject heirPrefab;

    [SerializeField]
    float heirsXDistance;

    [SerializeField]
    float heirsYPosition;

    [SerializeField]
    float heirsXPosition;

    [SerializeField]
    float rulerYPosition;

    [SerializeField]
    int startingHappiness;
    int currHappiness;

    [SerializeField]
    int startingPopulation;
    int currPopulation;

    [SerializeField]
    int startingEconomy;
    int currEconomy;

    [SerializeField]
    int startingMilitary;
    int currMilitary;

    [SerializeField]
    int victoryAmount;

    public static GameManager instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        currHappiness = startingHappiness;
        currPopulation = startingPopulation;
        currEconomy = startingEconomy;
        currMilitary = startingMilitary;
        UIManager.instance.UpdateAllUI();
        GenerateNewHeirs();
    }

    public void GenerateNewHeirs() {

        heirs.Clear();
        int heir_count = 3;

        float heirs_x_position = heirsXPosition + heirsXDistance * (heir_count - 1) / -2f;
        for (int i = 0; i < heir_count; i++) {
            GameObject heir = Instantiate(heirPrefab, new Vector3(heirs_x_position, heirsYPosition, 0f), Quaternion.identity);
            heir.GetComponent<Heir>().SetName(TraitsManager.instance.GetRandomName());
            heir.GetComponent<Heir>().SetTrait(TraitsManager.instance.GetRandomTrait());
            heirs.Add(heir);

            heirs_x_position += heirsXDistance;
        }
    }

    public int GetHappiness() {
        return currHappiness;
    }

    public int GetPopulation() {
        return currPopulation;
    }

    public int GetEconomy() {
        return currEconomy;
    }

    public int GetMilitary() {
        return currMilitary;
    }

    public void UpdateHappiness(int delta) {
        currHappiness += delta;
        UIManager.instance.UpdateHappinessUI();
    }
    public void UpdatePopulation(int delta) {
        currPopulation += delta;
        UIManager.instance.UpdatePopulationUI();
    }
    public void UpdateEconomy(int delta) {
        currEconomy += delta;
        UIManager.instance.UpdateEconomyUI();
    }
    public void UpdateMilitary(int delta) {
        currMilitary += delta;
        UIManager.instance.UpdateMilitaryUI();
    }

    public Vector3 GetRulerPosition() {
        return new Vector3(heirsXPosition, rulerYPosition, 0);
    }

    public void SetRuler(GameObject ruler) {
        currRuler = ruler;
    }

    public void RemoveCurrentRuler() {
        if (currRuler != null) currRuler.GetComponent<Heir>().PassAway();
    }

    public void RemoveUnchosen() {
        foreach (GameObject heir in heirs) {
            if (heir != currRuler) {
                heir.GetComponent<Heir>().RemoveSelf();
            }
        }
    }

    public int GetVictoryAmount() {
        return victoryAmount;
    }
}
