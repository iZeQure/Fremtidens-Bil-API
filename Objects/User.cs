namespace Fremtidens_Bil_API.Objects
{
    /// <summary>
    /// Base of User Entity
    /// </summary>
    /// <seealso cref="Fremtidens_Bil_API.Objects.BaseEntity" />
    public class User : BaseEntity
    {
        #region Attributes        
        /// <summary>
        /// The user name
        /// </summary>
        private string userName;

        /// <summary>
        /// The first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// The finger print identifier
        /// </summary>
        private int fingerPrintId;

        /// <summary>
        /// The heart rate
        /// </summary>
        private int heartRate;

        /// <summary>
        /// The account locked
        /// </summary>
        private bool accountLocked;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get { return userName; } set { userName = value; } }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get { return firstName; } set { firstName = value; } }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get { return lastName; } set { lastName = value; } }

        /// <summary>
        /// Gets or sets the finger print identifier.
        /// </summary>
        /// <value>
        /// The finger print identifier.
        /// </value>
        public int FingerPrintId { get { return fingerPrintId; } set { fingerPrintId = value; } }

        /// <summary>
        /// Gets or sets the heart rate.
        /// </summary>
        /// <value>
        /// The heart rate.
        /// </value>
        public int HeartRate { get { return heartRate; } set { heartRate = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether [account locked].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [account locked]; otherwise, <c>false</c>.
        /// </value>
        public bool AccountLocked { get { return accountLocked; } set { accountLocked = value; } }
        #endregion
    }
}
