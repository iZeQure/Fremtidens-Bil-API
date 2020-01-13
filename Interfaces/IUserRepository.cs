using Fremtidens_Bil_API.Models;
using Fremtidens_Bil_API.Objects;

namespace Fremtidens_Bil_API.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        /**
         * Old Methods.
         */
        //bool CheckUserExists(User user);
        //bool CheckMailExists(Credential credential);
        //bool AuthenticateCredentials(User user);
        //bool AuthenticateAccount(Credential credential);
        /* END */

        #region User Region
        bool Authenticate_LoginCredentials(User user);

        bool Authenticate_AccountLock(User user);

        void Authenticate_DisableAccount(User user);

        bool Check_EmailAddressExists(User user);

        bool Check_CPRNumberExists(User user);

        User Return_HeartBeatFromUserId(User user);

        User Return_FingerPrintIdFromUserId(User user);

        User Return_UserCredentialIdFromMailAddress(User user);

        User Return_UserInformationByMailAddress(User user);

        void Update_HeartBeatFromFingerPrintId(User user);
        #endregion
    }
}