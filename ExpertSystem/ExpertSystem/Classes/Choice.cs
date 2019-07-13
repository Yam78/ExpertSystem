/* Class for chocies related to header.
 * Related to header between headerId and ParentHeaderId
 * 
 * Author: Sami Väisänen
 * Date: 12.7.2019
 */

using System;

namespace ExpertSystem.Classes
{
    class Choice : IRulePart
    {
        #region PROPERTIES

        public Guid ID { get; set; }

        // Reference to header for this choice
        public Guid ParentReference { get; set; }

        public string TextValue { get; set; }

        public Guid SubHeaderID { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// Used only for serialization
        /// </summary>
        public Choice()
        {
        }

        /// <summary>
        /// Constructor with text. 
        /// Used to create choice related to header
        /// </summary>
        /// <param name="headerText"></param>
        public Choice(Guid id, Guid hdrId, string choiceText)
        {
            this.ID = id;
            this.ParentReference = hdrId;
            this.TextValue = choiceText;
        }

        #endregion

        #region METHODS / OVERRIDES

        public override string ToString()
        {
            return this.TextValue;
        }

        #endregion
    }
}