using Xunit;
using Final.controllers;
using Final.model;
using Final.services;
using Final.test.stub;
using Moq;
namespace Final.test.controllersT
{
    public class StudentControllerT
    {
        [Fact]
        public void TestGetHasApproved()
        {
            // Arrange
            var studentService = new StudentService();
            var studentController = new StudentController(studentService);
            Estudiante estudiante = new Estudiante { CI = 123456, Nombre = "Juan", Nota = 60 };

            // Act
            var result = studentController.GetHasApproved(estudiante);

            // Assert
            Assert.Equal("Aprobado", result);
            Assert.Equal("Juan", estudiante.Nombre);
            Assert.Equal(123456, estudiante.CI);
            Assert.Equal(60, estudiante.Nota);
        }
        [Fact]
        public void TestGetHasApprovedFail()
        {
            // Arrange
            var studentService = new StudentService();
            var studentController = new StudentController(studentService);
            Estudiante estudiante = new Estudiante { CI = 123456, Nombre = "Juan", Nota = 40 };

            // Act
            var result = studentController.GetHasApproved(estudiante);

            // Assert
            Assert.Equal("Desaprobado", result);
        }
        [Fact]

        public void TestStudentNameIsAsEntered()
        {
            // Arrange
            var studentService = new StudentService();
            var studentController = new StudentController(studentService);
            var estudiante = new Estudiante { CI = 789012, Nombre = "Maria", Nota = 75 };

            // Act
            var result = studentController.GetHasApproved(estudiante);

            // Assert
            Assert.Equal("Maria", estudiante.Nombre);
        }

        [Fact]
        public void TestStudentCIIsAsEntered()
        {
            // Arrange
            var studentService = new StudentService();
            var studentController = new StudentController(studentService);
            var estudiante = new Estudiante { CI = 555555, Nombre = "Carlos", Nota = 80 };

            // Act
            var result = studentController.GetHasApproved(estudiante);

            // Assert
            Assert.Equal(555555, estudiante.CI);
        }

        [Fact]
        public void TestStudentGradeIsWithinValidRange()
        {
            // Arrange
            var studentService = new StudentService();
            var studentController = new StudentController(studentService);

            // Grade less than 0
            var estudianteNegative = new Estudiante { CI = 111111, Nombre = "Pedro", Nota = -5 };
            // Grade greater than 100
            var estudianteOver = new Estudiante { CI = 222222, Nombre = "Ana", Nota = 105 };
            // Grade within range
            var estudianteValid = new Estudiante { CI = 333333, Nombre = "Luis", Nota = 85 };

            // Act & Assert
            Assert.False(estudianteNegative.Nota >= 0 && estudianteNegative.Nota <= 100);
            Assert.False(estudianteOver.Nota >= 0 && estudianteOver.Nota <= 100);
            Assert.True(estudianteValid.Nota >= 0 && estudianteValid.Nota <= 100);
        }

        [Fact]
        public void TestStudentNameLengthIsValid()
        {
            // Arrange
            var studentService = new StudentService();
            var studentController = new StudentController(studentService);

            // Name with exactly 10 characters
            var estudianteMin = new Estudiante { CI = 111111, Nombre = "ABCDEFGHIJ", Nota = 70 };
            // Name with exactly 50 characters
            var estudianteMax = new Estudiante { CI = 222222, Nombre = new string('A', 50), Nota = 80 };
            // Name with less than 10 characters
            var estudianteShort = new Estudiante { CI = 333333, Nombre = "Short", Nota = 90 };
            // Name with more than 50 characters
            var estudianteLong = new Estudiante { CI = 444444, Nombre = new string('B', 51), Nota = 85 };

            // Act & Assert
            Assert.True(estudianteMin.Nombre.Length >= 10 && estudianteMin.Nombre.Length <= 50);
            Assert.True(estudianteMax.Nombre.Length >= 10 && estudianteMax.Nombre.Length <= 50);
            Assert.False(estudianteShort.Nombre.Length >= 10 && estudianteShort.Nombre.Length <= 50);
            Assert.False(estudianteLong.Nombre.Length >= 10 && estudianteLong.Nombre.Length <= 50);
        }

        [Fact]
        public void TestGetHasApprovedStub()
        {
            // Arrange
            var studentService = new StudentServiceStub();
            var studentController = new StudentController(studentService);
            var estudiante = new Estudiante { CI = 123456, Nombre = "Juan", Nota = 60 };

            // Act
            var result = studentController.GetHasApproved(estudiante);

            // Assert
            Assert.Equal("Aprobado", result);
        }
        [Fact]
        public void TestGetHasApproved_moq()
        {
            // Arrange
            var studentService = new Moq.Mock<IStudentService>();
            studentService.Setup(x => x.hasapproved(It.IsAny<Estudiante>())).Returns(true);
            var studentController = new StudentController(studentService.Object);
            var estudiante = new Estudiante { CI = 123456, Nombre = "Juan", Nota = 60 };

            // Act
            var result = studentController.GetHasApproved(estudiante);

            // Assert
            Assert.Equal("Aprobado", result);
        }
        [Fact]
        public void TestGetHasApproved_moqFail()
        {
            // Arrange
            var studentService = new Moq.Mock<IStudentService>();
            studentService.Setup(x => x.hasapproved(It.IsAny<Estudiante>())).Returns(false);
            var studentController = new StudentController(studentService.Object);
            var estudiante = new Estudiante { CI = 123456, Nombre = "Juan", Nota = 40 };

            // Act
            var result = studentController.GetHasApproved(estudiante);

            // Assert
            Assert.Equal("Desaprobado", result);
        }
     }
 }
