using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public class TestimonialRepository: ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            var query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async void CreateTestimonial(CreateTestimonialDto testimonialDto)
        {
            var query = "insert into Testimonial (NameSurname, Title, Comment) values (@nameSurname, @title, @comment)";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", testimonialDto.NameSurname);
            parameters.Add("@title", testimonialDto.Title);
            parameters.Add("@comment", testimonialDto.Comment);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteTestimonial(int id)
        {
            var query = "Delete from Testimonial Where TestimonialId =@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var query =
                "Update Testimonial Set NameSurname=@nameSurname, Title=@title, Comment=@comment where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", updateTestimonialDto.NameSurname);
            parameters.Add("@title", updateTestimonialDto.Title);
            parameters.Add("@comment", updateTestimonialDto.Comment);
            parameters.Add("@testimonialId", updateTestimonialDto.TestimonialId);
            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultTestimonialDto> GetTestimonial(int id)
        {
            var query = "Select * From Testimonial Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("testimonialId", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultTestimonialDto>(query, parameters);
                return value;
            }
        }
    }
}
