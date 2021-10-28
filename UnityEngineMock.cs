using System.Collections;
using System.Collections.Generic;

//// Put the following at the top of a file that needs to be mockable:
//#if MOCK_UNITYENGINE
//using UnityEngineMock;
//#else
//using UnityEngine;
//#endif
//// Then define MOCK_UNITYENGINE to build with the mock.

namespace UnityEngineReplacement
{
    private static class Config
    {
        const string logFolderPath = "/tmp/";
        const string cacheFolderPath = "/tmp/";
        const string unityResourcePath = "Assets/Resources/";
    }

    public class Vector2Int : System.IEquatable<Vector2Int>
    {
        public int x, y;

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public float magnitude
        {
            get
            {
                return (float)System.Math.Sqrt(x * x + y * y);
            }
        }
 
        public int sqrMagnitude
        {
            get
            {
                return x * x + y * y;
            }
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x + b.x, a.y + b.y);
        }

        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x - b.x, a.y - b.y);
        }

        public static Vector2Int operator *(int a, Vector2Int b)
        {
            return new Vector2Int(a * b.x, a * b.y);
        }

        public static Vector2Int up = new Vector2Int(0, 1);
        public static Vector2Int down = new Vector2Int(0, -1);
        public static Vector2Int left = new Vector2Int(-1, 0);
        public static Vector2Int right = new Vector2Int(1, 0);

        public bool Equals(Vector2Int other) {
            return other.x == x && other.y == y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2Int)
            {
                return Equals((Vector2Int)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Vector2Int a, Vector2Int b)
        {
            if (((object)a) == null || ((object)b) == null)
                return System.Object.Equals(a, b);

            return a.Equals(b);
        }

        public static bool operator !=(Vector2Int a, Vector2Int b)
        {
            if (((object)a) == null || ((object)b) == null)
                return !Object.Equals(a, b);

            return !a.Equals(b);
        }
    }


    public class Vector2
    {
        public float x, y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float magnitude
        {
            get
            {
                return (float)System.Math.Sqrt(x * x + y * y);
            }
        }

        public float sqrMagnitude
        {
            get
            {
                return x * x + y * y;
            }
        }


        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(float a, Vector2 b)
        {
            return new Vector2(a * b.x, a * b.y);
        }

        public static Vector2 up = new Vector2(0, 1);
        public static Vector2 down = new Vector2(0, -1);
        public static Vector2 left = new Vector2(-1, 0);
        public static Vector2 right = new Vector2(1, 0);
    }

    public class Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float magnitude
        {
            get
            {
                return (float)System.Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public float sqrMagnitude
        {
            get
            {
                return (float)x * x + y * y + z * z;
            }
        }


        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator *(float a, Vector3 b)
        {
            return new Vector3(a * b.x, a * b.y, a * b.z);
        }

        public static Vector3 up = new Vector3(0, 1, 0);
        public static Vector3 down = new Vector3(0, -1, 0);
        public static Vector3 left = new Vector3(-1, 0, 0);
        public static Vector3 right = new Vector3(1, 0, 0);
        public static Vector3 forward = new Vector3(0, 0, 1);
        public static Vector3 back = new Vector3(0, 0, -1);
    }

    public static class Time
    {
        public static double realtimeSinceStartupAsDouble
        {
            get
            {
                return System.DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1_000.0;
            }
            // NOTE: these numbers get big!
            // System.DateTimeOffset.Now.ToUnixTimeMilliseconds ~= 2**42
            // while the UnixTime in seconds is roughly 2**32. These estimates hold
            // up more or less until the year 2100.
            // With single precision floats, the resolution of timestamps would
            // roughly be 2**(32-24) = 256 seconds = ~5 minutes. That is bad!
            // With double precision floats, the resolution is roughly
            // 2**(32-53) = 5e-7 seconds = half a microsecond. Good enough!
        }
    }

    public static class Mathf
    {
        //public static System.Func<float, float> Min = System.Math.Min;
        public static float Min(float a, float b)
        {
            return System.Math.Min(a, b);
        }

        public static int Min(int a, int b)
        {
            return System.Math.Min(a, b);
        }

        public static float Max(float a, float b)
        {
            return System.Math.Max(a, b);
        }

        public static int Max(int a, int b)
        {
            return System.Math.Max(a, b);
        }

        public static float Pow(float a, float b)
        {
            return (float)System.Math.Pow(a, b);
        }

        public static float Log(float a, float b=10f)
        {
            return (float)System.Math.Log(a, b);
        }

        public static float Abs(float a)
        {
            return System.Math.Abs(a);
        }

        public static int Abs(int a)
        {
            return System.Math.Abs(a);
        }

        public static float Floor(float a)
        {
            return (float)System.Math.Floor(a);
        }

        public static float Round(float a)
        {
            return (float)System.Math.Round(a);
        }

        public static int RoundToInt(float a)
        {
            return (int)System.Math.Round(a);
        }
    }


    public static class Debug
    {
        static System.IO.StreamWriter logFile;
        static bool initialized = false;

        static void Print(string message)
        {
            string dateTimeString = System.DateTimeOffset.Now.ToString("s");
            string logFileName = $"UnityEngineMockLog_{dateTimeString}.txt";
            string logPath =
                System.IO.Path.Combine(Config.logFolderPath, $"{logFileName}");
            if (!initialized && System.IO.File.Exists(logPath))
            {
                throw new System.Exception($"Log file [{logPath}] already exists!");
            }
            logFile = new System.IO.StreamWriter(logPath, append:initialized);
            initialized = true;
            string prefix = $"[{dateTimeString}] ";
            System.Console.WriteLine(message);
            logFile.WriteLine(prefix + message);
            logFile.Close();
        }

        [System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
        public static void Assert(bool statement, string message=null)
        {
            if (!statement)
            {
                string errorMessage = "Assertion failed";
                if (!string.IsNullOrWhiteSpace(message))
                {
                    errorMessage += ": " + message;
                }
                Print(errorMessage);
            }
        }

        public static void Log(string message)
        {
            Print(message);
        }

        public static void Log(object message)
        {
            Print(message.ToString());
        }
    }


    // HALF FUNCTIONAL FAKES:
    public class TextAsset : GameObject
    {
        public byte[] bytes;

        public TextAsset() { }
        public TextAsset(string path)
        {
            bytes = System.IO.File.ReadAllBytes(path);
        }
    }


    public static class Resources
    {
        public static System.Object Load(string path, System.Type T)
        {
            if (T == typeof(TextAsset))
            {
                return new TextAsset(
                    System.IO.Path.Combine(Config.unityResourcePath,
                    path + ".bytes"));
            }
            return null;
        }
    }

    public static class Application
    {
        // NOTE: make sure these paths exist before using them!
        public static string temporaryCachePath =
            System.IO.Path.Combine(cacheFolderPath, "unityCachePath");
        public static string streamingAssetsPath =
            System.IO.Path.Combine(cacheFolderPath, "unityStreamingPath");
    }


    // NON FUNCTIONAL FAKES:
    // If Unity complains about [ExtensionOfNativeClass] missing, make sure to open
    // a scene that does not contain any of the MonoBehaviors mocked away.

    public class MonoBehaviour : GameObject
    {
        public static void StartCoroutine(string s)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public static void Destroy(GameObject obj)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public static GameObject Instantiate(GameObject obj, Transform transform)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

    }

    public class Object {
    }

    public class Component {
        public bool enabled;
    }

    public class Transform
    {
        public Vector3 position;
        public Quaternion rotation;
        public Transform parent;
    }

    public class RectTransform : Transform
    {
        public Vector2 anchoredPosition;
    }

    public static class RectTransformUtility
    {
        public static void ScreenPointToLocalPointInRectangle(RectTransform rt,
            Vector2 p, GameObject camera, out Vector2 pOut)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }
    }

    public class GameObject
    {
        public bool enabled;
        public Transform transform;
        public GameObject gameObject;

        public T GetComponentInChildren<T>()
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public T GetComponent<T>()
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public T AddComponent<T>()
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public void SetActive(bool b)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public sealed class RequireComponent : System.Attribute
    {
        public System.Type m_Type0;
        public System.Type m_Type1;
        public System.Type m_Type2;

        public RequireComponent(System.Type requiredComponent)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public RequireComponent(System.Type requiredComponent,
            System.Type requiredComponent2)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public RequireComponent(System.Type requiredComponent, 
            System.Type requiredComponent2, System.Type requiredComponent3)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }
    }

    public class Quaternion
    {
        public static Quaternion Euler(float x, float y, float z)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }
    }

    public struct Color
    {
        public float r, g, b, a;
    }

    public class Image : GameObject
    {
        public Color color;
    }

    public class Canvas : GameObject
    {
        public GameObject worldCamera;
    }

    public static class Input
    {
        public static Vector2 mousePosition
        {
            get {
                throw new System.Exception("(should) not (be) implemented!");
            }
        }

        public static bool GetKey(KeyCode k)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public static bool GetKeyUp(KeyCode k)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public static bool GetKeyDown(KeyCode k)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public static bool GetMouseButton(int k)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public static bool GetMouseButtonUp(int k)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

        public static bool GetMouseButtonDown(int k)
        {
            throw new System.Exception("(should) not (be) implemented!");
        }

    }

    public enum KeyCode
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
    }

}  // namespace UnityEngineReplacement
