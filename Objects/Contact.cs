namespace Fremtidens_Bil_API.Objects
{
    /// <summary>
    /// Contact information of the base User
    /// </summary>
    /// <see cref="Fremtidens_Bil_API.Objects.User"/>
    /// <seealso cref="Fremtidens_Bil_API.Objects.BaseEntity" />
    public class Contact : BaseEntity
    {
        #region Attributes        
        /// <summary>
        /// The phone number
        /// </summary>
        private string phoneNumber;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        #endregion
    }
}
