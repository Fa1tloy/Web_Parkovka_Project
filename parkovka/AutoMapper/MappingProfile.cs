using AutoMapper;
using Web_Parkovka_Project.DTOs.Auth;
using Web_Parkovka_Project.DTOs.User;
using Web_Parkovka_Project.Model;
namespace Web_Parkovka_Project.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Регистрация преобразований DTO <-> Модель
            CreateMap<RegisterDTO, User>();
            CreateMap<User, UserResponseDTO>();
        }
    }
}
