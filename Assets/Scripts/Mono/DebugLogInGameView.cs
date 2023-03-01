using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mono
{
    public class DebugLogInGameView : MonoBehaviour
    {
        private struct Log
        {
            public LogType Type;
            public string Message;

            // ReSharper disable once NotAccessedField.Local
            public string StackTrace;
            public float Timer;
        }

        [SerializeField] private float LifeLog = 3f;
        [SerializeField] private TextMeshProUGUI LogText;
        [SerializeField] private Image BgLog;

        private const float TimeStep = 0.3f;

        private readonly List<Log> _logs = new List<Log>();

        private static readonly Dictionary<LogType, string> LogTypeColors = new Dictionary<LogType, string>()
        {
            {LogType.Assert, "green"},
            {LogType.Error, "red"},
            {LogType.Exception, "red"},
            {LogType.Log, "#00FFED"},
            {LogType.Warning, "yellow"},
        };


        private void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        private void Awake()
        {
            LogText.text = string.Empty;
        }

        private void Start()
        {
            StartCoroutine(DoCheck());
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote)) SetActiveBg();

            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Backspace)) ClearLogs();
        }

        private void ClearLogs()
        {
            _logs.Clear();
            LogText.text = string.Empty;
        }

        private void SetActiveBg()
        {
            BgLog.enabled = !BgLog.enabled;
        }

        private IEnumerator DoCheck()
        {
            for (;;)
            {
                RemoveLog();
                yield return new WaitForSeconds(TimeStep);
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void RemoveLog()
        {
            for (var i = 0; i < _logs.Count; i++)
                if (Time.unscaledTime - _logs[i].Timer > LifeLog)
                {
                    _logs.Remove(_logs[i]);
                    SetText();
                }
        }


        private void SetText()
        {
            if (LogText.preferredHeight + 40 + 20 >
                Screen.height) // height text area + height fps counter box + safety zone
                _logs.RemoveAt(0);

            // Debug.Log(logText.preferredHeight + "   " + Screen.height);
            var str = string.Empty;

            foreach (var log in _logs) str += $"<color={LogTypeColors[log.Type]}>{log.Message}</color>\n";

            LogText.text = str;
        }

        private void HandleLog(string message, string stackTrace, LogType type)
        {
            _logs.Add(new Log()
            {
                Message = message,
                StackTrace = stackTrace,
                Type = type,
                Timer = Time.unscaledTime
            });

            SetText();
        }
    }
}