using NUnit.Framework;
using Kanban.Domain;
using Kanban.DatabaseModels;
using Moq;
using Kanban.Infrastructure;

namespace Kanban.UnitTests
{
    [TestFixture]
    public class TaskTests
    {

        private TaskDomain domain;
        private Mock<IUnitOfWork> unitOfWork;
        private Task task;

        [SetUp]
        public void SetDomain()
        {
            domain = new TaskDomain();
            unitOfWork = new Mock<IUnitOfWork>();
            domain.unitOfWork = unitOfWork.Object;
            task = new Task();
            task.Description = "Teste";
            task.Hours = 4;
            task.ProjectId = 3;
            task.SprintId = 2;
            task.TaskId = 1;
            task.Tracking = 5;
            task.UserId = 6;
            unitOfWork.Setup(x => x.Tasks.Get(1)).Returns(task);
        }
    
        [Test]
        public void GetMustAccesBank()
        {
            domain.GetTaskById(1);

            unitOfWork.Verify(x => x.Tasks.Get(1), Times.Once());

        }

        [Test]
        public void PostMustUpdateAndComplete()
        {
            domain.UpdateTaskById(1, "Alteração");

            unitOfWork.Verify(x => x.Tasks.Get(1), Times.Once());
            unitOfWork.Verify(x => x.Complete(), Times.Once());
            Assert.AreEqual(task.Description, "Alteração");
        }

        [Test]
        public void PostMustAddTask()
        {
            domain.AddTask(this.task);

            unitOfWork.Verify(x => x.Tasks.Add(task), Times.Once());
            unitOfWork.Verify(x => x.Complete(), Times.Once());
        }

        [Test]
        public void DeleteMustRemoveTask()
        {
            domain.DeleteTaskById(1);

            unitOfWork.Verify(x => x.Tasks.Get(1), Times.Once());
            unitOfWork.Verify(x => x.Tasks.Remove(task), Times.Once());
            unitOfWork.Verify(x => x.Complete(), Times.Once());
        }
    }
}