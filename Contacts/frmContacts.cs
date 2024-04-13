using System;
using System.IO;
using System.Windows.Forms;

namespace Contacts
{
    public partial class frmContacts : Form
    {
        //globals
        //path = pad + bestandsnaam van geopend bestand
        //lines = verzameling van alle lijnen uit tekstbestand
        string path;
        string[] lines;

        public frmContacts()
        {
            InitializeComponent();
        }

        //methode om bestand in te lezen
        //en personen toe te voegen aan dropdownlist
        private void AddPeople()
        {
            //geopend bestand koppelen aan variabele path
            path = ofd.FileName;
            //alle regels uit tekstbestand in array lines stoppen
            lines = File.ReadAllLines(path); 

            //lines doorlopen en ieder lijntje splitsen
            //daarna personen aanmaken en waarden toekennen
            foreach (var line in lines)
            {
                //lijn splitsen op ;
                string[] details = line.Split(';');

                //nieuwe person aanmaken
                Person p = new Person
                {
                    //juiste waarden uit details koppelen aan person properties
                    Id = Convert.ToInt32(details[0]),
                    FirstName = details[1],
                    LastName = details[2],
                    Email = details[3]
                };

                //persoon toevoegen aan combobox/dropdownlist
                cbPeople.Items.Add(p);

            }
        }

        //methode om persoon aan te passen
        private void UpdateFile()
        {
            //geselecteerde persoon omzetten naar Person
            Person p = cbPeople.SelectedItem as Person;

            //alle waarden van p opnieuw invullen
            //op basis van waarden die in textboxes staan
            p.FirstName = txtFirstName.Text;
            p.LastName = txtLastName.Text;
            p.Email = txtEmail.Text;

            //lijn van persoon in lines array vervangen door
            //nieuwe waarden
            lines[cbPeople.SelectedIndex] = p.Id + ";" + p.FirstName +
                ";" + p.LastName + ";" + p.Email;

            //alle lijnen opnieuw naar tekstbestand schrijven
            File.WriteAllLines(path, lines);

            //persoon in combobox ook aanpassen met nieuwe waarden
            cbPeople.Items[cbPeople.SelectedIndex] = p;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //dialoogvenster "bestand openen"
            ofd.ShowDialog();
        }

        private void ofd_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddPeople();
            //eerste item uit de combobox selecteren
            cbPeople.SelectedIndex = 0;
        }

        private void cbPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            //geselecteerd item 'omzetten' naar Person
            Person p = cbPeople.SelectedItem as Person;
            //Person p = (Person)cbPeople.SelectedItem;

            //tekstvakken invullen met gegevens van persoon
            txtId.Text = p.Id.ToString();
            txtFirstName.Text = p.FirstName;
            txtLastName.Text = p.LastName;
            txtEmail.Text = p.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateFile();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(sfd.FileName, lines);
            };
        }
    }
}
