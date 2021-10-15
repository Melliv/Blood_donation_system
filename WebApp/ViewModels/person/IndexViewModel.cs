using System.Collections.Generic;
using DTO.App.V1;

namespace WebApp.ViewModels.person
{
    public class IndexViewModel
    {
        public SearchPerson Person { get; set; } = new();
        public List<Person?> Persons { get; set; } = new ();
    }
}