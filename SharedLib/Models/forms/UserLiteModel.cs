////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    public class UserLiteModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public string Email { get; set; }
        public AccessLevelsUsersEnum AccessLevelUser { get; set; }
        public ConfirmationUsersTypesEnum ConfirmationType { get; set; }
        public DateTime CreatedAt { get; set; }        
    }
}
