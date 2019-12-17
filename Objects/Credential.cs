namespace Fremtidens_Bil_API.Objects
{
    /// <summary>
    /// Credentials of for the base User.
    /// </summary>
    /// <see cref="Fremtidens_Bil_API.Objects.User"/>
    /// <seealso cref="Fremtidens_Bil_API.Objects.BaseEntity" />
    public class Credential : BaseEntity
    {
        #region Attributes        
        /// <summary>
        /// The mail address
        /// </summary>
        private string mailAddress;

        /// <summary>
        /// The password
        /// </summary>
        private string password;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the mail address.
        /// </summary>
        /// <value>
        /// The mail address.
        /// </value>
        public string MailAddress { get { return mailAddress; } set { mailAddress = value; } }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get { return password; } set { password = value; } }
        #endregion
    }
}
