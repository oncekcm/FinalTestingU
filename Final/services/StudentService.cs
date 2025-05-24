using Final.model;

namespace Final.services
{
    public class StudentService : IStudentService
    {
        public bool hasapproved(Estudiante estudiante)
        {
            if (estudiante.Nota >= 51 && estudiante.Nota <= 100)
            {
                return true;
            }
            else if (estudiante.Nota >= 0 && estudiante.Nota < 51)
            {
                return false;
            }
            else
            {
                throw new ArgumentException("La nota del estudiante debe estar entre 0 y 100.");
            }
        }
    }
}