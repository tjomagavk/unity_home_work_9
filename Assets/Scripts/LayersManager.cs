using UnityEngine;

public class LayersManager : MonoBehaviour
{
    private static LayersManager _instance;
    private int _pockets;
    private int _badGuy;

    public static LayersManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LayersManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("LayersManager");
                    _instance = container.AddComponent<LayersManager>();
                    _instance.InitializeManager();
                }
            }

            return _instance;
        }
    }

    private void InitializeManager()
    {
        _pockets = LayerMask.NameToLayer("Pockets");
        _badGuy = LayerMask.NameToLayer("BadGuy");
    }

    public static int GetPockets()
    {
        return Instance._pockets;
    }

    public static int GetBadGuy()
    {
        return Instance._badGuy;
    }
}