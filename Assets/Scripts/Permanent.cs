using GameObjectExtension;
using UnityEngine;

/// <summary>
/// 永続 GameObject としての親クラス
/// </summary>
public class Permanent : MonoBehaviour {

    /// <summary>
    /// Permanent インスタンスの実体
    /// </summary>
    private static Permanent instance;

    /// <summary>
    /// Permanent インスタンス
    /// </summary>
    public static Permanent Instance {
        get {
            if (instance == default(Permanent)) {
                instance = Install();
            }
            return instance;
        }
        private set {
            instance = value;
        }
    }

    /// <summary>
    /// Unity lifecycle: Awake
    /// </summary>
    /// <remarks>Singleton 化のために、既にインスタンスが存在していたら自殺</remarks>
    private void Awake() {
        if (FindObjectOfType<Permanent>() != null && FindObjectOfType<Permanent>().gameObject != this.gameObject) {
            Destroy(this);
        } else {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
    }

    /// <summary>
    /// Permanent クラスを Hierarchy に生やす
    /// </summary>
    /// <returns>生やした Permanent クラスのインスタンス</returns>
    public static Permanent Install() {
        GameObject go = FindObjectOfType<Permanent>() != null ? FindObjectOfType<Permanent>().gameObject : new GameObject(typeof(Permanent).Name);
        return go.GetOrAddComponent<Permanent>();
    }

    /// <summary>
    /// Permanent 配下の要素としてコンポーネントを生成する
    /// </summary>
    /// <param name="component">追加するコンポーネント</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>追加したインスタンス</returns>
    public static T Add<T>(T component = null) where T : MonoBehaviour {
        GameObject go = (component != null ? component.gameObject : new GameObject(typeof(T).Name));
        go.transform.SetParent(Instance.transform);
        // component 引数が渡された場合は、既に追加されているであろうことを期待して GetOrAddComponent を用いる
        return go.GetOrAddComponent<T>();
    }

}