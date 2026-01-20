using DTO;

namespace BL
{
    public interface IContactBL
    {
        Task<string> sendEmail(ContactFormDto form);
    }
}