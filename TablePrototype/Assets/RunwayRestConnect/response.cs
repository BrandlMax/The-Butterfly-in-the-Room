using System;

namespace Response
{
    [Serializable]
    public class Todo
    {
        public int id;

        public int userId;

        public string title;

        public bool completed;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}