using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            var query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async void CreateService(CreateServiceDto serviceDto)
        {
            var query = "insert into Service (ServiceName, ServiceStatus) values (@serviceName, @serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", serviceDto.ServiceName);
            parameters.Add("@serviceStatus", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteService(int id)
        {
            var query = "Delete from Service Where ServiceId =@serviceId";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateService(UpdateServiceDto updateServiceDto)
        {
            var query =
                "Update Service Set ServiceName=@serviceName, ServiceStatus=@serviceStatus where ServiceId=@serviceId";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", updateServiceDto.ServiceName);
            parameters.Add("@serviceStatus", updateServiceDto.ServiceStatus);
            parameters.Add("@serviceId", updateServiceDto.ServiceId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultServiceDto> GetService(int id)
        {
            var query = "Select * From Service Where ServiceId=@serviceId";
            var parameters = new DynamicParameters();
            parameters.Add("serviceId", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultServiceDto>(query, parameters);
                return value;
            }
        }
    }
}
