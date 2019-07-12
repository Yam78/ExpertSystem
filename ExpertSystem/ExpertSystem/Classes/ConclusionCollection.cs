using ExpertSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpertSystem
{
    class ConclusionCollection : IRulePartCollection<Conclusion>
    {

        #region PROPERTIES

        // List of headers
        public List<Conclusion> ConclusionList { get; set; }

        #endregion

        #region CONSTRUCTORS

        public ConclusionCollection()
        {
            ConclusionList = new List<Conclusion>();
        }

        #endregion

        #region METHODS FOR INTERFACE

        /// <summary>
        /// Count of the list items
        /// </summary>
        public int Count => ConclusionList.Count;

        /// <summary>
        /// Add new conclusion for choice
        /// </summary>
        /// <param name="choiceId"></param>
        /// <param name="conclusionText"></param>
        /// <returns></returns>
        public Guid Add(Guid choiceId, string conclusionText)
        {
            Guid retVal = Guid.NewGuid();

            try
            {
                Conclusion conclusionToAdd = new Conclusion(retVal, choiceId, conclusionText);

                // Set new Id for choice and add new choice to list
                ConclusionList.Add(conclusionToAdd);
            }
            catch (Exception)
            {
                // Addition failed -> Throw or return Guid.Empty - not sure yet
                throw;
            }

            // Return new Id
            return retVal;
        }

        /// <summary>
        /// Add new conclusion - Not used, but exists here for Interface - maybe later
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid Add(Conclusion item)
        {
            Guid retVal = item.ID;

            ConclusionList.Add(item);

            return retVal;
        }

        /// <summary>
        /// Remove Conclusion from list by Instance
        /// </summary>
        /// <param name="cncToDelete"></param>
        public bool Remove(Conclusion cncToDelete)
        {
            bool retVal = false;

            try
            {
                // Remove by instance
                retVal = ConclusionList.Remove(cncToDelete);
                retVal = true;
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        /// <summary>
        /// Remove conclusion by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Remove(Guid ID)
        {
            bool retVal = true;

            try
            {
                foreach (Conclusion cnc in ConclusionList)
                {
                    if (cnc.ID == ID)
                    {
                        ConclusionList.Remove(cnc);
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

        #endregion
        
        /// <summary>
        /// Find conclusion by choice
        /// </summary>
        /// <param name="chcId">ID of the choice</param>
        /// <returns></returns>
        public List<Conclusion> GetConclusionsByParentReference(Guid chcId)
        {
            List<Conclusion> retVal = new List<Conclusion>();

            try
            {
                retVal = (from q in ConclusionList where q.ParentReference == chcId select q).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }
    }
}

