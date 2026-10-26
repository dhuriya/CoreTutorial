using StudentManagementFile.API.Models;
using StudentManagementFile.API.Services;

namespace StudentManagementFile.API.Tests
{
    public class StudentServiceTests : IDisposable
    {
        private readonly string _testFileName;
        private readonly string _testFilePath;
        private readonly StudentService _service;

        public StudentServiceTests()
        {
            // Har test ke liye unique file — parallel tests mein conflict na ho
            _testFileName = $"test_students_{Guid.NewGuid()}.json";
            _testFilePath = Path.Combine(Directory.GetCurrentDirectory(), _testFileName);
            _service = new StudentService(_testFileName);
        }

        public void Dispose()
        {
            // Test ke baad file delete karein
            if (File.Exists(_testFilePath))
                File.Delete(_testFilePath);
        }

        // ─────────────────────────────────────────────
        // ADD TESTS
        // ─────────────────────────────────────────────

        [Fact]
        public void Add_ShouldAssignIdStartingFromOne()
        {
            var student = new Student { Name = "Aarav", Email = "a@x.com", Age = 20, Course = "B.Tech" };

            var created = _service.Add(student);

            Assert.Equal(1, created.Id);
        }

        [Fact]
        public void Add_ShouldAssignIncrementalIds()
        {
            var s1 = _service.Add(new Student { Name = "A", Email = "a@x.com", Age = 20, Course = "C1" });
            var s2 = _service.Add(new Student { Name = "B", Email = "b@x.com", Age = 21, Course = "C2" });
            var s3 = _service.Add(new Student { Name = "C", Email = "c@x.com", Age = 22, Course = "C3" });

            Assert.Equal(1, s1.Id);
            Assert.Equal(2, s2.Id);
            Assert.Equal(3, s3.Id);
        }

        [Fact]
        public void Add_ShouldPersistToFile()
        {
            _service.Add(new Student { Name = "Aarav", Email = "a@x.com", Age = 20, Course = "B.Tech" });

            // Nayi service instance same file se padhe
            var freshService = new StudentService(_testFileName);
            var all = freshService.GetAll();

            Assert.Single(all);
            Assert.Equal("Aarav", all[0].Name);
        }

        // ─────────────────────────────────────────────
        // GET TESTS
        // ─────────────────────────────────────────────

        [Fact]
        public void GetAll_EmptyFile_ReturnsEmptyList()
        {
            var result = _service.GetAll();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsStudent()
        {
            var created = _service.Add(new Student { Name = "Aarav", Email = "a@x.com", Age = 20, Course = "B.Tech" });

            var found = _service.GetById(created.Id);

            Assert.NotNull(found);
            Assert.Equal("Aarav", found.Name);
        }

        [Fact]
        public void GetById_NonExistingId_ReturnsNull()
        {
            var found = _service.GetById(999);

            Assert.Null(found);
        }

        // ─────────────────────────────────────────────
        // UPDATE TESTS
        // ─────────────────────────────────────────────

        [Fact]
        public void Update_ExistingStudent_UpdatesFields()
        {
            var created = _service.Add(new Student { Name = "Old", Email = "old@x.com", Age = 20, Course = "OldCourse" });

            var updated = new Student { Name = "New", Email = "new@x.com", Age = 25, Course = "NewCourse" };
            var success = _service.Update(created.Id, updated);

            Assert.True(success);
            var found = _service.GetById(created.Id);
            Assert.Equal("New", found!.Name);
            Assert.Equal(25, found.Age);
        }

        [Fact]
        public void Update_NonExistingId_ReturnsFalse()
        {
            var success = _service.Update(999, new Student { Name = "X", Email = "x@x.com", Age = 20, Course = "C" });

            Assert.False(success);
        }

        // ─────────────────────────────────────────────
        // DELETE TESTS
        // ─────────────────────────────────────────────

        [Fact]
        public void Delete_ExistingId_RemovesStudent()
        {
            var created = _service.Add(new Student { Name = "Aarav", Email = "a@x.com", Age = 20, Course = "B.Tech" });

            var success = _service.Delete(created.Id);

            Assert.True(success);
            Assert.Null(_service.GetById(created.Id));
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsFalse()
        {
            var success = _service.Delete(999);

            Assert.False(success);
        }

        // ─────────────────────────────────────────────
        // FILTER / PAGINATION TESTS
        // ─────────────────────────────────────────────

        [Fact]
        public void GetFiltered_BySearch_ReturnsMatchingStudents()
        {
            _service.Add(new Student { Name = "Aarav Sharma", Email = "aarav@x.com", Age = 20, Course = "B.Tech" });
            _service.Add(new Student { Name = "Priya Verma", Email = "priya@x.com", Age = 21, Course = "B.Tech" });

            var result = _service.GetFiltered(new StudentQueryParameters { Search = "aarav" });

            Assert.Equal(1, result.TotalCount);
            Assert.Equal("Aarav Sharma", result.Items[0].Name);
        }

        [Fact]
        public void GetFiltered_ByCourse_ReturnsOnlyThatCourse()
        {
            _service.Add(new Student { Name = "A", Email = "a@x.com", Age = 20, Course = "B.Tech" });
            _service.Add(new Student { Name = "B", Email = "b@x.com", Age = 21, Course = "BBA" });

            var result = _service.GetFiltered(new StudentQueryParameters { Course = "B.Tech" });

            Assert.Equal(1, result.TotalCount);
            Assert.Equal("B.Tech", result.Items[0].Course);
        }

        [Fact]
        public void GetFiltered_Pagination_ReturnsCorrectPage()
        {
            for (int i = 1; i <= 15; i++)
                _service.Add(new Student { Name = $"Student {i}", Email = $"s{i}@x.com", Age = 20, Course = "B.Tech" });

            var page1 = _service.GetFiltered(new StudentQueryParameters { Page = 1, PageSize = 5 });
            var page3 = _service.GetFiltered(new StudentQueryParameters { Page = 3, PageSize = 5 });

            Assert.Equal(15, page1.TotalCount);
            Assert.Equal(5, page1.Items.Count);
            Assert.Equal(3, page1.TotalPages);
            Assert.True(page1.HasNextPage);
            Assert.False(page1.HasPreviousPage);

            Assert.Equal(5, page3.Items.Count);
            Assert.False(page3.HasNextPage);
            Assert.True(page3.HasPreviousPage);
        }

        [Fact]
        public void GetFiltered_SortByAgeDescending_ReturnsSorted()
        {
            _service.Add(new Student { Name = "A", Email = "a@x.com", Age = 18, Course = "C" });
            _service.Add(new Student { Name = "B", Email = "b@x.com", Age = 25, Course = "C" });
            _service.Add(new Student { Name = "C", Email = "c@x.com", Age = 20, Course = "C" });

            var result = _service.GetFiltered(new StudentQueryParameters { SortBy = "age", SortOrder = "desc" });

            Assert.Equal(25, result.Items[0].Age);
            Assert.Equal(20, result.Items[1].Age);
            Assert.Equal(18, result.Items[2].Age);
        }

        // ─────────────────────────────────────────────
        // CONCURRENCY TEST (bonus — impress karne ke liye)
        // ─────────────────────────────────────────────

        [Fact]
        public void Add_ConcurrentCalls_AssignsUniqueIds()
        {
            Parallel.For(0, 50, i =>
            {
                _service.Add(new Student { Name = $"S{i}", Email = $"s{i}@x.com", Age = 20, Course = "C" });
            });

            var all = _service.GetAll();
            Assert.Equal(50, all.Count);
            Assert.Equal(50, all.Select(s => s.Id).Distinct().Count());  // sab IDs unique
        }
    }
}