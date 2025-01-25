namespace Bulky.DataAccess.DBInitializer
{
    /// <summary>
    /// Interface for database initialization.
    /// </summary>
    public interface IDBInitializer
    {
        /// <summary>
        /// Method to initialize the database.
        /// This can be used to apply migrations, seed default data, or perform any necessary setup at application startup.
        /// </summary>
        void Initialize();
    }
}
