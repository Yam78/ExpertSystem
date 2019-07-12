/* Class(es) for ruleworld and with basic methods for adding, updating and removing
 * 
 * Autrhor: Sami Väisänen
 * Date: 13.2.2019
 */


namespace ExpertSystem.Classes
{
    class RuleWorld
    {

        #region PROPERTIES

        // Property for storing headers
        public HeaderCollection Headers { get; set; }

        // Property for storing Choices
        public ChoiceCollection Choices { get; set; }

        // Property for storing conclusions
        public ConclusionCollection Conclusions { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// </summary>
        public RuleWorld()
        {
            // Set values for current rule:
            // HeaderCollection, choices to make and 
            Headers = new HeaderCollection();
            Choices = new ChoiceCollection();
            //Conclusions = new ConclusionCollection();
        }

        #endregion

    }
}