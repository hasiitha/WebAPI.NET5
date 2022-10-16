﻿using ExampleApplication.Models;
using MongoDB.Driver;

namespace ExampleApplication.Service;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _students;

    public StudentService(IStudentDatabaseSettings settings,IMongoClient mongoClient) {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _students = database.GetCollection<Student>(settings.StudentCollectionName);
    
    }
    public Student Create(Student student)
    {
        _students.InsertOne(student);
        return student;
    }

    public List<Student> Get()
    {
       return _students.Find(student => true).ToList();
    }

    public Student Get(string id)
    {
        return _students.Find(student => student.Id == id).FirstOrDefault();
    }

    public void Remove(string id)
    {
       _students.DeleteOne(student=>student.Id == id);
    }

    public void Update(string id,Student student)
    {
        _students.ReplaceOne(stu => stu.Id == id, student);
    }
}
