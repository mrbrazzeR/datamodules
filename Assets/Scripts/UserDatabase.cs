using System;

namespace Data
{
    public abstract class UserDatabase
    {
        public event EventHandler DataChanged;
        protected void OnDataChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        public abstract string GetDataJson();

        public abstract void SynchronizeData(string data);
    }
}
