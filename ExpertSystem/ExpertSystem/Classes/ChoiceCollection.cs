using ExpertSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpertSystem
{
    class ChoiceCollection : IRulePartCollection<Choice>
    {
        #region PROPERTIES

        // List of choices
        public List<Choice> ChoiceList { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChoiceCollection()
        {
            ChoiceList = new List<Choice>();
        }

        #endregion

        #region METHODS FOR INTERFACE

        /// <summary>
        /// Count of the items in the list
        /// </summary>
        public int Count => ChoiceList.Count;

        /// <summary>
        /// Add new choice
        /// </summary>
        /// <param name="headerId">Id for header</param>
        /// <param name="choiceText">String for choice</param>
        /// <returns></returns>
        public Guid Add(Guid headerId, string choiceText)
        {
            Guid retVal = Guid.NewGuid();

            try
            {
                // Set new Id for choice and add new choice to list
                Choice choiceToAdd = new Choice(retVal, headerId, choiceText);
                ChoiceList.Add(choiceToAdd);
            }
            catch (Exception)
            {
                throw;
            }

            // Return new Id
            return retVal;
        }

        public Guid Add(Choice item)
        {
            Guid retVal = item.ID;

            ChoiceList.Add(item);

            return retVal;
        }

        /// <summary>
        /// Remove choice from list by Instance
        /// </summary>
        /// <param name="chcToDelete"></param>
        public bool Remove(Choice chcToDelete)
        {
            bool retVal = false;

            if (ChoiceList != null)
            {
                // Remove by instance
                retVal = ChoiceList.Remove(chcToDelete);
                retVal = true;
            }

            return retVal;
        }

        /// <summary>
        /// Remove Choice by ChoiceID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Remove(Guid ID)
        {
            bool retVal = true;

            try
            {
                foreach (Choice chc in ChoiceList)
                {
                    if (chc.ID == ID)
                    {
                        ChoiceList.Remove(chc);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        /// <summary>
        /// Update choice value
        /// </summary>
        /// <param name="choiceId">Id for choice</param>
        /// <param name="choiceText">TextValue to be updated</param>
        public void UpdateChoice(Guid choiceId, string choiceText)
        {
            if (ChoiceList != null)
            {
                // List of choices is initialized
                foreach (Choice chc in ChoiceList)
                {
                    // With matching id, update text
                    if (chc.ID == choiceId)
                    {
                        chc.TextValue = choiceText;
                        break;
                    }
                    else { }
                }
            }
        }

        #endregion

        public List<Choice> GetChoicesByParentReference(Guid hdrId)
        {
            List<Choice> retVal = new List<Choice>();

            try
            {
                retVal = (from q in ChoiceList where q.ParentReference == hdrId select q).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        /// <summary>
        /// Get previous header in hierarchy by current header.
        /// Seeks choices where current header is as sub, so mathes must belong to header that is upper in hierarchy.
        /// </summary>
        /// <param name="currentHeaderID"></param>
        /// <returns></returns>
        public Guid GetParentHeader(Guid currentHeaderID)
        {
            Guid retVal = Guid.Empty;

            try
            {
            // Get parent header by finding match from choices where current header ID is as SubHeader
            retVal = (from Choice chc in ChoiceList
                         where chc.SubHeaderID == currentHeaderID
                         select chc.ParentReference).FirstOrDefault();
            }
            catch (Exception)
            {
                // Return GUID.Empty as return value as no parent found
            }

            return retVal;
        }
    }
}

