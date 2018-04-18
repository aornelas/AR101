using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour {

   public string Country;
   public float HeightMeters;
   public float TiltSpeed = 3f;

   private string _rocketName;
   private bool _raised;
   private bool _raising;

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

   public void Update () {
      if (_raising) {
         if (transform.rotation.eulerAngles.x > 0) {
            transform.rotation =
               Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * TiltSpeed);
         } else {
            _raising = false;
            _raised = true;
            Debug.Log("Fully raised");
         }
      }
   }

   public void OnMouseDown()
   {
      if (!_raised) {
         _raising = true;
      } else {
         _raised = false;
      }
   }
}
