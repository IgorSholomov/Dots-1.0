using UnityEngine;

namespace Mono
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float OrthographicSize = 150f;
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
                _camera.orthographicSize -= Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * OrthographicSize;
        }
    }
}