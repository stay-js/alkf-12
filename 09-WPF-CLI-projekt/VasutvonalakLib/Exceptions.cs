namespace VasutvonalakLib
{
    public class DataStoreUninitializedException()
        : Exception("DataStore is not initialized. Call DataStore.Initialize() first.")
    { }

    public class DataStoreAlreadyInitializedException()
            : Exception("DataStore is already initialized. Call DataStore.Initialize() only once.")
    { }
}