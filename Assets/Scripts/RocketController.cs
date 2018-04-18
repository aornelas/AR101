using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour {

   public string Country;
   public float HeightMeters;

   private string _rocketName;
   private bool _raised;

   public void Start () {
      _rocketName = gameObject.name;

      var canvasObj = transform.Find ("Rocket Card");

      var rocketNameObj = canvasObj.Find ("name");
      rocketNameObj.GetComponent<Text>().text = _rocketName;

      var countryObj = canvasObj.Find ("country");
      countryObj.GetComponent<Text> ().text = Country;

      var heightObj = canvasObj.Find ("height");
      heightObj.GetComponent<Text> ().text = HeightMeters + " m";
   }

   // Update is called once per frame
   void Update () {

   }

   public void OnMouseDown()
   {
      if (!_raised) {
         transform.Rotate(new Vector3(-90, 0, 0));
         _raised = true;
      } else {
         transform.Rotate(new Vector3(90, 0, 0));
         _raised = false;
      }
   }
}
