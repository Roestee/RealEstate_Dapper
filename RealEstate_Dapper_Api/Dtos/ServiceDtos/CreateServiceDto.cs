namespace RealEstate_Dapper_Api.Dtos.ServiceDtos
{
    public class CreateServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
