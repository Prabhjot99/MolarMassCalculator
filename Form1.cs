// Periodic table data obtained from GoodmanSciences at
// https://gist.github.com/GoodmanSciences/c2dd862cd38f21b0ad36b8f96b4bf1ee
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace MMC_NoName01
{
    public partial class Form1 : Form
    {

        public BindingSource _bs = new BindingSource();

        Dictionary<string, Element> _lookupElementDict;

        public Form1()
        {
            InitializeComponent();
        }

        // On form load, immediately populate the lookup dictionary
        private void Form1_Load(object sender, EventArgs e)
        {
            // Use try/catch block for file IO
            try
            {
                // Bind data scource
                UI_DataGridView.DataSource = _bs;

                // Extract periodic table data
                string periodicTableRaw = File.ReadAllText("../../Periodic Table of Elements.csv");

                // Split up the rows and skip the first header row
                var periodTableRows = periodicTableRaw.Split(new char[] { '\r', '\n' }).Skip(1);

                // Create lookup dictionary of elements
                _lookupElementDict = new Dictionary<string, Element>();

                // Go through rows from data (each row is an element) - skip empty whitespace rows
                foreach (var row in from r in periodTableRows where r.Trim().Length != 0 select r)
                {
                    // Split up rows by commas because it is a CSV file
                    string[] columns = row.Split(',');

                    // Get the relevant element attributes for each column
                    int atomicNumber = int.Parse(columns[0]);
                    string name = columns[1];
                    string symbol = columns[2];
                    double mass = double.Parse(columns[3]);

                    // Populate the lookup dictionary with elements (key = symbol)
                    _lookupElementDict.Add(symbol, new Element(atomicNumber, name, symbol, mass));
                }

                // Populate datagridview with elements from lookup dictionary using linq
                _bs.DataSource = from elementKVP in _lookupElementDict let element = elementKVP.Value
                                 select new
                                 {
                                     AtomicNumber = element.AtomicNumber,
                                     Name = element.ElementName,
                                     Symbol = element.ElementSymbol,
                                     Mass = element.AtomicMass
                                 };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Regex and datagridview live update
        private void UI_TbxChemicalFormula_TextChanged(object sender, EventArgs e)
        {
            string _input = UI_TbxChemicalFormula.Text;

            // Each chemical will be matched with this regex (CH4 matches C and H4)
            Regex _regex = new Regex("([A-Z][a-z]?)([0-9]{0,9})?");
            MatchCollection matches = _regex.Matches(_input);
            Dictionary<string, int> elementCount = new Dictionary<string, int>();

            // Test that whole input string is a valid chemical formula
            Regex testRegex = new Regex("^([A-Z][a-z]?[0-9]{0,9})+$");
            bool validFormula = testRegex.IsMatch(_input);

            // Use LINQ join to filter matches where the element is not a real element
            var validElements =
                from Match match in matches
                join Element element in _lookupElementDict.Values
                on match.Groups[1].Value equals element.ElementSymbol
                select match;

            // All the matches were valid elements
            if(matches.Count.Equals(validElements.ToList().Count) && validFormula)
            {
                //if the chemical formula entered is valid, change the color of the label to green to indicate success
                UI_lblMolarMass.BackColor = Color.LightGreen;

                //Iterate through each match in the valid element
                foreach (Match v in validElements)
                {
                    //Count of each element in the chemical formula would be atleast 1
                    int count = 1;

                    //check if a number exists with the symbol, if it exists, that would be the count
                    if (v.Groups[2].Value.Length > 0)
                        count = int.Parse(v.Groups[2].Value);

                    // Add to dictionary counting how many of each element
                    if (elementCount.ContainsKey(v.Groups[1].Value))
                        elementCount[v.Groups[1].Value] += count;
                    else
                        elementCount.Add(v.Groups[1].Value, count);
                }

                // Output elements and their counts
                //use join to find if the key in the dictionary is found in the periodic table
                //This means that key==symbol in the dictionary
                var elementCollection = from kvp in elementCount
                                        join element in _lookupElementDict.Values
                                        on kvp.Key equals element.ElementSymbol
                                        select new
                                        {
                                            Element = element.ElementSymbol,
                                            Count = kvp.Value,
                                            Mass = element.AtomicMass,
                                            TotalMass = element.AtomicMass * kvp.Value
                                        };
                _bs.DataSource = elementCollection;

                //calculate and display the total molar mass in the label
                UI_lblMolarMass.Text = elementCollection.Sum(element => element.TotalMass).ToString();
            }
            else
            {
                //The red color of the label indicates that the chemical formula is invalid.
                UI_lblMolarMass.BackColor = Color.Red;

            }
           
        }

        private void UI_BtnSortName_Click(object sender, EventArgs e)
        {

            //use orderby to sort the full table by name
            //The chemical formula textbox clears when the sort button is pressed
            //The back color of the label changes to normal
            _bs.DataSource = from n in _lookupElementDict
                             let element = n.Value
                             select new
                             {
                                 AtomicNumber = element.AtomicNumber,
                                 Name = element.ElementName,
                                 Symbol = element.ElementSymbol,
                                 Mass = element.AtomicMass
                             } into a orderby a.Name ascending select a;
            UI_TbxChemicalFormula.Text = "";
            UI_lblMolarMass.Text = "0";
            UI_lblMolarMass.BackColor = Color.Empty;
         
        }

        private void UI_BtnSortAtomicNumber_Click(object sender, EventArgs e)
        {
            //use orderby to sort the full table by atomic number
            //The chemical formula textbox clears when the sort button is pressed
            //The back color of the label changes to normal
            _bs.DataSource = from n in _lookupElementDict
                             let element = n.Value
                             select new
                             {
                                 AtomicNumber = element.AtomicNumber,
                                 Name = element.ElementName,
                                 Symbol = element.ElementSymbol,
                                 Mass = element.AtomicMass
                             } into a
                             orderby a.AtomicNumber ascending
                             select a;

            UI_TbxChemicalFormula.Text = "";
            UI_lblMolarMass.BackColor = Color.Empty;
            UI_lblMolarMass.Text = "0";

        }
        //single character symbold
        private void UI_SortSymbols_Click(object sender, EventArgs e)
        {
            //filter the full table to display only the elements with single character symbols
            //The chemical formula textbox clears when the button is pressed
            //The back color of the label changes to normal
            _bs.DataSource = from n in _lookupElementDict
                             let element = n.Value
                             where element.ElementSymbol.Length==1
                             select new
                             {
                                 AtomicNumber = element.AtomicNumber,
                                 Name = element.ElementName,
                                 Symbol = element.ElementSymbol,
                                 Mass = element.AtomicMass
                             }  into a
                             orderby a.Name ascending
                             select a;
            UI_TbxChemicalFormula.Text = "";
            UI_lblMolarMass.BackColor = Color.Empty;
            UI_lblMolarMass.Text = "0";
        }
    }
}
