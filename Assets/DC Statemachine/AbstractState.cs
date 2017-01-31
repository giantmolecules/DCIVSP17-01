using UnityEngine;
using System.Collections;

public abstract class AbstractState 
{

    
	// Update is called once per frame the same as a typical script
	public abstract void Update(); 

    
    //how should your state become Avtive?
    public abstract void Active();

    //how should your state become InActive?
    public abstract void InActive();
    
}
