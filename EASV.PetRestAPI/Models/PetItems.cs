using System;
namespace EASV.PetRestAPI.Models
{
    public class PetItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
