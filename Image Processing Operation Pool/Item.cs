﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace Image_Processing_Operation_Pool
{


    public class DoubleRange
    {
        public double Min { get; set; }
        public double Max { get; set; }
    }

    public class IntRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    //public class Array
    //{
    //    public int rows { get; set; }
    //    public int columns { get; set; }
    //}
    //public class Parameter : ICloneable
    //{
    //    public string Name { get; set; }
    //    public Type type { get; set; }
    //    public DoubleRange DoubleRange { get; set; }
    //    public string Default { get; set; }
    //    public string Description { get; set; }
    //    public string Current_Value { get; set; }
    //    public List<string> StringRange { get; set; }
    //    public IntRange IntRange { get; set; }
    //    public string Array { get; set; }

    //    public object Clone()
    //    {
    //        Parameter clone = new Parameter();

    //        clone.Name          = Name;         
    //        clone.type          = type;         
    //        clone.DoubleRange   = DoubleRange;  
    //        clone.Default       = Default;      
    //        clone.Description   = Description;  
    //        clone.Current_Value = Current_Value;

    //        if (null != StringRange)
    //        {
    //            clone.StringRange = new List<string>();
    //            foreach (var str in StringRange)
    //            {
    //                clone.StringRange.Add(str);
    //            }
    //        }
    //        else
    //        {
    //            clone.StringRange = null;
    //        }
           
    //        clone.StringRange   = StringRange  ;
    //        clone.IntRange      = IntRange     ;
    //        clone.Array         = Array        ;
                                
    //        return clone;
    //    }
    //}



    public class RootObject : ICloneable
    {


        public string functionName { get; set; }
        public string description { get; set; }
        public List<Parameter> parameters { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        //public TabPage createForm(string functionName, Hashtable hashtable)
        //{
        //    RootObject root = null;
        //    if (hashtable.ContainsKey(functionName))
        //    {
        //        root = (RootObject)hashtable[functionName];
        //    }
        //    if (root != null) 
        //        return createFormByFunc(root);
        //    else 
        //        return null;
        //}

        /// <summary>
        /// the method creates a general form. for each functiont the method ModifyFormByType is called and designes it.
        /// </summary>
        /// <param name="root"> the function according witch the form is desighned</param>
        /// <returns>return the designed form</returns>
        public Control createFormByFunc(Control control)
        {
            //creating the form itself:
            control.Text = functionName;
            control.Controls.Clear();

            control.AutoSize = true;
            //modify form:
            FlowLayoutPanel flws = new FlowLayoutPanel();
            flws.FlowDirection = FlowDirection.LeftToRight;
            flws.AutoSize = true;
            flws.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            //flws.AutoScroll = true;
            control.Controls.Add(flws);

            foreach (Parameter p in parameters)
            {
                //funcTabPage.Text = "Edit parameters for " + root.functionName;
                ModifyFormByType(p, control, flws);
            }


            return control;
        }


        public void formSettings(Form functionForm)
        {
            functionForm.AutoSize = true;
            //modify form:
            FlowLayoutPanel flws = new FlowLayoutPanel();
            flws.AutoScroll = true;
            flws.FlowDirection = FlowDirection.LeftToRight;
            flws.AutoSize = true;
            flws.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            //flws.AutoScroll = true;
            functionForm.Controls.Add(flws);
        }
        /// <summary>
        /// the method adds comtrollers to the form according to the param type
        /// </summary>
        /// <param name="param">the parameter to add</param>
        /// <param name="funcTabPage">  the form to design</param>
        /// <param name="flws">FlowLayoutPanel organizes thr controlls on the form</param>
        /// <returns></returns>
        public Control ModifyFormByType(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {

            switch (param.type)
            {
                case Type.Array:
                    addArrayPropToForm(param, funcTabPage, flws);
                    break;
                case Type.Bool:
                    addBoolPropToForm(param, funcTabPage, flws);
                    break;
                case Type.Double:
                    addDoublePropToForm(param, funcTabPage, flws);
                    break;
                case Type.Double_Range:
                    addDouble_RangePropToForm(param, funcTabPage, flws);
                    break;
                case Type.Int:
                    addIntPropToForm(param, funcTabPage, flws);
                    break;
                case Type.Int_Range:
                    addInt_RangePropToForm(param, funcTabPage, flws);
                    break;
                case Type.String:
                    addStringPropToForm(param, funcTabPage, flws);
                    break;
                case Type.String_Range:
                    addString_RangePropToForm(param, funcTabPage, flws);
                    break;
                default:
                    break;
            }

            return funcTabPage;
        }
        /// <summary>
        /// adds boolean parameter represented by two RadioButtons "true" and "Flase" controlls
        /// </summary>
        /// <param name="funcTabPage"></param>
        /// <returns></returns>
        private void addBoolPropToForm(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {


            //place param name:
            iTalk.iTalk_Label paramName = new iTalk.iTalk_Label();
            paramName.ForeColor = System.Drawing.Color.Black;
            paramName.Text = param.Name;
            paramName.Font = new Font("Arial", 12);
            flws.Controls.Add(paramName);

            // add description form parameter
            ToolTip description = new ToolTip();
            description.ToolTipIcon = ToolTipIcon.Info;
            description.IsBalloon = true;
            description.ShowAlways = true;
            description.SetToolTip(paramName, param.Description);

            // add controllers for boolean selection
            iTalk.iTalk_RadioButton TrueRadioButton = new iTalk.iTalk_RadioButton();
            TrueRadioButton.Text = "True";


            iTalk.iTalk_RadioButton FalseRadioButton = new iTalk.iTalk_RadioButton();
            FalseRadioButton.Text = "Fasle";

            TrueRadioButton.Checked = param.Current_Value.Equals("True");
            FalseRadioButton.Checked = !TrueRadioButton.Checked;

            flws.Controls.Add(TrueRadioButton);
            flws.Controls.Add(FalseRadioButton);

            //add events:
            TrueRadioButton.CheckedChanged += new iTalk.iTalk_RadioButton.CheckedChangedEventHandler((object o) =>
            {

                param.Current_Value = TrueRadioButton.Checked.ToString();
                MessageBox.Show(param.Current_Value);
            });

            funcTabPage.Controls.Add(flws);


        }

        //////////////////////////////////replace here the numericUpDown/////////////////
        /// <summary>
        /// adds int parameter represented by NumericUpDown controll to inset the value. allows only numbers
        /// </summary>
        /// <param name="funcTabPage"></param>
        /// <returns></returns>
        private void addIntPropToForm(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {
            iTalk.iTalk_Label paramName = new iTalk.iTalk_Label();
            // Label paramName = new Label();
            paramName.ForeColor = System.Drawing.Color.Black;
            paramName.Text = param.Name;
            paramName.Font = new Font("Arial", 12);
            flws.Controls.Add(paramName);

            //add controller:
            // iTalk.iTalk_NumericUpDown intUpDown = new iTalk.iTalk_NumericUpDown();
            //flws.Controls.Add(intUpDown);
            NumericUpDown intUpDown = new NumericUpDown();
            flws.Controls.Add(intUpDown);

            //set defaullt:
            // intUpDown.Value = int.Parse(param.Current_Value);


            //add explanation:
            ToolTip explanation = new ToolTip();
            explanation.ToolTipIcon = ToolTipIcon.Info;
            explanation.IsBalloon = true;
            explanation.ShowAlways = true;
            explanation.SetToolTip(intUpDown, "Choose The int value for the parameter , the default value is " + param.Default);

            //set current value:
            intUpDown.Value = int.Parse(param.Current_Value);

            //add description:
            ToolTip description = new ToolTip();
            description.ToolTipIcon = ToolTipIcon.Info;
            description.IsBalloon = true;
            description.ShowAlways = true;
            description.SetToolTip(paramName, param.Description);

            //add event:
            intUpDown.ValueChanged += new System.EventHandler((object o, EventArgs e) =>
            {
                param.Current_Value = intUpDown.Value.ToString();
                //MessageBox.Show("param.Current_Value is :" + param.Current_Value);
            });


            //intUpDown.CursorChanged += new System.EventHandler((object o, EventArgs Even) =>
            //{
            //    param.Current_Value = intUpDown.Value.ToString();
            //    Debug.Write("param.Current_Value is :" + param.Current_Value);
            //});

            funcTabPage.Controls.Add(flws);
        }


        /// <summary>
        /// adds int_range parameter represented by TrackBarcontroll with min and max values possible
        /// </summary>
        /// <param name="funcTabPage"></param>
        /// <returns></returns>
        private void addInt_RangePropToForm(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {
            //place param name:
            iTalk.iTalk_Label paramName = new iTalk.iTalk_Label();
            // Label paramName = new Label();
            paramName.ForeColor = System.Drawing.Color.Black;
            paramName.Text = param.Name;
            paramName.Font = new Font("Arial", 12);
            flws.Controls.Add(paramName);

            //add description:
            ToolTip description = new ToolTip();
            description.ToolTipIcon = ToolTipIcon.Info;
            description.IsBalloon = true;
            description.ShowAlways = true;
            description.SetToolTip(paramName, param.Description);

            //add controller:
            //iTalk.iTalk_TrackBar iTalkTrackBar = new iTalk.iTalk_TrackBar();
            // flws.Controls.Add(iTalkTrackBar);
            TrackBar trackBar = new TrackBar();
            flws.Controls.Add(trackBar);

            //add explanation:
            ToolTip explanation = new ToolTip();
            explanation.ToolTipIcon = ToolTipIcon.Info;
            explanation.IsBalloon = true;
            explanation.ShowAlways = true;
            explanation.SetToolTip(trackBar, "Choose The value between" + param.IntRange.Max + " and " + param.IntRange.Min);

            //set min and max
            trackBar.Minimum = param.IntRange.Min;
            trackBar.Maximum = param.IntRange.Max;

            //set current value:
            //trackBar.Value = int.Parse(param.Current_Value);

            ToolTip ShowNumberChanging = new ToolTip();
            explanation.ToolTipIcon = ToolTipIcon.None;

            // add event:
            trackBar.Scroll += new System.EventHandler((object o, EventArgs e) =>
            {
                ShowNumberChanging.SetToolTip(trackBar, trackBar.Value.ToString());
                param.Current_Value = trackBar.Value.ToString();
                //MessageBox.Show("param current value is " + param.Current_Value);
            });


            //iTalkTrackBar.ValueChanged += new iTalk.iTalk_TrackBar.ValueChangedEventHandler(() =>
            //{
            //    param.Current_Value = iTalkTrackBar.Value.ToString();
            //    MessageBox.Show("param current value is " + param.Current_Value);
            //});

            funcTabPage.Controls.Add(flws);

        }




        /// <summary>
        /// adss double parameter represented by TextBox controll to insert the value
        /// </summary>
        /// <param name="funcTabPage"></param>
        /// <returns></returns>
        private void addDoublePropToForm(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {
            // add param name:
            iTalk.iTalk_Label paramName = new iTalk.iTalk_Label();
            // Label paramName = new Label();
            paramName.ForeColor = System.Drawing.Color.Black;
            paramName.Text = param.Name;
            paramName.Font = new Font("Arial", 12);
            flws.Controls.Add(paramName);

            //add description:
            ToolTip description = new ToolTip();
            description.ToolTipIcon = ToolTipIcon.Info;
            description.IsBalloon = true;
            description.ShowAlways = true;
            description.SetToolTip(paramName, param.Description);


            //add controller:
            iTalk.iTalk_TextBox_Small iTalkTextBox = new iTalk.iTalk_TextBox_Small();
            flws.Controls.Add(iTalkTextBox);
            // TextBox textBox = new TextBox();
            iTalkTextBox.Text = param.Current_Value;
            //  flws.Controls.Add(textBox);


            //set current value:
            iTalkTextBox.Text = param.Current_Value;

            //textBox.TextChanged += new System.EventHandler((object sender, EventArgs e) =>
            //{
            //    //textInsert.Text = textBox.Text;
            //    param.Current_Value = textBox.Text;               
            //});

            iTalkTextBox.TextChanged += new EventHandler((object sender, EventArgs e) =>
            {
                param.Current_Value = iTalkTextBox.Text;
                //MessageBox.Show(param.Current_Value);
            });


            funcTabPage.Controls.Add(flws);


        }


        //////////////////////// change to track bar here////////////////////////////////////////
        /// <summary>
        /// adds parameter parameter represented by TrackBar controll with min and max values possible
        /// </summary>
        /// <param name="funcTabPage"></param>
        /// <returns></returns>
        private object addDouble_RangePropToForm(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {

            //place param name:
            iTalk.iTalk_Label paramName = new iTalk.iTalk_Label();
            // Label paramName = new Label();
            paramName.ForeColor = System.Drawing.Color.Black;
            paramName.Text = param.Name;
            paramName.Font = new Font("Arial", 12);
            flws.Controls.Add(paramName);

            //add description:
            ToolTip description = new ToolTip();
            description.ToolTipIcon = ToolTipIcon.Info;
            description.IsBalloon = true;
            description.ShowAlways = true;
            description.SetToolTip(paramName, param.Description);

            //add controller:
            iTalk.iTalk_TextBox_Small DoubleTextBox = new iTalk.iTalk_TextBox_Small();
            //   TrackBar trackBar = new TrackBar();
            flws.Controls.Add(DoubleTextBox);


            //add explanation:
            ToolTip explanation = new ToolTip();
            explanation.ToolTipIcon = ToolTipIcon.Info;
            explanation.IsBalloon = true;
            explanation.ShowAlways = true;
            explanation.SetToolTip(DoubleTextBox, "Enter a Double number");



            //set min and max
            //   DoubleTextBox.Minimum = Convert.ToInt32(param.DoubleRange.Min);
            //  DoubleTextBox.Maximum = Convert.ToInt32(param.DoubleRange.Max);

            //set current value:
            DoubleTextBox.Text = param.Current_Value;

            ToolTip ShowNumberChanging = new ToolTip();
            explanation.ToolTipIcon = ToolTipIcon.None;

            // add event:

            DoubleTextBox.TextChanged += new EventHandler((object sender, EventArgs e) =>
            {
                param.Current_Value = DoubleTextBox.Text;
                // MessageBox.Show(param.Current_Value);
            });

            funcTabPage.Controls.Add(flws);
            return funcTabPage;
        }

        /// <summary>
        /// adds string parameter represented by TextBox controll to insert the string
        /// </summary>
        /// <param name="funcTabPage"></param>
        /// <returns></returns>
        private void addStringPropToForm(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {
            //add param name:
            iTalk.iTalk_Label paramName = new iTalk.iTalk_Label();
            paramName.ForeColor = System.Drawing.Color.Black;
            paramName.Text = param.Name;
            paramName.Font = new Font("Arial", 12);
            flws.Controls.Add(paramName);

            //add description:
            ToolTip description = new ToolTip();
            description.ToolTipIcon = ToolTipIcon.Info;
            description.IsBalloon = true;
            description.ShowAlways = true;
            description.SetToolTip(paramName, param.Description);

            //add controller:
            iTalk.iTalk_TextBox_Small stringTextBox = new iTalk.iTalk_TextBox_Small();
            //TextBox stringTextBox = new TextBox();
            flws.Controls.Add(stringTextBox);

            //add explanation:
            ToolTip explanation = new ToolTip();
            explanation.ToolTipIcon = ToolTipIcon.Info;
            explanation.IsBalloon = true;
            explanation.ShowAlways = true;
            explanation.SetToolTip(stringTextBox, "enter a string value");

            //set current value:
            stringTextBox.Text = param.Current_Value;


            //add event:
            //stringTextBox.TextChanged += new System.EventHandler((object sender, EventArgs e) =>
            //{
            //    param.Current_Value = stringTextBox.Text;
            //});

            stringTextBox.TextChanged += new EventHandler((object sender, EventArgs e) =>
            {
                param.Current_Value = stringTextBox.Text;
                //MessageBox.Show(param.Current_Value);
            });
            funcTabPage.Controls.Add(flws);

        }

        /// <summary>
        /// adds parameter with multiple strings values possible, represented by ComboBox controll wich holds the options
        /// </summary>
        /// <param name="funcTabPage"></param>
        /// <returns></returns>
        private void addString_RangePropToForm(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {

            //add param name:
            iTalk.iTalk_Label paramName = new iTalk.iTalk_Label();
            // Label paramName = new Label();
            paramName.ForeColor = System.Drawing.Color.Black;
            paramName.Text = param.Name;
            paramName.Font = new Font("Arial", 12);
            flws.Controls.Add(paramName);

            //add description:
            ToolTip description = new ToolTip();
            description.ToolTipIcon = ToolTipIcon.Info;
            description.IsBalloon = true;
            description.ShowAlways = true;
            description.SetToolTip(paramName, param.Description);

            //add controller:
            iTalk.iTalk_ComboBox optionsComboBox = new iTalk.iTalk_ComboBox();
            flws.Controls.Add(optionsComboBox);

            //fill proprety with options:
            foreach (string option in param.StringRange)
            {
                optionsComboBox.Items.Add(option);
            }

            //add explanation:
            ToolTip explanation = new ToolTip();
            explanation.ToolTipIcon = ToolTipIcon.Info;
            explanation.IsBalloon = true;
            explanation.ShowAlways = true;
            explanation.SetToolTip(optionsComboBox, "Choose one of the options in the comboBox for the parameter value. The default for this parametert is " + param.Default);

            //set current value:
            optionsComboBox.Text = param.Current_Value;

            //add event:
            optionsComboBox.SelectedValueChanged += new System.EventHandler((object sender, EventArgs e) =>
            {
                param.Current_Value = optionsComboBox.Text;
                // MessageBox.Show(param.Current_Value);
            });

            funcTabPage.Controls.Add(flws);

        }


        ///////////here////////////////////////////
        /// <summary>
        /// add array parameter r
        /// </summary>
        /// <param name="funcTabPage"></param>
        /// <returns></returns>
        private Control addArrayPropToForm(Parameter param, Control funcTabPage, FlowLayoutPanel flws)
        {

            // add param name:
            iTalk.iTalk_Label paramName = new iTalk.iTalk_Label();
            // Label paramName = new Label();
            paramName.ForeColor = System.Drawing.Color.Black;
            paramName.Text = param.Name;
            paramName.Font = new Font("Arial", 12);
            flws.Controls.Add(paramName);

            // add controller
            iTalk.iTalk_TextBox_Small ArrayTextBox = new iTalk.iTalk_TextBox_Small();
            // TextBox ArrayTextBox = new TextBox();
            flws.Controls.Add(ArrayTextBox);

            //add explanation:
            ToolTip explanation = new ToolTip();
            explanation.ToolTipIcon = ToolTipIcon.Info;
            explanation.IsBalloon = true;
            explanation.ShowAlways = true;
            explanation.SetToolTip(ArrayTextBox, "Enter the array values separated by a comma. For example Matrix 3x3 : " + "\n" + "1" + "," + "2" + "," + "3" + ";" + "4" + "," + "5" + "," + "6" + ";" + "7" + "," + "8" + "," + "9");


            //add event:

            funcTabPage.Controls.Add(flws);
            return funcTabPage;
        }

        public object Clone()
        {
            RootObject clone = new RootObject();
            clone.functionName = functionName;
            clone.description = description;
            clone.parameters = new List<Parameter>();
            foreach (var param in parameters)
            {
                clone.parameters.Add((Parameter)param.Clone());
            }

            return clone;
        }
    }

    public class ListRoot
    {
        public List<RootObject> functions { get; set; }
    }

    public enum Type
    {
        Bool,
        Int,
        Int_Range,
        Double,
        Double_Range,
        String,
        String_Range,
        Array
    };

    // values is relevant only for "range" types, and is {min, max} for double_range and int_range, and {"v1", "v2", ...} 
    // for string_range, and empty/ignored for all other types {}

    // the default values set the initial values for the Parameters objects in the Function object





}

