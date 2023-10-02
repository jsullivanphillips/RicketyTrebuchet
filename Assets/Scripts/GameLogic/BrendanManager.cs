using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrendanManager : MonoBehaviour
{
    [Header("Player Config")]
    [Range(0,8)]
    [SerializeField] int starting_health = 4;
    [Range(0, 5)]
    [SerializeField] int starting_orbs = 5;
    [Range(0, 10)]
    [SerializeField] int starting_sparkle = 4;

    private CanvasManager canvasManager;

    private int curr_health;
    private int curr_orb;
    private int curr_sparkle;

    public static BrendanManager instance { get; private set;}

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than one Brendan Manager in the scene.");
        }
        instance = this;
    }

    private void Start() {
        curr_health = starting_health;
        curr_orb = starting_orbs;
        curr_sparkle = starting_sparkle;
    }


    ////// Functions for the Canvas Manager
    public void setCanvasRef(CanvasManager cm) {
        canvasManager = cm;
    }

    // These could all be one funct, which would return a list / array, but I forgor the syntax...
    public int getStartHearts() {
        return starting_health;
    }

    public int getStartOrbs() {
        return starting_orbs;
    }

    public int getStartSparkles() {
        return starting_sparkle;
    }

    // Stupid thing because it's not modding properly
    // And apparently % ISNT mod, it's "remainder"...
    int Mod(int a, int n) => (a % n + n) % n;

    int quickMod(int num, int modder) {
        return ((num % modder + modder) % modder);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Decrement all resources.");
            canvasManager.setHearts(quickMod((curr_health - 1), 4));
            canvasManager.setOrbs(quickMod((curr_orb - 1), 5));
            canvasManager.setSparkleBar(quickMod((curr_sparkle - 1), 10));

            curr_health--;
            curr_orb--;
            curr_sparkle--;
        }
    }
}
