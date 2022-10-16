﻿using ExampleApplication.Models;
using ExampleApplication.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

       public StudentController(IStudentService studentService) {
            this.studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return studentService.Get();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = studentService.Get(id);
            if (student == null) {
                return NotFound($"Student with id = {id} not found");
            }
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            studentService.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingstudent = studentService.Get(id);
            if (existingstudent == null) {
                return NotFound($"Student with id = {id} not found");
            }
            studentService.Update(id,student);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = studentService.Get(id);
            if (student == null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            studentService.Remove(student.Id);
            return Ok($"Student with id = {id} deleted");
        }
    }
}
