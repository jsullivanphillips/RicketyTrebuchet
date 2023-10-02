using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    // Hook ref of child object, and grab the heart prefab.
    [Header("Hearts")]
    [SerializeField] private GameObject heart_bar;
    [SerializeField] private List<GameObject> hearts;
    private int curr_hearts;

    // Hook ref of child object, and grab the orb prefab.
    [Header("Orbs")]
    [SerializeField] private GameObject orb_bar;
    [SerializeField] private List<GameObject> orbs;
    private int curr_orbs;
    
    // Hook ref of child obj, and set the sprites of the various Bar levels into the list.
    [Header("Sparkle")]
    [SerializeField] private GameObject sparkle_bar;
    [SerializeField] private List<Sprite> sparkle_sprites;
    private int curr_sparkles;

    // Start is called before the first frame update
    void Start()
    {
        BrendanManager.instance.setCanvasRef(this);

        curr_hearts = BrendanManager.instance.getStartHearts();
        curr_orbs = BrendanManager.instance.getStartOrbs();
        curr_sparkles = BrendanManager.instance.getStartSparkles();

        setupUI();
    }

    private void setupUI() {
        for (int i = 0; i < curr_hearts; i++) {
            hearts[i].SetActive(true);
        }

        for (int i = 0; i < curr_orbs; i++) {
            orbs[i].SetActive(true);
        }
        
        sparkle_bar.GetComponent<Image>().sprite = sparkle_sprites[curr_sparkles];
    }

    public void setHearts(int to_set) {        
        
        if (to_set > curr_hearts) {
            for (int i = curr_hearts; i <= to_set; i++) {
                //Debug.Log("I: " + i + " , while to set os: " + to_set);
                hearts[i].SetActive(true);
            }
        }
        else if (to_set < curr_hearts) {
            for (int i = curr_hearts; i > to_set; i--) {
                //Debug.Log("Butt I: " + i);
                hearts[i - 1].SetActive(false);
            }
        }

        curr_hearts = to_set;
    }

    public void setOrbs(int to_set) {        
        Debug.Log("orby" + to_set);

        if (to_set > curr_orbs) {
            Debug.Log("higher");
            for (int i = curr_orbs; i <= to_set; i++) {
                //Debug.Log("I: " + i + " , while to set os: " + to_set);
                orbs[i].SetActive(true);
            }
        }
        else if (to_set < curr_orbs) {
            Debug.Log("lower");
            for (int i = curr_orbs; i > to_set; i--) {
                //Debug.Log("Butt I: " + i);
                orbs[i - 1].SetActive(false);
            }
        }

        curr_orbs = to_set;
    }

    public void crementSparkleBar(int amount) {
        curr_sparkles = (curr_sparkles + amount) % 10;
        sparkle_bar.GetComponent<Image>().sprite = sparkle_sprites[curr_sparkles];
    }

    public void setSparkleBar(int to_set) {
        curr_sparkles = to_set;
        sparkle_bar.GetComponent<Image>().sprite = sparkle_sprites[curr_sparkles];
    }
}
