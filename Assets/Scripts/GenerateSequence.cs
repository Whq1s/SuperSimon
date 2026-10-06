using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GenerateSequence : MonoBehaviour
{

    [SerializeField] Button[] buttonArray;
    [SerializeField] public int[] sequence = {0, 0, 0, 0, 0};
    [SerializeField] public bool isAbleToPlay;
    public int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGame(){
        isAbleToPlay = false;
        yield return new WaitForSeconds(0.5f);
        foreach (var button in buttonArray){
             button.interactable = false;
        }
        int random = Random.Range(0, 5);
        sequence[currentIndex] = random;

        for (int i = 0; i <= currentIndex; i++){
            if(i != currentIndex){
                buttonArray[sequence[i]].interactable = true;
                yield return new WaitForSeconds(2);
                buttonArray[sequence[i]].interactable = false; 
                yield return new WaitForSeconds(2);
            } else {
            buttonArray[sequence[i]].interactable = true;
            yield return new WaitForSeconds(2);
            buttonArray[sequence[i]].interactable = false; 
            }
        }

          foreach (var button in buttonArray){
             button.interactable = true;
        }
        currentIndex++;
        isAbleToPlay = true;
    }
}
