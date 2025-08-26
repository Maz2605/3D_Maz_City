using UnityEngine;
using System;
using System.Collections.Generic;
using _Scripts.DesignPattern.Singleton;

namespace _DebugTools.Scripts.Core
{
    public class DebugConsole : Singleton<DebugConsole>
    {
        readonly Dictionary<string, Action<string[]>> _commands = new();

        string _line = "";
        bool _captureLog = true;
        Vector2 _scroll;

        protected override void Awake()
        {
            base.Awake();
            KeepAlive(true);
            Register("help", _ => Print(string.Join(", ", _commands.Keys)));
            Register("timescale", a =>
            {
                if (a.Length > 0 && float.TryParse(a[0], out var s)) Time.timeScale = Mathf.Clamp(s, 0, 10);
            });
            Register("hud", _ => DebugHUDManager.Instance?.ToggleHUD());
            Register("clear", _ => _buffer = "");
        }

        void OnEnable()
        {
            if (_captureLog) Application.logMessageReceived += OnLog;
        }

        protected override void OnDisable()
        {
            if (_captureLog) Application.logMessageReceived -= OnLog;
        }

        string _buffer = "";

        void OnLog(string cond, string stack, LogType type)
        {
            _buffer += $"\n[{type}] {cond}";
        }

        public void Register(string name, Action<string[]> handler)
        {
            name = name.ToLowerInvariant();
            if (!_commands.ContainsKey(name)) _commands.Add(name, handler);
        }

        void Execute(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;
            var parts = input.Split(' ');
            var cmd = parts[0].ToLowerInvariant();
            var args = new string[Mathf.Max(0, parts.Length - 1)];
            Array.Copy(parts, 1, args, 0, args.Length);

            if (_commands.TryGetValue(cmd, out var action)) action.Invoke(args);
            else Print($"Unknown: {cmd}");
        }

        public void Print(string msg)
        {
            _buffer += "\n> " + msg;
        }

        // IMGUI panel hiển thị khi consoleRoot bật
        void OnGUI()
        {
            if (!DebugHUDManager.Instance || !DebugHUDManager.Instance.gameObject.activeInHierarchy) return;
            var r = new Rect(10, 10, 520, 240);
            GUILayout.BeginArea(r, GUI.skin.window);
            _scroll = GUILayout.BeginScrollView(_scroll, GUILayout.Height(180));
            GUILayout.Label(_buffer, GUILayout.ExpandHeight(true));
            GUILayout.EndScrollView();

            GUILayout.BeginHorizontal();
            GUI.SetNextControlName("consoleInput");
            _line = GUILayout.TextField(_line, GUILayout.ExpandWidth(true));
            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return)
            {
                Execute(_line);
                _line = "";
                GUI.FocusControl("consoleInput");
            }

            if (GUILayout.Button("Run", GUILayout.Width(60)))
            {
                Execute(_line);
                _line = "";
            }

            GUILayout.EndHorizontal();

            GUILayout.EndArea();
        }
    }
}