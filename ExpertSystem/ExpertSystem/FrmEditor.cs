/* Main class for expert system
 * 
 * Author: Sami Väisänen
 * Date: 13.2.2019 
 */
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
        public RuleWorld Rules { get; set; }

        // Property for storing selected header
        public int CurrentHeaderId { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrmEditor()
        {
            InitializeComponent();
            CurrentHeaderId = -1;
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

        #region BUTTON EVENTS

        /// <summary>
        /// Leaving header creates new header if none yet available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbHeader_Leave(object sender, EventArgs e)
        {
            // Check if rules are initialized
            if (Rules == null)
            {
                // No rules, create instance of rules and add first rule´s header
                Rules = new RuleWorld();
                CurrentHeaderId = Rules.AddHeader(tbHeader.Text);
            }
            else
            {
                // Rule exists, If leave, update text
                Rules.UpdateHeader(CurrentHeaderId, tbHeader.Text);
            }
        }

        /// <summary>
        /// Move to upper level in decision tree if possible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToParent_Click(object sender, EventArgs e)
        {
            int tmpCurHdr = 0;

            if (Rules == null)
            {
                MessageBox.Show("Ylempää tasoa ei ole.");
                return;
            }

            try
            {
                // Get header by subheader id
                tmpCurHdr = (from RuleWorld.Choice chc in Rules.Choices
                             where chc.SubHeaderId == CurrentHeaderId
                             select chc.ParentHeaderId).FirstOrDefault();

            }
            catch (Exception ex)
            {
                // An exception occurred -> throw exception further
                throw ex;                
            }

            if (tmpCurHdr > 0)
            {
                // Header for parent rule found, set it as current header
                CurrentHeaderId = tmpCurHdr;
                UpDateView(true, true, true);
            }
        }

        /// <summary>
        /// Add new choice event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddChoice_Click(object sender, EventArgs e)
        {
            // Get user response
            string response = DialogHelper.InputBox("Anna vastausvaihtoehto:");

            // Validate response
            if (response != null && response != "")
            {
                // Add choice to data
                int addedId = Rules.AddChoice(CurrentHeaderId, response);
                // Update listview
                PopulateChoices();
                // Update screen contents
                UpDateView(false, true, true);
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
                    int choiceId = ((RuleWorld.Choice)lvChoices.SelectedItems[0].Tag).Id;
                    Rules.UpdateChoice(choiceId, newText);
                    PopulateChoices();
                    UpDateView(false, true, true);
                }
            }
        }

        /// <summary>
        /// Delete selected choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteChoice_Click(object sender, EventArgs e)
        {
            // Get choice from listview´s tag
            RuleWorld.Choice selectedChc = (RuleWorld.Choice)lvChoices.SelectedItems[0].Tag;

            // Remove selected choice 
            Rules.DeleteChoice(selectedChc);

            // RePopulate choices and refresh controls
            PopulateChoices();
            UpDateView(false, true, true);
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
                RuleWorld.Choice SelectedChoice = (RuleWorld.Choice)lvChoices.SelectedItems[0].Tag;

                // Check if subheader is given
                if (SelectedChoice.SubHeaderId > CurrentHeaderId)
                {
                    // Open sub without creating it
                    CurrentHeaderId = SelectedChoice.SubHeaderId;
                }
                else
                {
                    // Subheader is not created, crete new and open it to UI
                    SelectedChoice.ParentHeaderId = CurrentHeaderId;
                    CurrentHeaderId = Rules.AddHeader("");
                    SelectedChoice.SubHeaderId = CurrentHeaderId;
                }
                // Repopulate UI
                UpDateView(true, true, true);
            }

            // Set focus
            tbHeader.Select();
        }

        /// <summary>
        /// Andd conclusion event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddConclusion_Click(object sender, EventArgs e)
        {
            // Ask conclusion text from user
            string response = DialogHelper.InputBox("Anna ratkaisuvaihtoehto:");

            if (response != null && response != "")
            {
                // Null-check passed, add new conclusion and repopulate screen
                int addedId = Rules.AddConclusion(((RuleWorld.Choice)lvChoices.SelectedItems[0].Tag).Id, response);
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
            MessageBox.Show("BTNDELETECONCLUSION IS NOT IMPLEMENTED");
        }

        /// <summary>
        /// Delete choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteChoice_Click_1(object sender, EventArgs e)
        {
            RuleWorld.Choice selectedChoice = null;

            // Check selectedItem
            if (lvChoices.SelectedItems != null)
            {
                selectedChoice = (RuleWorld.Choice)lvChoices.SelectedItems[0].Tag;

                // Remove tag from list
                Rules.DeleteChoice(selectedChoice);

                /// Remove from list
                lvChoices.Items.Remove(lvChoices.SelectedItems[0]);

                /// Populate / refresh
                PopulateChoices();
            }
            else
            {
                // Nothing selected
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
            tbHeader.Text = (from q in Rules.Headers where q.Id == CurrentHeaderId select q.Text).FirstOrDefault();

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
            List<RuleWorld.Choice> lviChoices = (from chc in Rules.Choices where chc.ParentHeaderId == CurrentHeaderId select chc).ToList();

            // Loop choices
            foreach (RuleWorld.Choice chc in lviChoices)
            {
                // Declare new listviewitem
                ListViewItem lvi = new ListViewItem()
                {
                    Text = chc.Text,
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
            // Clear selections
            int selectedChoiceId = -1;
            try
            {
                // Get first to check existance of conclusions for selected header
                selectedChoiceId = (from chc in Rules.Choices where chc.ParentHeaderId == CurrentHeaderId select chc).FirstOrDefault().Id;
            }
            catch (Exception)
            {
            }

            if (selectedChoiceId >= 0)
            {
                // Conclusions available

                try
                {
                    // Clear control for conclusions
                    lvConclusions.Items.Clear();

                    // Request list of conclusions for listview
                    List<RuleWorld.Conclusion> lstConclusions = (from conc in Rules.Conclusions where conc.ChoiceId == selectedChoiceId select conc).ToList();

                    // Loop conclusions to create listviewitems
                    foreach (RuleWorld.Conclusion conc in lstConclusions)
                    {
                        // Declare new lvi
                        ListViewItem lvi = new ListViewItem()
                        {
                            // Set contents and reference
                            Text = conc.Text,
                            Tag = conc
                        };

                        // Add lvi to listview
                        lvConclusions.Items.Add(lvi);
                    }
                }
                catch (Exception)
                {
                }
            }
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
