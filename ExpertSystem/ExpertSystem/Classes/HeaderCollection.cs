using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpertSystem.Classes
{
    class HeaderCollection : IRulePartCollection<Header>
    {
        #region PROPERTIES

        // List of headers
        public List<Header> HeaderList { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// </summary>
        public HeaderCollection()
        {
            // Initialize list
            HeaderList = new List<Header>();
        }

        #endregion

        #region INTERFACE METHODS

        /// <summary>
        /// Get count of the list
        /// </summary>
        public int Count => HeaderList.Count;

        /// <summary>
        /// Add new header by string
        /// </summary>
        /// <param name="hdrText"></param>
        /// <returns></returns>
        public Guid Add(string hdrText)
        {
            Guid retVal = Guid.Empty;

            try
            {
                // Create new header for adding
                Header hdr = new Header(Guid.NewGuid(), hdrText);
                HeaderList.Add(hdr);
                retVal = hdr.ID;
            }
            catch (Exception)
            {
                // Just return -1 as id...
            }

            // Return new id
            return retVal;
        }

        /// <summary>
        /// Method for adding new header by instance.
        /// Should not be used unless headerId is ok!
        /// </summary>
        /// <param name="hdr">Header object to add</param>
        /// <returns></returns>
        public Guid Add(Header hdr)
        {
            Guid  retVal = Guid.Empty ;

            try
            {
                // Add new header to list. NOTE! ID must be set correctly!
                retVal = hdr.ID;
                HeaderList.Add(hdr);
            }
            catch (Exception)
            {
                // Just return -1 as addition failed
            }

            return retVal;
        }

        /// <summary>
        /// Remove header from headers by instance.
        /// </summary>
        /// <param name="hdr">Header to remove</param>
        /// <returns>True = Removed, False = Failed to remove</returns>
        public bool Remove(Header hdr)
        {
            bool retVal = true;

            try
            {
                HeaderList.Remove(hdr);
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// Removes header from headers by headerId
        /// </summary>
        /// <param name="hdrId">ID of the header</param>
        /// <returns>True = Removed, False = Failed to remove</returns>
        public bool Remove(Guid hdrId)
        {
            bool retVal = true;

            try
            {
                Header hdr = (from q in HeaderList where q.ID == hdrId select q).FirstOrDefault();
                Remove(hdr);
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// Update header value by ID
        /// </summary>
        /// <param name="hdrId"></param>
        /// <param name="newText"></param>
        /// <returns></returns>
        public bool Update(Guid hdrId, string newText)
        {
            bool retVal = false;

            foreach (Header hdr in HeaderList)
            {
                if (hdr.ID == hdrId)
                {
                    hdr.TextValue = newText;
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        #endregion

        public Header GetHeader(Guid hdrId)
        {
            Header retVal = null;

            // Loop headers and compare ID
            foreach (Header hdr in HeaderList)
            {
                if (hdr.ID == hdrId)
                {
                    retVal = hdr;
                }
            }

            return retVal;
        }



    }
}