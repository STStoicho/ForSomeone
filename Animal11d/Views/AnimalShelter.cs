using Animal11d.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal11d.Controllers
{
    public partial class AnimalShelter : Form
    {
        AnimalsLogic animalLogic = new AnimalsLogic();
        BreedLogic breedLogic = new BreedLogic();

        public AnimalShelter()
        {
            InitializeComponent();
        }

        private void LoadRecord(Animal animal)
        {
            txb_Id.Text = animal.Id.ToString();
            txb_Name.Text = animal.Name;
            txb_Desc.Text = animal.Description;
            txb_Age.Text = animal.Age.ToString();
            cmb_Breed.Text = animal.Breeds.Name;
        }

        private void ClearScreen()
        {
            txb_Id.Clear();
            txb_Name.Clear();
            txb_Age.Clear();
            txb_Desc.Clear();
            cmb_Breed.Text = "";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txb_Id.Text) || !txb_Id.Text.All(char.IsDigit))
            {
                MessageBox.Show("Enter ID!");
                txb_Id.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txb_Id.Text);
            }

            if (string.IsNullOrEmpty(txb_Name.Text))
            {
                Animal findedAnimal = animalLogic.Get(findId);
                if (findedAnimal == null)
                {
                    MessageBox.Show("Няма такъв запис е БД!");
                    txb_Id.Focus();
                    return;
                }
                LoadRecord(findedAnimal);
            }
            else
            {
                Animal updatedAnimal = new Animal();
                updatedAnimal.Name = txb_Name.Text;
                updatedAnimal.Age = int.Parse(txb_Age.Text);
                updatedAnimal.BreedsId = (int)cmb_Breed.SelectedValue;
                updatedAnimal.Description = txb_Desc.Text;

                animalLogic.Update(findId, updatedAnimal);

                MessageBox.Show("Successfully updated!");
            }
            btn_SelectAll_Click(sender, e);
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txb_Name.Text) || txb_Name.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txb_Name.Focus();
                return;
            }

            Animal newAnimal = new Animal();
            newAnimal.Name = txb_Name.Text;
            newAnimal.Age = int.Parse(txb_Age.Text);
            newAnimal.BreedsId = (int)cmb_Breed.SelectedValue;
            newAnimal.Description = txb_Desc.Text;

            animalLogic.Create(newAnimal);
            MessageBox.Show("Successfully added!");
            ClearScreen();
            btn_SelectAll_Click(sender, e);
        }

        private void AnimalShelter_Load(object sender, EventArgs e)
        {
            List<Breed> allBreeds = breedLogic.GetAllBreeds();
            cmb_Breed.DataSource = allBreeds;
            cmb_Breed.DisplayMember = "Name";
            cmb_Breed.ValueMember = "Id";

            btn_SelectAll_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txb_Id.Text) || !txb_Id.Text.All(char.IsDigit))
            {
                MessageBox.Show("Enter ID!");
                txb_Id.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txb_Id.Text);
            }
            Animal findedAnimal = animalLogic.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Enter ID!");
                txb_Id.Focus();
                return;
            }

            DialogResult answer = MessageBox.Show("Are you sure you want to delete No " + findId + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                animalLogic.Delete(findId);

                MessageBox.Show("Successfully deleted!");

                ClearScreen();
            }

            btn_SelectAll_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txb_Id.Text) || !txb_Id.Text.All(char.IsDigit))
            {
                MessageBox.Show("Enter ID!");
                txb_Id.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txb_Id.Text);
            }
            Animal findedAnimal = animalLogic.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Enter ID!");
                txb_Id.Focus();
                return;
            }
            LoadRecord(findedAnimal);
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            List<Animal> allAnimals = animalLogic.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allAnimals)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name}, Age: {item.Age}, Breed: {item.Breeds.Name}, Description: {item.Description}");
            }
        }
    }
}
