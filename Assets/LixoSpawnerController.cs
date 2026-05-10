using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LixoSpawnerController : MonoBehaviour
{
    public float maximumX;
    public float fixedY;
    public float fixedZ;
    public GameObject Lixo;
    public int MaxPoints;
    public int points = 0;
    public float timer = 1f;
    public TMP_Text pointsText;
    public TMP_Text victoryText;
    // Start is called before the first frame update
    void Start()
    {      StartCoroutine(SpawnerRoutine());
        victoryText.gameObject.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnerRoutine(){
        while (points < MaxPoints){
            Instantiate (Lixo,
            new Vector3(Random.Range(- maximumX, maximumX + 1),
            fixedY,
            fixedZ),
            Quaternion.identity);
            yield return new WaitForSeconds(timer);
        }
        victoryText.gameObject.SetActive(true);
    }
    public void AddToPoints(int value)
{
    points += value;
    pointsText.text = "Points: " + points.ToString();
}
    
    public void RemoveFromPoints(int value)
{
    points -= value;
    if (points < 0) points = 0;
    pointsText.text = "Points: " + points.ToString();
}
}
