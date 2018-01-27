using UnityEngine;

public class BasicObjectManager:MonoBehaviour {

    public void destroy(){
        Destroy(this.gameObject);
    }
}