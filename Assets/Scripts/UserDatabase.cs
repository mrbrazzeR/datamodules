namespace Data
{
    public abstract class UserDatabase
    {
        protected abstract void Save();
        protected abstract void Load();

        public abstract string GetDataJson();

        public abstract void SynchronizeData(string data);
    }
}
