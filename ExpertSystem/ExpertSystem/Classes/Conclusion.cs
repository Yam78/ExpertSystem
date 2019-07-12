using System;

namespace ExpertSystem.Classes
    {
    /// <summary>
    /// Class for conclusions
    /// </summary>
    class Conclusion : IRulePart
    {
        #region PROPERTIES

        // Key value
        public Guid ID { get; set; }
        
        // Reference to choice in which this conclusion refers
        public Guid ParentReference { get; set; }

        // Value of the conclusion
        public String TextValue { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor for serialization
        /// </summary>
        public Conclusion()
        {
        }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="id">ID for new conclusion</param>
        /// <param name="chcId">Id of the choice this belongs to</param>
        /// <param name="conclusionText">Conclusion</param>
        public Conclusion(Guid id, Guid chcId, string conclusionText)
        {
            this.ID = id;
            this.ParentReference = chcId;
            this.TextValue = conclusionText;
        }


        #endregion

        #region METHODS / OVERRIDES

        /// <summary>
        /// Override: TOSTRING
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.TextValue;
        }

        #endregion
    }
}