using Final.model;
using Final.services;

namespace Final.controllers
{
    public class StudentController
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public string GetHasApproved(Estudiante estudiante)
        {
            return _studentService.hasapproved(estudiante) ? "Aprobado" : "Desaprobado";
        }
        public string GetStudentName(Estudiante estudiante)
        {
            return estudiante.Nombre ?? string.Empty;
        }
        public int GetStudentCI(Estudiante estudiante)
        {
            return estudiante.CI;
        }
    }
}