using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Contacts
{
    public partial class frmContacts : Form
    {
        // globals
        // fullPath = pad + bestandsnaam van geopend bestand
        // linesFromFile = verzameling van alle lijnen uit tekstbestand
        string fullPath;
        string[] linesFromFile;

        public frmContacts()
        {
            InitializeComponent();
        }

        // methode om bestand in te lezen
        // en personen toe te voegen aan dropdownlist
        private void AddPeople()
        {
            // geopend bestand koppelen aan variabele fullPath
            // bijvoorbeeld: C:\contacten\creo.txt
            fullPath = ofd.FileName;

            // alle regels uit tekstbestand in array linesFromFile stoppen
            linesFromFile = File.ReadAllLines(fullPath);

            // testen wat het eerste en tweede element
            // in de array linesFromFile is
            Debug.WriteLine("Eerste lijn: " + linesFromFile[0]);
            Debug.WriteLine("Tweede lijn: " + linesFromFile[1]);

            // linesFromFile doorlopen en ieder lijntje splitsen
            // daarna personen aanmaken en waarden toekennen
            foreach (var line in linesFromFile)
            {
                // één line is bvb
                // 1;Koenraad;Pecceu;koenraad.pecceu@creo.be
                // ik moet deze line splitsen op ';'
                // de data komt nu in een nieuwe array terecht
                string[] personInfo = line.Split(';');
                // testen of de namen correct er in komen
                Debug.WriteLine(personInfo[1]);

                // nieuwe person variabele/object maken
                Person p = new Person();
                // data vanuit personInfo array gebruiken
                // om properties van p in te vullen
                p.Id = Convert.ToInt32(personInfo[0]);
                p.FirstName = personInfo[1];
                p.LastName = personInfo[2];
                p.Email = personInfo[3];

                // persoon p toevoegen aan combobox
                cbPeople.Items.Add(p);
            }

        }

        // methode om persoon aan te passen
        // en alles opnieuw te bewaren in het geopende bestand
        private void UpdateFile()
        {
            // geselecteerde persoon omzetten naar Person
            

            // alle waarden van p opnieuw invullen
            // op basis van waarden die in textboxes staan
           

            // lijn van persoon in lines array vervangen door
            // nieuwe waarden
            

            // alle lijnen opnieuw naar tekstbestand schrijven
            

            //persoon in combobox ook aanpassen met nieuwe waarden
            

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // standaardmap instellen indien beschikbaar

            string defaultPath = @"C:\contacten\";
            if (Directory.Exists(defaultPath))
            {
                ofd.InitialDirectory = defaultPath;
            }
            
            // dialoogvenster voor bestand openen starten

            ofd.ShowDialog();
        }

        private void ofd_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // AddPeople methode uitvoeren om alle namen in de combobox te plaatsen
            AddPeople();
            // eerste item uit de combobox selecteren
            cbPeople.SelectedIndex = 0;
        }

        private void cbPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            // geselecteerd item 'omzetten' (casten) naar Person
            // en opslaan in variabele van type Person
            Person p = (Person)cbPeople.SelectedItem;

            // tekstvakken invullen met gegevens van persoon
            txtId.Text = p.Id.ToString();
            txtFirstName.Text = p.FirstName;
            txtLastName.Text = p.LastName;
            txtEmail.Text = p.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // UpdateFile methode uitvoeren om aangepaste persoon te bewaren
            UpdateFile();
        }
    }
}
