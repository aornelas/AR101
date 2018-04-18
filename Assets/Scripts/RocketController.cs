using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour {

   public string Country;
   public float HeightMeters;
   public GameObject LaunchButton;
   public float TiltSpeed = 3f;
   public float LaunchForce = 1f;

   private GameObject _canvas;
   private AudioSource _flickAudio;
   private AudioSource _launchAudio;
   private string _rocketName;
   private bool _raised;
   private bool _raising;
   private bool _lowering;
   private bool _countingDown;
   private float _applyForceTimer = 0f;

   public void Start () {
      _rocketName = gameObject.name;

      var canvasObj = transform.Find ("Rocket Card");
      _canvas = canvasObj.gameObject;
      _canvas.SetActive(false);
      LaunchButton.SetActive(false);

      var rocketNameObj = canvasObj.Find ("name");
      rocketNameObj.GetComponent<Text>().text = _rocketName;

      var countryObj = canvasObj.Find ("country");
      countryObj.GetComponent<Text> ().text = Country;

      var heightObj = canvasObj.Find ("height");
      heightObj.GetComponent<Text> ().text = HeightMeters + " m";

      var audioSources = GetComponents<AudioSource>();
      _flickAudio = audioSources[0];
      _launchAudio = audioSources[1];
   }

   public void Update () {
      if (_raising) {
         if (transform.rotation.eulerAngles.x > 0.1f) {
            transform.rotation =
               Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * TiltSpeed);
         } else {
            _raising = false;
            _raised = true;
            _canvas.SetActive(true);
            LaunchButton.SetActive(true);
            ButtonController.OnPressed += StartCountdown;
         }
      }

      if (_lowering) {
         if (transform.rotation.eulerAngles.x < 89.9f) {
            transform.rotation =
               Quaternion.Slerp (transform.rotation, Quaternion.Euler (90, 0, 0), Time.deltaTime * TiltSpeed);
         } else {
            _lowering = false;
            _canvas.SetActive(false);
         }
      }

      if (_applyForceTimer > 0f) {
         GetComponent<Rigidbody>().AddForce(transform.up * LaunchForce);
         _applyForceTimer -= Time.deltaTime;
      }
   }

   public void OnMouseDown()
   {
      if (_countingDown) return;

      _flickAudio.Play();
      if (!_raised && !_raising) {
         _raising = true;
         _lowering = false;
      } else {
         _lowering = true;
         _raising = false;
         _raised = false;
         ButtonController.OnPressed -= StartCountdown;
         LaunchButton.SetActive(false);
      }
   }

   private void StartCountdown()
   {
      if (!_countingDown) {
         _countingDown = true;
         _canvas.SetActive(false);
         _launchAudio.Play();
         Invoke ("LaunchRocket", 5.85f);
      } else {
         _countingDown = false;
         _canvas.SetActive(true);
         _launchAudio.Stop();
      }
   }

   private void LaunchRocket()
   {
      _applyForceTimer = 5f;
   }
}
