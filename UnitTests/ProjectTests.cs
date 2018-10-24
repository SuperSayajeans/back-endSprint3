using NUnit.Framework;
using Kanban.Domain;
using Kanban.DatabaseModels;
using Moq;
using Kanban.Infrastructure;

namespace Kanban.UnitTests
{
    [TestFixture]
    public class ProjectTests
    {

        private ProjectDomain domain;
        private Mock<IUnitOfWork> unitOfWork;
        private Project project;

        [SetUp]
        public void SetDomain()
        {
            domain = new ProjectDomain();
            unitOfWork = new Mock<IUnitOfWork>();
            domain.unitOfWork = unitOfWork.Object;
            project = new Project();
            project.Name = "Teste";
            project.NOfMembers = 4;
            project.PO = 3;
            project.Master = 4;
            unitOfWork.Setup(x => x.Projects.Get(1)).Returns(project);
        }

        [Test]
        public void GetMustAccesBank()
        {
            domain.GetProjectById(1);

            unitOfWork.Verify(x => x.Projects.Get(1), Times.Once());

        }

        [Test]
        public void PostMustUpdateAndComplete()
        {
            domain.UpdateProjectById(1, "Alteração");

            unitOfWork.Verify(x => x.Projects.Get(1), Times.Once());
            unitOfWork.Verify(x => x.Complete(), Times.Once());
            Assert.AreEqual(project.Name, "Alteração");
        }

        [Test]
        public void PostMustAddTask()
        {
            domain.AddProject(this.project);

            unitOfWork.Verify(x => x.Projects.Add(project), Times.Once());
            unitOfWork.Verify(x => x.Complete(), Times.Once());
        }

        [Test]
        public void DeleteMustRemoveTask()
        {
            domain.DeleteProjectById(1);

            unitOfWork.Verify(x => x.Projects.Get(1), Times.Once());
            unitOfWork.Verify(x => x.Projects.Remove(project), Times.Once());
            unitOfWork.Verify(x => x.Complete(), Times.Once());
        }
    }
}