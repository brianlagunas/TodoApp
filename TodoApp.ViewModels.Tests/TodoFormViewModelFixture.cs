using System.Linq;
using TodoApp.ViewModels.Tests.Mocks;
using Xunit;

namespace TodoApp.ViewModels.Tests
{
    public class TodoFormViewModelFixture
    {
        public TodoFormViewModelFixture()
        {

        }

        [Fact]
        public void WhenAddTodoItemCommandIsInvokedTodoItemIsAdded()
        {
            var sut = new TodoViewModel(new TodoServiceMock());

            Assert.Null(sut.Items);

            sut.TodoText = "New Item";
            sut.AddTodoItemCommand.Execute();

            Assert.Equal(1, sut.Items.Count());
        }

        [Fact]
        public void WhenAddTodoItemCommandIsInvokedTodoTextIsNull()
        {
            var sut = new TodoViewModel(new TodoServiceMock());
            sut.TodoText = "New Item";
            sut.AddTodoItemCommand.Execute();

            Assert.Null(sut.TodoText);
        }

        [Fact]
        public void WhenTodoTextPropertyIsNullAddTodoItemCommandCanExecuteIsFalse()
        {
            var sut = new TodoViewModel(new TodoServiceMock());
            sut.TodoText = null;

            Assert.False(sut.AddTodoItemCommand.CanExecute());
        }

        [Fact]
        public void WhenTodoTextPropertyIsNotNullAddTodoItemCommandCanExecuteIsTrue()
        {
            var sut = new TodoViewModel(new TodoServiceMock());
            sut.TodoText = "New Item";

            Assert.True(sut.AddTodoItemCommand.CanExecute());
        }

        [Fact]
        public void WhenAddTodoItemCommandIsInvokedItemsPropertyChangedIsRaised()
        {
            var sut = new TodoViewModel(new TodoServiceMock());
            sut.TodoText = "NewItem";

            Assert.PropertyChanged(sut, "Items", () => sut.AddTodoItemCommand.Execute());
        }

        [Fact]
        public void WhenRefreshCommandIsInvokedItemsPropertyIsSet()
        {
            var sut = new TodoViewModel(new TodoServiceMock());

            Assert.Null(sut.Items);

            sut.RefreshCommand.Execute();

            Assert.NotNull(sut.Items);
        }

        [Fact]
        public void WhenRefreshCommandIsInvokedItemsPropertyChangedIsRaised()
        {
            var sut = new TodoViewModel(new TodoServiceMock());            

            Assert.PropertyChanged(sut, "Items", () => sut.RefreshCommand.Execute());
        }

        [Fact]
        public void WhenRefreshCommandIsInvokedItemsIsRefreshingIsTrue()
        {
            var sut = new TodoViewModel(new TodoServiceMock());

            Assert.False(sut.IsRefreshing);
            Assert.PropertyChanged(sut, "IsRefreshing", () => sut.RefreshCommand.Execute());
        }

        [Fact]
        public void WhenCompleteTodoItemCommandIsInvokedTodoItemCompletedPropertyIsTrue()
        {
            var sut = new TodoViewModel(new TodoServiceMock());
            sut.TodoText = "New Item";
            sut.AddTodoItemCommand.Execute();
            var item = sut.Items.First();

            Assert.False(item.Completed);

            sut.CompleteTodoItemCommand.Execute(item);

            Assert.True(item.Completed);            
        }
    }
}
