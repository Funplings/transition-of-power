using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heir : MonoBehaviour {

    string myName;
    TraitsManager.Trait myTrait;

    [SerializeField]
    Text titleText;

    [SerializeField]
    GameObject selectButton;

    public void SetName(string name) {
        myName = name;
        UpdateTitleText();
    }

    public void SetTrait(TraitsManager.Trait trait) {
        myTrait = trait;
        UpdateTitleText();
    }

    public void UpdateTitleText() {
        titleText.text = string.Format("{0} the {1}", myName, myTrait.Name);
    }

    public string GetName() {
        return myName;
    }

    public TraitsManager.Trait getTrait() {
        return myTrait;
    }

    public void SelectHeir() {
        int happinessDelta = Random.Range(myTrait.HappinessDeltaMin, myTrait.HappinessDeltaMin);
        int populationDelta = Random.Range(myTrait.PopulationDeltaMin, myTrait.PopulationDeltaMax);
        int economyDelta = Random.Range(myTrait.EconomyDeltaMin, myTrait.EconomyDeltaMax);
        int militaryDelta = Random.Range(myTrait.MilitaryDeltaMin, myTrait.MilitaryDeltaMax);

        GameManager.instance.UpdateHappiness(happinessDelta);
        GameManager.instance.UpdatePopulation(populationDelta);
        GameManager.instance.UpdateEconomy(economyDelta);
        GameManager.instance.UpdateMilitary(militaryDelta);

        GameManager.instance.RemoveCurrentRuler();

        GameManager.instance.SetRuler(gameObject);
        GameManager.instance.RemoveUnchosen();

        selectButton.SetActive(false);
        StartCoroutine(MoveSmoothlyTo(GameManager.instance.GetRulerPosition(), 0.5f));

        StartCoroutine(GenerateHeirsAfter(0.5f));
    }

    public void RemoveSelf() {
        selectButton.SetActive(false);
        StartCoroutine(MoveSmoothlyTo(new Vector3(transform.position.x, -10, 0), 0.5f));
        StartCoroutine(DestroySelfAfter(0.5f));
    }

    public void PassAway() {
        StartCoroutine(MoveSmoothlyTo(new Vector3(transform.position.x, 10, 0), 0.5f));
        StartCoroutine(DestroySelfAfter(0.5f));
    }


    private IEnumerator MoveSmoothlyTo(Vector3 newPosition, float time) {
        Vector3 velocity = Vector3.zero;
        Vector3 oldPosition = transform.position;
        for (float t = 0.0f; t < time; t += Time.deltaTime) {
            transform.position = Vector3.Lerp(oldPosition, newPosition, Mathf.Pow((t / time), 0.5f));
            yield return null;
        }
        transform.position = newPosition;
    }

    private IEnumerator DestroySelfAfter(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private IEnumerator GenerateHeirsAfter(float time) {
        yield return new WaitForSeconds(time);
        GameManager.instance.GenerateNewHeirs();
    }
}
