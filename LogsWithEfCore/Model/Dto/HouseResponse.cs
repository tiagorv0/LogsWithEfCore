using LogsWithEfCore.Model.Enum;

namespace LogsWithEfCore.Model.Dto;

public class HouseResponse
{
    public long Id { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public decimal Value { get; set; }
    public double Front { get; set; }
    public double Length { get; set; }
    public HouseType Type { get; set; }

    public decimal SquareMeterValue => Value / (decimal)SquareMeter;
    public double SquareMeter => Front * Length;
}
