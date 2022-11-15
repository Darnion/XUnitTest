using FluentAssertions;
using DataGridView_Adm_Com.Models;

namespace XUnitTests
{
    public class XUnitTest
    {
        public MethodsLibrary.Methods Entrants = new MethodsLibrary.Methods();

        public void FillItem(ref Entrant item)
        {
            item.FullName = "Foo";
            item.Gender = Gender.Male;
            item.BirthDate = DateTime.Now.AddYears(-16);
            item.EducationForm = EducationForm.FullTime;
            item.MathExams = 67;
            item.RussianExams = 0;
            item.ITExams = 43;
        }

        public void FillItemAnotherValue(ref Entrant item)
        {
            item.FullName = "Foo";
            item.Gender = Gender.Male;
            item.BirthDate = DateTime.Now.AddYears(-16);
            item.EducationForm = EducationForm.FullTime;
            item.MathExams = 67;
            item.RussianExams = 80;
            item.ITExams = 43;
        }

        [Fact]
        public void AddItem()
        {
            var item = new Entrant();
            FillItem(ref item);

            var checkAdd = Entrants.AddEntrant(item);
            var checkAll = Entrants.GetEntrants();

            checkAdd.Should().Be(item);
            checkAll.Should().HaveCount(1).And.NotBeEmpty();
        }

        [Fact]
        public void EditItem()
        {
            var oldItem = new Entrant();
            FillItem(ref oldItem);
            var newItem = new Entrant();
            FillItemAnotherValue(ref newItem);

            Entrants.AddEntrant(oldItem);

            Entrants.EditEntrant(oldItem, newItem);

            var checkAll = Entrants.GetEntrants();

            checkAll.Should().HaveCount(1).And.NotBeEmpty();
            Assert.Equal(checkAll[0], newItem);
        }

        [Fact]
        public void DeleteItem()
        {
            var item = new Entrant();
            FillItem(ref item);

            Entrants.AddEntrant(item);
            Entrants.DeleteEntrant(item);

            var checkAll = Entrants.GetEntrants();

            checkAll.Should().BeEmpty();
        }

        [Fact]
        public void PassedItems()
        {
            var firstItem = new Entrant();
            FillItem(ref firstItem);

            var secondItem = new Entrant();
            FillItemAnotherValue(ref secondItem);

            Entrants.AddEntrant(firstItem);
            Entrants.AddEntrant(secondItem);

            var checkAll = Entrants.GetEntrants();

            checkAll.Should().HaveCount(2).And.NotBeEmpty();

            var checkPassed = Entrants.GetCountOnlyPassed();

            checkPassed.Should().Be(1);
        }
    }
}
