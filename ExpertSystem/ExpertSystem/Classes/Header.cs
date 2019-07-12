/* This class if for rule header. It is simple class with ID and Textfield.
*  Used for presenting headers
*  
*  Author: Sami Väisänen
*  Date: 12.7.2019
*/

using System;

namespace ExpertSystem
{
    class Header : IRulePart
    {
        #region PROPERTIES

        public Guid ID { get; set; }

        // NOT USED
        public Guid ParentReference { get; set; }

        public string TextValue { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Generic constructor
        /// </summary>
        public Header()
        {
        }

        /// <summary>
        /// Constructor with text
        /// </summary>
        /// <param name="headerText"></param>
        public Header(Guid id, string headerText)
        {
            this.ID = id;
            this.TextValue = headerText;
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