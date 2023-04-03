using UnityEngine;

public class Crystal : MonoBehaviour
{
    private int _mobsInCollider;
    public int MobsInCollider 
    { 
        get 
        {
            return _mobsInCollider; 
        } 
        set 
        {
            _mobsInCollider = value; 
        } 
    }

    
}
