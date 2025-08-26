using _DebugTools.Scripts.Core;
using DebugTools.Core;
using UnityEngine;

public class DebugTeleport : MonoBehaviour
{
    [SerializeField] DebugConfig config;
    [SerializeField] PlayerLocator locator;
    [SerializeField] Transform[] waypoints;
    int idx;

    void Awake(){ if(!config) config = Resources.Load<DebugConfig>("DebugConfig"); }
    void Start(){ DebugConsole.Instance?.Register("tp", CmdTp); }

    void Update()
    {
        if (!config) return;
        if (Input.GetKeyDown(config.tpNext)) TeleportTo(idx + 1);
        if (Input.GetKeyDown(config.tpPrev)) TeleportTo(idx - 1);
    }

    void CmdTp(string[] a)
    {
        if (a.Length == 3 &&
            float.TryParse(a[0], out var x) &&
            float.TryParse(a[1], out var y) &&
            float.TryParse(a[2], out var z))
        {
            Teleport(new Vector3(x,y,z));
        }
        else if (a.Length == 1 && int.TryParse(a[0], out var i)) TeleportTo(i-1);
    }

    void TeleportTo(int newIndex)
    {
        if (waypoints == null || waypoints.Length == 0) return;
        idx = (newIndex % waypoints.Length + waypoints.Length) % waypoints.Length;
        Teleport(waypoints[idx].position, waypoints[idx].rotation);
    }

    void Teleport(Vector3 p, Quaternion? r = null)
    {
        var t = locator ? locator.Get() : null;
        if (!t) return;
        var cc = t.GetComponent<CharacterController>();
        if (cc) { cc.enabled = false; t.SetPositionAndRotation(p, r ?? t.rotation); cc.enabled = true; }
        else     t.SetPositionAndRotation(p, r ?? t.rotation);
    }
}

