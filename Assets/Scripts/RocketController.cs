using UnityEngine;

public class RocketController : MonoBehaviour {

   private string _rocketName;

   public void Start () {
      _rocketName = gameObject.name;
      Debug.Log("Rocket name: " + _rocketName);
   }

   // Update is called once per frame
   void Update () {

   }
}
