using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLearn.Models
{
    public class SomeOtherService
    {
        private readonly IStudentRepository? _repository = null;
        public SomeOtherService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public void SomeMethod()
        {
            
        }
    }
}