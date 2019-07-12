/* Class for getting user input.
 * Supports just buttons and getting string values
 * 
 * Author: Sami Väisänen
 * Date: 13.2.2019
 */

using System;
using System.Windows.Forms;

namespace ExpertSystem
{
    public partial class FrmInput : Form
    {
        #region PROPERTIES

        DialogResult leftDlgRes;
        DialogResult midDlgRes;
        DialogResult rightDlgRes;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrmInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with initializations
        /// </summary>
        /// <param name="header">Header of the box</param>
        /// <param name="showInput">True = Show inputbox, False = hide it</param>
        /// <param name="leftButtonText">TextValue for left button</param>
        /// <param name="leftResult">Returnvalue for left button as dialogresult</param>
        /// <param name="midButtonText">Middlebutton text</param>
        /// <param name="midResult">Middlebutton result as dialogresult</param>
        /// <param name="rightButtonText">TextValue for rightmost button</param>
        /// <param name="rightResult">Returnvalue for rigthmost button</param>
        public FrmInput(String header, bool showInput,
            string leftButtonText, DialogResult leftResult,
            string midButtonText, DialogResult midResult,
            string rightButtonText, DialogResult rightResult)
        {
            InitializeComponent();
            LblHeader.Text = header;

            if (!showInput)
            {
                TbInput.Visible = false;
                this.Height = this.Height - 20;
            }

            InitButton(BtnLeft, leftButtonText);
            InitButton(BtnMiddle, midButtonText);
            InitButton(BtnRight, rightButtonText);

            leftDlgRes = leftResult;
            midDlgRes = midResult;
            rightDlgRes = rightResult;
        }

        /// <summary>
        /// Constructor with default return value
        /// </summary>
        /// <param name="header">Header of the box</param>
        /// <param name="showInput">True = Show inputbox, False = hide it</param>
        /// <param name="leftButtonText">TextValue for left button</param>
        /// <param name="leftResult">Returnvalue for left button as dialogresult</param>
        /// <param name="midButtonText">Middlebutton text</param>
        /// <param name="midResult">Middlebutton result as dialogresult</param>
        /// <param name="rightButtonText">TextValue for rightmost button</param>
        /// <param name="rightResult">Returnvalue for rigthmost button</param>
        /// <param name="defaultValue">Default value to return as string</param>
        public FrmInput(String header, bool showInput,
            string leftButtonText, DialogResult leftResult,
            string midButtonText, DialogResult midResult,
            string rightButtonText, DialogResult rightResult,
            string defaultValue)
        {
            InitializeComponent();
            LblHeader.Text = header;

            if (!showInput)
            {
                TbInput.Visible = false;
                this.Height = this.Height - 20;
            }

            InitButton(BtnLeft, leftButtonText);
            InitButton(BtnMiddle, midButtonText);
            InitButton(BtnRight, rightButtonText);

            leftDlgRes = leftResult;
            midDlgRes = midResult;
            rightDlgRes = rightResult;

            TbInput.Text = defaultValue;
            TbInput.Focus();
        }

        #endregion

        #region FORM EVENTS

        /// <summary>
        /// Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInput_Load(object sender, EventArgs e)
        {
            this.TbInput.Select();
        }

        #endregion

        #region BUTTON EVENTS

        /// <summary>
        /// Event for clicking rightmost button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRight_Click(object sender, EventArgs e)
        {
            this.DialogResult = rightDlgRes;
        }

        /// <summary>
        /// Event for middle button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMiddle_Click(object sender, EventArgs e)
        {
            this.DialogResult = midDlgRes;
        }

        /// <summary>
        /// Event for left button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLeft_Click(object sender, EventArgs e)
        {
            this.DialogResult = leftDlgRes;
        }

        #endregion

        #region PUBLICS

        /// <summary>
        /// Function to get entered value
        /// </summary>
        /// <returns></returns>
        public String GetValue()
        {
            return TbInput.Text;
        }

        #endregion

        #region PRIVATES

        /// <summary>
        /// Initialize buttons
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="text"></param>
        private void InitButton(Button btn, string text)
        {
            if (text == null || text == "")
            {
                // TextValue for button is not given, hide button
                btn.Visible = false;
            }
            else
            {
                // TextValue is given, set text
                btn.Text = text;
            }
        }

        #endregion

    }
}
