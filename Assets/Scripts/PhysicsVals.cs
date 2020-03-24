using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine;

public class PhysicsVals : Singleton<PhysicsVals>
{

    public Dictionary<string, float[]> physVals = new Dictionary<string, float[]>(){
        {"playerMass", new float[3]{0, 50, 5f} },
        {"playerDragLin", new float[3]{0, 10, 1.5f}},
        {"playerDragAng", new float[3]{0, 10, 1.2f}},
        {"playerForce", new float[3]{0, 50, 34}},
        {"playerAcceleration", new float[3]{0, 20, 10}},
        {"playerDeceleration", new float[3]{0, 30, 12}},
        {"chainMass", new float[3]{0, 50, 8f}},
        {"chainDragLin", new float[3]{0, 10, 0.05f}},
        {"chainDragAng", new float[3]{0, 10, 0.1f}},
        {"chainSpringDist", new float[3]{0, 2, 0.05f}},
        {"chainSpringDamp", new float[3]{0, 10, 3.5f}},
        {"chainSpringFreq", new float[3]{0, 5, 1}},
    };

    public GameObject sliderPrefab;
    public GameObject player1Obj;
    public GameObject player2Obj;
    public GameObject[] chains;
    public Transform sliderPos;
    public float yOffset;

    private player1Controller player1;
    private player2Controller player2;
    private Rigidbody2D[] playerBodies;

    private List<Rigidbody2D> chainBodies;
    private List<SpringJoint2D> chainSprings; 

    void Start()
    {
        player1 = player1Obj.GetComponent<player1Controller>();
        player2 = player2Obj.GetComponent<player2Controller>();
        playerBodies = new Rigidbody2D[2];
        playerBodies[0] = player1Obj.GetComponent<Rigidbody2D>();
        playerBodies[1] = player2Obj.GetComponent<Rigidbody2D>();

        chainBodies = new List<Rigidbody2D>();
        chainSprings = new List<SpringJoint2D>();

        foreach (GameObject chain in chains)
        {
            chainBodies.Add(chain.GetComponent<Rigidbody2D>());
            foreach (SpringJoint2D spring in chain.GetComponents<SpringJoint2D>())
            {
                chainSprings.Add(spring);
            }
        }

        int i = 0;
        foreach(string key in physVals.Keys)
        {
            float min = physVals[key][0];
            float max = physVals[key][1];
            float init = physVals[key][2];
            createValueSlider(key, min, max, init, sliderPos, -yOffset * i);
            i++;
        }



    }
    // Update is called once per frame
    void Update()
    {
        
        
        foreach (Rigidbody2D player in playerBodies)
        {
            player.mass =  getValFromDict("playerMass");
            player.drag = getValFromDict("playerDragLin");
            player.angularDrag = getValFromDict("playerDragAng");
        }
       
        player2.acceleration = getValFromDict( "playerAcceleration");
        player1.acceleration = getValFromDict( "playerAcceleration");
        player2.deceleration = getValFromDict( "playerDeceleration");
        player1.deceleration = getValFromDict( "playerDeceleration");
        player1.force = getValFromDict("playerForce");
        player2.force = getValFromDict("playerForce");
        
        foreach (Rigidbody2D chain in chainBodies) 
        {
            chain.mass = getValFromDict("chainMass");
            chain.drag = getValFromDict("chainDragLin");
            chain.angularDrag = getValFromDict("chainDragAng");
        }

        foreach (SpringJoint2D spring in chainSprings)
        {
            spring.distance = getValFromDict("chainSpringDist");
            spring.dampingRatio = getValFromDict("chainSpringDamp");
            spring.frequency = getValFromDict("chainSpringFreq");
        }

    }

    private float getValFromDict(string key) {
        return physVals[key][2];
    }

    public void updateVal(string valKey, float valData)
    {
        physVals[valKey][2] = valData;
    }

    private void createValueSlider(string valKey, float valMin, float valMax, float valInit, Transform pos, float offset)
    {
        GameObject newSlider = GameObject.Instantiate(sliderPrefab, pos);
        newSlider.GetComponent<SliderLabel>().setLabel(valKey);
        newSlider.GetComponent<Transform>().Translate(new Vector3(0, offset, 0));
        Slider newSliderObj = newSlider.GetComponent<Slider>();
        newSliderObj.maxValue = valMax;
        newSliderObj.minValue = valMin;
        newSliderObj.value = valInit;
        newSliderObj.onValueChanged.AddListener( (float newVal) => {
            updateVal(valKey, newVal);
        });

    }
}
