using Final.model;
using Final.services;

namespace Final.test.stub
{
    public class StudentServiceStub : IStudentService
    {
        public bool hasapproved(Estudiante estudiante)
        {
            if (estudiante.Nota >= 51)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}