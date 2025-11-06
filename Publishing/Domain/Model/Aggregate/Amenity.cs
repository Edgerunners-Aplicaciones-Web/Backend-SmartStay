namespace ACME.LearningCenterPlatform.API;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

public class Amenity
{   

    public Amenity()
    {
        Name = string.Empty;
    }


    public Amenity(string name)
    {
        Name = name;
    }

    public Amenity(CreateAmenityCommand command)
    {
        Name = command.Name;
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<PropertyAmenity> PropertyAmenities { get; set; } = new List<PropertyAmenity>();
}