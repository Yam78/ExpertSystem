/* Class(es) for ruleworld and with basic methods for adding, updating and removing
 * 
 * Autrhor: Sami Väisänen
 * Date: 13.2.2019
 */

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExpertSystem
{
    public class RuleWorld
    {

        #region PROPERTIES

        // List of headers
        public List<Header> Headers { get; set; }

        // List of choices
        public List<Choice> Choices { get; set; }

        // List of conclusions
        public List<Conclusion> Conclusions { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// </summary>
        public RuleWorld()
        {
            // Set values for current rule:
            // Headers, choices to make and 
            Headers = new List<Header>();
            Choices = new List<Choice>();
            Conclusions = new List<Conclusion>();
        }

        #endregion

        #region PUBLIC METHODS

        #region HEADER

        /// <summary>
        /// Add new header
        /// </summary>
        /// <param name="hdrText"></param>
        /// <returns></returns>
        public int AddHeader(string hdrText)
        {
            int retVal = 0;

            try
            {
                if (Headers == null)
                {
                    // List is not initialized, initialize
                    Headers = new List<Header>();
                }

                // Increase header count (new id for header)
                retVal = Headers.Count + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Add header by parameters
            Headers.Add(new Header(Headers.Count + 1, hdrText));

            // Return new id / count
            return retVal;
        }
        
        /// <summary>
        /// Update header text
        /// </summary>
        /// <param name="aHdr">Id for header</param>
        /// <param name="HeaderText"></param>
        public void UpdateHeader(int headerId, string HeaderText)
        {
            if (Headers != null)
            {
                foreach (Header hdr in Headers)
                {
                    // Loop headers and find match by id. When found, replace text from parameters
                    if (hdr.Id == headerId)
                    {
                        hdr.Text = HeaderText;
                        break;
                    }
                }
            }
        }

        #endregion

        #region CHOICE

        /// <summary>
        /// Add new choice
        /// </summary>
        /// <param name="headerId">Id for header</param>
        /// <param name="choiceText">String for choice</param>
        /// <returns></returns>
        public int AddChoice(int headerId, string choiceText)
        {
            int retVal = -1;

            if (Choices == null)
            {
                // Not yet initialized, initialize list
                Choices = new List<Choice>();
            }

            // Set new Id for choice and add new choice to list
            retVal = Choices.Count + 1;
            Choices.Add(new Choice(retVal, headerId, choiceText));

            // Return new Id
            return retVal;
        }

        /// <summary>
        /// Remove choice from list
        /// </summary>
        /// <param name="chcToDelete"></param>
        public void DeleteChoice(Choice chcToDelete)
        {
            if (Choices != null)
            {
                // Remove by instance
                Choices.Remove(chcToDelete);
            }
        }

        /// <summary>
        /// Update choice value
        /// </summary>
        /// <param name="choiceId">Id for choice</param>
        /// <param name="choiceText">Text to be updated</param>
        public void UpdateChoice(int choiceId, string choiceText)
        {
            if (Choices != null)
            {
                // List of choices is initialized
                foreach (Choice chc in Choices)
                {
                    // With matching id, update text
                    if (chc.Id == choiceId)
                    {
                        chc.Text = choiceText;
                        break;
                    }
                    else { }
                }
            }
        }

        #endregion

        #region CONCLUSION

        public int AddConclusion(int choiceId, string conclusionText)
        {
            int retVal = -1;

            if (Conclusions == null)
            {
                Conclusions = new List<Conclusion>();
            }

            retVal = Conclusions.Count + 1;

            Conclusions.Add(new Conclusion(retVal, choiceId, conclusionText));

            return retVal;
        }

        #endregion // Conclusion

        #endregion // Public methods

        #region CLASSES

        /// <summary>
        /// This class if for rule header. It is simple class with ID and Textfield.
        /// Used for presenting headers
        /// </summary>
        public class Header
        {
            [XmlAttribute]
            public int Id { get; set; }
            [XmlAttribute]
            public String Text { get; set; }

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
            public Header(int id, string headerText)
            {
                this.Id = id;
                this.Text = headerText;
            }
        }

        /// <summary>
        /// Class for chocies
        /// </summary>
        public class Choice
        {
            [XmlAttribute]
            public int Id { get; set; }
            [XmlAttribute]
            public int ParentHeaderId { get; set; }
            [XmlAttribute]
            public int SubHeaderId { get; set; }
            [XmlAttribute]
            public String Text { get; set; }

            public Choice()
            {

            }

            /// <summary>
            /// Constructor with text
            /// </summary>
            /// <param name="headerText"></param>
            public Choice(int id, int hdrId, string choiceText)
            {
                this.Id = id;
                this.ParentHeaderId = hdrId;
                this.Text = choiceText;
            }
        }

        /// <summary>
        /// Class for conclusions
        /// </summary>
        public class Conclusion
        {
            [XmlAttribute]
            public int Id { get; set; }

            [XmlAttribute]
            public int ChoiceId { get; set; }

            [XmlAttribute]
            public String Text { get; set; }

            public Conclusion()
            {

            }

            /// <summary>
            /// Constructor with text
            /// </summary>
            /// <param name="headerText"></param>
            public Conclusion(int id, int chcId, string choiceText)
            {
                this.Id = id;
                this.ChoiceId = chcId;
                this.Text = choiceText;
            }
        }

        #endregion 
    }
}
