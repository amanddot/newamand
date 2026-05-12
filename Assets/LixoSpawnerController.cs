using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LixoSpawnerController : MonoBehaviour
{
    public float maximum;

    public float fixedY;

    public float fixedZ;

    public float time;

    public GameObject lixo;

    public int maxPoints;

    public int points = 0;   

    public TMP_Text pointsText;

    public TMP_Text victoryText;

    void Start() {
    StartCoroutine(SpawnRoutine());
    victoryText.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    IEnumerator SpawnRoutine() {
    while (points < maxPoints) {
        Instantiate(lixo,
            new Vector3(Random.Range(-maximum, maximum + 1),
                fixedY,
                fixedZ),
            Quaternion.identity);
        yield return new WaitForSeconds(time);
    }
    victoryText.gameObject.SetActive(true);
}

public void AddToPoints(int value) {
    points += value;
    pointsText.text = "Pontos: " + points.ToString();
}
}

