using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    Text happinessText;
    [SerializeField]
    Slider happinessBar;

    [SerializeField]
    Text populationText;
    [SerializeField]
    Slider populationBar;

    [SerializeField]
    Text economyText;
    [SerializeField]
    Slider economyBar;

    [SerializeField]
    Text militaryText;
    [SerializeField]
    Slider militaryBar;

    public static UIManager instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    public void UpdateAllUI() {
        UpdateHappinessUI();
        UpdatePopulationUI();
        UpdateEconomyUI();
        UpdateMilitaryUI();
    }

    public void UpdateHappinessUI() {
        happinessText.text = string.Format("Happiness: {0}", GameManager.instance.GetHappiness());
        happinessBar.value = (float) GameManager.instance.GetHappiness() / GameManager.instance.GetVictoryAmount();
    }

    public void UpdatePopulationUI() {
        populationText.text = string.Format("Population: {0}", GameManager.instance.GetPopulation());
        populationBar.value = (float) GameManager.instance.GetPopulation() / GameManager.instance.GetVictoryAmount();
    }

    public void UpdateEconomyUI() {
        economyText.text = string.Format("Economy: {0}", GameManager.instance.GetEconomy());
        economyBar.value = (float) GameManager.instance.GetEconomy() / GameManager.instance.GetVictoryAmount();
    }

    public void UpdateMilitaryUI() {
        militaryText.text = string.Format("Military: {0}", GameManager.instance.GetMilitary());
        militaryBar.value = (float) GameManager.instance.GetMilitary() / GameManager.instance.GetVictoryAmount();
    }
}
