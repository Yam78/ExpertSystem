/* Class for launching different kind of inputboxes
 * 
 * Author: Sami Väisänen
 * Date: 13.2.2019
 */
 
using System;
using System.Windows.Forms;

namespace ExpertSystem
{
    static class DialogHelper
    {
        /// <summary>
        /// Open Yes/No dialog
        /// </summary>
        /// <param name="hdr">Header for box</param>
        /// <returns></returns>
        public static DialogResult DialogYesNo(string hdr)
        {
            // Declare return value
            DialogResult retVal = DialogResult.OK;

            try
            {
                // Declare form, open it and get returnvalue
                FrmInput YesNo = new FrmInput(hdr, false, "", DialogResult.None, "Kyllä", DialogResult.Yes, "Ei", DialogResult.No);
                retVal = YesNo.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        /// <summary>
        /// Open Ok/Cancel dialog
        /// </summary>
        /// <param name="hdr"></param>
        /// <returns></returns>
        public static DialogResult DialogOkCancel(string hdr)
        {
            // Declare return value
            DialogResult retVal = DialogResult.OK;

            try
            {
                // Declare dialog, open it and retrieve return value
                FrmInput OkCancel = new FrmInput(hdr, false, "", DialogResult.None, "Hyväksy", DialogResult.OK, "Peruuta", DialogResult.Cancel);
                retVal = OkCancel.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        /// <summary>
        /// Inputbox for getting user input
        /// </summary>
        /// <param name="hdr"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static String InputBox(string hdr, string defaultValue="")
        {
            // Declare return value
            String retVal = null;

            try
            {
                // Declare dialog, open it and get retrun value
                FrmInput inputBox = new FrmInput(hdr, true, "", DialogResult.None, "Hyväksy", DialogResult.OK, "Peruuta", DialogResult.Cancel, defaultValue);
                DialogResult dr = inputBox.ShowDialog();
                if (dr == DialogResult.OK )
                {
                    retVal = inputBox.GetValue();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }
    }
}
