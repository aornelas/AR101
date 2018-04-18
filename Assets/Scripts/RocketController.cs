using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour {

   private string _rocketName;

   public void Start () {
      _rocketName = gameObject.name;

      var canvasObj = transform.Find ("Rocket Card");

      var rocketNameObj = canvasObj.Find ("name");
      rocketNameObj.GetComponent<Text>().text = _rocketName;
   }

   // Update is called once per frame
   void Update () {

   }
}
