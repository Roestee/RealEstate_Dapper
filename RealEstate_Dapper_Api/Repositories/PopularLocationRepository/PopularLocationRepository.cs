using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository: IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            var query = "Select * From PopularLocation";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async void CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
        {
            var query = "insert into PopularLocation (Title, ImageUrl) values (@title, @imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", popularLocationDto.Title);
            parameters.Add("@imageUrl", popularLocationDto.ImageUrl);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            var query = "Delete from PopularLocation Where PopularLocationId =@popularLocationId";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            var query =
                "Update PopularLocation Set Title=@title, ImageUrl=@imageUrl where PopularLocationId=@popularLocationId";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updatePopularLocationDto.Title);
            parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            parameters.Add("@popularLocationId", updatePopularLocationDto.PopularLocationId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultPopularLocationDto> GetPopularLocation(int id)
        {
            var query = "Select * From PopularLocation Where PopularLocationId=@popularLocationId";
            var parameters = new DynamicParameters();
            parameters.Add("popularLocationId", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultPopularLocationDto>(query, parameters);
                return value;
            }
        }
    }
}
