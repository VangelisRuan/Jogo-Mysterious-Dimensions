using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonPause : MonoBehaviour
{
    public GameObject textoDoPause;
     void Start(){
         GetComponent<Button>().onClick.AddListener(TogglePause);
     }
     public void TogglePause() {
         Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f; 

         if (Time.timeScale == 0)
         {
             textoDoPause.SetActive(true);
         }
         else 
         {
             textoDoPause.SetActive(false);
         }       
     }

}
