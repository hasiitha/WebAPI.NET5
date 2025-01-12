﻿namespace ExampleApplication.Models
{
    public class StudentDatabaseSettings : IStudentDatabaseSettings
    {
        public string StudentCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
