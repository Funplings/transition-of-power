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
    float startingHappiness;
    float currHappiness;

    [SerializeField]
    float startingPopulation;
    float currPopulation;

    [SerializeField]
    float startingEconomy;
    float currEconomy;

    [SerializeField]
    float startingMilitary;
    float currMilitary;

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
        GenerateNewHeirs();
    }

    // Update is called once per frame
    void Update() {
        
    }

    GameObject GenerateHeir() {
        return heirPrefab;
    }

    void GenerateNewHeirs() {

        heirs.Clear();
        int heir_count = 3;

        float heirs_x_position = heirsXDistance * (heir_count - 1) / -2f;
        for (int i = 0; i < heir_count; i++) {
            GameObject heir = GenerateHeir();
            heirs.Add(heir);
            Instantiate(heir, new Vector3(heirs_x_position, heirsYPosition, 0f), Quaternion.identity);
            heirs_x_position += heirsXDistance;
        }
    }
}
