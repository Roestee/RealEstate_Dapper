﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository: IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            var query = "insert into WhoWeAreDetail (Title, SubTitle, Description1, Description2) values (@title, @subTitle, @description1, @description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subTitle", createWhoWeAreDetailDto.SubTitle);
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            var query = "Delete from WhoWeAreDetail Where WhoWeAreDetailId =@whoWeAreDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            var query =
                "Update WhoWeAreDetail Set Title=@title, SubTitle=@subTitle, Description1=@description1,Description2=@description2 where WhoWeAreDetailId=@whoWeAreDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@subTitle", updateWhoWeAreDetailDto.SubTitle);
            parameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            var query = "Select * From WhoWeAreDetail";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }
        public async Task<GetByIdWhoWeAreDetalDto> GetWhoWeAreDetailAsync(int id)
        {
            var query = "Select * From WhoWeAreDetail Where WhoWeAreDetailId=@whoWeAreDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("whoWeAreDetailId", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetalDto>(query, parameters);
                return value;
            }
        }
    }
}
