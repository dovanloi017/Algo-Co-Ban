public static List<T> BuildListFromString<T>(string values, char split = '|')
    {
        List<T> list = new List<T>();
        if (string.IsNullOrEmpty(values))
            return list;

        string[] arr = values.Split(split);
        foreach (string value in arr)
        {
            if (string.IsNullOrEmpty(value)) continue;
            T val = (T)Convert.ChangeType(value, typeof(T));
            list.Add(val);
        }
        return list;
    }
  public static void CheckDisconnection(MonoBehaviour behaviour, Action onDisconnected)
    {
        behaviour.StartCoroutine(ConnectUrl("http://www.google.com", onDisconnected));
    }
 private static IEnumerator ConnectUrl(string url, Action onDisconnected)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error != null)
        {
            yield return new WaitForSeconds(2f);
            www = new WWW(url);
            yield return www;

            if (www.error != null)
                onDisconnected();
        }
    }
