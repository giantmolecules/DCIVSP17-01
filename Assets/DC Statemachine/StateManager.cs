using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

    //Create properties to hold our three states
    StateOne _StateOne;
    StateTwo _StateTwo;
    StateThree _StateThree;

    AbstractState[] _StateList;
    //create a property that is our current state
    AbstractState _CurrentSate;
    bool canChange = true;
	// Use this for initialization
	void Start () {

        //Make sure that the state manager is always
        //present in every scene at all time
        DontDestroyOnLoad(this);

        //Initialize our three states so we can use them
        //Store them in an array so we can switch them out
        _StateList = new AbstractState[3];
        _StateOne = new StateOne();
        _StateList[0] = _StateOne;
        _StateTwo = new StateTwo();
        _StateList[1] = _StateTwo;
        _StateThree = new StateThree();
        _StateList[2] = _StateThree;


        //Set the current state at startup
        _CurrentSate = _StateOne;
        _CurrentSate.Active();
    }
	
	// Update is called once per frame
	void Update () {

        
        //Are we already tring to change, if not we can change
        //All code for changing states must be in the if statement
        if(canChange)
        {
            int r = (int)Random.Range(0, 3);
            float time = Random.Range(3, 12);
            setState(r, time);
        }
        
        //Call the update code in the currently executing state
        _CurrentSate.Update();
	}



    /// <summary>
    /// Method to change states 
    /// </summary>
    /// <param name="stateNumber"></param>
    void setState(int stateNumber, float seconds)
    {
        Debug.Log("We are going to Change States in: " + seconds + "seconds.");
        //Tell the system we cannot change states
        canChange = false;
        //Set the current state as inactive
        _CurrentSate.InActive();
        //Start a routine so that we can continue to draw the events from the current state

        StartCoroutine(FadeState(seconds, stateNumber));
       
    }

    /// <summary>
    /// Fade function to allow for us to wait to switch out the current state
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="stateNumber"></param>
    /// <returns></returns>
    IEnumerator FadeState(float seconds, int stateNumber)
    {
        //Waiting for given number of seconds before we change
        yield return new WaitForSeconds(seconds);

        //Set the current state to our chosen state
        _CurrentSate = _StateList[stateNumber];
        
        //Activate the current state
        _CurrentSate.Active();
        
        //Tell the system we can change states
        canChange = true;
    }
}
