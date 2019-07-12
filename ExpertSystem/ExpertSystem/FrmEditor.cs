/* Main class for expert system
 * 
 * Author: Sami Väisänen
 * Date: 13.2.2019 
 */
using ExpertSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ExpertSystem
{
    public partial class FrmEditor : Form
    {

        #region PROPERTIES

        // Property for rules
        RuleWorld Rules { get; set; }

        // Property for storing selected header
        public Guid CurrentHeaderId { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrmEditor()
        {
            InitializeComponent();
            CurrentHeaderId = Guid.Empty;

            // No rules, create instance of rules
            Rules = new RuleWorld();
        }

        #endregion

        #region FORM EVENTS

        /// <summary>
        /// LOAD event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditor_Load(object sender, EventArgs e)
        {
            // Initialize columns
            lvChoices.Columns.Add("Choice");
            lvChoices.Columns[0].Width = lvChoices.Width - 20;

            lvConclusions.Columns.Add("Conclusion");
            lvConclusions.Columns[0].Width = lvConclusions.Width - 20;
        }

        #endregion

        #region HEADER EVENTS

        /// <summary>
        /// Leaving header creates new header if none yet available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbHeader_Leave(object sender, EventArgs e)
        {
            // Check if rules are initialized
            if (Rules.Headers.Count == 0)
            {
                CurrentHeaderId = Rules.Headers.Add(tbHeader.Text);
            }
            else
            {
                // Rule exists, If leave, update text
                Rules.Headers.Update(CurrentHeaderId, tbHeader.Text);
            }
        }

        /// <summary>
        /// Move to upper level in decision tree if possible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToParent_Click(object sender, EventArgs e)
        {
            Guid tmpCurHdr = Guid.Empty;

            try
            {
                // Get header by subheader id
                tmpCurHdr = Rules.Choices.GetParentHeader(CurrentHeaderId);

                if (tmpCurHdr != Guid.Empty)
                {
                    // Header for parent rule found, set it as current header
                    CurrentHeaderId = tmpCurHdr;
                    UpDateView(true, true, true);
                }
                else
                {
                    MessageBox.Show("Ylempää tasoa ei ole.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ylempää tasoa ei ole tai tuli virhe.");
                return;
            }
        }

        #endregion

        #region CHOICE EVENTS

        /// <summary>
        /// Add new choice event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddChoice_Click(object sender, EventArgs e)
        {
            if (CurrentHeaderId == null || CurrentHeaderId == Guid.Empty)
            {
                MessageBox.Show("Syötä ensin otsikko/kysymys!");
                return;
            }

            // Get user response
            string response = DialogHelper.InputBox("Anna vastausvaihtoehto:");

            // Validate response
            if (response != null && response != "")
            {
                try
                {
                    // Add choice to data
                    Guid addedId = Rules.Choices.Add(CurrentHeaderId, response);
                    // Update listview
                    PopulateChoices();
                    // Update screen contents
                    UpDateView(false, true, true);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Edit selected choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditChoice_Click(object sender, EventArgs e)
        {
            if (lvChoices.SelectedItems.Count > 0)
            {
                string newText = DialogHelper.InputBox("Muokkaa vaihtoehtoa:", lvChoices.SelectedItems[0].Text);
                if (newText != null && newText != "")
                {
                    Guid choiceId = ((Choice)lvChoices.SelectedItems[0].Tag).ID;
                    Rules.Choices.UpdateChoice(choiceId, newText);
                    PopulateChoices();
                    UpDateView(false, true, true);
                }
            }
            else
            {
                MessageBox.Show("Muokattavaa vaihtoehtoa ei ole valittu!");
            }
        }

        /// <summary>
        /// Delete choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteChoice_Click_1(object sender, EventArgs e)
        {
            Choice selectedChoice = null;

            // Check selectedItem
            if (lvChoices.SelectedItems != null && lvChoices.SelectedItems.Count > 0)
            {
                selectedChoice = (Choice)lvChoices.SelectedItems[0].Tag;

                // Remove tag from list
                Rules.Choices.Remove(selectedChoice);

                /// Remove from list
                lvChoices.Items.Remove(lvChoices.SelectedItems[0]);

                /// Populate / refresh
                PopulateChoices();
            }
            else
            {
                // Nothing selected
                MessageBox.Show("Ei poistettavaa tai poistettavaa ei ole valittu.");
            }

        }

        /// <summary>
        /// Move to next header. If none exists, create placeholder for it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNextHeader_Click(object sender, EventArgs e)
        {
            if (lvChoices.SelectedIndices.Count > 0)
            {
                // Get tag of the selected choice
                Choice SelectedChoice = (Choice)lvChoices.SelectedItems[0].Tag;

                // Check if subheader is given
                if (SelectedChoice.SubHeaderID != Guid.Empty)
                {
                    // Open sub without creating it
                    CurrentHeaderId = SelectedChoice.SubHeaderID;
                }
                else
                {
                    // Subheader is not created, crete new and open it to UI
                    SelectedChoice.ParentReference = CurrentHeaderId;
                    CurrentHeaderId = Rules.Headers.Add("");
                    SelectedChoice.SubHeaderID = CurrentHeaderId;
                }
                // Repopulate UI
                UpDateView(true, true, true);
            }
            else
            {
                MessageBox.Show("Vaihtoehtoa ei ole valittu!");
                return;
            }

            // Set focus
            tbHeader.Select();
        }

        #endregion

        #region CONCLUSION

        /// <summary>
        /// Andd conclusion event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddConclusion_Click(object sender, EventArgs e)
        {
            if (lvChoices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vaihtoehtoa ei ole valittu!");
                return;
            }

            // Ask conclusion text from user
            string response = DialogHelper.InputBox("Anna ratkaisuvaihtoehto:");

            if (response != null && response != "")
            {
                // Null-check passed, add new conclusion and repopulate screen
                Conclusion cncToAdd = new Conclusion(Guid.NewGuid(), ((Choice)(lvChoices.SelectedItems[0].Tag)).ID, response);
                Guid addedId = Rules.Conclusions.Add(cncToAdd);
                PopulateConclusions();
                UpDateView(false, true, true);
            }
        }

        /// <summary>
        /// Delete Conclusion clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteConclusion_Click(object sender, EventArgs e)
        {
            if (lvConclusions.SelectedItems.Count > 0)
            {
                try
                {
                    Conclusion ConclusionToRemove = (Conclusion)lvConclusions.SelectedItems[0].Tag;
                    Rules.Conclusions.Remove(ConclusionToRemove);
                }
                catch (Exception)
                {
                    // Do not break anything - just leave as is - to be implemented later...
                }
            }
        }



        #endregion

        #region OTHER EVENTS

        /// <summary>
        /// ListViewItem doubleclicked
        /// Show text in messagebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvChoices_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        /// <summary>
        /// Export ruleworld to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MIExport_Click(object sender, EventArgs e)
        {
            // Ask filename and path
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dr = sfd.ShowDialog();

            if (dr != DialogResult.Cancel)
            {
                string path = sfd.FileName;

                // Check file existance
                if (System.IO.File.Exists(path))
                {

                }
                else
                {

                }

                // If exists, ask user to overwrite or abort
                // If overwrite, delete and create new
                // else create new
                System.IO.FileStream fstr = new System.IO.FileStream(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\') + 1) + "RuleXml.xml", System.IO.FileMode.CreateNew);
                XmlSerializer xmlSer = new XmlSerializer(typeof(RuleWorld));
                xmlSer.Serialize(fstr, Rules);
                fstr.Close();
                MessageBox.Show("Tallennettu");
            }
        }

        #endregion

        #region PRIVATES

        /// <summary>
        /// Updates listboxes and header from saved list
        /// </summary>
        /// <param name="hdr"></param>
        /// <param name="chc"></param>
        /// <param name="cnc"></param>
        public void UpDateView(bool hdr, bool chc, bool cnc)
        {
            // Set text for current header
            tbHeader.Text = (from q in Rules.Headers.HeaderList where q.ID == CurrentHeaderId select q.TextValue).FirstOrDefault();

            // Fill choices
            PopulateChoices();

            // Fill conclusions
            PopulateConclusions();
        }

        /// <summary>
        /// Fill list of choices
        /// </summary>
        private void PopulateChoices()
        {
            // Clear list and fill it with choices by current header
            lvChoices.Items.Clear();
            List<Choice> listedChoices = Rules.Choices.GetChoicesByParentReference(CurrentHeaderId);

            // Loop choices
            foreach (Choice chc in listedChoices)
            {
                // Declare new listviewitem
                ListViewItem lvi = new ListViewItem()
                {
                    Text = chc.TextValue,
                    Tag = chc
                };

                // Add choice to control
                lvChoices.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Populate conclusions
        /// </summary>
        private void PopulateConclusions()
        {
            //try
            //{
            //    if (lvChoices.SelectedIndices.Count > 0)
            //    {
            //        int firstChcID = ((Choice)lvChoices.SelectedItems[0].Tag).ID;

            //        // Clear control 
            //        lvConclusions.Items.Clear();

            //        // Request list of conclusions for listview
            //        List<Conclusion> lstConclusions = (from conc in Rules.Conclusions.ConclusionList where conc.ParentReference == firstChcID select conc).ToList();

            //        // Loop conclusions to create listviewitems
            //        foreach (Conclusion conc in lstConclusions)
            //        {
            //            // Declare new lvi
            //            ListViewItem lvi = new ListViewItem()
            //            {
            //                // Set contents and reference
            //                Text = conc.TextValue,
            //                Tag = conc
            //            };

            //            // Add lvi to listview
            //            lvConclusions.Items.Add(lvi);
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

        #endregion

        private void MITreeView_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EI IMPLEMENTOITU");
        }

        private void MIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}