using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{

    GameObject[] hearts;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;

    public Sprite fullheart;

    public Sprite halfheart;

    public Sprite emptyheart;
    // Start is called before the first frame update
    void Start()
    {
        hearts = new GameObject[5]{image1,image2,image3,image4,image5};
    }

    public void UpdateHealth(int health) {
    for (int i = 0; i < 5; i++){
        if (health>=2){
            hearts[i].GetComponent<Image>().sprite=fullheart;
            health-=2;
        }
        else if (health==1){
            hearts[i].GetComponent<Image>().sprite=halfheart;
            health--;
        }
        else if (health<1){
            hearts[i].GetComponent<Image>().sprite=emptyheart;

        }
        }
            
    }
}

